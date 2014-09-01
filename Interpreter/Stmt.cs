using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Stmt
    {
        Assign assign;
        If ifexp;
        Loop loop;
        In inexp;
        Out outexp;

        public void parse(Tokenizer tokenizer)
        {
            int type = tokenizer.getToken();

            if (type == 32) // Assign
            {
                assign = new Assign();
                assign.parse(tokenizer);
            }
            else if (type == 5) // if
            {
                ifexp = new If();
                ifexp.parse(tokenizer);
            }
            else if (type == 8) //loop
            {
                loop = new Loop();
                loop.parse(tokenizer);
            }
            else if (type == 10) //read
            {
                inexp = new In();
                inexp.parse(tokenizer);
            }
            else if (type == 11) //write
            {
                outexp = new Out();
                outexp.parse(tokenizer);
            }
            else
            {
                System.Diagnostics.Debug.Fail("Statement Does not have correct type");
            }
        }

        public void print()
        {
            if (assign != null)
            {
                assign.print();
            }
            else if (ifexp != null)
            {
                ifexp.print();
            }
            else if (loop != null)
            {
                loop.print();
            }
            else if (inexp != null)
            {
                inexp.print();
            }
            else // outexp
            {
                outexp.print();
            }
        }
        public void execute(Tokenizer data)
        {
            if (assign != null)
            {
                assign.execute();
            }
            else if (ifexp != null)
            {
                ifexp.execute(data);
            }
            else if (loop != null)
            {
                loop.execute(data);
            }
            else if (inexp != null)
            {
                inexp.execute(data);
            }
            else // outexp
            {
                outexp.execute(data);
            }
        }
    }
}
