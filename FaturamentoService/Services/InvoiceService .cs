using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FaturamentoService.DTOs;
using FaturamentoService.Models;
using FaturamentoService.Repositories;

namespace FaturamentoService.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
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
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            invoice.Status = InvoiceStatus.Open; 

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

     
    }
}