using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Services
{
    public class GubreService : IGubreService
    {

        private readonly IGenericRepository<Gubreleme> _gubrelemeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GubreService(IGenericRepository<Gubreleme> gubre, IUnitOfWork unitOfWork) 
        {
            _gubrelemeRepository = gubre;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(GubreCreate model)
        {
            var yeniGubre = new Gubreleme
            {
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                CreatedDate = DateTime.Now
            };

            if (yeniGubre == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Gübre"));
            }

            _gubrelemeRepository.AddAsync(yeniGubre);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Gübre"));
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var gubre = await _gubrelemeRepository.GetByIdAsync(id);
            if (gubre == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Gübre"));
            }

            _gubrelemeRepository.Delete(gubre);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<string>(Messages.Delete("Gübre"));
        }

        public IResponse<GubreQuery> GetGubreById(int gubreId)
        {
            var gubre =  _gubrelemeRepository.GetByIdAsync(gubreId).Result;

            if (gubre == null)
            {
                return new ErrorResponse<GubreQuery>(Messages.NotFound("Gübre"));
            }
            
            //Elle mapleme işlemi
            var gubreQuery = new GubreQuery();
            gubreQuery.Id = gubre.Id;
            gubreQuery.Ad = gubre.Ad;
            gubreQuery.Aciklama = gubre.Aciklama;

            return new SuccessResponse<GubreQuery>(gubreQuery);
        }

    }
}
