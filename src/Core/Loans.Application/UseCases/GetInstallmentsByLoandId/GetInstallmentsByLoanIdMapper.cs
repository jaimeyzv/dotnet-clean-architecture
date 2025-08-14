using AutoMapper;
using Loans.Domain.Entities;

namespace Loans.Application.UseCases.GetInstallmentsByLoandId
{
    public class GetInstallmentsByLoanIdMapper : Profile
    {
        public GetInstallmentsByLoanIdMapper()
        {
            CreateMap<InstallmentDomain, InstallmentItemResponse>();

            //CreateMap<List<InstallmentDomain>, GetInstallmentsByLoanIdResponse>()
            //.ForMember(dest => dest.Installments,
            //           opt => opt.MapFrom(src => src));

            //CreateMap<List<InstallmentDomain>, GetInstallmentsByLoanIdResponse>()
            //    .ConvertUsing((src, _, ctx) => new GetInstallmentsByLoanIdResponse
            //    {
            //        Installments = ctx.Mapper.Map<List<InstallmentItemResponse>>(src)
            //    });

            //CreateMap<GetInstallmentsByLoanIdResponse, List<InstallmentDomain>>()
            //.ForMember(dest => dest,
            //           opt => opt.MapFrom(src => src));
        }
    }
}
