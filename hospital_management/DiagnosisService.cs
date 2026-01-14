 namespace IHCMS
{
class DiagnosisService
    {
        public static void Evaluate(
            in int age,
            ref string condition,
            out string riskLevel,
            params int[] testScores)
        {
            int total = 0;
            foreach (int score in testScores)
                total += score;

            static bool IsCritical(int sum) => sum > 250;

            if (IsCritical(total) || age > 60)
            {
                condition = "Serious";
                riskLevel = "High";
            }
            else
            {
                riskLevel = "Moderate";
            }
        }
    }
}