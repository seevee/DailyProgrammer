using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _124_New_Line_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments!");
                return;
            }

            string path = args[0];
            string inputEncoding = args[1];
            string text;

            try
            {
                text = System.IO.File.ReadAllText(path, Encoding.ASCII);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return;
            }

            switch (inputEncoding)
            {
                case "Windows":
                    Console.WriteLine(text.Replace("\n", "\r\n"));
                    break;

                case "Unix":
                    Console.WriteLine(text.Replace("\r\n", "\n"));
                    break;

                default:
                    Console.WriteLine("Invalid encoding type: " + inputEncoding);
                    return;
            }
        }
    }
}
