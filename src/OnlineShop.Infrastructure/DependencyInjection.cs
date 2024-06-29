using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Interfaces.Services.Authentication;
using OnlineShop.Domain.Services.Authentication;

using OnlineShop.Application.Interfaces.Brands;
using OnlineShop.Application.Interfaces.Categories;
using OnlineShop.Application.Interfaces.InventoryTransactions;
using OnlineShop.Application.Interfaces.Products;
using OnlineShop.Application.Interfaces.ProductVariants;
using OnlineShop.Application.Interfaces.Stocks;
using OnlineShop.Application.Services;

using OnlineShop.Infrastructure.Data;
using OnlineShop.Infrastructure.Repositories;
using OnlineShop.Application.Interfaces.Files;
using OnlineShop.Application.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace OnlineShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment env
        )
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Online Shop API",
                        Version = "v1"
                    }
                );

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });


            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.Configure<FileStorageOptions>(configuration.GetSection("FileStorage"));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 12;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                options.DefaultScheme =
                options.DefaultSignInScheme =
                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
                    )
                };
            });


            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IInventoryTransactionRepository, InventoryTransactionRepository>();
            services.AddScoped<IInventoryTransactionService, InventoryTransactionService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
            services.AddScoped<IProductVariantService, ProductVariantService>();

            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockService, StockService>();

            services.AddScoped<IAppFileRepository, AppFileRepository>();
            services.AddScoped<IAppFileService, AppFileService>();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
