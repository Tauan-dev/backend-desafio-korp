using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FaturamentoService.Models.Enums;
using ApiGateway.Clients;
using FaturamentoService.DTOs;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceGatewayController : ControllerBase
    {
        private readonly IFaturamentoClient _faturamentoClient;
        private readonly IEstoqueClient _estoqueClient;

        public InvoiceGatewayController(IFaturamentoClient faturamentoClient, IEstoqueClient estoqueClient)
        {
            _faturamentoClient = faturamentoClient;
            _estoqueClient = estoqueClient;
        }

        [HttpPost("{id}/print")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PrintInvoice(Guid id)
        {
            try
            {
                var invoice = await _faturamentoClient.GetInvoiceByIdAsync(id);
                if (invoice == null)
                {
                    return NotFound(new { StatusCode = 404, Message = "Nota fiscal não encontrada." });
                }

                if (invoice.Status == InvoiceStatus.Closed)
                {
                    return BadRequest(new { StatusCode = 400, Message = "Nota fiscal já está fechada." });
                }

            
                foreach (var item in invoice.Products)
                {
                    var product = await _estoqueClient.GetProductByIdAsync(item.ProductId);
                    if (product.Stock < item.Quantity)
                    {
                        return BadRequest(new
                        {
                            StatusCode = 400,
                            Message = $"Estoque insuficiente para o produto '{product.Name}' (ID: {item.ProductId})."
                        });
                    }
                }

                var baixadosComSucesso = new List<(Guid productId, int quantity)>();
                foreach (var item in invoice.Products)
                {
                    try
                    {
                        await _estoqueClient.DecreaseStockAsync(item.ProductId, item.Quantity);
                        baixadosComSucesso.Add((item.ProductId, item.Quantity));
                    }
                    catch (Exception ex)
                    {
                    
                        return StatusCode(500, new
                        {
                            StatusCode = 500,
                            Message = $"Erro ao baixar o estoque do produto '{item.ProductId}'.",
                            Detail = ex.Message
                        });
                    }
                }

               
                try
                {
                    await _faturamentoClient.CloseInvoiceAsync(id);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new
                    {
                        StatusCode = 500,
                        Message = "Erro ao fechar a nota fiscal após baixar o estoque.",
                        Detail = ex.Message
                    });
                }

                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Nota fiscal impressa com sucesso. Estoque atualizado e nota fechada."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    Message = "Erro inesperado ao processar a impressão da nota.",
                    Detail = ex.Message
                });
            }
        }
    }
}
