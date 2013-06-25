using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _127_McCarthy_91_Function
{
    class Program
    {
        static int mcCarthy (int value){
            if (value > 100)
            {
                int output = value - 10;
                Console.WriteLine("M({0}) since {1} is greater than 100", output, value);
                return output;
            }
            else
            {
                int output = value + 11;
                Console.WriteLine("M(M({0})) since {1} is equal to or less than 100", output, value);
                return mcCarthy( mcCarthy( output ));
            }
        }
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("M({0})", n);

            int output = mcCarthy(n);         
            Console.Write(output);
            Console.ReadKey();
        }
    }
}
