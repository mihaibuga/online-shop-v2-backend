using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Helpers.QueryObjects
{
    public class ProductQueryObject : QueryObject
    {
        public ProductQueryObject()
        {
            SortBy = null;
            IsAscending = true;
            PageNumber = 1;
            PageSize = 10;
        }
        public ProductQueryObject(string sortBy, bool isAscending, int pageNumber, int pageSize)
        {
            SortBy = sortBy;
            IsAscending = isAscending;
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
