namespace OnlineShop.Application.Helpers.QueryObjects
{
    public class QueryObject
    {
        public string? SortBy { get; set; }
        public bool IsAscending { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public QueryObject()
        {
            SortBy = null;
            IsAscending = true;
            PageNumber = 1;
            PageSize = 10;
        }
        public QueryObject(string sortBy, bool isAscending, int pageNumber, int pageSize)
        {
            SortBy = sortBy;
            IsAscending = isAscending;
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
