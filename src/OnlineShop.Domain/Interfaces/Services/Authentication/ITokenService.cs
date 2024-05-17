using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Domain.Interfaces.Services.Authentication
{
	public interface ITokenService
	{
		string CreateToken(AppUser user);
	}
}
