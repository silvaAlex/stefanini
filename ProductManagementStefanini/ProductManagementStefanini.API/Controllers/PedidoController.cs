using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.Domain.Models;
using ProductManagement.API.Domain.Services;
using ProductManagementStefanini.API.Infra.Response;

namespace ProductManagementStefanini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("{id}")]
        public ActionResult<PedidoResponse> GetPedido(int id)
        {
            PedidoResponse result = new();
            Pedido? pedido = _pedidoService.GetPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return result.GetPedidoResponse(pedido);
        }

        [HttpPut("{id}")]
        public ActionResult PutPedido(int id, [FromBody] bool pago = true)
        {
            Pedido? pedido = _pedidoService.GetPedidoById(id);

            if (pedido is not null)
            {
                if (id != pedido.Id)
                {
                    return BadRequest();
                }

                pedido.Pago = pago;
            }
            else
            {
                return NotFound();
            }

            _pedidoService.UpdatePedido(pedido);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePedido(int id)
        {
            _pedidoService?.DeletePedido(id);

            return Ok();
        }

        [HttpPost]
        public ActionResult PostPedido([FromBody] Pedido pedido)
        {
            _pedidoService.AddPedido(pedido);

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }
    }
}
