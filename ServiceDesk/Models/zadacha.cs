using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDesk.Models
{
    [Serializable]
    public class Zadacha
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Opisanya { get; set; }
        public DateTime date { get; set; }
        public int modulID { get; set; }
        public int predprinID { get; set; }
       // public byte[] FileBytes { get; }
        public byte[] fileUpload { get; set; }
        public HttpPostedFile PostedFile { get; }

        //public static implicit operator Zadacha(Seryal v)
        //{
        //    throw new NotImplementedException();
        //}

        //public Zadacha(int id, string name, string opisanya, DateTime date, int modulID, int predprinID) {
        //    Id = id;
        //    Name = name;
        //    Opisanya = opisanya;
        //    this.date =date;
        //    this.modulID = modulID;
        //    this.predprinID = predprinID;

        //}
    }
}