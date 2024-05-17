using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Infrastructure.Identity
{
	public class IdentityDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public IdentityDbContext(
			DbContextOptions<IdentityDbContext> options)
		: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			List<AppRole> roles = new List<AppRole>
			{
				new AppRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new AppRole
				{
					Name = "User",
					NormalizedName = "USER"
				},
			};

			builder.Entity<AppRole>().HasData(roles);
		}
	}
}
