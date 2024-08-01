using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using System;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.SulamaDTO;

namespace Katmanli.Service.Services
{
    public class SulamaService : ISulamaService
    {
        private readonly IGenericRepository<Sulama> _sulamaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SulamaService(IGenericRepository<Sulama> sulamaRepository, IUnitOfWork unitOfWork)
        {
            _sulamaRepository = sulamaRepository;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(SulamaDTO.SulamaCreate model)
        {
            var yeniSulama = new Sulama
            {
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                CreatedDate = DateTime.Now
            };

            if (yeniSulama == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Sulama"));
            }

            _sulamaRepository.AddAsync(yeniSulama).Wait();
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Sulama"));
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var sulama = await _sulamaRepository.GetByIdAsync(id);
            if (sulama == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Sulama"));
            }

            _sulamaRepository.Delete(sulama);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<string>(Messages.Delete("Sulama"));
        }

        public IResponse<SulamaQuery> GetSulamaById(int sulamaId)
        {
            var sulama = _sulamaRepository.GetByIdAsync(sulamaId).Result;
            if (sulama == null)
            {
                return new ErrorResponse<SulamaQuery>(Messages.NotFound("Sulama"));
            }

            var sulamaQuery = new SulamaQuery
            {
                Id = sulama.Id,
                Ad = sulama.Ad,
                Aciklama = sulama.Aciklama,
            };

            return new SuccessResponse<SulamaQuery>(sulamaQuery);
        }
    }
}
