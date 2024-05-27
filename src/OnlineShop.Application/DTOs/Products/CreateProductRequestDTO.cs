﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.DTOs.Products
{
	public class CreateProductRequestDto : ICreateBaseEntityRequestDto
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		public decimal? PreviousPrice { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
