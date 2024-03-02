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
        public async Task<ActionResult<PedidoResponse>> GetPedido(int id)
        {
            var result = await _pedidoService.GetPedidoById(id);

            if (result is not null)
            {
                var response = new PedidoResponse().GetPedidoResponse(result);

                return Ok(response);
            }

            return NotFound($"Pedido com {id} não foi encontrado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, [FromBody] bool pago = true)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _pedidoService.GetPedidoById(id);

            if (result is not null)
            {
                result.Pago = pago;

                await _pedidoService.UpdatePedido(result);

                return Ok("Pedido atualizado");
            }

            return BadRequest("Erro ao atualizar o pedido");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePedidoAsync(int id)
        {
            var result = await _pedidoService.DeletePedido(id);

            if (result) return Ok($"Pedido com {id} deletado com sucesso");

            return BadRequest($"Pedido com {id} não pode ser removido ou não foi encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _pedidoService.AddPedido(pedido);

            if (result) return Ok("Pedido criado com sucesso");
            return BadRequest("Erro ao criar o pedido");
        }
    }
}
