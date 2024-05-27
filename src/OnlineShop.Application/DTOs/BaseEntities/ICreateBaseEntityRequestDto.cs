namespace OnlineShop.Application.DTOs.BaseEntities
{
    public interface ICreateBaseEntityRequestDto
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}
