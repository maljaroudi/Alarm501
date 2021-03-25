using System;
using Alarm501;
namespace Alarm501_Console
{
    class Program
    {
        Handler handlerDel;
        public void SetController(Handler c)
        {
            handlerDel = c;
        }

        static void Main(string[] args)
        {


            Console.WriteLine("Hello World!");
        }
    }
}
