using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceDesk.Helper;
using System.Data.SqlClient;
using System.Data;

namespace ServiceDesk.Models
{
    public class modulRep
    {

        public IEnumerable<modul> Moduls()
        {
            List<modul> list = new List<modul>();
            using (SqlConnection conn = new SqlConnection(Config.SqlConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("getModul", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader SReader = cmd.ExecuteReader())
                    {
                        modul book;
                        while (SReader.Read())
                        {
                            book = new modul();
                            book.Id = Convert.ToInt32(SReader["id"]);
                            book.Name = SReader["name"].ToString();

                            list.Add(book);
                        }
                    }
                }
            }
            return list.AsEnumerable<modul>();
        }

        public IEnumerable<predprin> Predprins()
        {
            List<predprin> list = new List<predprin>();
            using (SqlConnection conn = new SqlConnection(Config.SqlConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("[dbo].[getPredprin]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader SReader = cmd.ExecuteReader())
                    {
                        predprin book;
                        while (SReader.Read())
                        {
                            book = new predprin();
                            book.Id = Convert.ToInt32(SReader["id"]);
                            book.Name = SReader["name"].ToString();

                            list.Add(book);
                        }
                    }
                }
            }
            return list.AsEnumerable<predprin>();
        }

        public void addZadacha(Zadacha book)
        {

            using (SqlConnection conn = new SqlConnection(Config.SqlConnStr))
            {
                conn.Open();
              
                using (SqlCommand cmd = new SqlCommand("[dbo].[addZadacha]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inName", SqlDbType.NVarChar).Value = book.Name;
                    cmd.Parameters.Add("@inOpisanya", SqlDbType.NVarChar).Value = book.Opisanya;
                    cmd.Parameters.Add("@inDayy", SqlDbType.Date).Value = book.date;
                    cmd.Parameters.Add("@inModulId", SqlDbType.Int).Value = book.modulID;
                    cmd.Parameters.Add("@inPredprinID", SqlDbType.Int).Value = book.predprinID;
                    cmd.Parameters.Add("@inByte", SqlDbType.VarBinary).Value = book.fileUpload;
                    cmd.ExecuteNonQuery();
                }
            }

        }

      
    }
}