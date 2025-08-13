using AutoMapper;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Entities;

namespace Loans.Infrastructure.Persistance.Mappers
{
    public sealed class LoanEntityMapper : Profile
    {
        public LoanEntityMapper()
        {
            CreateMap<LoanEntity, LoanDomain>();
            CreateMap<LoanDomain, LoanEntity>();
        }
    }
}
