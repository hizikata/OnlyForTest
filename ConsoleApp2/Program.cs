using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo obj = Console.ReadKey();
            
            ConsoleKey key = obj.Key;
            char keychar = obj.KeyChar;
            Console.WriteLine(key);
            Console.WriteLine(keychar);
            Console.ReadLine();
        }
    }
    public class Test
    {
        public Test()
        {

        }
        public int Add(int x ,int y)
        {
            return x + y;
        }
    }
}
