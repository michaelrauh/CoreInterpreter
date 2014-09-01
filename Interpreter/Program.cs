using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer tokenizer = new Tokenizer(args[0]);
            Tokenizer data = new Tokenizer(args[1]);

            //Flush starting null value to get to first value
            data.skipToken();
            tokenizer.skipToken();

            Prog program = new Prog();
            program.parse(tokenizer);
            program.print();
            program.execute(data);
            System.Console.In.Read();
        }
    }
}