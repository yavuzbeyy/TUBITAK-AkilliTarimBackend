using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Katmanli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IklimController : ControllerBase
    {
        private readonly IIklimService _iklimService;

        public IklimController(IIklimService iklimService)
        {
            _iklimService = iklimService;
        }

        [HttpPost("Create")]
        public IActionResult Create(IklimDTO.IklimCreate iklimCreateModel)
        {
            var iklimOlustur = _iklimService.Create(iklimCreateModel);
            if (iklimOlustur.Success)
            {
                return Ok(iklimOlustur);
            }
            return BadRequest(iklimOlustur);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var iklimSil = await _iklimService.Delete(id);
            if (iklimSil.Success)
            {
                return Ok(iklimSil);
            }
            return BadRequest(iklimSil);
        }

        [HttpGet("GetIklimById/{id}")]
        public IActionResult GetIklimById(int id)
        {
            var iklim = _iklimService.GetIklimById(id);
            if (iklim.Success)
            {
                return Ok(iklim);
            }
            return NotFound(iklim);
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll() 
        {
        
            var iklimler = _iklimService.ListAll();

            if (iklimler.Success)
            {
                return Ok(iklimler);
            }
            return NotFound(iklimler);
        }
    }
}
