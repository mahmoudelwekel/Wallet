using System.Collections.Generic;

namespace App.Domain.Common.Models
{
    public class PagedResult<T>
    {
        public int TotalNumberOfRecords { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public IList<T> Data { get; set; }
    }
}
