using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class In
    {
        Id_List id_list;

        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 10,"expecting 'read'");
            tokenizer.skipToken();
            id_list = new Id_List();
            id_list.parse(tokenizer, false);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 12, "expecting ';' after read operation");
            tokenizer.skipToken();
        }

        public void print()
        {
            System.Console.Out.Write("read ");
            id_list.print();
            System.Console.Out.WriteLine();
        }

        public void execute(Tokenizer data)
        {
            id_list.read(data);
        }
    }
}