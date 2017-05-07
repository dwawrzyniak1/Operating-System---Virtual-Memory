using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System___Virtual_Memory
{
    class RAND : Alghorithm
    {
        public RAND(int[] pages, int frameSize) : base(pages, frameSize)
        {

        }
        public int Simulate()
        {
            int frameNumber = 0;
            Random random = new Random();
            for (int i = 0; i < Page.Length; i++)
            {
                bool callAbsent = IsCallAbsent(Page[i]);
                if (callAbsent)
                {
                    CallAssignment(frameNumber, Page[i]);
                    frameNumber = random.Next(Frame.Length);
                }
            }
            return NumberOfPageChanges;
        }

        private void CallAssignment(int frameNumber, int pageCall)
        {
            Frame[frameNumber] = pageCall;
            NumberOfPageChanges++;
        }
    }
}
