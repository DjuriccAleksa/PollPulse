using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.RequestFeatrues
{
    public class PaginationData
    {
        public int CurretPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious => CurretPage > 1;
        public bool HasNext => CurretPage < TotalPages;

    }
}
