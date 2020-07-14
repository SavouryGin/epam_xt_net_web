using System.Text.RegularExpressions;

namespace Task_3_3_2_Super_String
{
    public static class SuperString
    {

        public static string IdentifyLanguage(this string input)
        {
            Regex eng = new Regex(@"^[a-zA-Z]+$");     // The input consists entirely of English characters
            Regex rus = new Regex(@"^[а-яёА-ЯЁ]+$");   // The input consists entirely of Russian characters
            Regex num = new Regex(@"^[0-9]+$");        // The input consists entirely of numbers
            Regex punct = new Regex(@"^[\s\p{P}]+$");  // The input consists entirely of punctuation or spaces

            if (eng.IsMatch(input))
            {
                return "English";
            } 
            else if (rus.IsMatch(input))
            {
                return "Russian";
            } 
            else if (num.IsMatch(input))
            {
                return "Number";
            }
            else if (punct.IsMatch(input))
            {
                return "Punctuation";
            }
            else
            {
                return "Mixed";
            }
        }
    }
}
