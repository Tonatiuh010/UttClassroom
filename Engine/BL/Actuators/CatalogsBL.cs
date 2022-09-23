using Engine.BO;
using Engine.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.BL
{
    public class CatalogsBL : BaseBL
    {        

        public static List<Address> GetAddresses(int? id = null) 
            => Dal.GetAddresses(id);

        public static List<Asset> GetAssets(int? id = null, string? code = null, string? group = null) 
            => Dal.GetAssets(id, code, group);

        public static List<Contact> GetContacts(int? id = null) 
            => Dal.GetContacts(id);

        public static List<ContactFamily> GetContactFamilies(int? id = null)
            => Dal.GetFamilyContacts(id);

        public static Asset? GetAsset(int id) 
            => GetAssets(id: id).FirstOrDefault();

    }
}
