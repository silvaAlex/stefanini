using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementStefanini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetPedido()
        {
            var item = new { 
                Id = 1,
                NomeCliente = "Alex",
                Email = "silva_jralex@hotmail.com"
            };

            return Ok(item);
        }
    }
}
