using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Modelos;

namespace API.Libreria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibros _libros;

        public LibrosController(ILibros libros)
        {
            _libros = libros;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Libros libros)
        {
            var result = await this._libros.GuardarLibro(libros);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._libros.ListarLibro();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Libros libros)
        {
            var result = await this._libros.ActualizarLibro(libros);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Libros libros)
        {
            var result = await this._libros.EliminarLibro(libros);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}