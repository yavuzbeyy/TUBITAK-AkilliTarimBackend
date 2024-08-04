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
    public class ToprakController : ControllerBase
    {
        private readonly IToprakService _toprakService;

        public ToprakController(IToprakService toprakService)
        {
            _toprakService = toprakService;
        }

        [HttpPost("Create")]
        public IActionResult Create(ToprakCreate toprakCreateModel)
        {
            var toprakOlustur = _toprakService.Create(toprakCreateModel);
            if (toprakOlustur.Success)
            {
                return Ok(toprakOlustur);
            }
            return BadRequest(toprakOlustur);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toprakSil = await _toprakService.Delete(id);
            if (toprakSil.Success)
            {
                return Ok(toprakSil);
            }
            return BadRequest(toprakSil);
        }

        [HttpGet("GetToprakById/{id}")]
        public IActionResult GetToprakById(int id)
        {
            var toprak = _toprakService.GetToprakById(id);
            if (toprak.Success)
            {
                return Ok(toprak);
            }
            return NotFound(toprak);
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {

            var topraklar = _toprakService.ListAll();

            if (topraklar.Success)
            {
                return Ok(topraklar);
            }
            return NotFound(topraklar);
        }
    }
}
