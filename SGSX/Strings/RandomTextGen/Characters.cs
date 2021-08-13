using System.Linq;
namespace SGSX.Strings.RandomTextGen
{
    public static class Characters : object
    {
        static Characters()
        { 
        }

        internal const char SpaceChar = ' ';

        internal static readonly char[] endingChars = new char[3] { '.', '?', '!' };

        private static System.Random _rNG;
        private static System.Random RNG
        {
            get
            {
                if (_rNG is null)
                {
                    _rNG = new System.Random();
                }
                return _rNG;
            }
        }


        private static System.Collections.Generic.IList<char> _vowels;
        public static System.Collections.Generic.IList<char> Vowels
        {
            get
            {
                if (_vowels is null)
                {
                    _vowels = new System.Collections.Generic.List<char>()
                    {
                        'a','e','o','u','i',
                    };
                }
                return _vowels;
            }
        }


        private static System.Collections.Generic.IList<char> _words;
        public static System.Collections.Generic.IList<char> Words
        {
            get
            {
                if (_words is null)
                {
                    _words = new System.Collections.Generic.List<char>()
                    {
                        'b','c','d','f','g','h','j','k','l','m','n','p',
                        'q','r','s','t','v','w','x','y','z',
                    };
                }
                return _words;
            }
        }


        private static System.Collections.Generic.IList<char> _extraWords;
        public static System.Collections.Generic.IList<char> ExtraWords
        {
            get
            {
                if (_extraWords is null)
                {
                    _extraWords = new System.Collections.Generic.List<char>()
                    {
                        '0','1','2','3','4','5','6','7','8','9',',','.',':',';','!','?',
                    };
                }
                return _extraWords;
            }
        }


        internal static string GetLetter(char previousChar)
        {
            if (previousChar == '\0')
            {
                char result = GetLetter(System.Convert.ToBoolean(RNG.Next(0, 2)));
                return result.ToString().ToUpper();
            }
            if (Vowels.Any(current => current.ToString().ToLower() == previousChar.ToString().ToLower()) == false)
            {
                char result = GetLetter(false);
                return result.ToString();
            }
            else
            {
                string result = GetLetter(true).ToString();
                int randomNumber = RNG.Next(0, 100);
                if (randomNumber >= 85)
                {
                    result += result;
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        private static char GetLetter(bool isWord)
        {
            if (isWord == true)
            {
                char result = Words[RNG.Next(0, Words.Count)];
                return result;
            }
            else
            {
                char result = Vowels[RNG.Next(0, Vowels.Count)];
                return result;
            }
        }

        internal static string SpecialCharChance()
        {
            int chance = RNG.Next(0, 100);
            if (chance < 75)
            {
                string result = GetSpecialLetter();
                return result;
            }
            else
            {
                return string.Empty;
            }
        }

        internal static string GetSpecialLetter()
        {
            char newChar = ExtraWords[RNG.Next(0, ExtraWords.Count)];
            string result;
            if (char.IsDigit(newChar))
            {
                result = newChar.ToString();
                result = result.Insert(0, " ");
            }
            else
            {
                result = newChar.ToString();
            }
            return result;
        }

        internal static char GetEndingChar()
        {
            char result = endingChars[RNG.Next(0, 3)];
            return result;
        }

    }
}
