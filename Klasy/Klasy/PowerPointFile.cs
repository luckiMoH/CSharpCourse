using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    internal class PowerPointFile : IFile
    {
        public string FileName { get; set; }
        public int Size { get; set; }
        public DateTime CreatedOn { get; set; }
        public void Compress()
        {
            Console.WriteLine("Compressing PowerPointFile");
        }
        public void Present()
        {
            Console.WriteLine($"{FileName} presenting..");
        }
    }
}
