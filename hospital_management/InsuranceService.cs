 namespace IHCMS
{
class InsuranceService
    {
        public static double ApplyCoverage(double billAmount, int coveragePercent)
        {
            double discount = billAmount * coveragePercent / 100;
            return billAmount - discount;
        }
    }
}