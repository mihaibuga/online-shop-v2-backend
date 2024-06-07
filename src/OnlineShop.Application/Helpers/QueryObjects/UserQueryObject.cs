namespace OnlineShop.Application.Helpers.QueryObjects
{
    public class UserQueryObject
    {
        public string? SortBy { get; set; }
        public bool IsAscending { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public UserQueryObject()
        {
            SortBy = null;
            IsAscending = true;
            PageNumber = 1;
            PageSize = 10;
        }
        public UserQueryObject(string sortBy, bool isAscending, int pageNumber, int pageSize)
        {
            SortBy = sortBy;
            IsAscending = isAscending;
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
