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
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.BitkiDTO;

namespace Katmanli.Service.Services
{
    public class BitkiService : IBitkiService
    {
        private readonly IGenericRepository<Bitki> _bitkiRepository;
        private readonly IGenericRepository<Sulama> _sulamaRepository;
        private readonly IGenericRepository<Gubreleme> _gubrelemeRepository;
        private readonly IGenericRepository<Iklim> _iklimRepository;
        private readonly IGenericRepository<Toprak> _toprakRepository;
        private readonly IGenericRepository<Sehir> _sehirRepository;
        private readonly IGenericRepository<SehirBitki> _sehirBitkiRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BitkiService(IGenericRepository<Bitki> bitkiRepository, IUnitOfWork unitOfWork, IGenericRepository<Sulama> sulamaRepository, IGenericRepository<Gubreleme> gubrelemeRepository, IGenericRepository<Iklim> iklimRepository, IGenericRepository<Toprak> toprakRepository, IGenericRepository<Sehir> sehirRepository, IGenericRepository<SehirBitki> sehirBitkiRepository)
        {
            _bitkiRepository = bitkiRepository;
            _unitOfWork = unitOfWork;
            _sulamaRepository = sulamaRepository;
            _gubrelemeRepository = gubrelemeRepository;
            _iklimRepository = iklimRepository;
            _toprakRepository = toprakRepository;
            _sehirRepository = sehirRepository;
            _sehirBitkiRepository = sehirBitkiRepository;
        }

        public IResponse<string> Create(BitkiDTO.BitkiCreate model)
        {
            var yeniBitki = new Bitki
            {
                Aciklama = model.Aciklama,
                IklimId = model.IklimId,
                ToprakId = model.ToprakId,
                SulamaId = model.SulamaId,
                GubrelemeId = model.GubrelemeId,
                Fotokey = model.Fotokey,
                CreatedDate = DateTime.Now
            };

            if (yeniBitki == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Bitki"));
            }

            _bitkiRepository.AddAsync(yeniBitki).Wait();
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Bitki"));
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var bitki = await _bitkiRepository.GetByIdAsync(id);
            if (bitki == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Bitki"));
            }

            _bitkiRepository.Delete(bitki);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<string>(Messages.Delete("Bitki"));
        }

        public IResponse<BitkiDTO.BitkiQuery> FindById(int id)
        {
            var bitki = _bitkiRepository.GetByIdAsync(id).Result;
            if (bitki == null)
            {
                return new ErrorResponse<BitkiDTO.BitkiQuery>(Messages.NotFound("Bitki"));
            }

            var bitkiQuery = new BitkiDTO.BitkiQuery
            {
                Id = bitki.Id,
                Aciklama = bitki.Aciklama,
                IklimId = bitki.IklimId,
                ToprakId = bitki.ToprakId,
                SulamaId = bitki.SulamaId,
                GubrelemeId = bitki.GubrelemeId,
                Fotokey = bitki.Fotokey,
            };

            return new SuccessResponse<BitkiDTO.BitkiQuery>(bitkiQuery);
        }

        public IResponse<IEnumerable<BitkiDTO.BitkiQuery>> ListAll()
        {
            var bitkiler = _bitkiRepository.GetAll();
            var bitkiQueries = bitkiler.Select(bitki => new BitkiDTO.BitkiQuery
            {
                Id = bitki.Id,
                Aciklama = bitki.Aciklama,
                IklimId = bitki.IklimId,
                ToprakId = bitki.ToprakId,
                SulamaId = bitki.SulamaId,
                GubrelemeId = bitki.GubrelemeId,
                Fotokey = bitki.Fotokey,
            });

            return new SuccessResponse<IEnumerable<BitkiDTO.BitkiQuery>>(bitkiQueries);
        }

        public async Task<IResponse<BitkiDTO.BitkiUpdate>> Update(BitkiDTO.BitkiUpdate model)
        {
            var bitki = await _bitkiRepository.GetByIdAsync(model.Id);
            if (bitki == null)
            {
                return new ErrorResponse<BitkiDTO.BitkiUpdate>(Messages.NotFound("Bitki"));
            }

            bitki.Aciklama = model.Aciklama;
            bitki.IklimId = model.IklimId;
            bitki.ToprakId = model.ToprakId;
            bitki.SulamaId = model.SulamaId;
            bitki.GubrelemeId = model.GubrelemeId;
            bitki.Fotokey = model.Fotokey;

            _bitkiRepository.Update(bitki);
            await _unitOfWork.CommitAsync();

            return new SuccessResponse<BitkiDTO.BitkiUpdate>(model);
        }


