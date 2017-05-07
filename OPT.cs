using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System___Virtual_Memory
{
    class OPT : Alghorithm
    {
        private int[] frameIndexes;
        public OPT(int sizeOfVirtualMemory, int sizeOfPhysicalMemory, int generatingRange) : base(sizeOfVirtualMemory, sizeOfPhysicalMemory, generatingRange)
        {
        }
        public OPT(int[] pages, int frameSize) : base(pages, frameSize)
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
                    if (IsThereFreeFrame())
                    {
                        CallAsignment(frameNumber, Page[i]);
                        frameNumber++;
                        if (frameNumber >= Frame.Length) frameNumber = 0;
                        continue;
                    }
                    CallAssignment(frameNumber, Page[i], i);
                }
            }
            return NumberOfPageChanges;
        }

        private bool IsThereFreeFrame()
        {
            if (Frame[Frame.Length - 1] == 0) return true;
            for (int i = 0; i < Frame.Length - 1; i++)
                if (Frame[i] == 0) return true;
            return false;
        }

        private void CallAsignment(int frameNumber, int pageCall)
        {
            Frame[frameNumber] = pageCall;
            NumberOfPageChanges++;
        }

        private void CallAssignment(int frameNumber, int pageCall, int index)
        {
            int frameIndex = SearchOptimalFrame(index);
            if (frameIndex != -1) Frame[frameIndex] = pageCall;
            else Frame[frameNumber] = pageCall;
            NumberOfPageChanges++;
        }

        private int SearchOptimalFrame(int pageIndex)
        {
            frameIndexes = new int[Frame.Length];
            Array.Copy(Frame, frameIndexes, Frame.Length);
            for(int i = pageIndex; i < Page.Length; i++)
                for(int j = 0; j < frameIndexes.Length && frameIndexes.Length > 1; j++)
                {
                    if (Page[i] == frameIndexes[j])
                    {
                        ChangeArrayLenght(j);
                        continue;
                    } 
                }
            return IndexOf(Frame, frameIndexes[0]);   
        }

        private int IndexOf(int[] array, int value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == value) return i;
            }
            return -1;
        }

        private void ChangeArrayLenght(int j)
        {
            int size = frameIndexes.Length - 1;
            if(j == size)
            {
                var temp = new int[size];
                Array.Copy(frameIndexes, temp, size);
                frameIndexes = temp;
            }
            else
            {
                var temp = new int[size];
                Array.Copy(frameIndexes, temp, j);
                Array.Copy(frameIndexes, j + 1, temp, j, size - j);
                frameIndexes = temp;
            }
        }
    }
}
