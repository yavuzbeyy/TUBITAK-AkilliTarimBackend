using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Services
{
    public class UploadService : IUploadService
    {
        private readonly IGenericRepository<UploadImage> _uploadImageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UploadService(IGenericRepository<UploadImage> uploadImageRepository, IUnitOfWork unitOfWork)
        {
            _uploadImageRepository = uploadImageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<(string fileName, FileResult fileContent)>> GetFile(string filekey)
        {
            string contentType = "image/jpeg";
            FileResult fileResult;

            if (string.IsNullOrEmpty(filekey))
            {
                return new ErrorResponse<(string, FileResult)>(Messages.NotFound("dosya"));
            }

            var imageResult = _uploadImageRepository.GetAll().Where(x => x.FileKey == filekey).ToList();


            if (imageResult == null || !File.Exists(imageResult.First().FilePath))
            {
                return new ErrorResponse<(string, FileResult)>(Messages.NotFound("dosya"));
            }

            // Diğer dosya türleri için FileContentResult kullan
            var fileContent = System.IO.File.ReadAllBytes(imageResult.First().FilePath);
            fileResult = new FileContentResult(fileContent, contentType);

            return new SuccessResponse<(string, FileResult)>((imageResult.First().FileOriginalName, fileResult));
        }

        public string UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExtension = Path.GetExtension(fileName).ToLower();
                var uploadPath = "C:\\Users\\yavuz\\OneDrive\\Desktop\\Projelerim\\TÜBİTAK 2209-A Akıllı Tarım Uygulaması Projesi\\Backend\\Katmanli.API\\wwwroot\\Uploads";


                string documentIdentityKey = Guid.NewGuid().ToString();
                string documentGuidName = documentIdentityKey + fileExtension;
                string fileType = GetFileType(fileName);

                if (fileType != "Resim")
                {
                    throw new Exception(""); //hata döndür
                }

                var filePath = Path.Combine(uploadPath + "/" + documentGuidName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                _uploadImageRepository.AddAsync(new UploadImage
                {
                    FileOriginalName = fileName,
                    FileGuidedName = documentGuidName,
                    FileKey = documentIdentityKey,
                    FilePath = filePath
                });
                _unitOfWork.Commit();


                return documentIdentityKey;
            }
            return null;
        }

        private string GetFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".jfif":
                    return "Resim";
                default:
                    return "Diger";
            }
        }
    }
}
