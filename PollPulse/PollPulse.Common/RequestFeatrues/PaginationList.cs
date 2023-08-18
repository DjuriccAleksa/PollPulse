using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.RequestFeatrues
{
    public class PaginationList<T> : List<T>
    {
        public PaginationData PaginationData { get; set; }

        public PaginationList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PaginationData = new PaginationData
            {
                PageSize = pageSize,
                CurretPage = pageNumber,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }

        public static PaginationList<T> ToPaginationList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber-1) *pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginationList<T>(items, count, pageNumber, pageSize);
        }

    }
}
