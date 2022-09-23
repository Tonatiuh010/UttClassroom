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
using Engine.Services;
using MySql.Data.MySqlClient;
using I = Engine.DAL.Classes;
using D = Engine.BL.Delegates;
using Org.BouncyCastle.Crypto.Digests;
using System.Collections.Specialized;

namespace Engine.DAL
{
    public class ClassroomDAL : I.DAL
    {
        public delegate void DALCallback(ClassroomDAL dal);


        public static ClassroomDAL Instance => new(ClassroomCredentials.Instance);        
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
                            IsStudy = Validate.getDefaultBoolIfDBNull(reader["IS_STUDY"])
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

        public List<Asset> GetAssets(int? id, string? code, string? group)
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
                        IsEmergency = Validate.getDefaultBoolIfDBNull(reader["IS_EMERGENCY"])                        
                    });
                }

                reader.Close();

            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetFamilyContacts", msg, ex));

            return model;
        }

        public List<Group> GetGroups(int? id, string? code)
        {
            List<Group> model = new();

            TransactionBlock(this, () => {
                using var cmd = CreateCommand(SQL.GET_GROUPS, CommandType.StoredProcedure);

                IDataParameter pResult = CreateParameterOut("OUT_MSG", MySqlDbType.String);
                cmd.Parameters.Add(CreateParameter("IN_GROUP", id, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("IN_GROUP_CODE", id, MySqlDbType.String));
                cmd.Parameters.Add(pResult);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.Add(new()
                    {
                        Id = Validate.getDefaultIntIfDBNull(reader["GROUP_ID"]),
                        Code = Validate.getDefaultStringIfDBNull(reader["GROUP_CODE"]),
                        Key = Validate.getDefaultStringIfDBNull(reader["GROUP_KEY"]),
                        Quarter = Validate.getDefaultIntIfDBNull(reader["QUARTER"]),
                        Major = new Major()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["MAJOR_ID"]),
                            Code = Validate.getDefaultStringIfDBNull(reader["MAJOR_CODE"]),
                            Name = Validate.getDefaultStringIfDBNull(reader["MAJOR"]),
                            Level = new Asset()
                            {
                                Id = Validate.getDefaultIntIfDBNull(reader["LEVEL_ID"]),
                                Code = Validate.getDefaultStringIfDBNull(reader["LEVEL_CODE"]),
                                Name = Validate.getDefaultStringIfDBNull(reader["LEVEL"])
                            }
                        },
                        Field = new Asset()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["FIELD_ID"]),
                            Code = Validate.getDefaultStringIfDBNull(reader["FIELD_CODE"]),
                            Name = Validate.getDefaultStringIfDBNull(reader["FIELD"])
                        },
                        Period = new Asset()
                        {
                            Id = Validate.getDefaultIntIfDBNull(reader["PERIOD_ID"]),
                            Code = Validate.getDefaultStringIfDBNull(reader["PERIOD_CODE"]),
                            Name = Validate.getDefaultStringIfDBNull(reader["PERIOD"])
                        },
                        Description = Validate.getDefaultStringIfDBNull(reader["DESCRIPTION"]),
                    });
                }

                reader.Close();
            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetGroups", msg, ex));


            return model;
        }

        private void GetGroupStudents(int? groupId, int? studentId, D.CallbackReader callback)
        {            

            TransactionBlock(this, () => {
                using var cmd = CreateCommand(SQL.GET_GROUP_STUDENTS, CommandType.StoredProcedure);

                IDataParameter pResult = CreateParameterOut("OUT_MSG", MySqlDbType.String);
                cmd.Parameters.Add(CreateParameter("IN_GROUP", groupId, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("IN_STUDENT", studentId, MySqlDbType.Int32));
                cmd.Parameters.Add(CreateParameter("IN_CURSED", false, MySqlDbType.Int16));
                /* IS CURSED AS a parameter */
                cmd.Parameters.Add(pResult);

                using var reader = cmd.ExecuteReader();

                callback(reader);                

                reader.Close();
            }, (ex, msg) => SetExceptionResult("ClassroomDAL.GetGroupStudents", msg, ex));
            
        }

        public List<Student> GetGroupStudents(int groupId)
        {
            List<Student> model = new();

            GetGroupStudents( groupId, null, reader => {
               
                while (reader.Read())
                {
                    model.Add(new()
                    {
                        Id = Validate.getDefaultIntIfDBNull(reader["STUDENT_ID"]),
                        Code = Validate.getDefaultStringIfDBNull(reader["STUDENT_CDOE"]),
                        Name = Validate.getDefaultStringIfDBNull(reader["STUDENT_NAME"]),
                        LastName = Validate.getDefaultStringIfDBNull(reader["STUDENT_LAST_NAME"]),
                        Birth = Validate.getDefaultDateIfDBNull(reader["STUDENT_BIRTH"])
                    });
                }                
            });

            return model;
        }

        public Group? GetStudentGroup(int studentId)
        {
            Group? model = null;

            GetGroupStudents(null, studentId, reader => {

                if (reader.Read())
                {
                    model = new()
                    {
                        Id = Validate.getDefaultIntIfDBNull(reader["GROUP_ID"]),
                        Code = Validate.getDefaultStringIfDBNull(reader["GROUP_CODE"]),
                        Key = Validate.getDefaultStringIfDBNull(reader["GROUP_KEY"]),
                        Quarter = Validate.getDefaultIntIfDBNull(reader["QUARTER"]),
                        Description = Validate.getDefaultStringIfDBNull(reader["DESCRIPTION"])

                    };
                }
            });

            return model;
        }

    }
}