        public IResponse<BitkiFullInformation> ListBitkilerFullInformation(int bitkiId)
        {
            var bitkiTumBilgiler = new BitkiFullInformation();

            var bitki = _bitkiRepository.GetByIdAsync(bitkiId).Result;
            if (bitki == null)
            {
                return new ErrorResponse<BitkiFullInformation>(Messages.NotFound("Bitki"));
            }

            if (bitki.ToprakId != null)
            {
                var bitkininTopragi = _toprakRepository.GetByIdAsync(bitki.ToprakId.Value).Result;
                if (bitkininTopragi != null)
                {
                    bitkiTumBilgiler.ToprakAciklama = bitkininTopragi.Aciklama;
                    bitkiTumBilgiler.ToprakAdi = bitkininTopragi.Ad;
                }
            }

            if (bitki.SulamaId != null)
            {
                var bitkininSulamaBilgileri = _sulamaRepository.GetByIdAsync(bitki.SulamaId.Value).Result;
                if (bitkininSulamaBilgileri != null)
                {
                    bitkiTumBilgiler.SulamaAciklama = bitkininSulamaBilgileri.Aciklama;
                    bitkiTumBilgiler.SulamaAdi = bitkininSulamaBilgileri.Ad;
                }
            }

            if (bitki.GubrelemeId != null)
            {
                var bitkininGubreBilgileri = _gubrelemeRepository.GetByIdAsync(bitki.GubrelemeId.Value).Result;
                if (bitkininGubreBilgileri != null)
                {
                    bitkiTumBilgiler.GubrelemeAciklama = bitkininGubreBilgileri.Aciklama;
                    bitkiTumBilgiler.GubrelemeAdi = bitkininGubreBilgileri.Ad;
                }
            }

            if (bitki.IklimId != null)
            {
                var bitkininIklimBilgileri = _iklimRepository.GetByIdAsync(bitki.IklimId.Value).Result;
                if (bitkininIklimBilgileri != null)
                {
                    bitkiTumBilgiler.IklimAciklama = bitkininIklimBilgileri.Aciklama;
                    bitkiTumBilgiler.IklimAdi = bitkininIklimBilgileri.Ad;
                }
            }

            return new SuccessResponse<BitkiFullInformation>(bitkiTumBilgiler);
        }

        public IResponse<IEnumerable<BitkiFullInformation>> GetCityAndPlantsByLocation(double enlemKoordinat, double boylamKoordinat)
        {

            var sehirler = _sehirRepository.GetAll();

            if (sehirler == null || !sehirler.Any())
            {
                return new ErrorResponse<IEnumerable<BitkiFullInformation>>("Şehirler bulunamadı");
            }

            Sehir enYakinSehir = null;
            double enKisaMesafe = double.MaxValue;

            foreach (var sehir in sehirler)
            {
                var mesafe = Haversine(enlemKoordinat, boylamKoordinat, sehir.EnlemKoordinat, sehir.BoylamKoordinat);
                if (mesafe < enKisaMesafe)
                {
                    enKisaMesafe = mesafe;
                    enYakinSehir = sehir;
                }
            }

            if (enYakinSehir == null)
            {
                return new ErrorResponse<IEnumerable<BitkiFullInformation>>("Şehirler bulunamadı");
            }

            var bitkiler = GetPlantsBySehirId(enYakinSehir.Id);

            return new SuccessResponse<IEnumerable<BitkiFullInformation>>(bitkiler);
        }

        private IEnumerable<BitkiFullInformation> GetPlantsBySehirId(int sehirId)
        {
            var sehirVeBitkiler = _sehirBitkiRepository.GetAll().Where(x => x.SehirId == sehirId);

            var bitkiBilgileri = new List<BitkiFullInformation>();

            foreach (var item in sehirVeBitkiler)
            {
                var bitkiBilgi = ListBitkilerFullInformation(item.BitkiId).Data;
                bitkiBilgileri.Add(bitkiBilgi);
            }

            return bitkiBilgileri;
        }









        private double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Radius of the earth in km
            var latDistance = ToRadians(lat2 - lat1);
            var lonDistance = ToRadians(lon2 - lon1);
            var a =
                Math.Sin(latDistance / 2) * Math.Sin(latDistance / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(lonDistance / 2) * Math.Sin(lonDistance / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = R * c; // convert to km

            return distance;
        }

        private double ToRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }

    }
}
