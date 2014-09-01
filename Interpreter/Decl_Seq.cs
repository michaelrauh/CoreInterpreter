using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Decl_Seq
    {
        Decl decl;
        Decl_Seq decl_seq;

        public void parse(Tokenizer tokenizer)
        {
            decl = new Decl();
            decl.parse(tokenizer);
            if (tokenizer.getToken() != 2) //check for 'begin' keyword
            {
                decl_seq = new Decl_Seq();
                decl_seq.parse(tokenizer);
            }
        }

        public void print()
        {
            decl.print();
            if (decl_seq != null)
            {
                decl_seq.print();
            }
        }
    }
}
