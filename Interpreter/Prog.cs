using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Prog
    {
        Stmt_Seq stmt_seq;
        Decl_Seq decl_seq;

        public void parse(Tokenizer tokenizer)
        {
            //Check for "program"
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 1, "Program does not begin with keyword 'program'");
            tokenizer.skipToken();

            // Construct declaration sequence and check for "begin"
            decl_seq = new Decl_Seq();
            decl_seq.parse(tokenizer);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 2, "Program does not contain 'begin'");
            tokenizer.skipToken();
            

            //Construct statement sequence and check for "end"
            stmt_seq = new Stmt_Seq();
            stmt_seq.parse(tokenizer);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 3, "Program does not end with 'end'");
            tokenizer.skipToken();
            
        }
        public void print()
        {
            System.Console.Out.WriteLine("program ");
            decl_seq.print();
            System.Console.Out.WriteLine("begin ");
            stmt_seq.print();
            System.Console.Out.Write("end");
            System.Console.Out.WriteLine();
        }

        public void execute(Tokenizer data)
        {
            stmt_seq.execute(data);
        }
    }
}
