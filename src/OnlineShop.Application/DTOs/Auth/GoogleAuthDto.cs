using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.Auth
{
	public class GoogleAuthDto
	{
		[Required]
		public required string Username { get; set; }

		[Required]
		[EmailAddress]
		public required string Email { get; set; }
	}
}
