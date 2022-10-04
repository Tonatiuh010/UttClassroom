﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Engine.BO
{
    public class AssetGroup
    {        
        public string Name { get; set; }
        public List<Asset> Assets { get; set; }
        
        public AssetGroup(string name, List<Asset> assets)
        {
            Name = name;
            Assets = assets;
        }


        public object ToObject()
        {
            object obj = new object();
            return obj;
        }

    }
}
