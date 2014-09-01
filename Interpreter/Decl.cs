using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Decl
    {
        Id_List id_list;

        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 4, "expecting 'int' keyword");
            tokenizer.skipToken();
            id_list = new Id_List();
            id_list.parse(tokenizer, true);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 12, "expecting ';'");
            tokenizer.skipToken();
        }
        public void print()
        {
            System.Console.Out.Write("int ");
            id_list.print();
            System.Console.Out.WriteLine(';');
        }
    }
}
