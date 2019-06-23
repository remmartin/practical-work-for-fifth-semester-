using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace _250918
{
    class Laboratory : IEnumerable<Equipment>
    {
        string lab_name;
        DateTime date;
        public List<Equipment> eq_list;

        public string LabName
        {
            get { return lab_name; }
            set { lab_name = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Laboratory(string lab_name, DateTime date)
        {
            this.date = date;
            this.lab_name = lab_name;
            this.eq_list = new List<Equipment>();
        }

        public void AddEquipment(params Equipment[] equipments) {
            foreach (Equipment eq in equipments)
            {
                if (!eq_list.Contains(eq)) eq_list.Add(eq);
            }
        }

        public void RemoveEquipmentAt(int index) {
            if ((index >= 0) && (index < eq_list.Count))
            {
                eq_list.RemoveAt(index);
            }
        }

        override public string ToString()
        {
            string res = "";
            foreach (Equipment eq in eq_list) res += "  " + eq.ToString() + "\n"; 
            return (lab_name + " " + date + " \n" + res);
        }


        public string ShortString() {
            return (lab_name + " " + date);
        }

        public int ComputersInLab() { 
            int i = 0;
            foreach (Equipment eq in this.eq_list){
                if (eq is Computer) i++;
            }
            return i;
        }


        IEnumerator<Equipment> IEnumerable<Equipment>.GetEnumerator()
        {
            return eq_list.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> CompIter()
        {
            foreach (Equipment i in eq_list) {
                if (i is Computer && ((Computer)i).processors > 1) {
                    yield return i;
                }
            }
        }

    }
}
