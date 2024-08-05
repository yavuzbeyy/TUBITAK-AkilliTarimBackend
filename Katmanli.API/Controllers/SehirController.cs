using Katmanli.DataAccess.DTOs;
using Katmanli.Service.Interfaces;
using Katmanli.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.SehirDTO;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        private readonly ISehirService _sehirService;

        public SehirController(ISehirService sehirService)
        {
            _sehirService = sehirService;
        }

        [HttpPost("Create")]
        public IActionResult Create(SehirCreate sehirCreateModel)
        {
            var sehirOlustur = _sehirService.Create(sehirCreateModel);
            if (sehirOlustur.Success)
            {
                return Ok(sehirOlustur);
            }
            return BadRequest(sehirOlustur);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sehirSil = await _sehirService.Delete(id);
            if (sehirSil.Success)
            {
                return Ok(sehirSil);
            }
            return BadRequest(sehirSil);
        }

        [HttpGet("GetSehirById/{id}")]
        public IActionResult GetSehirById(int id)
        {
            var sehir = _sehirService.GetSehirById(id);
            if (sehir.Success)
            {
                return Ok(sehir);
            }
            return NotFound(sehir);
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {

            var sehirler = _sehirService.ListAll();

            if (sehirler.Success)
            {
                return Ok(sehirler);
            }
            return NotFound("Şehirler");
        }
    }
}
