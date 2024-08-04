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
    public class SulamaController : ControllerBase
    {
        private readonly ISulamaService _sulamaService;

        public SulamaController(ISulamaService sulamaService)
        {
            _sulamaService = sulamaService;
        }

        [HttpPost("Create")]
        public IActionResult Create(SulamaDTO.SulamaCreate sulamaCreateModel)
        {
            var sulamaOlustur = _sulamaService.Create(sulamaCreateModel);
            if (sulamaOlustur.Success)
            {
                return Ok(sulamaOlustur);
            }
            return BadRequest(sulamaOlustur);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sulamaSil = await _sulamaService.Delete(id);
            if (sulamaSil.Success)
            {
                return Ok(sulamaSil);
            }
            return BadRequest(sulamaSil);
        }

        [HttpGet("GetSulamaById/{id}")]
        public IActionResult GetSulamaById(int id)
        {
            var sulama = _sulamaService.GetSulamaById(id);
            if (sulama.Success)
            {
                return Ok(sulama);
            }
            return NotFound(sulama);
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {

            var sulamaTurleri = _sulamaService.ListAll();

            if (sulamaTurleri.Success)
            {
                return Ok(sulamaTurleri);
            }
            return NotFound(sulamaTurleri);
        }
    }
}
