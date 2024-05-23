using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Modelos;

namespace API.Libreria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneros _generos;

        public GenerosController(IGeneros generos)
        {
            _generos = generos;
        }
    
        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar([FromBody] Generos generos)
        {
            var result = await this._generos.GuardarGenero(generos);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var result = await this._generos.ListarGenero();
            return Ok(result);
        }
    
        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Generos generos)
        {
            var result = await this._generos.ActualizarGenero(generos);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] Generos generos)
        {
            var result = await this._generos.EliminarGenero(generos);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}