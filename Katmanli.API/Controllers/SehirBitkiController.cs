using Katmanli.DataAccess.DTOs;
using Katmanli.Service.Interfaces;
using Katmanli.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirBitkiController : ControllerBase
    {
        private readonly ISehirBitkiService _sehirBitkiService;

        public SehirBitkiController(ISehirBitkiService sehirBitkiService)
        {
            _sehirBitkiService = sehirBitkiService;
        }

        [HttpPost("Create")]
        public IActionResult Create(SehirBitkiDTO.SehirBitkiCreate sehirBitkiCreateModel)
        {
            var sehirBitkiOlustur = _sehirBitkiService.Create(sehirBitkiCreateModel);
            if (sehirBitkiOlustur.Success)
            {
                return Ok(sehirBitkiOlustur);
            }
            return BadRequest(sehirBitkiOlustur);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sehirBitkiSil = await _sehirBitkiService.Delete(id);
            if (sehirBitkiSil.Success)
            {
                return Ok(sehirBitkiSil);
            }
            return BadRequest(sehirBitkiSil);
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {

            var sehirVeBitkiler = _sehirBitkiService.ListAll();

            if (sehirVeBitkiler.Success)
            {
                return Ok(sehirVeBitkiler);
            }
            return NotFound("Şehirlere ait bitkiler");
        }
    }
}
