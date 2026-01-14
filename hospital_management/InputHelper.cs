 namespace IHCMS
{
class InputHelper
    {
        public static int ReadAge(string input)
        {
            if (int.TryParse(input, out int age))
                return age;

            throw new Exception("Invalid age input");
        }
    }
}