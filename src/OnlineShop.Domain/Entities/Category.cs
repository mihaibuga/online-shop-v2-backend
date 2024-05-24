﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
	[Table("Categories")]
	public class Category : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		public ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
