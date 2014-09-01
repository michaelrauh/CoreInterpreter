using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Cond
    {
        Cond cond1;
        Cond cond2;
        Comp comp;
        int code;

        public Cond()
        {
            code = -1;
        }

        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 20 || tokenizer.getToken() == 16, "'(', '[', or '!' expected in cond");

            if (tokenizer.getToken() == 20) //comp
            {
                comp = new Comp();
                comp.parse(tokenizer);
                code = 0;
            }
            else
            {
                if (tokenizer.getToken() == 15) // !
                {
                    tokenizer.skipToken();
                    code = 1;
                    cond1 = new Cond();
                    cond1.parse(tokenizer);
                }
                else // [
                {
                    tokenizer.skipToken();
                    cond1.parse(tokenizer);
                    System.Diagnostics.Debug.Assert(tokenizer.getToken() == 18 || tokenizer.getToken() == 19, "expected '&& or '||' in cond");
                    if (tokenizer.getToken() == 18) // &&
                    {
                        code = 2;
                    }
                    else // ||
                    {
                        code = 3;
                    }
                    tokenizer.skipToken();
                    cond2 = new Cond();
                    cond2.parse(tokenizer);
                    System.Diagnostics.Debug.Assert(tokenizer.getToken() == 17, "expecting ']' in cond");
                    tokenizer.skipToken();
                }
            }
        }

        public void print()
        {
            if (code == 0) // comp
            {
                comp.print();
            }
            else if (code == 1)
            {
                System.Console.Out.Write('!');
                cond1.print();
            }
            else if (code == 2)
            {
                System.Console.Out.Write('[');
                cond1.print();
                System.Console.Out.Write("&&");
                cond2.print();
                System.Console.Out.Write(']');
            }
            else //19 // ||
            {
                System.Console.Out.Write('[');
                cond1.print();
                System.Console.Out.Write("||");
                cond2.print();
                System.Console.Out.Write(']');
            }
        }
        public bool execute()
        {
            if (code == 0)
            {
                return comp.execute();
            }
            else if (code == 1)
            {
                return !cond1.execute();
            }
            else if (code == 2)
            {
                return cond1.execute() && cond2.execute();
            }
            else
            {
                return cond1.execute() || cond2.execute();
            } 
        }
    }
}
