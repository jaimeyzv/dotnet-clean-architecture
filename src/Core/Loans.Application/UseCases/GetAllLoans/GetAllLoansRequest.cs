using MediatR;

namespace Loans.Application.UseCases.GetAllLoans
{
    public sealed record GetAllLoansRequest() : IRequest<GetAllLoansResponse>;
}
