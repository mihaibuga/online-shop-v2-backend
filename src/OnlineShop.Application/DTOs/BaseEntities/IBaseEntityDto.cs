namespace OnlineShop.Application.DTOs.BaseEntities
{
    public interface IBaseEntityDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}
