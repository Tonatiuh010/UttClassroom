using Engine.BO;
using Engine.DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Engine.BL
{
    public class CatalogsBL : BaseBL
    {

        public static List<Address> GetAddresses(int? id = null)
        {
            var addresses = Dal.GetAddresses(id);

            foreach (var a in addresses)
                CompleteAddress(a);
            
            return addresses;
        }

        public static List<Asset> GetAssets(int? id = null, string? code = null, string? group = null)
            => Dal.GetAssets(id, code, group);

        public static List<Contact> GetContacts(int? id = null)
            => Dal.GetContacts(id);

        public static List<ContactFamily> GetContactFamilies(int? id = null)
        {
            var contactFamilies = Dal.GetFamilyContacts(id);

            foreach (var cf in contactFamilies)
                CompleteContactFamily(cf);

            return contactFamilies;
        }

        public static Address? GetAddress(int id)
           => GetAddresses(id: id).FirstOrDefault();

        public static Asset? GetAsset(int id)
            => GetAssets(id: id).FirstOrDefault();

        public static Contact? GetContact(int id)
            => GetContacts(id: id).FirstOrDefault();

        public static ContactFamily? GetContactFamily(int id)
            => GetContactFamilies(id: id).FirstOrDefault();

        public static JArray GetFullAsset()
        {
            var keys = Dal.GetAssetKeys();            
            JArray list = new();

            foreach(var k in keys)
            {                
                var assets = GetAssets(group: k);

                if (assets != null && assets.Count > 0)
                    list.Add(new JObject()
                    {
                        [k] = JToken.FromObject(assets)
                    });
            }
            

            return list;
        }

        private static void CompleteAddress(Address? a)
        {
            if(a != null && a.IsValid())
            {
                a.Location = null;
            }
        }

        private static void CompleteContactFamily(ContactFamily? c)
        {
            if(c != null && c.IsValid() && c.Contact != null && c.Contact.IsValid())
            {
                c.Contact = GetContact(c.Contact.Id);
            }
        }

    }
}
