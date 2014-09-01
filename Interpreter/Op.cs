using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Op
    {
        Id id;
        int number;
        Exp exp;

        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 32 || tokenizer.getToken() == 31 || tokenizer.getToken() == 20, "expecting id, number, or '(' in op");

            if (tokenizer.getToken() == 32) //id
            {
                id = new Id();
                id.parse(tokenizer,false);
            }
            else if (tokenizer.getToken() == 31) // number
            {
                number = tokenizer.intVal();
                tokenizer.skipToken();
            }
            else // '('
            {
                tokenizer.skipToken();
                exp = new Exp();
                exp.parse(tokenizer);
                System.Diagnostics.Debug.Assert(tokenizer.getToken() == 21, "missing paren in op");
                tokenizer.skipToken();
            }
        }

        public void print()
        {
            if (id != null)
            {
                id.print();
            }
            else if (exp !=null)
            {
                System.Console.Out.Write('(');
                exp.print();
                System.Console.Out.Write(')');
            }
            else
            {
                System.Console.Out.Write(number);
            }
        }

        public int execute()
        {
            if (id != null)
            {
                return id.value();
            }
            
            else if (exp != null)
            {
                return exp.execute();
            }
            else
            {
                return number;
            }
        }
    }
}