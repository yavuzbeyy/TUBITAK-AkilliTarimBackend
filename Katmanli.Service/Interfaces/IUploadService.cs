﻿using Katmanli.Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface IUploadService
    {
        string UploadFile(IFormFile file);

        Task<IResponse<(string fileName, FileResult fileContent)>> GetFile(string filekey);
    }
}
