using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FaturamentoService.DTOs;
using FaturamentoService.Models;
using FaturamentoService.Repositories;
using FaturamentoService.Models.Enums;

namespace FaturamentoService.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        private readonly IEstoqueClient _estoqueClient;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, IEstoqueClient estoqueClient)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _estoqueClient = estoqueClient;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto?> GetByIdAsync(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            return _mapper.Map<InvoiceDto>(invoice) ??
                throw new KeyNotFoundException($"Nota fiscal com ID {id} não encontrada.");
        }

        public async Task<InvoiceDto> CreateAsync(CreateInvoiceDto invoiceDto)
        {
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                Status = InvoiceStatus.Open,
                CreatedAt = DateTime.UtcNow,
                FiscalNumber = invoiceDto.FiscalNumber,
                Products = new List<InvoiceProduct>()
            };

            foreach (var item in invoiceDto.Products)
            {
                var product = await _estoqueClient.GetProductByIdAsync(item.ProductId);
                if (product == null)
                    throw new KeyNotFoundException($"Produto com ID {item.ProductId} não encontrado no EstoqueService.");

                invoice.Products.Add(new InvoiceProduct
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Invoice = invoice
                });
            }

            await _invoiceRepository.CreateAsync(invoice);
            return _mapper.Map<InvoiceDto>(invoice);
        }



        public async Task<InvoiceDto?> UpdateAsync(Guid id, CreateInvoiceDto invoiceDto)
        {
            var existing = await _invoiceRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Nota fiscal com ID {id} não encontrada.");

            _mapper.Map(invoiceDto, existing);
            await _invoiceRepository.UpdateAsync(existing);

            return _mapper.Map<InvoiceDto>(existing);
        }
        public async Task<bool> CloseInvoiceAsync(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
                throw new KeyNotFoundException($"Nota fiscal com ID {id} não encontrada.");

            if (invoice.Status == InvoiceStatus.Closed)
                return false;

            invoice.Status = InvoiceStatus.Closed;
            await _invoiceRepository.UpdateAsync(invoice);
            return true;
        }



    }
}