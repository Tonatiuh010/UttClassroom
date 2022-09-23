﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.MySQL;
using Engine.BO;
using Engine.Interfaces;
using Engine.Service;
using D = Engine.BL.Delegates;

namespace Engine.DAL.Classes
{
    internal abstract class DAL : MySqlDataBase
    {        
        protected static readonly Validate Validate = Validate.Instance;        
        public static D.CallbackExceptionMsg? OnDALError { get; set; }

        protected DAL(IConectionString? conn) : base(conn?.ConnectionString) 
            => OnDALError = null;

        protected static void SetExceptionResult(string actionName, string msg, Exception ex) =>
            OnDALError?.Invoke(ex, $"Error on ({actionName}) - {msg}");
    }
}