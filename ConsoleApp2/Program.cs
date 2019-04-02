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
            try
            {
                Console.WriteLine($"Hello {args[1]}!");
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine(ioore.Message);
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
