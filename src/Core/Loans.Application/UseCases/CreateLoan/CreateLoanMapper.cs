using AutoMapper;
using Loans.Domain.Entities;

namespace Loans.Application.UseCases.CreateLoan
{
    public class CreateLoanMapper : Profile
    {
        public CreateLoanMapper()
        {
            CreateMap<CreateLoanRequest, LoanDomain>()
                .ForMember(dest => dest.Principal, opt => opt.MapFrom(src => src.Amount));
            CreateMap<LoanDomain, CreateLoanResponse>();
        }
    }
}
