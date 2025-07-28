using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueService.DTOs;


namespace ApiGateway.Clients
{
    public class EstoqueClient : IEstoqueClient
    {
        private readonly HttpClient _httpClient;

        public EstoqueClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/product/{id}");
            response.EnsureSuccessStatusCode();

            var product = await response.Content.ReadFromJsonAsync<ProductDto>();
            return product ?? throw new Exception("Produto não encontrado.");
        }

        public async Task<bool> DecreaseStockAsync(Guid id, int quantity)
        {
            var response = await _httpClient.PostAsJsonAsync(
                $"/api/product/{id}/decrease-stock",
                new { quantity }
            );

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[Erro Estoque] {response.StatusCode} - {content}");
                return false;
            }

            return true;
        }
    }
}