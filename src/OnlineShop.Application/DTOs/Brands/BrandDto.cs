﻿using OnlineShop.Application.DTOs.BaseEntities;

namespace OnlineShop.Application.DTOs.Brands
{
    public class BrandDto : IBaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsEnabled { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
	}
}
