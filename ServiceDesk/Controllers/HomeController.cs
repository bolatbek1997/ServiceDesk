using ServiceDesk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public PartialViewResult Modul(Zadacha zadacha)
        {
            modulRep modulRep = new modulRep();
            Serializable ss = new Serializable();

            using (Stream inputStream = zadacha.PostedFile.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                zadacha.fileUpload = memoryStream.ToArray();
            }

            modulRep.addZadacha(zadacha);
            ss.addXml(zadacha);
            //ss.getObject();
            //return RedirectToAction("modul", "Home");
            return PartialView("addZadacha");
        }
        public ActionResult Modul()
        {
            modulRep modulRep = new modulRep();
            ViewBag.moduls = modulRep.Moduls();
            ViewBag.predprin = modulRep.Predprins();
            return View();
        }
        public ActionResult Object ()
        {
            Serializable ss = new Serializable();
            return View(ss.getObject());
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        [HttpPost]
        public void SaveFile(HttpPostedFileBase fileUpl)
        {
            Zadacha zadacha = new Zadacha();
            //zadacha.PostedFile = fileUpl;
            using (Stream inputStream = fileUpl.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                zadacha.fileUpload = memoryStream.ToArray();
            }
            //zadacha.PostedFile = zadacha.fileUpload;
            //if (fileUpl != null && !string.IsNullOrWhiteSpace(fileUpl.FileName))
            //{
            //    ServiceDesk.FileSaveWS.ContentsWebServiceSoapClient myFileWS = new FileSaveWS.ContentsWebServiceSoapClient();
            //    myFileWS.ClientCredentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
            //    byte[] bytes = new byte[fileUpl.ContentLength];
            //    if (bytes.Length > 0)
            //    {
            //        double fileMbSize = ConvertBytesToMegabytes(fileUpl.ContentLength);
            //        if (fileMbSize > 4.0)
            //        {
            //            ModelState.AddModelError("dirFile", "размер файла повышает 4 МБ");
            //            throw new Exception("размер файла повышает 4 МБ");
            //        }
            //        fileUpl.InputStream.Read(bytes, 0, bytes.Length);
            //        fileUrl = myFileWS.UploadFileFromByteNew(bytes, System.IO.Path.GetFileName(fileUpl.FileName), 30, 3, "RegNumberCode", false, "900502301693",
            //            "Altynbekov Baqtiyar ospanuly", "hcsbkkz\\tulepbergenov.b", true);
            //    }
            //}
         //  return fileUrl;
        }
    }
}