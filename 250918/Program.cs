using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250918
{
    class Program
    {
        static void Main(string[] args)
        {
            LaboratoryList laboratories = new LaboratoryList();
            laboratories.AddDefaults();
            Console.WriteLine(laboratories);
            Console.WriteLine();
            Console.WriteLine("1: Максимальное число компьютеров в лаборатории --  {0}", laboratories.MaxComputers);
            Console.WriteLine();
            Console.ReadKey();

            Console.Write("2: Компьютер с максималльным числом процессоров:\n   ");
            Console.WriteLine(laboratories.MaxProc.ToString());
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("3: Принтеры в порядке возрастания года выпуска:");
            foreach (Printer pr in laboratories.PrintersByYear) Console.WriteLine("    " + pr.ToString());
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("4: Принтеры, сгруппированные по фирме-изготовителю:");
            foreach (var group in laboratories.GroupByProducer) {
                Console.WriteLine("Producer of printers: " + group.Key);
                foreach (var pr in group) Console.WriteLine("    " + pr.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("5: Одинаковые компьютеры, установленные в разных лабораториях:");
            foreach (Computer comp in laboratories.AllRepeatingComputers) {
                Console.WriteLine("    " + comp.ToString());
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
