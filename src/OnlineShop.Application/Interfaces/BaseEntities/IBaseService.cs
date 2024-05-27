namespace OnlineShop.Application.Interfaces.BaseEntities
{
    public interface IBaseService<TDto, CreateTRequestDto>
    {
        Task<TDto> CreateAsync(CreateTRequestDto brandDto);
        Task<List<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(Guid id);
        Task<TDto> UpdateAsync();
        Task<TDto?> DeleteAsync(Guid id);
    }
}
