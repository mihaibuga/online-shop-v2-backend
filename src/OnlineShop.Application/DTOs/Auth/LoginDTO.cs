﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.Auth
{
	public class LoginDto
	{
		[Required]
		public string? Username { get; set; }

		[Required]
		public string? Password { get; set; }
	}
}
