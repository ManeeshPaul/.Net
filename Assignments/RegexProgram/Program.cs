using System.Text.RegularExpressions;

namespace RegexProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string Pattern = "[0-9]";  //To check given string contains a number
            //string Pattern = "[0-9]{3}";  //To check given string contains a number and it contains atleast 3 digits 
            //string Pattern = "[0-9]{3}$";  //To check given string ending with a number with atleast 3 digit
            //string Pattern = "^[0-9]{3}$";    //To check given string starting and ending with a number with atleast 3 digit
            /*
            Regex reg = new Regex(Pattern);

            string s = "707";
            if(reg.IsMatch(s))
            {
                Console.WriteLine(s+" is a number");
            }
            else
            {
                Console.WriteLine(s+" is not a number");
            }

            */

            ///*******************************


            //string Pattern = "a*b";  //
            string Pattern = "a+b";   //  + is a quantifier that matches one or more occurrences of the preceding element, which in this case is a.
            Regex reg = new Regex(Pattern);
            string str = "dabjsds";
            Match match = reg.Match(str);

            if (match.Success)
            {
                Console.WriteLine("Matching");
            }
            else
            {
                Console.WriteLine("Not matching");
            }


            // string Pattern = "a?b";  //? is a quantifier that matches zero or one occurrence of the preceding element

        }
    }
}