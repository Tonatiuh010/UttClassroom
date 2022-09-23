using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataService.MySQL;
using Engine.BO;
using Engine.Constants;
using Engine.Interfaces;
using Engine.Service;
using MySql.Data.MySqlClient;
using I = Engine.DAL.Classes;

namespace Engine.DAL
{
    internal class ClassroomDAL : I.DAL
    {
        public delegate void DALCallback(ClassroomDAL dal);


        public static ClassroomDAL Instance = new(ClassroomCredentials.Instance);        
        private ClassroomDAL(IConectionString? conn) : base(conn) { }


        public List<Student> GetStudents(int? id)
        {
            List<Student> model = new ();

            TransactionBlock(this, () => {
                using var cmd = CreateCommand(SQL.GET_STUDENTS, CommandType.StoredProcedure);

                IDataParameter pResult = CreateParameterOut("OUT_MSG", MySqlDbType.String);
                cmd.Parameters.Add(CreateParameter("IN_STUDENT", id, MySqlDbType.Int32));
                cmd.Parameters.Add(pResult);

                using var reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    model.Add(new() { 
                        Id = Validate.getDefaultIntIfDBNull(reader["STUDENT_ID"]),
                        Name = Validate.getDefaultStringIfDBNull(reader["NAME"]),
                        LastName = Validate.getDefaultStringIfDBNull(reader["LAST_NAME"]),
                        ImageBytes = null,
                        Birth = Validate.getDefaultDateIfDBNull(reader["BIRTH"]),
                        BirthPlace = new ()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["BIRTH_LOCATION"]),
                            Country = new()
                            {
                                Id = Validate.getDefaultIntIfDBNull(reader["COUNTRY_ID"]),
                                Name = Validate.getDefaultStringIfDBNull(reader["COUNTRY"])
                            },
                            City = new ()
                            {
                                Id = Validate.getDefaultIntIfDBNull(reader["CITY_ID"]),
                                Name = Validate.getDefaultStringIfDBNull(reader["CITY"])
                            }
                        },
                        Contact = new Contact()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["CONTACT_ID"]),
                            Email = Validate.getDefaultStringIfDBNull(reader["EMAIL1"]),
                            Email2 = Validate.getDefaultStringIfDBNull(reader["EMAIL2"]),
                            Phone = Validate.getDefaultStringIfDBNull(reader["PHONE1"]),
                            Phone2 = Validate.getDefaultStringIfDBNull(reader["PHONE2"])
                        },
                        Address = new Address()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["ADDRESS_ID"]),
                            Street = Validate.getDefaultStringIfDBNull(reader["STREET"]),
                            Number = Validate.getDefaultStringIfDBNull(reader["NUMBER"]),
                            Neighborhood = Validate.getDefaultStringIfDBNull(reader["NEIGHBORHOOD"]),
                            Location = new () { 
                                Id = Validate.getDefaultIntIfDBNull(reader["ADDRESS_LOCATION"])
                            }
                        },
                        Genre = new ()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["GENRE_ID"]),
                            Code = Validate.getDefaultStringIfDBNull(reader["GENRE_CODE"]),
                            Name = Validate.getDefaultStringIfDBNull(reader["GENRE"])
                        },
                        Marital = new ()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["MARITAL_ID"]),
                            Code = Validate.getDefaultStringIfDBNull(reader["MARITAL_CODE"]),
                            Name = Validate.getDefaultStringIfDBNull(reader["MARITAL"])
                        },
                        Labor = new ()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["LABOR_ID"]),
                            Department = Validate.getDefaultStringIfDBNull(reader["DEPARTMENT"]),
                            Business = Validate.getDefaultStringIfDBNull(reader["BUSINESS"]),
                            Address = new ()
                            {
                                Id = Validate.getDefaultIntIfDBNull(reader["LABOR_ADDRESS"])
                            },
                            Contact = new ()
                            {
                                Id = Validate.getDefaultIntIfDBNull(reader["LABOR_CONTACT"])
                            },
                            //IsStudy = Validate.getDefaultIntIfDBNull(reader["IS_STUDY"])
                        }

                    });                
                }

                reader.Close();

            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetStudents", msg, ex));

            return model;
        }

        public List<Address> GetAddresses(int? id)
        {
            List<Address> model = new();

            TransactionBlock(this, () => {
                using var cmd = CreateCommand(SQL.GET_ADDRESSES, CommandType.StoredProcedure);

                IDataParameter pResult = CreateParameterOut("OUT_MSG", MySqlDbType.String);
                cmd.Parameters.Add(CreateParameter("IN_ADDRESS", id, MySqlDbType.Int32));
                cmd.Parameters.Add(pResult);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.Add( new ()
                    {
                        Id = Validate.getDefaultIntIfDBNull(reader["ADDRESS_ID"]),
                        Street = Validate.getDefaultStringIfDBNull(reader["STREET"]),
                        Number = Validate.getDefaultStringIfDBNull(reader["NUMBER"]),
                        Neighborhood = Validate.getDefaultStringIfDBNull(reader["NEIGHBORHOOD"]),
                        Location = new()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["LOCATION_ID"]),
                            Country = new()
                            {
                                Id = Validate.getDefaultIntIfDBNull(reader["COUNTRY_ID"]),
                                Code = Validate.getDefaultStringIfDBNull(reader["COUNTRY_CODE"]),
                                Name = Validate.getDefaultStringIfDBNull(reader["COUNTRY"]),
                            },
                            City = new ()
                            {
                                Id = Validate.getDefaultIntIfDBNull(reader["CITY_ID"]),
                                Code = Validate.getDefaultStringIfDBNull(reader["CITY_CODE"]),
                                Name = Validate.getDefaultStringIfDBNull(reader["CITY"]),
                            }, 
                            CityName = Validate.getDefaultStringIfDBNull(reader["CITY_NAME"])
                        }
                    });
                }

                reader.Close();

            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetAddresses", msg, ex));

            return model;
        }

        public List<Asset> GetAssets(int? id, string? code, string group)
        {
            List<Asset> model = new();

            TransactionBlock(this, () => {
                using var cmd = CreateCommand(SQL.GET_ASSETS, CommandType.StoredProcedure);

                IDataParameter pResult = CreateParameterOut("OUT_MSG", MySqlDbType.String);
                cmd.Parameters.Add(CreateParameter("IN_ASSET", id, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("IN_CODE", code, MySqlDbType.String));
                cmd.Parameters.Add(CreateParameter("IN_ATTR1", group, MySqlDbType.String));
                cmd.Parameters.Add(pResult);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.Add(new()
                    {
                        Id = Validate.getDefaultIntIfDBNull(reader["ASSET_ID"]),
                        Code = Validate.getDefaultStringIfDBNull(reader["ASSET_CODE"]),
                        Name = Validate.getDefaultStringIfDBNull(reader["NAME"]),
                        Group = Validate.getDefaultStringIfDBNull(reader["ATTR1"]),
                        Attr = Validate.getDefaultStringIfDBNull(reader["ATTR2"]),
                        Attr2 = Validate.getDefaultStringIfDBNull(reader["ATTR3"]),
                        Description = Validate.getDefaultStringIfDBNull(reader["DESCRIPTION"])
                    });
                }

                reader.Close();

            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetAssets", msg, ex));

            return model;
        }

        public List<Contact> GetContacts(int? id)
        {
            List<Contact> model = new();

            TransactionBlock(this, () => {
                using var cmd = CreateCommand(SQL.GET_CONTACTS, CommandType.StoredProcedure);

                IDataParameter pResult = CreateParameterOut("OUT_MSG", MySqlDbType.String);
                cmd.Parameters.Add(CreateParameter("IN_CONTACT", id, MySqlDbType.Int32));               
                cmd.Parameters.Add(pResult);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.Add(new ()
                    {
                        Id = Validate.getDefaultIntIfDBNull(reader["CONTACT_ID"]),
                        Email = Validate.getDefaultStringIfDBNull(reader["EMAIL1"]),
                        Email2 = Validate.getDefaultStringIfDBNull(reader["EMAIL2"]),
                        Phone = Validate.getDefaultStringIfDBNull(reader["PHONE1"]),
                        Phone2 = Validate.getDefaultStringIfDBNull(reader["PHONE2"]),
                        Description = Validate.getDefaultStringIfDBNull(reader["DESCRIPTION"])
                    });
                }

                reader.Close();

            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetContacts", msg, ex));

            return model;
        }

        public List<ContactFamily> GetFamilyContacts(int? id)
        {
            List<ContactFamily> model = new();

            TransactionBlock(this, () => {
                using var cmd = CreateCommand(SQL.GET_FAMILY_CONTACTS, CommandType.StoredProcedure);

                IDataParameter pResult = CreateParameterOut("OUT_MSG", MySqlDbType.String);
                cmd.Parameters.Add(CreateParameter("IN_CONTACT", id, MySqlDbType.Int32));
                cmd.Parameters.Add(pResult);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.Add(new(Validate.getDefaultIntIfDBNull(reader["STUDENT_ID"]))
                    {
                        Id = Validate.getDefaultIntIfDBNull(reader["CON_FAMILY_ID"]),
                        Name = Validate.getDefaultStringIfDBNull(reader["NAME"]),
                        Kinship = Validate.getDefaultStringIfDBNull(reader["KINSHIP"]),
                        Work = Validate.getDefaultStringIfDBNull(reader["WORK"]),                       
                        Contact = new Contact()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["CONTACT_ID"]),
                            Email = Validate.getDefaultStringIfDBNull(reader["EMAIL1"]),
                            Email2 = Validate.getDefaultStringIfDBNull(reader["EMAIL2"]),
                            Phone = Validate.getDefaultStringIfDBNull(reader["PHONE1"]),
                            Phone2 = Validate.getDefaultStringIfDBNull(reader["PHONE2"]),
                        },
                        //IsEmergency = Validate.getDefaultIntIfDBNull(reader["IS_EMERGENCY"])                        
                    });
                }

                reader.Close();

            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetContacts", msg, ex));

            return model;
        }

    }
}
