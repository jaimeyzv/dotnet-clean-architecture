using Loans.Domain.Types;

namespace Loans.Application.Services
{
    public static class RepaymentModalityHelper
    {
        public static string ToDisplayRepaymentModality(this RepaymentModality r) => r switch
        {
            RepaymentModality.Weekly => "Weekly",
            RepaymentModality.Every15Days => "Every15Days",
            RepaymentModality.Monthly => "Monthly",
            _ => throw new InvalidOperationException("Invalid RepaymentModality")
        };

        public static RepaymentModality GetRepaymentModalityEnum(this string? value) =>
            (value ?? string.Empty).Trim().ToUpperInvariant() switch
            {
                "WEEKLY" => RepaymentModality.Weekly,
                "EVERY15DAYS" => RepaymentModality.Every15Days,
                "MONTHLY" => RepaymentModality.Monthly,
                _ => throw new InvalidOperationException($"Invalid RepaymentModality: '{value}'")
            };
    }
}
