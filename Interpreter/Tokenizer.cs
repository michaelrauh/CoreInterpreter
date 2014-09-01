using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Tokenizer
    {
        Token current { get; set; }
        Queue<Token> tokens { get; set; }

        public Tokenizer(string filename)
        {
            //string path = System.IO.Directory.GetCurrentDirectory() + "/" + filename;
            string path = filename;
            tokens = new Queue<Token>();

            using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
            {
                List<char> oneSpecial = new List<char> { ';', ',', '[', ']', '(', ')', '+', '-', '*' };
                List<char> twoSpecial = new List<char> { '=', '&', '|', '!', '<', '>' };
                char c;
                string word = "";
                while (sr.Peek() >= 0)
                {
                    c = (char)sr.Read();
                    while (word.Length > 0 && char.IsWhiteSpace(word[0]))
                    {
                        word = word.Substring(1);
                    }
                    if (char.IsWhiteSpace(c) && word.Length > 0)
                    {
                        tokens.Enqueue(new Token(word));
                        word = "";
                    }
                    else if (oneSpecial.Contains(c) || twoSpecial.Contains(c)) // Special characters
                    {
                        if (word.Length > 0)
                        {
                            tokens.Enqueue(new Token(word));
                            word = "";
                        }
                        if (oneSpecial.Contains(c)) // length one special
                        {
                            tokens.Enqueue(new Token(c.ToString()));
                            word = "";
                        }
                        else // possible length two special
                        {
                            if (c == '&')
                            {
                                c = (char)sr.Read();
                                if (c == '&')
                                {
                                    tokens.Enqueue(new Token("&&"));
                                    word = "";
                                }
                                else //invalid
                                {
                                    tokens.Enqueue(new Token("invalid")); //"invalid" is lowercase and therefore invalid
                                    word = "";
                                }
                            }
                            else if (c == '|')
                            {
                                c = (char)sr.Read();
                                if (c == '|')
                                {
                                    tokens.Enqueue(new Token("||"));
                                    word = "";
                                }
                                else //invalid
                                {
                                    tokens.Enqueue(new Token("invalid"));
                                    word = "";
                                }
                            }
                            else if (c == '!')
                            {
                                c = (char)sr.Read();
                                if (c == '=')
                                {
                                    tokens.Enqueue(new Token("!="));
                                    word = "";
                                }
                                else //invalid
                                {
                                    tokens.Enqueue(new Token("invalid"));
                                    word = "";
                                }
                            }
                            else if (c == '=' || c == '<' || c == '>')
                            {
                                word = c.ToString();
                                c = (char)sr.Read();
                                if (c == '=') // two special
                                {
                                    tokens.Enqueue(new Token(word + c));
                                    word = "";
                                }
                                else // one special
                                {
                                    tokens.Enqueue(new Token(word));
                                    word = c.ToString();
                                }
                            }
                        }
                    }
                    else if (!char.IsWhiteSpace(c)) // c is not special so build until whitespace or special. Possible bad characters handled by token
                    {
                        word = word + c;
                    }
                }
                if (word.Length > 0) // handles last token
                {
                    tokens.Enqueue(new Token(word));
                }
                // Add end token to the end
                var end = new Token("EOF");
                end.code = 33;
                tokens.Enqueue(end);
            }
        }
        public int getToken()
        {
            return this.current.code;
        }
        public void skipToken()
        {
            this.current = this.tokens.Dequeue();
        }
        public int intVal()
        {
            return this.current.Val;
        }
        public string idName()
        {
            return this.current.Name;
        }
    }
}