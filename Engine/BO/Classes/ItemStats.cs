using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.BO
{
    public class ItemStats
    {
        public string Name { get; set; }
        public object? Value { get; set; }        
        
        public ItemStats(string name, object value)
        {
            Value = value;
            Name = name;
        }

        public T? GetValue<T>()
        {
            try
            {
                return default;
                // return (T)Value;
            }
            catch
            {
                return default;
            }
        }

    }
}
