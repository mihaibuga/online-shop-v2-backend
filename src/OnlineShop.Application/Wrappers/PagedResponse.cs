using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool IsNextPage { get; set; }
        public bool IsPreviousPage { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}
