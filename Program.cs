using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System___Virtual_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            var pages = new int[1000];
            Random random = new Random();
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i] = random.Next(1, 6);
            }
            //var pages = new int [12] {1,2,3,4,1,2,5,1,2,3,4,5};
            FIFO fifo = new FIFO(pages, 4);
            OPT opt = new OPT(pages, 4);
            ALRU alru = new ALRU(pages, 4);
            LRU lru = new LRU(pages, 4);
            RAND rand = new RAND(pages, 4);
            Console.WriteLine("Liczba brakow strony w algorytmie FIFO wynosi {0}",fifo.Simulate());
            Console.WriteLine("Liczba brakow strony w algorytmie Optymalnym wynosi {0}",opt.Simulate());
            Console.WriteLine("Liczba brakow strony w algorytmie Aproksymalnym LRU wynosi {0}",alru.Simulate());
            Console.WriteLine("Liczba brakow strony w algorytmie LRU wynosi {0}",lru.Simulate());
            Console.WriteLine("Liczba brakow strony w algorytmie RAND wynosi {0}", rand.Simulate());
            Console.ReadLine();
        }
    }
}
