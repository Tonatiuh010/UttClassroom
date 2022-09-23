﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.BO;

namespace Engine.Interfaces.DataCollector
{
    public interface IGroupStudentsCollector
    {
        public delegate List<Student>? SearchStudents(int groupId);

        public int GroupId { get; set; }
        public SearchStudents? GetStudents { get; }
        public List<Student>? Students => GetStudents?.Invoke(GroupId);
    }
}
