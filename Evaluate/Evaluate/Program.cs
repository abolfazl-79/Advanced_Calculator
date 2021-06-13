using System;

namespace Evaluate
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "-√(Sin(33))+π";
            //string y = "Sin(30)";
            Converting c = new Converting();
            Evaluate ev = new Evaluate();
            Console.WriteLine(c.infixToPrefix(x));
            Console.WriteLine(ev.evaluate(x));


        }
    }
}
