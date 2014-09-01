using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Trm
    {
        Op op;
        Trm trm;

        public void parse(Tokenizer tokenizer)
        {
            op = new Op();
            op.parse(tokenizer);

            if (tokenizer.getToken() == 24) // *
            {
                tokenizer.skipToken();
                trm = new Trm();
                trm.parse(tokenizer);
            }
        }

        public void print()
        {
            op.print();
            if (trm != null)
            {
                System.Console.Out.Write(" * ");
                trm.print();
            }
        }
        public int execute()
        {
            if (trm == null)
            {
                return op.execute();
            }
            else
            {
                return op.execute() * trm.execute();
            }
        }
    }
}
