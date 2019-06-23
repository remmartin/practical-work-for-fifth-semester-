using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250918
{
    enum PrinterType { Laser, Ink };
    class Printer : Equipment
    {
        bool color;
        PrinterType type;
        public Printer(string prod_name, int year, string serial_num, bool color, PrinterType type) : base(prod_name, year, serial_num){
            this.color = color;
            this.type = type;
        }

        public override string ToString()
        {
            return base.ToString() + "\n         color: " + color.ToString() + "\n         type: " + type.ToString();
        }
    }
}
