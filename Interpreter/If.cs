using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class If
    {
        Cond cond;
        Stmt_Seq stmt_seq1;
        Stmt_Seq stmt_seq2;

        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 5, "expecting 'if' keyword");
            tokenizer.skipToken();
            cond = new Cond();
            cond.parse(tokenizer);

            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 6, "expecting 'then' keyword");
            tokenizer.skipToken();
            stmt_seq1 = new Stmt_Seq();
            stmt_seq1.parse(tokenizer);

            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 3 || tokenizer.getToken() == 7, "expecting 'end' or 'else' after 'if'");

            if (tokenizer.getToken() == 7)
            {
                tokenizer.skipToken();
                stmt_seq2 = new Stmt_Seq();
                stmt_seq2.parse(tokenizer);
            }

            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 3, "expecting 'end' after 'if'");
            tokenizer.skipToken();
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 12, "expecting ';' after 'if'");
            tokenizer.skipToken();
        }

        public void print()
        {
            System.Console.Out.Write("if ");
            cond.print();
            System.Console.Out.Write("then ");
            stmt_seq1.print();
            if (stmt_seq2 != null)
            {
                System.Console.Out.Write("else ");
                stmt_seq2.print(); 
            }
            System.Console.Out.Write("end;");
            System.Console.Out.WriteLine();
        }

        public void execute(Tokenizer data)
        {
            if (stmt_seq2 == null) // simple if
            {
                if (cond.execute())
                {
                    stmt_seq1.execute(data);
                }
            }
            else //if-else
            {
                if (cond.execute())
                {
                    stmt_seq1.execute(data);
                }
                else
                {
                    stmt_seq2.execute(data);
                }
            }
        }
    }
}
