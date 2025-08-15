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
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetLoanStatusEnum()))
                .ForMember(dest => dest.RepaymentModality, opt => opt.MapFrom(src => src.RepaymentModality.GetRepaymentModalityEnum()));
            CreateMap<LoanDomain, LoanEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToDisplayLoanStatus()))
                .ForMember(dest => dest.RepaymentModality, opt => opt.MapFrom(src => src.RepaymentModality.ToDisplayRepaymentModality()));
        }
    }
}
