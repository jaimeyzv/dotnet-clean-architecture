using AutoMapper;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Entities;

namespace Loans.Infrastructure.Persistance.Mappers
{
    public sealed class InstallmentEntityMapper : Profile
    {
        public InstallmentEntityMapper()
        {
            //CreateMap<InstallmentEntity, InstallmentDomain>();

            CreateMap<InstallmentEntity, InstallmentDomain>()
                .ConstructUsing(src => new InstallmentDomain 
                {
                    InstallmentId = src.LoanInstallmentId,
                    InstallmentNumber = src.InstallmentNumber,
                    DueDate = src.DueDate,
                    Amount = src.Amount,
                    IsPaid = src.IsPaid,
                    PaymentDate = src.PaymentDate,
                    LoanId = src.LoanInstallmentsLoanId
                });

            CreateMap<InstallmentDomain, InstallmentEntity>();
        }
    }
}
