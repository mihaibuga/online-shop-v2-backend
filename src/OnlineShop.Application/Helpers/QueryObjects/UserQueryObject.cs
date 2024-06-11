namespace OnlineShop.Application.Helpers.QueryObjects
{
    public class UserQueryObject : QueryObject
    {
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
