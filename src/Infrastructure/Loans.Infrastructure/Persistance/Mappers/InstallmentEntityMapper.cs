using AutoMapper;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Entities;

namespace Loans.Infrastructure.Persistance.Mappers
{
    public sealed class InstallmentEntityMapper : Profile
    {
        public InstallmentEntityMapper()
        {
            CreateMap<InstallmentEntity, InstallmentDomain>();
            CreateMap<InstallmentDomain, InstallmentEntity>();
        }
    }
}
