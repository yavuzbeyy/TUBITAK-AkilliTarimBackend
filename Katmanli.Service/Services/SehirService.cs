using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using System;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.SehirDTO;

namespace Katmanli.Service.Services
{
    public class SehirService : ISehirService
    {
        private readonly IGenericRepository<Sehir> _sehirRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SehirService(IGenericRepository<Sehir> sehirRepository, IUnitOfWork unitOfWork)
        {
            _sehirRepository = sehirRepository;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(SehirCreate model)
        {
            var yeniSehir = new Sehir
            {
                SehirAdi = model.SehirAdi,
                EnlemKoordinat = model.EnlemKoordinat,
                BoylamKoordinat = model.BoylamKoordinat,
                CreatedDate = DateTime.Now
            };

            if (yeniSehir == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Şehir"));
            }

            _sehirRepository.AddAsync(yeniSehir).Wait();
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Şehir"));
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var sehir = await _sehirRepository.GetByIdAsync(id);
            if (sehir == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Şehir"));
            }

            _sehirRepository.Delete(sehir);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<string>(Messages.Delete("Şehir"));
        }

        public IResponse<SehirQuery> GetSehirById(int sehirId)
        {
            var sehir = _sehirRepository.GetByIdAsync(sehirId).Result;
            if (sehir == null)
            {
                return new ErrorResponse<SehirQuery>(Messages.NotFound("Şehir"));
            }

            var sehirQuery = new SehirQuery
            {
                SehirAdi = sehir.SehirAdi,
                EnlemKoordinat = sehir.EnlemKoordinat,
                BoylamKoordinat = sehir.BoylamKoordinat
            };

            return new SuccessResponse<SehirQuery>(sehirQuery);
        }

        public IResponse<IEnumerable<SehirQuery>> ListAll()
        {
            var sehirler = _sehirRepository.GetAll();

            var sehirQuery = sehirler.Select(sehir => new SehirQuery 
            {
                Id = sehir.Id,
                SehirAdi = sehir.SehirAdi,
                BoylamKoordinat = sehir.BoylamKoordinat,
                EnlemKoordinat = sehir.EnlemKoordinat
            });
       
         return new SuccessResponse<IEnumerable<SehirQuery>>(sehirQuery);

        }


    }
}
