using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {   
                Console.WriteLine($"Hello {args[0]}!");
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
                
            }
            catch (Exception)
            {

                
                throw new DemoExecption();
            }
        }
    }

    public class DemoExecption : Exception
    {
        public DemoExecption(string message)
        {

        }

        public DemoExecption()
        {

        }
    }
}
