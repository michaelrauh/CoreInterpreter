using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Out
    {
        Id_List id_list;

        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 11, "expecting 'write'");
            tokenizer.skipToken();
            id_list = new Id_List();
            id_list.parse(tokenizer, false);
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 12, "expecting ';' after write operation");
            tokenizer.skipToken();
        }
        public void print()
        {
            System.Console.Out.Write("write ");
            id_list.print();
            System.Console.Out.WriteLine();
        }
        public void execute(Tokenizer data)
        {
            id_list.write(data);
        }
    }
}