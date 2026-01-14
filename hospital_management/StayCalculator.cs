 namespace IHCMS
{
class StayCalculator
    {
        public static int CalculateStayDays(int days)
        {
            if (days <= 0)
                return 0;

            return 1 + CalculateStayDays(days - 1);
        }
    }
}