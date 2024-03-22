using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Options
{
    public class PageConfiguration
    {
        public PageConfiguration()
        {
            PageCapacity = 1;
        }
        public int PageCapacity { get; set; }
    }
}
