namespace Loans.Domain.Types
{
    public enum RepaymentModality
    {
        Weekly = 1,         // 7 days
        Every15Days = 2,    // 15 days
        Monthly = 3         // 30 or 31 7 days depending on the month
    }
}
