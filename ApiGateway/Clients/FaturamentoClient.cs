using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaturamentoService.DTOs;


namespace ApiGateway.Clients
{
    public class FaturamentoClient : IFaturamentoClient
    {
        private readonly HttpClient _httpClient;

        public FaturamentoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<InvoiceDto>($"api/invoice/{id}");
        }

        public async Task<bool> CloseInvoiceAsync(Guid id)
        {
            var response = await _httpClient.PutAsync($"api/invoice/{id}/close", null);
            return response.IsSuccessStatusCode;
        }

    }
}