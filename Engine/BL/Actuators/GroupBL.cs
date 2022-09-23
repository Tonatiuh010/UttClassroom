using Engine.DAL;
using Engine.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.BL
{
    public class GroupBL : BaseBL
    {        

        public static List<Group> GetGroups(int? id = null, string? code = null)
           => Dal.GetGroups(id, code);

        public static Group? GetStudentGroup(int studentId)
            => Dal.GetStudentGroup(studentId);
    }
}
