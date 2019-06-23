using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _250918
{
    [Serializable]
    class LaboratoryList
    {
        //1
        public int MaxComputers => (from lab in lab_list select lab.Count(eq => eq is Computer)).Max();
        //2
        public Computer MaxProc => (from lab in lab_list
                                    from eq in lab.eq_list
                                    where eq is Computer
                                    orderby ((Computer)eq).processors descending
                                    select ((Computer)eq)).FirstOrDefault();
        //3
        public IEnumerable<Printer> PrintersByYear => (from lab in lab_list
                                                      from eq in lab.eq_list
                                                      where eq is Printer
                                                      orderby ((Printer)eq).Year ascending
                                                      select ((Printer)eq)).Distinct();
        //4
        public IEnumerable<IGrouping<string, Printer>> GroupByProducer => from eq in (from lab in lab_list
                                                                                      from eq in lab.eq_list
                                                                                      where eq is Printer
                                                                                      select eq).Distinct()
                                                                          group (eq as Printer) by eq.Producer;
        //5
        public IEnumerable<Computer> AllRepeatingComputers => from lab in lab_list
                                                              from eq in lab.eq_list
                                                              where eq is Computer
                                                              group ((Computer)eq) by eq.GetHashCode() into repcomp
                                                              where repcomp.Count() > 1
                                                              select repcomp.First();

        LaboratoryList DeepCopy()
        {
            LaboratoryList list_copy = null;
            MemoryStream memoryStream = null;


            using (memoryStream = new MemoryStream())
            {
                try
                {
                    BinaryFormatter binF = new BinaryFormatter();
                    binF.Serialize(memoryStream, this);

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    list_copy = binF.Deserialize(memoryStream) as LaboratoryList;
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }

            return list_copy;
        }

        static bool Save(string filename, LaboratoryList obj) {
            FileStream fileStream = null;
            try
            {
                fileStream = File.Create(filename);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
                if (fileStream != null) fileStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (fileStream != null) fileStream.Close();
                Console.WriteLine("Исключение: " + ex.Message);
                return false;
            }
        }

        static bool Load(string filename, ref LaboratoryList obj) {
            
            FileStream fileStream = null;
            try
            {
                fileStream = File.OpenRead(filename);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                obj = binaryFormatter.Deserialize(fileStream) as LaboratoryList;
                Console.WriteLine(" ===== booksLibrary\n" + obj);
                string error = binaryFormatter.Deserialize(fileStream) as string;
                if (fileStream != null) fileStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (fileStream != null) fileStream.Close();
                Console.WriteLine("Исключение: " + ex.Message);
                return false;
            }

        }

        private List<Laboratory> lab_list;
        public LaboratoryList(List<Laboratory> lab_list = null) {
            if (lab_list == null) {
                lab_list = new List<Laboratory>();
            }
            this.lab_list = lab_list;
        }
        public void AddDefaults()
        {
            Laboratory lab1 = new Laboratory("NAME 1", new DateTime(2000, 1, 3));
            lab1.AddEquipment(new Printer("HP", 2000, "1222", true, PrinterType.Ink), new Computer("Samsung", 2016, "1333", 1, ComputerType.Notebook));
            lab1.AddEquipment(new Computer("Sony", 2008, "42", 7, ComputerType.Desktop), new Computer("HP", 1997, "1444", 10, ComputerType.Workstation));
            lab_list.Add(lab1);

            Laboratory lab2 = new Laboratory("NAME 2", new DateTime(2005, 7, 18));
            lab2.AddEquipment(new Printer("Canon", 2005, "2222", true, PrinterType.Ink), new Printer("HP", 2014, "203452", false, PrinterType.Laser));
            lab_list.Add(lab2);

            Laboratory lab3 = new Laboratory("NAME 3", new DateTime(2015, 11, 5));
            lab3.AddEquipment(new Computer("Sony", 2008, "42", 7 , ComputerType.Desktop));
            lab_list.Add(lab3);

        }

        override public string ToString(){
            string res = "";
            foreach (Laboratory lab in lab_list) res += "  " + lab.ToString() + "\n"; 
            return (res);
        }

        
        
    }
}
