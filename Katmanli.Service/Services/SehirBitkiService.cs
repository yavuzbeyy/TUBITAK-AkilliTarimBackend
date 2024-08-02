using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Katmanli.Service.Services
{
    public class SehirBitkiService : ISehirBitkiService
    {
        private readonly IGenericRepository<SehirBitki> _sehirBitkiRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SehirBitkiService(IGenericRepository<SehirBitki> sehirBitkiRepository, IUnitOfWork unitOfWork)
        {
            _sehirBitkiRepository = sehirBitkiRepository;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(SehirBitkiDTO.SehirBitkiCreate model)
        {
            var yeniSehirBitki = new SehirBitki
            {
                SehirId = model.SehirId,
                BitkiId = model.BitkiId,
                CreatedDate = DateTime.Now
            };

            if (yeniSehirBitki == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Şehir Bitki"));
            }

            _sehirBitkiRepository.AddAsync(yeniSehirBitki).Wait();
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Şehir Bitki"));
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var sehirBitki = await _sehirBitkiRepository.GetByIdAsync(id);
            if (sehirBitki == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Şehir Bitki"));
            }

            _sehirBitkiRepository.Delete(sehirBitki);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<string>(Messages.Delete("Şehir Bitki"));
        }
    }
}
