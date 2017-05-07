using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System___Virtual_Memory
{
    class ALRU : Alghorithm
    {
        private int[] frameCallBit;
        private int frameNumber;
        public ALRU(int[] pages, int frameSize) : base(pages, frameSize)
        {
            frameCallBit = new int[frameSize];
            for (int i = 0; i < frameSize; i++)
                frameCallBit[i] = 0;
        }
        public int Simulate()
        {
            frameNumber = 0;
            for (int i = 0; i < Page.Length; i++)
            {
                bool callAbsent = IsCallAbsent(Page[i]);
                if (callAbsent)
                {
                    CallAssignment(Page[i]);
                    CheckFrameNumber();
                    CheckCallBits(i);
                }
            }
            return NumberOfPageChanges;
        }

        private void CheckCallBits(int index)
        {
            if((index+1)%Frame.Length == 0)
            {
                for (int k = 0; k < frameCallBit.Length; k++)
                    frameCallBit[k] = 0;
            }
        }

        private void CheckFrameNumber()
        {
            if (frameNumber >= Frame.Length) frameNumber = 0;
        }

        protected override bool IsCallAbsent(int pageCall)
        {
            for (int i = 0; i < Frame.Length; i++)
                if (Frame[i] == pageCall)
                {
                    frameCallBit[i] = 1;
                    return false;
                }
            return true;
        }
        private void CallAssignment(int pageCall)
        {
            frameNumber = FindFrameNumber();
            Frame[frameNumber] = pageCall;
            frameCallBit[frameNumber++] = 1;
            NumberOfPageChanges++;
        }

        private int FindFrameNumber()
        {
            for(int i = frameNumber; i < frameCallBit.Length; i++)
            {
                if(frameCallBit[i] == 0)
                    return i;
                if(frameCallBit[i] == 1)
                    frameCallBit[i] = 0;
            }
            return 0;
        }
    }
}
