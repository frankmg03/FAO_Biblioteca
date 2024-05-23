using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Modelos;

namespace API.Libreria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutores _autores;

        public AutoresController(IAutores autores)
        {
            _autores = autores;
        }
    
        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar([FromBody] Autores autores)
        {
            var result = await this._autores.GuardarAutor(autores);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var result = await this._autores.ListAutor();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Autores autores)
        {
            var result = await this._autores.ActualizarAutor(autores);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] Autores autores)
        {
            var result = await this._autores.EliminarAutor(autores);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}