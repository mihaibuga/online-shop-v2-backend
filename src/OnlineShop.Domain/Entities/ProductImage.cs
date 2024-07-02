using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
    [Table("ProductImages")]
    public class ProductImage : BaseEntity
    {
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid? AppFileId { get; set; }
        public AppFile? Image { get; set; }
    }
}
