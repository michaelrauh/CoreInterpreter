using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Assign
    {
        Exp exp;
        Id id;

        public void parse(Tokenizer tokenizer)
        {
            id = new Id();
            id.parse(tokenizer, false);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 14, "expecting '=' in assignment");
            tokenizer.skipToken();

            exp = new Exp();
            exp.parse(tokenizer);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 12, "expecting ';' after assignment");
            tokenizer.skipToken();
        }
        public void print()
        {
            id.print();
            System.Console.Out.Write('=');
            exp.print();
            System.Console.Out.WriteLine(';');
        }
        public void execute()
        {
            id.assign(exp.execute());
        }
    }
}
