using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.BO
{
    public class Asset : BaseBO
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Group { get; set; }
        public string? Attr { get; set; }
        public string? Attr2 { get; set; }
        public string? Description { get; set; }
    }
}
