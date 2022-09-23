using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Engine.Services.DataCollector;
using Engine.Interfaces.DataCollector;

namespace Engine.BO
{
    public class Group : BaseBO
    {
        private IGroupStudentsCollector ServiceGroup => GroupStudentsCollector.Instance(Id);

        public string? Code { get; set; }
        public string? Key { get; set; }
        public int? Quarter { get; set; }
        public string? Description { get; set; }
        public Major? Major { get; set; }
        public Asset? Field { get; set; }
        public Asset? Period { get; set; }
        
        public List<Student>? Students => ServiceGroup.Students;

    }
}
