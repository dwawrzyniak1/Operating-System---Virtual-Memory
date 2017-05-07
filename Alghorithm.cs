using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System___Virtual_Memory
{
    class Alghorithm
    {
        public int[] Frame { get; protected set; }
        public int[] Page { get; protected set; }
        public int NumberOfPageChanges { get; protected set; }
        public Alghorithm(int sizeOfVirtualMemory, int sizeOfPhysicalMemory, int generatingRange)
        {
            Frame = new int[sizeOfPhysicalMemory];
            Page = new int[sizeOfVirtualMemory];
            NumberOfPageChanges = 0;
            GenerateCalls(generatingRange);
        }
        public Alghorithm(int[] page, int sizeOfPhysicalMemory)
        {
            Page = page;
            Frame = new int[sizeOfPhysicalMemory];
            NumberOfPageChanges = 0;
        }

        private void GenerateCalls(int generatingRange)
        {
            Random random = new Random();
            for (int i = 0; i < Page.Length; i++)
            {
                Page[i] = random.Next(1, generatingRange);
            }
                
        }
        protected virtual bool IsCallAbsent(int pageCall)
        {
            for (int i = 0; i < Frame.Length; i++)
                if (Frame[i] == pageCall) return false;
            return true;
        }
    }
}
