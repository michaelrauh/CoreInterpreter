using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Id
    {
        static List <string> declared = new List<string>();
        static Dictionary <string,int> ids = new Dictionary<string,int>();
        string idname;

        public void parse(Tokenizer tokenizer, bool declaring)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 32, "tried to parse non-id as id");

            if (declaring)
            {
                System.Diagnostics.Debug.Assert(!declared.Contains(tokenizer.idName()), "variable declared twice");
                declared.Add(tokenizer.idName());
            }
            else
            {
                System.Diagnostics.Debug.Assert(declared.Contains(tokenizer.idName()), "undeclared variable used");
            }
            idname = tokenizer.idName();
            tokenizer.skipToken();
        }

        public void print()
        {
            System.Console.Out.Write(idname);
        }

        public int value()
        {
            System.Diagnostics.Debug.Assert(ids.ContainsKey(idname), "uninitialized variable detected");
            return ids[idname];
        }

        public void assign(int value)
        {
            if (ids.ContainsKey(idname))
            {
                ids[idname] = value;
            }
            else
            {
                ids.Add(idname, value);
            }
        }
    }
}
