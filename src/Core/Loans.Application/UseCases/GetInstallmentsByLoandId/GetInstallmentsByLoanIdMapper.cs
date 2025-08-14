using AutoMapper;
using Loans.Domain.Entities;

namespace Loans.Application.UseCases.GetInstallmentsByLoandId
{
    public class GetInstallmentsByLoanIdMapper : Profile
    {
        public GetInstallmentsByLoanIdMapper()
        {
            CreateMap<InstallmentDomain, InstallmentItemResponse>();
        }
    }
}
