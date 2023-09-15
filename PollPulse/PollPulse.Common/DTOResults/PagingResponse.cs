using PollPulse.Common.RequestFeatrues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTOResults
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public PaginationData PaginationData { get; set; }
    }
}
