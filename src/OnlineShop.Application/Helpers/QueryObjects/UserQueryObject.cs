namespace OnlineShop.Application.Helpers.QueryObjects
{
    public class UserQueryObject
    {
        public string? SortBy { get; set; } = null;
        public bool IsAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
