using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helper
{
    public class QueryObject
    {
        public string title { get; set; } = null;
        public string author { get; set; } = null;
        public string publisher { get; set; } = null;
        public string language { get; set; } = null;
        public int pageNumber { get; set; }=1;
        public int pageSize { get; set; }=20;
    }
}