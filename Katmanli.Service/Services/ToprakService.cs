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
    public class ToprakService : IToprakService
    {
        private readonly IGenericRepository<Toprak> _toprakRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ToprakService(IGenericRepository<Toprak> toprakRepository, IUnitOfWork unitOfWork)
        {
            _toprakRepository = toprakRepository;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(ToprakCreate model)
        {
            var yeniToprak = new Toprak
            {
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                CreatedDate = DateTime.Now
            };

            if (yeniToprak == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Toprak"));
            }

            _toprakRepository.AddAsync(yeniToprak).Wait();
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Toprak"));
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var toprak = await _toprakRepository.GetByIdAsync(id);
            if (toprak == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Toprak"));
            }

            _toprakRepository.Delete(toprak);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<string>(Messages.Delete("Toprak"));
        }

        public IResponse<ToprakQuery> GetToprakById(int toprakId)
        {
            var toprak = _toprakRepository.GetByIdAsync(toprakId).Result;
            if (toprak == null)
            {
                return new ErrorResponse<ToprakQuery>(Messages.NotFound("Toprak"));
            }

            var toprakQuery = new ToprakQuery
            {
                Id = toprak.Id,
                Ad = toprak.Ad,
                Aciklama = toprak.Aciklama,

            };

            return new SuccessResponse<ToprakQuery>(toprakQuery);
        }

        public IResponse<IEnumerable<ToprakQuery>> ListAll()
        {
            var topraklar = _toprakRepository.GetAll();

            var toprakQuery = topraklar.Select(iklim => new  ToprakQuery
            {
                Id = iklim.Id,
                Ad = iklim.Ad,
                Aciklama = iklim.Aciklama
            });

            return new SuccessResponse<IEnumerable<ToprakQuery>>(toprakQuery);
        }
    }
    }

