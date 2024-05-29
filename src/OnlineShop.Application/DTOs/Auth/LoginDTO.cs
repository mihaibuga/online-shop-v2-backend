using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.Auth
{
	public class LoginDto
	{
		[Required]
		public required string Username { get; set; }

		[Required]
		public required string Password { get; set; }
	}
}
