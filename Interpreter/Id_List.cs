using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Id_List
    {
        Id id;
        Id_List id_list;

        public void parse(Tokenizer tokenizer,bool declaring)
        {
            id = new Id();
            id.parse(tokenizer, declaring);
            if (tokenizer.getToken() == 13) // ,
            {
                tokenizer.skipToken();
                id_list = new Id_List();
                id_list.parse(tokenizer, declaring);
            }
        }
        public void print()
        {
            id.print();
            if (id_list != null)
            {
                System.Console.Out.Write(',');
                id_list.print();
            }
        }

        public void write(Tokenizer data)
        {
            id.print();
            System.Console.Out.Write(" = ");
            System.Console.Out.WriteLine(id.value());

            if (id_list != null)
            {
                id_list.write(data);
            }
        }

        public void read(Tokenizer data)
        {
                System.Diagnostics.Debug.Assert(data.getToken() == 23 || data.getToken() == 31, "input is not a number");

                //Handle Id
                if (data.getToken() == 31)
                {
                    id.assign(data.intVal());
                }
                else
                {
                    data.skipToken();
                    data.getToken();
                    id.assign(data.intVal() * -1);
                }

                // Handle Id_list
                if (id_list != null)
                {
                    id_list.read(data);
                }
        }
    }
}
