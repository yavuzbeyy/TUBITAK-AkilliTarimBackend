using Katmanli.DataAccess.DTOs;
using Katmanli.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Katmanli.DataAccess.DTOs.BitkiDTO;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitkiController : ControllerBase
    {
        private readonly IBitkiService _bitkiService;

        public BitkiController(IBitkiService bitkiService)
        {
            _bitkiService = bitkiService;
        }

        [HttpPost("Create")]
        public IActionResult Create(BitkiCreate bitkiCreateModel)
        {
            var bitkiOlustur = _bitkiService.Create(bitkiCreateModel);
            if (bitkiOlustur.Success)
            {
                return Ok(bitkiOlustur);
            }
            return BadRequest(bitkiOlustur);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bitkiSil = await _bitkiService.Delete(id);
            if (bitkiSil.Success)
            {
                return Ok(bitkiSil);
            }
            return BadRequest(bitkiSil);
        }

        [HttpGet("FindById/{id}")]
        public IActionResult FindById(int id)
        {
            var bitki = _bitkiService.FindById(id);
            if (bitki.Success)
            {
                return Ok(bitki);
            }
            return NotFound(bitki);
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            var bitkiler = _bitkiService.ListAll();
            if (bitkiler.Success)
            {
                return Ok(bitkiler);
            }
            return BadRequest(bitkiler);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(BitkiUpdate bitkiUpdateModel)
        {
            var bitkiGuncelle = await _bitkiService.Update(bitkiUpdateModel);
            if (bitkiGuncelle.Success)
            {
                return Ok(bitkiGuncelle);
            }
            return BadRequest(bitkiGuncelle);
        }

        [HttpGet("ListBitkilerFullInformation/{bitkiId}")]
        public IActionResult ListBitkilerFullInformation(int bitkiId)
        {
            var bitkiBilgiler = _bitkiService.ListBitkilerFullInformation(bitkiId);
            if (bitkiBilgiler.Success)
            {
                return Ok(bitkiBilgiler);
            }
            return NotFound(bitkiBilgiler);
        }

        [HttpGet("GetCityAndPlantsByLocation")]
        public IActionResult GetCityAndPlantsByLocation(double enlemKoordinat, double boylamKoordinat)
        {
            var bitkiler = _bitkiService.GetCityAndPlantsByLocation(enlemKoordinat, boylamKoordinat);
            if (bitkiler.Success)
            {
                return Ok(bitkiler);
            }
            return BadRequest(bitkiler);
        }
    }
}
