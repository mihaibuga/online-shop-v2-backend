﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	[Table("Brands")]
	public class Brand : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		public ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
