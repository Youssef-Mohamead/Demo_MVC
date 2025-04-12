using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Demo.BusinessLogic.Services.AttachementService
{
    public interface IAttachementService
    {
        //Upload
        public string? Upload(IFormFile file, string FolderName);
        //Delete
        bool Delete(string filePath);

    }
}
