using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            var adr = new BasicBinaryHeap<int>();

            adr.Builder(5, 6, 1, 7, 0);
            adr.Insert(8);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(adr.Extract());
            }
        }
    }
}
