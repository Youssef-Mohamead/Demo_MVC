using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Demo.BusinessLogic.Services.AttachementService
{
    public class AttachementService : IAttachementService
    {
        List<string> allowedEtensions = [".png",".jpg",".Jpeg"];
        const int  maxSize= 2_097_152;// 1024 * 1024
        public string? Upload(IFormFile file, string FolderName)
        {
            //1.Check Extension
            var etension = Path.GetExtension(file.FileName); // .png /.jpg <=this example
            if (!allowedEtensions.Contains(etension)) return null;
            //*******************************************
            //2.Check Size
            if (file.Length == 0 || file.Length > maxSize)
                return null;
            //*******************************************
            //3.Get Located Folder Path
            var FolderPath= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files",FolderName);

            //*******************************************
            //4.Make Attachment Name Unique-- GUID
            var fileName=$"{Guid.NewGuid()}_{file.FileName}";

            //*******************************************
            //5.Get File Path
            var filePath = Path.Combine(FolderPath,fileName);//File Location

            //*******************************************
            //6.Create File Stream To Copy File[Unmanaged]
           using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            
            //*******************************************
            //7.Use Stream To Copy File
            file.CopyTo(fileStream);
            //*******************************************
            //8.Return FileName To Store In Database

            return fileName;
        }
        public bool Delete(string filePath)
        {
           //Check if File Exists Or Not If Exists Remove It
                if (!File.Exists(filePath)) return false;
                else
                {
                    File.Delete(filePath);
                    return true;
                }
        }

    }
}
