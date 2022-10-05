using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Engine.Services.DataCollector;
using Engine.Interfaces.DataCollector;
using System.Text.Json.Nodes;

namespace Engine.BO
{
    public class Group : BaseBO
    {
        private static IGroupStatsCollector ServiceStats => GroupStatsCollector.Instance;
        private IGroupStudentsCollector ServiceGroup => GroupStudentsCollector.Instance(Id);
        private static List<ItemStats> Historial => ServiceStats.Stats;

        public string? Code { get; set; }
        public string? Key { get; set; }
        public int? Quarter { get; set; }
        public string? Description { get; set; }
        public Major? Major { get; set; }
        public Asset? Field { get; set; }
        public Asset? Period { get; set; }                
        public List<StudentExt>? Students => ServiceGroup.Students;        
        public JsonObject Stats => ItemStats.ToJsonObject( Historial );

    }
}
