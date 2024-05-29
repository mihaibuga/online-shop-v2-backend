namespace OnlineShop.Application.DTOs.Auth
{
	public class NewUserDto
	{
		public required string UserName { get; set; }
		public required string Email { get; set; }
		public required string Token { get; set; }
	}
}
