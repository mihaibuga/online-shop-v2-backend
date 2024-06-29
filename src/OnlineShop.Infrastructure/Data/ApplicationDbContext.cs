using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.ProductAttributes;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<InventoryTransaction> StockInventoryTransactions { get; set; }
        public DbSet<AppRole> UserRoles { get; set; }
        public DbSet<AppFile> AppFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureDefaultDates(builder.Entity<Product>());
            ConfigureDefaultDates(builder.Entity<Brand>());
            ConfigureDefaultDates(builder.Entity<Category>());
            ConfigureDefaultDates(builder.Entity<ProductVariant>());
            ConfigureDefaultDates(builder.Entity<Stock>());
            ConfigureDefaultDates(builder.Entity<InventoryTransaction>());
            ConfigureDefaultDates(builder.Entity<AppFile>());

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId);

            builder.Entity<ProductVariant>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(pv => pv.ProductId);

            builder.Entity<ProductAttribute>()
                .HasOne(pa => pa.ProductVariant)
                .WithMany(pv => pv.Attributes)
                .HasForeignKey(pa => pa.ProductVariantId);

            builder.Entity<Stock>()
                .HasOne(s => s.ProductVariant)
                .WithOne(pv => pv.Stock)
                .HasForeignKey<Stock>(s => s.ProductVariantId);

            builder.Entity<InventoryTransaction>()
                .HasOne(it => it.ProductVariant)
                .WithMany(p => p.InventoryTransactions)
                .HasForeignKey(it => it.ProductVariantId);

            builder.Entity<InventoryTransaction>()
                .Property(it => it.Type)
            .HasConversion<string>();

            builder.Entity<ProductAttribute>()
                .HasDiscriminator<string>("ProductAttributeType")
                .HasValue<CapacityAttribute>("Capacity")
                .HasValue<ColorAttribute>("Color")
                .HasValue<ConditionAttribute>("Condition")
                .HasValue<ScreenSizeAttribute>("ScreenSize");

            ConfigureDefaultDates(builder.Entity<CapacityAttribute>());
            ConfigureDefaultDates(builder.Entity<ColorAttribute>());
            ConfigureDefaultDates(builder.Entity<ConditionAttribute>());
            ConfigureDefaultDates(builder.Entity<ScreenSizeAttribute>());
        }

        private void ConfigureDefaultDates<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : class
        {
            builder.Property<DateTime>("CreatedDate").HasDefaultValueSql("GETDATE()");
            builder.Property<DateTime?>("ModifiedDate").HasDefaultValueSql("GETDATE()");
        }
    }
}
