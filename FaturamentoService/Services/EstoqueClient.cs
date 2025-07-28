using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaturamentoService.DTOs;

namespace FaturamentoService.Services
{
    public class EstoqueClient : IEstoqueClient
    {
        private readonly HttpClient _httpClient;

        public EstoqueClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductDto>($"/api/product/{id}");
            }
            catch
            {
                return null;
            }
        }
    }
}