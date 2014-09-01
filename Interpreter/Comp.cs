using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Comp
    {
        Op op1;
        Op op2;
        int compop;

        public Comp()
        {
            compop = 0;  
        }
        public void parse(Tokenizer tokenizer)
        {
            System.Diagnostics.Debug.Assert(tokenizer.getToken() == 20, "'(' expected in comparison");
            tokenizer.skipToken();
            op1 = new Op();
            op1.parse(tokenizer);
            compop = tokenizer.getToken();
            System.Diagnostics.Debug.Assert(compop >= 25 && compop <= 30, "comparison operator expected");
            tokenizer.skipToken();
            op2 = new Op();
            op2.parse(tokenizer);
            System.Diagnostics.Debug.Assert(tokenizer.getToken()==21, "')' expected in comparison");
            tokenizer.skipToken();          
        }
        public void print()
        {
            System.Console.Out.Write('(');
            op1.print();
            switch (compop)
            {
                case 25:
                    System.Console.Out.Write("!=");
                    break;
                case 26:
                    System.Console.Out.Write("==");
                    break;
                case 27:
                    System.Console.Out.Write("<");
                    break;
                case 28:
                    System.Console.Out.Write(">");
                    break;
                case 29:
                    System.Console.Out.Write("<=");
                    break;
                case 30:
                    System.Console.Out.Write(">=");
                    break;
            }
            op2.print();
            System.Console.Out.Write(")");
        }
        public bool execute()
        {
            switch (compop)
            {
                case 25:
                    return op1.execute() != op2.execute();
                case 26:
                    return op1.execute() == op2.execute();
                case 27:
                    return op1.execute() < op2.execute();
                case 28:
                    return op1.execute() > op2.execute();
                case 29:
                    return op1.execute() <= op2.execute();
                case 30:
                    return op1.execute() >= op2.execute();
            }
            System.Diagnostics.Debug.Fail("comparison operator not recognized");
            return false;
        }
    }
}
