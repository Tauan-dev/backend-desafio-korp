using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FaturamentoService.DTOs;
using FaturamentoService.Models;

namespace FaturamentoService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore()) // status pode ser setado no service
                .ForMember(dest => dest.Products, opt => opt.Ignore()); // produtos são tratados separadamente

            CreateMap<InvoiceProduct, InvoiceProductDto>();
        }
    }
}