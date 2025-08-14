using AutoMapper;
using Loans.Domain.Entities;

namespace Loans.Application.UseCases.GetAllLoans
{
    public class GetAllLoansMapper : Profile
    {
        public GetAllLoansMapper()
        {
            CreateMap<LoanDomain, LoanItemResponse>();            
        }
    }
}
