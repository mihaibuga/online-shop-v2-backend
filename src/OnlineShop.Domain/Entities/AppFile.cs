using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
    [Table("Files")]
    public class AppFile : BaseEntity
    {
        public string RawFileName { get; set; }
        public string FileExtension { get; set; }
        public string CompleteFileName { get; set; }
        public string FileSourcePath { get; set; }
    }
}
