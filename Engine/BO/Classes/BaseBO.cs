﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.BO
{
    public class BaseBO
    {
        private Type Type { get; set; }        

        public int Id { get; set; }
        public bool IsValid() => Id != 0;

        /* Id != null && */

        public BaseBO() => Type = GetType();

        //public T? Cast<T>(BaseBO obj)
        //{
        //    T? result = default;

        //    try
        //    {
        //        if (Type == obj.Type)
        //        {

        //        }
        //    } catch
        //    {

        //    }

        //    return result;
        //}
    }
}
