using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace MayusTool
{
    /// <summary>
    /// Text utilities class
    /// </summary>
    /// <remarks>
    /// JABF    18/09/2018  -   First write
    /// JABF    19/09/2018  -   R8, Changes in random letter cap, forcing the decimal separator to ","
    /// JABF    19/09/2018  -   Removed lowercasing of unaffected words
    /// JABF    20/09/2018  -   New ConvertText logic
    /// JABF    20/09/2018  -   Force caps with special enclosing
    /// JABF    21/09/2018  -   Force caps of words in CSV
    /// JABF    02/10/2018  -   Negative number spelling fixed
    /// </remarks>
    static class Utilities
    {
        public const string ENCLOSING_START = "#uwu[";
        public const string ENCLOSING_END = "]";

        private const string CAPS_FILE = "MayusTool.csv";

        private const string WORD_CASE = "WordCase";
        private const string LETTER_CASE = "LetterCase";
        private const string REVERSE = "Reverse";
        private const string NONE = "None";

        private const int PROB_REVERSE = 14;
        private const int PROB_WORD = 33 + PROB_REVERSE;
        private const int PROB_LETTER = 24 + PROB_WORD;

        /// <summary>
        /// This fucks up the text in "source" parameter
        /// </summary>
        /// <param name="source">Text to fuck up</param>
        /// <param name="output">Fucked up text, out parameter</param>
        /// <param name="wordMayus">We want word caps</param>
        /// <param name="reverse">We want reversed words</param>
        /// <param name="letterMayus">We want random cap letters in words</param>
        /// <param name="numbers">We want numbers to be spelt out</param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    18/09/2018  0.1         First write (not really)
        /// JABF    19/09/2018  0.2         Number spell change, parenthesis now added in other method, \r\n fix
        /// JABF    19/09/2018  0.3         Removed lowercasing of unaffected words
        /// JABF    20/09/2018  0.4         Removed a million else if, now all that is in CheckAction()
        /// JABF    20/09/2018  0.5         Forcing caps with #uwu[]
        /// </remarks>
        public static void ConvertText(string source, out string output, bool wordMayus, bool reverse, bool letterMayus, bool numbers)
        {
            source = source.Replace("\r\n", " \r\n ");  // So we don't fuck up line breaks
            output = string.Empty;
            string[] original = source.Split(' ');
            Random rnd = new Random();
            int modifier = 0;

            foreach (string tmp in original)
            {
                if (tmp != string.Empty)
                {
                    if (tmp == "\r\n")
                    {
                        output += tmp;
                    }
                    else
                    {
                        modifier = rnd.Next(1, 101);

                        switch (CheckAction(modifier, wordMayus, reverse, letterMayus))
                        {
                            case WORD_CASE:
                                output += tmp.ToUpper() + " ";
                                break;
                            case LETTER_CASE:
                                output += RandomCaps(tmp) + " ";
                                break;
                            case REVERSE:
                                output += Reverse(tmp) + " ";
                                break;
                            case NONE:
                                output += tmp + " ";
                                break;
                        }
                        
                        if (numbers && IsNumeric(tmp))
                            output += NumberToLetter(tmp);
                    }
                }
            }

            ForceCaps(output, out output);
            output = ForceCaps(output);
        }

        /*  don't   dead
            open    inside  */
        /// <summary>
        /// Method which checks the action to be applied to the current word
        /// </summary>
        /// <param name="percentage">1 to 100</param>
        /// <param name="wordMayus">We want word caps</param>
        /// <param name="reverse">We want reversed words</param>
        /// <param name="letterMayus">We want random cap letters in words</param>
        /// <returns>Any of the string constants for the modifiers</returns>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    20/09/2018  0.1         First write
        /// </remarks>
        private static string CheckAction(int percentage, bool wordMayus, bool reverse, bool letterMayus)
        {
            if (0 < percentage && percentage <= PROB_REVERSE && reverse)
                return REVERSE;
            if (PROB_REVERSE < percentage && percentage <= PROB_WORD && wordMayus)
                return WORD_CASE;
            if (PROB_WORD < percentage && percentage <= PROB_LETTER && letterMayus)
                return LETTER_CASE;
            return NONE;    // a million return statements, Eliseo would be proud
        }

        /// <summary>
        /// Looks for words enclosed with ENCLOSING_START and ENCLOSING_END and forces them to be upper case
        /// </summary>
        /// <param name="input">Text to fuck up</param>
        /// <param name="output">Fucked up text</param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    20/09/2018  0.1         First write
        /// </remarks>
        private static void ForceCaps(string input, out string output)
        {
            output = input;

            while (input.ToLower().IndexOf(ENCLOSING_START) != -1)      // Fuck regex
            {
                string upperWord = input.ToUpper().Substring(
                    input.ToLower().IndexOf(ENCLOSING_START) + ENCLOSING_START.Length, 
                    input.ToLower().IndexOf(ENCLOSING_END) - (input.ToLower().IndexOf(ENCLOSING_START) + ENCLOSING_START.Length));
                string originalWord = input.Substring(
                    input.ToLower().IndexOf(ENCLOSING_START),
                    input.ToLower().IndexOf(ENCLOSING_END) - input.ToLower().IndexOf(ENCLOSING_START) + ENCLOSING_END.Length);

                input = input.Replace(originalWord, upperWord);
            }

            output = input;
        }

        /// <summary>
        /// Looks for MayusculTool.csv and reads its context. Puts those words in upper case
        /// </summary>
        /// <param name="input">Text to fuck up</param>
        /// <returns>Fucked up text</returns>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    21/09/2018  0.1         First write
        /// </remarks>
        private static string ForceCaps(string input)
        {
            string output = input;

            if (File.Exists(CAPS_FILE))
            {
                string[] words = File.ReadAllText(CAPS_FILE).Split(',');

                foreach (string tmp in words)
                {
                    output = Regex.Replace(output, tmp, tmp.ToUpper(), RegexOptions.IgnoreCase);
                }
            }

            return output;
        }

        /// <summary>
        /// Method which reverses a word
        /// </summary>
        /// <param name="word">Word to reverse</param>
        /// <returns>Reversed word</returns>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    18/09/2018  0.1         First write (not really)
        /// JABF    19/09/2018  0.2         Removed \r\n handling
        /// JABF    21/09/2018  0.3         If word is force caped, just forget it
        /// </remarks>
        private static string Reverse(string word)
        {
            if (!word.Contains(ENCLOSING_START))
            {
                char[] wordChars = word.ToCharArray();
                Array.Reverse(wordChars);
                return new string(wordChars);
            }
            else
            {
                return word;    // Eliseo would be proud
            }
        }

        /// <summary>
        /// Method which puts random caps in a word
        /// </summary>
        /// <param name="word">Word to write like a rEtaRD</param>
        /// <returns>Reversed word</returns>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    18/09/2018  0.1         First write (not really)
        /// JABF    19/09/2018  0.2         More chances of getting cap letters
        /// </remarks>
        private static string RandomCaps(string word)
        {
            char[] wordChars = word.ToCharArray();
            string result = string.Empty;
            Random rnd = new Random();
            int modifier = 0;

            foreach (char tmp in wordChars)
            {
                modifier = rnd.Next(0, 10);

                if (modifier % 3 == 0)
                    result += tmp.ToString().ToUpper();
                else
                    result += tmp.ToString().ToLower();
            }

            return result;
        }

        /// <summary>
        /// Method which spells numbers out
        /// </summary>
        /// <param name="num">Number to spell out</param>
        /// <returns>Spelt out number</returns>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    18/09/2018  0.1         First write (not really)
        /// JABF    19/09/2018  0.2         Decimal separator fix, overflow exception, parenthesis added here now
        /// JABF    02/10/2018  0.3         Negative number fix
        /// </remarks>
        private static string NumberToLetter(string num)
        {
            string res, dec = "";
            Int64 integer;
            int decimals;
            double nmbr;
            num = num.Replace(",", ".");

            try
            {
                NumberFormatInfo provider = new NumberFormatInfo(); // Make sure the decimal separator is "."
                provider.CurrencyDecimalSeparator = ".";
                nmbr = Convert.ToDouble(num, provider);

                integer = Convert.ToInt64(Math.Truncate(nmbr));
                decimals = Convert.ToInt32(Math.Round((nmbr - integer) * 100, 2));
                if (decimals > 0)
                {
                    dec = " con " + NumberToText(decimals);
                }
                res = "(";
                if (integer < 0)
                {
                    res += "menos ";
                    integer *= -1;
                }
                res += NumberToText(Convert.ToDouble(integer)) + dec + ") ";
                return res;
            }
            catch
            {
                return "";
            }            
        }

        /// <summary>
        /// Method with all the number spelling logic (is this machine learning??) (works up to 999999999999999)
        /// </summary>
        /// <param name="value">Number</param>
        /// <returns>Spelt number</returns>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    18/09/2018  0.1         First write (not really)
        /// </remarks>
        private static string NumberToText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "cero";
            else if (value == 1) Num2Text = "uno";
            else if (value == 2) Num2Text = "dos";
            else if (value == 3) Num2Text = "tres";
            else if (value == 4) Num2Text = "cuatro";
            else if (value == 5) Num2Text = "cinco";
            else if (value == 6) Num2Text = "seis";
            else if (value == 7) Num2Text = "siete";
            else if (value == 8) Num2Text = "ocho";
            else if (value == 9) Num2Text = "nueve";
            else if (value == 10) Num2Text = "diez";
            else if (value == 11) Num2Text = "once";
            else if (value == 12) Num2Text = "doce";
            else if (value == 13) Num2Text = "trece";
            else if (value == 14) Num2Text = "catorce";
            else if (value == 15) Num2Text = "quince";
            else if (value < 20) Num2Text = "dieci" + NumberToText(value - 10);
            else if (value == 20) Num2Text = "veinte";
            else if (value < 30) Num2Text = "veinti" + NumberToText(value - 20);
            else if (value == 30) Num2Text = "treinta";
            else if (value == 40) Num2Text = "cuarenta";
            else if (value == 50) Num2Text = "cincuenta";
            else if (value == 60) Num2Text = "sesenta";
            else if (value == 70) Num2Text = "setenta";
            else if (value == 80) Num2Text = "ochenta";
            else if (value == 90) Num2Text = "noventa";
            else if (value < 100) Num2Text = NumberToText(Math.Truncate(value / 10) * 10) + " y " + NumberToText(value % 10);
            else if (value == 100) Num2Text = "cien";
            else if (value < 200) Num2Text = "ciento " + NumberToText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = NumberToText(Math.Truncate(value / 100)) + " cientos";
            else if (value == 500) Num2Text = "quinientos";
            else if (value == 700) Num2Text = "setecientos";
            else if (value == 900) Num2Text = "novecientos";
            else if (value < 1000) Num2Text = NumberToText(Math.Truncate(value / 100) * 100) + " " + NumberToText(value % 100);
            else if (value == 1000) Num2Text = "mil";
            else if (value < 2000) Num2Text = "mil " + NumberToText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = NumberToText(Math.Truncate(value / 1000)) + " mil";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + NumberToText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "un millón";
            else if (value < 2000000) Num2Text = "un millón " + NumberToText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = NumberToText(Math.Truncate(value / 1000000)) + " millones";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + NumberToText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "un billón";
            else if (value < 2000000000000) Num2Text = "un billón " + NumberToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = NumberToText(Math.Truncate(value / 1000000000000)) + " billones";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + NumberToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

        /// <summary>
        /// Method which checks if an expression is a number
        /// </summary>
        /// <param name="Expression">To check</param>
        /// <returns>True if number</returns>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    18/09/2018  0.1         First write (not really)
        /// </remarks>
        private static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
    }
}
