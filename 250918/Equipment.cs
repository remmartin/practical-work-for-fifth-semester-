using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250918
{
    class Equipment : IComparable<Equipment> 
    {
        string prod_name;
        int year;
        string serial_num;

        public Equipment(string prod_name, int year, string serial_num) {
            this.prod_name = prod_name;
            this.serial_num = serial_num;
            this.year = year;
        }

        public string Producer
        {
            get { return prod_name; }
            set { prod_name = value; }
        }
        
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        
        public string SerialNum
        {
            get { return serial_num; }
            set { serial_num = value; }
        }

        public override int GetHashCode()
        {
            return prod_name.GetHashCode() + year.GetHashCode() + serial_num.GetHashCode();
        }


        public virtual string ToString() { 
            return("\n         producer: " + prod_name + "\n         serial number: " + serial_num + "\n         year: " + (year.ToString()));
        }

        public override bool Equals(object a){
            if ((Equipment)a == null) return false;
            return ((((Equipment)a).prod_name == this.prod_name) && (((Equipment)a).year == this.year) && (((Equipment)a).serial_num == this.serial_num));
        }

        public static bool operator == (Equipment a, Equipment b){
            return((Object.ReferenceEquals(a, b))||(Object.ReferenceEquals(a, null))||(a.Equals(b)));
        }

        public static bool operator != (Equipment a, Equipment b){
            return !(a==b);
        }


        public int CompareTo(Equipment other)
        {
            return (year.CompareTo(other.year));
        }

        int IComparable<Equipment>.CompareTo(Equipment other)
        {
            throw new NotImplementedException();
        }
    }
}
