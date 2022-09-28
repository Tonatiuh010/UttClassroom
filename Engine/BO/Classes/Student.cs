using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Engine.BO
{
    public class Student : BaseBO
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }

        [JsonIgnore]
        public byte[]? ImageBytes { get; set; }

        public DateTime? Birth { get; set; }

        public int? Age { get {
                if (Birth.HasValue)
                {
                    var today = DateTime.Today;
                    return today.Year - Birth.Value.Year;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Location? BirthPlace { get; set; }
        public Asset? Genre { get; set; }
        public Asset? Marital { get; set; }
        public Contact? Contact { get; set; }
        public Address? Address { get; set; }
        public Scholarly? Scholarly { get; set; }
        public Labor? Labor { get; set; }

    }
}
