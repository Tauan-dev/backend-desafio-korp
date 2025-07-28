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
            CreateMap<InvoiceProduct, InvoiceProductDto>();


            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.FiscalNumber, opt => opt.MapFrom(src => src.FiscalNumber))
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<CreateInvoiceProductDto, InvoiceProduct>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore());
        }
    }

}