using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Modelos;

namespace API.Libreria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamos _prestamos;

        public PrestamosController(IPrestamos prestamos)
        {
            _prestamos = prestamos;
        }
    
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Prestamos prestamos)
        {
            var result = await this._prestamos.GuardarPrestamo(prestamos);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await this._prestamos.ListarPrestamos();
            return Ok(result);
        }
    
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Prestamos prestamos)
        {
            var result = await this._prestamos.ActualizarPrestamo(prestamos);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] Prestamos prestamos)
        {
            var result = await this._prestamos.EliminarPrestamo(prestamos);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}