using AutoMapper;
using Loans.Application.Services;
using Loans.Domain.Entities;

namespace Loans.Application.UseCases.GetInstallmentsByLoandId
{
    public class GetInstallmentsByLoanIdMapper : Profile
    {
        public GetInstallmentsByLoanIdMapper()
        {
            CreateMap<InstallmentDomain, InstallmentItemResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToDisplayInstallmentStatus()));
        }
    }
}
