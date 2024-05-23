using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Modelos;

namespace API.Libreria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _clientes;

        public ClientesController(IClientes clientes)
        {
            _clientes = clientes;
        }
    
        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar([FromBody] Clientes clientes)
        {
            var result = await this._clientes.GuardarCliente(clientes);
            if (result == false)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var result = await this._clientes.ListarCliente();
            return Ok(result);
        }
    
        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Clientes clientes)
        {
            var result = await this._clientes.ActualizarCliente(clientes);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] Clientes clientes)
        {
            var result = await this._clientes.EliminarCliente(clientes);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}