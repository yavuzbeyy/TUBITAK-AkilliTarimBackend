using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using System;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.IklimDTO;

namespace Katmanli.Service.Services
{
    public class IklimService : IIklimService
    {
        private readonly IGenericRepository<Iklim> _iklimRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IklimService(IGenericRepository<Iklim> iklimRepository, IUnitOfWork unitOfWork)
        {
            _iklimRepository = iklimRepository;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(IklimDTO.IklimCreate model)
        {
            var yeniIklim = new Iklim
            {
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                CreatedDate = DateTime.Now
            };

            if (yeniIklim == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("İklim"));
            }

            _iklimRepository.AddAsync(yeniIklim).Wait();
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("İklim"));
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var iklim = await _iklimRepository.GetByIdAsync(id);
            if (iklim == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("İklim"));
            }

            _iklimRepository.Delete(iklim);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<string>(Messages.Delete("İklim"));
        }

        public IResponse<IklimQuery> GetSehirById(int iklimId)
        {
            var iklim = _iklimRepository.GetByIdAsync(iklimId).Result;
            if (iklim == null)
            {
                return new ErrorResponse<IklimQuery>(Messages.NotFound("İklim"));
            }

            var iklimQuery = new IklimQuery
            {
                Id = iklim.Id,
                Ad = iklim.Ad,
                Aciklama = iklim.Aciklama,
            };

            return new SuccessResponse<IklimDTO.IklimQuery>(iklimQuery);
        }
    }
}
