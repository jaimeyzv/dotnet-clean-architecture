using Loans.Domain.Types;

namespace Loans.Application.Services
{
    public static class LoanStatusHelper
    {
        public static string ToDisplayLoanStatus(this LoanStatus s) => s switch
        {
            LoanStatus.Active => "Active",
            LoanStatus.PaidOff => "PaidOff",
            LoanStatus.Delinquent => "Delinquent",
            _ => throw new InvalidOperationException("Invalid InstallmentStatus")
        };

        public static LoanStatus GetLoanStatusEnum(this string? value) =>
            (value ?? string.Empty).Trim().ToUpperInvariant() switch
            {
                "ACTIVE" => LoanStatus.Active,
                "PAIDOFF" => LoanStatus.PaidOff,
                "DELINQUENT" => LoanStatus.Delinquent,
                _ => throw new InvalidOperationException($"Invalid LoanStatus: '{value}'")
            };
    }
}
