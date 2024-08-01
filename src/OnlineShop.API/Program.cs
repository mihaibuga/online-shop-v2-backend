using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using OnlineShop.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    }
    )
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    }
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

// Serve static files from the "Uploads" directory
var envFileStorageFolderName = builder.Configuration.GetSection("FileStorage");
var uploadsPath = Path.Combine(
    builder.Environment.ContentRootPath,
    envFileStorageFolderName.Value != null
        ? envFileStorageFolderName.Value
        : "Uploads"
    );

if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});

app.UseCors(x => x
    .WithOrigins("http://localhost:5296", "https://localhost:7065/")
    //.SetIsOriginAllowedToAllowWildcardSubdomains()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    //.WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS"));
    //.SetPreflightMaxAge(TimeSpan.FromSeconds(3600)));
    .SetIsOriginAllowed(origin => true));

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
