using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Exp
    {

        Trm trm;
        Exp exp;
        bool isPlus;

        public void parse(Tokenizer tokenizer)
        {
            trm = new Trm();
            trm.parse(tokenizer);

            if (tokenizer.getToken() == 22 || tokenizer.getToken() == 23)
            {
                if (tokenizer.getToken() == 22)
                {
                    isPlus = true;
                }
                else
                {
                    isPlus = false;
                }
                tokenizer.skipToken();
                exp = new Exp();
                exp.parse(tokenizer);
            }
        }

        public void print()
        {
            trm.print();
            if (exp != null)
            {
                if (isPlus)
                {
                    System.Console.Out.Write(" + ");
                }
                else
                {
                    System.Console.Out.Write(" - ");
                }
                exp.print();
            }
        }
        public int execute()
        {
            if (exp == null)
            {
                return trm.execute();
            }
            else
            {
                if (isPlus)
                {
                    return trm.execute() + exp.execute();
                }
                else
                {
                    return trm.execute() - exp.execute();
                }
            }
        }
    }
}