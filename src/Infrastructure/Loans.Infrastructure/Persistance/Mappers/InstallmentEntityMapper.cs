using AutoMapper;
using Loans.Application.Services;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Entities;

namespace Loans.Infrastructure.Persistance.Mappers
{
    public sealed class InstallmentEntityMapper : Profile
    {
        public InstallmentEntityMapper()
        {
            CreateMap<InstallmentEntity, InstallmentDomain>()
                .ConstructUsing(src => new InstallmentDomain 
                {
                    InstallmentId = src.LoanInstallmentId,
                    InstallmentNumber = src.InstallmentNumber,
                    DueDate = src.DueDate,
                    Amount = src.Amount,
                    Status = src.Status.GetInstallmentStatusEnum(),
                    PaymentDate = src.PaymentDate,
                    LoanId = src.LoanInstallmentsLoanId
                });

            CreateMap<InstallmentDomain, InstallmentEntity>()
                .ForMember(dest => dest.LoanInstallmentId, opt => opt.MapFrom(src => src.InstallmentId))
                .ForMember(dest => dest.LoanInstallmentsLoanId, opt => opt.MapFrom(src => src.LoanId));
        }
    }
}
