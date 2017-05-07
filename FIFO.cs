using System;

namespace Operating_System___Virtual_Memory
{
    class FIFO : Alghorithm
    {
        public FIFO(int sizeOfVirtualMemory, int sizeOfPhysicalMemory, int generatingRange) : base(sizeOfVirtualMemory, sizeOfPhysicalMemory, generatingRange)
        {
        }
        public FIFO(int[] pages, int frameSize) : base(pages, frameSize)
        {

        }
        public int Simulate()
        {
            int frameNumber = 0;
            for(int i = 0; i < Page.Length; i++)
            {
                bool callAbsent = IsCallAbsent(Page[i]);
                if (callAbsent)
                {
                    if (frameNumber >= Frame.Length) frameNumber = 0;
                    CallAssignment(frameNumber, Page[i]);
                    frameNumber++;
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
