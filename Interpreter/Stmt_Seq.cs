using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Stmt_Seq
    {
        Stmt stmt;
        Stmt_Seq stmt_seq;

        public void parse(Tokenizer tokenizer)
        {
            stmt = new Stmt();
            stmt.parse(tokenizer);

            if (tokenizer.getToken() != 3)
            {
                stmt_seq = new Stmt_Seq();
                stmt_seq.parse(tokenizer);
            }
        }
        public void execute(Tokenizer data)
        {
            stmt.execute(data);

            if (stmt_seq != null)
            {
                stmt_seq.execute(data);
            }
        }
        public void print()
        {
            stmt.print();

            if (stmt_seq != null)
            {
                stmt_seq.print();
            }
        }
    }
}
