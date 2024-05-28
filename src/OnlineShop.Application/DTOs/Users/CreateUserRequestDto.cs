using System.ComponentModel.DataAnnotations;


namespace OnlineShop.Application.DTOs.Users
{
	public class CreateUserRequestDto
	{
		[Required]
		public string? Username { get; set; }

		[Required]
		[EmailAddress]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
		public string? Email { get; set; }

		[Required]
		public string? Password { get; set; }
	}
}
