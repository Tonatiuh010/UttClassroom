using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.BO;
using Engine.Interfaces.DataCollector;

namespace Engine.Service.DataCollector
{
    public class GroupStudentsCollector : IGroupStudentsCollector
    {
        public static IGroupStudentsCollector.SearchStudents? SearchStudents { get; set; } = null;
        public static GroupStudentsCollector Instance(int groupId) => new(SearchStudents, groupId);

        public int GroupId { get; set; }
        public IGroupStudentsCollector.SearchStudents? GetStudents { get; }

        private GroupStudentsCollector(IGroupStudentsCollector.SearchStudents? callback, int groupId)
        {
            GroupId = groupId;
            GetStudents = callback;
        }
    }
}
