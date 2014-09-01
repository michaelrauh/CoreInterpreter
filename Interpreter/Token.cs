using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Token
    {
        public int Val { get; set; }
        public string Name { get; set; }
        public int code { get; set; }
        List<string> reserved = new List<string> { "program","begin","end","int","if","then","else","while","loop","read","write",
                            ";",",","=","!","[","]","&&","||","(",")","+","-","*","!=","==","<",">","<=",">="};

        private bool isLegal(string literal)
        {
            bool legal = true;
            int maxLetterIndex = 0;
            int minNumberIndex = 0;
            for (int i = 0; i < literal.Length; i++)
            {
                if (char.IsLetter(literal[i]))
                {
                    if (!char.IsUpper(literal[i]))
                    {
                        legal = false;
                    }
                    else
                    {
                        maxLetterIndex = i;
                    }
                }
                else if (char.IsDigit(literal[i]))
                {
                    if (minNumberIndex == 0)
                    {
                        minNumberIndex = i;
                    }
                }
                else // it is not a letter or digit
                {
                    legal = false;
                }
            }
            if (literal.Any(char.IsDigit) && maxLetterIndex > minNumberIndex) // If it has digits, they need to be on the right
            {
                legal = false;
            }
            return legal;
        }
        public Token(string literal)
        {
            int value;
            bool isNum = Int32.TryParse(literal, out value);

            if (isNum)
            {
                Val = value;
                code = 31;
            }
            else if (reserved.Contains(literal)) // This is too liberal and is calling identifiers numbers
            {
                code = reserved.IndexOf(literal) + 1; // returns the position in the list which is the id (starting at 1)
            }
            else // Assume that it is an Identifier, but if it is not legal, put code 34
            {
                if (isLegal(literal))
                {
                    Name = literal;
                    code = 32;
                }
                else
                {
                    code = 34;
                }
            }
        }
    }
}