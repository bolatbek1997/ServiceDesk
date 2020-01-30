using ServiceDesk.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceDesk.Models
{
    public class Serializable
    {         
        public static Zadacha XmlToObject(string str) {
            //  XmlSerializer formatter = new XmlSerializer(typeof(Zadacha));
            Zadacha result = new Zadacha();
            XmlSerializer serializer = new XmlSerializer(typeof(Zadacha));
            using (TextReader reader = new StringReader(str))
            {
                result = (Zadacha)serializer.Deserialize(reader);
            }       
            return result;
        }

        public Zadacha getObject() {
            string str = null;
            using (SqlConnection conn = new SqlConnection(Config.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("[dbo].[getSeryal]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader SReader = cmd.ExecuteReader())
                    {
                        
                        while (SReader.Read())
                        {
                           // book = new predprin();
                            //book.Id = Convert.ToInt32(SReader["id"]);
                            str = SReader["Xmll"].ToString();
                           // list.Add(book);
                        }
                    }
                }

            }
                    return XmlToObject(str);
        }

        

        public static string ObjectToXMLGeneric<T>(T filter)
        {

            string xml = null;
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, filter);
                try
                {
                    xml = sw.ToString();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return xml;
        }
        public void addXml(Zadacha person)
        {
            using (SqlConnection conn = new SqlConnection(Config.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("[dbo].[setSeryal]", conn))
                {
                    var FilterXML = ObjectToXMLGeneric(person);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inXml", SqlDbType.Xml).Value = FilterXML;
                    //cmd.Parameters.Add("@inName", SqlDbType.Xml).Value = fs.;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}