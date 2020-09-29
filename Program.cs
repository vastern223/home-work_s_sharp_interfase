using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{

    interface IRemoveableDisk
    {
        bool HasDisk { get; }
        void Insert();
        void Reject();
    }

    interface IDisk
    {
        string Read();
        void Write(string text);
    }

    interface IPrintInformation
    {
        string GetName();
        void Print(string str);
    }


    class Disk : IDisk
    {
        private string memory;
        private int memSize;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        public int MemSize
        {
            get { return memSize; }
            set { memSize = value; }
        }

        public Disk()
        {
            Memory = "null";
            MemSize = 0;
            Name = "no name";
        }
        public Disk(string memory, int memSize, string name)
        {
            Memory = memory;
            MemSize = memSize;
            Name = name;
        }

        public string Read()
        {
            return Memory;
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public override string ToString()
        {
            return $"Memory {Memory}\n" +
                   $"MemSize {MemSize}\n" +
                   $"Name {Name}\n";
        }

    }

    class CD : Disk, IRemoveableDisk
    {
        private bool hasDisk;
        public bool HasDisk => hasDisk;

        public void Insert()
        {
            Console.WriteLine("disk Insert");

        }

        public void Reject()
        {
            Console.WriteLine("disk Reject");
        }

        public override string ToString()
        {
            return $"hasDisk{hasDisk}";
        }

    }

    class Flash : Disk, IRemoveableDisk
    {
        private bool hasDisk;
        public bool HasDisk => hasDisk;

        public void Insert()
        {
            Console.WriteLine("disk Insert");

        }

        public void Reject()
        {
            Console.WriteLine("disk Reject");

        }

        public override string ToString()
        {
            return $"hasDisk{hasDisk}";
        }
    }

    class HDD : Disk
    {

    }

    class DVD : Disk
    {
        private bool hasDisk;
        public bool HasDisk => hasDisk;

        public void Insert()
        {
            Console.WriteLine("disk Insert");
        }

        public void Reject()
        {
            Console.WriteLine("disk Reject");
        }
        public override string ToString()
        {
            return $"hasDisk{hasDisk}";
        }
    }


    class Comp
    {
        private int countDisk;
        private int countPrintDevice;
        private Disk[] disk;
        private IPrintInformation[] printDevice;

        public void AddDevice(int index, IPrintInformation si)
        {
            IPrintInformation[] printDevice2 = new IPrintInformation[printDevice.Length];
            for (int i = 0; i < printDevice.Length; i++)
            {
                printDevice2[i] = printDevice[i];
            }
            printDevice2[printDevice.Length] = si;
            printDevice = printDevice2;
            countPrintDevice++;
        }

        public void AddDisk(int index, Disk d)
        {
            Disk[] disk2 = new Disk[disk.Length];
            for (int i = 0; i < disk.Length; i++)
            {
                disk2[i] = disk[i];
            }
            disk2[disk.Length] = d;
            disk = disk2;
            countDisk++;
        }

        public bool CheckDisk(string device)
        {

            for (int i = 0; i < disk.Length; i++)
            {
                if (disk[i].Name == device)
                {
                    return true;
                }
            }
            return false;
        }

        public Comp(int d, int pb)
        {
            countDisk = d;
            countPrintDevice = pb;
            disk = new Disk[d];
            for (int i = 0; i < d; i++)
            {
                disk[i] = new Disk();
            }

            printDevice = new IPrintInformation[pb];
          
        }

        public void InsertReject(string device, bool b)
        {
            Console.WriteLine("InsertReject");
        }

        public bool PrintInfo(string text, string device)
        {
            Console.WriteLine(text);
            return true;
        }

        public string ReadInfo(string device)
        {
            return device;
        }

        public void ShowDisk()
        {
            for (int i = 0; i < disk.Length; i++)
            {
                Console.WriteLine(disk[i].ToString());
            }
        }

        public void ShowPrintDevice()
        {
            for (int i = 0; i < printDevice.Length; i++)
            {
                printDevice[i].GetName();
            }
        }

        public bool WriteInfo(string text, string showDevice)
        {
            Console.WriteLine(showDevice);
            return true;
        }

        public override string ToString()
        {
            return $"Count of disks: {countDisk}\n" +
                   $"Count of Print Device: {countPrintDevice}\n";
        }
    }



    class Printer : IPrintInformation
    {
        public string GetName()
        {
            return "name Printer ";
        }

        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Monitor : IPrintInformation
    {
        public string GetName()
        {
            return "name monitor ";
        }

        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Comp comp = new Comp(2, 2);
            comp.ShowDisk();


        }
    }
}
