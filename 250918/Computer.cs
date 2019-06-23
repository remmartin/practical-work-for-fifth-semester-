using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250918
{
    enum ComputerType {Desktop, Notebook, Workstation};
    class Computer:Equipment, IComparable<Computer>
    {
        public int processors;
        ComputerType type;
        public Computer(string prod_name, int year, string serial_num, int processors, ComputerType type) :base(prod_name, year, serial_num){
            this.processors = processors;
            this.type = type;
        }

        public override string ToString()
        {
            return base.ToString() + "\n         processors: " + processors.ToString() + "\n         type: " + type.ToString();
        }

        public int CompareTo(Computer other)
        {
            return (processors.CompareTo(other.processors));
        }


        int IComparable<Computer>.CompareTo(Computer other)
        {
            throw new NotImplementedException();
        }
    }
}
