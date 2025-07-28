using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueService.Data;
using EstoqueService.Models;
using Microsoft.EntityFrameworkCore;


namespace EstoqueService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EstoqueDbContext _context;

        public ProductRepository(EstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await SaveAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            Console.WriteLine($"[DEBUG] Atualizando produto: {product.Id}, novo estoque: {product.Stock}");

            var existingProduct = await GetProductByIdAsync(product.Id);
            if (existingProduct == null) return null;

            existingProduct.Stock = product.Stock;

            var success = await SaveAsync();

            return existingProduct;
        }



        public async Task<bool> DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }


    }
}