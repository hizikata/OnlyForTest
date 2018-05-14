using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static event EventHandler TestEvent;
        static void Main(string[] args)
        {
            int? a=null;
            int b = a ?? 10;           
            Console.WriteLine(b);
            OnTestEvent();
            TestEvent?.Invoke(null, null);
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        static void OnTestEvent()
        {
            TestEvent += TestEventMethod;
        }
        static void TestEventMethod(object sender,EventArgs e)
        {
            Console.WriteLine("TestEvent invoke");
        }
    }
    public class Test
    {
        public Test()
        {

        }
        public int Value { get; set; }
    }
}
