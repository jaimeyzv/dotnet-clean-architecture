using Loans.Domain.Types;

namespace Loans.Application.Services
{
    public static class InstallmentStatusHelper
    {
        public static string ToDisplayInstallmentStatus(this InstallmentStatus s) => s switch
        {
            InstallmentStatus.Pending => "Pending",
            InstallmentStatus.Paid => "Paid",
            InstallmentStatus.Overdue => "Overdue",
            _ => throw new InvalidOperationException("Invalid InstallmentStatus")
        };

        public static InstallmentStatus GetInstallmentStatusEnum(this string? value) =>
            (value ?? string.Empty).Trim().ToUpperInvariant() switch
            {
                "PENDING" => InstallmentStatus.Pending,
                "PAID" => InstallmentStatus.Paid,
                "OVERDUE" => InstallmentStatus.Overdue,
                _ => throw new InvalidOperationException($"Invalid InstallmentStatus: '{value}'")
            };
    }
}
