using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Loop
    {
        Cond cond;
        Stmt_Seq stmt_seq;

        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 8,"expecting 'while'");
            tokenizer.skipToken();
            cond = new Cond();
            cond.parse(tokenizer);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 9, "expecting 'loop'");
            tokenizer.skipToken();
            stmt_seq = new Stmt_Seq();
            stmt_seq.parse(tokenizer);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 3, "expecting 'end' in loop");
            tokenizer.skipToken();
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 12, "expecting ';' after 'end' in loop");
            tokenizer.skipToken();
        }
        public void print()
        {
            System.Console.Out.Write("while ");
            cond.print();
            System.Console.Out.WriteLine();
            System.Console.Out.Write("loop ");
            stmt_seq.print();
            System.Console.Out.Write("end;");
            System.Console.Out.WriteLine();
        }
        public void execute(Tokenizer data)
        {
            while (cond.execute())
            {
                stmt_seq.execute(data);
            }
        }
    }
}
