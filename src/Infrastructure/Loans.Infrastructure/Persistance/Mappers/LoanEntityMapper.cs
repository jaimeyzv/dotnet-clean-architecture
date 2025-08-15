using AutoMapper;
using Loans.Application.Services;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Entities;

namespace Loans.Infrastructure.Persistance.Mappers
{
    public sealed class LoanEntityMapper : Profile
    {
        public LoanEntityMapper()
        {
            CreateMap<LoanEntity, LoanDomain>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetLoanStatusEnum()));
            CreateMap<LoanDomain, LoanEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToDisplayLoanStatus()));
        }
    }
}
