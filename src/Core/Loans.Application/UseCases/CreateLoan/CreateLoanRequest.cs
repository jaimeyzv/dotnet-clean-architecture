using MediatR;

namespace Loans.Application.UseCases.CreateLoan
{
    public class CreateLoanRequest : IRequest<CreateLoanResponse>
    {
        public decimal Amount { get; set; }
        public string BorrowerName { get; set; }
        public int DurationMonths { get; set; }
    }
}
