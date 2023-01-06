using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        public static bool IsNullEmptyOrWhiteSpace(string input)
        {
            if (input is null || input == string.Empty || input.All(char.IsSeparator)){
                return true;
            }

            else { return false; }

        }

        public static string MixString(string a, string b)
        {
            if (IsNullEmptyOrWhiteSpace(a)|| IsNullEmptyOrWhiteSpace(b))
            { 
                throw new ArgumentException();
            }

            string c;
            int count = a.Length >= b.Length ? b.Length : a.Length;
            bool isASmallest = a.Length <= b.Length ? true : false;

            if (isASmallest) { c = b; } else { c = a; }

            for (int i = 0; i < count; i++)
            {
                if (isASmallest)
                {
                    c = c.Insert(i + i, a[i].ToString());
                }
                else
                {
                    c = c.Insert(i + i + 1, b[i].ToString());
                }
                    
            }

            return c;
        }

        public static string ToLowerCase(string a)
        {
            char[] charArr = a.ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] >= 'A' && charArr[i] <= 'Z')
                {
                    charArr[i] = (char) (charArr[i] - 'A' + 'a');
                }
                                        // É
                else if (charArr[i] == '\u00C9')
                {
                                    // é
                    charArr[i] = '\u00E9';
                }
            }
            return new string(charArr);
        }

        public static string Voyelles(string a)
        {
            string voyelles = "aeiouy";
            string result = "";

            a = ToLowerCase(a);

            foreach (char character in a)
            {
                if (voyelles.Contains(character, StringComparison.OrdinalIgnoreCase) && !result.Contains(character, StringComparison.OrdinalIgnoreCase)) 
                {
                    result = result.Insert(result.Length, character.ToString());
                }
            }
            return result;
        }

        public static string BazardString(string input)
        {
            string result = "";
            string nonAppend = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result = result.Insert(result.Length, input[i].ToString());
                }
                else
                {
                    nonAppend = nonAppend.Insert(nonAppend.Length, input[i].ToString());
                }
            }

            return result + nonAppend;
        }

        public static string Reverse(string a)
        {
            string x = "";
            for (int i = 0; i < a.Length; i++)
            {
                x = x.Insert(0, a[i].ToString());
            }
            return x;
        }

        public static string UnBazardString(string input)
        {
            var first = input.Substring(0, (int)(input.Length / 2));
            var last = input.Substring((int)(input.Length / 2), (int)(input.Length / 2));

            for (int i = 0; i < last.Length; i++)
            {

                first = first.Insert(i + i + 1, last[i].ToString());

            }
            return first;
        }

        public static string ToCesarCode(string input, int offset)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string alphabis = alphabet;

            string first = alphabis.Substring(0, offset);

            alphabis = alphabis.Substring(offset, alphabis.Length - offset);
            alphabis = alphabis += first;

            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    output += ' ';
                    continue;
                }

                for (int y = 0; y < alphabis.Length; y++)
                {
                    if (input[i] == alphabet[y])
                    {
                        output += alphabis[y];
                    }
                }
            }

            return output;

        }
    }
}
