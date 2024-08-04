using Katmanli.DataAccess.DTOs;
using Katmanli.Service.Interfaces;
using Katmanli.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GubreController : ControllerBase
    {
        private readonly IGubreService _gubreService;

        public GubreController(IGubreService gubreService)
        {
            _gubreService = gubreService;
        }

        [HttpPost("Create")]
        public IActionResult Create(GubreCreate gubreCreateModel)
        {
            var gubreOlustur = _gubreService.Create(gubreCreateModel);
            if (gubreOlustur.Success)
            {
                return Ok(gubreOlustur);
            }
            return BadRequest(gubreOlustur);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gubreSil = await _gubreService.Delete(id);
            if (gubreSil.Success)
            {
                return Ok(gubreSil);
            }
            return BadRequest(gubreSil);
        }

        [HttpGet("GetGubreById/{id}")]
        public IActionResult GetGubreById(int id)
        {
            var gubre = _gubreService.GetGubreById(id);
            if (gubre.Success)
            {
                return Ok(gubre);
            }
            return NotFound(gubre);
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {

            var gubreler = _gubreService.ListAll();

            if (gubreler.Success)
            {
                return Ok(gubreler);
            }
            return NotFound(gubreler);
        }
    }
}
