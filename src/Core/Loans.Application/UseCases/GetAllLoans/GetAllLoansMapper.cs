using AutoMapper;
using Loans.Application.Services;
using Loans.Domain.Entities;

namespace Loans.Application.UseCases.GetAllLoans
{
    public class GetAllLoansMapper : Profile
    {
        public GetAllLoansMapper()
        {
            CreateMap<LoanDomain, LoanItemResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToDisplayLoanStatus()))
                .ForMember(dest => dest.RepaymentModality, opt => opt.MapFrom(src => src.RepaymentModality.ToDisplayRepaymentModality()));
        }
    }
}
