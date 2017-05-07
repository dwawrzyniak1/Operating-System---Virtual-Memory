using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System___Virtual_Memory
{
    class LRU : Alghorithm
    {
        private Queue queue;
        private int frameNumber;
        public LRU(int[] pages, int frameSize) : base(pages, frameSize)
        {
            queue = new Queue();
        }
        public int Simulate()
        {
            frameNumber = 0;
            for (int i = 0; i < Page.Length; i++)
            {
                bool callAbsent = IsCallAbsent(Page[i]);
                if (callAbsent)
                {
                    if (ThereIsFreeFrame())
                    {
                        Frame[frameNumber] = Page[i];
                        queue.Enqueue(Page[i]);
                        NumberOfPageChanges++;
                        continue;
                    }
                    CallAssignment(Page[i]);
                    frameNumber++;
                }
            }
            return NumberOfPageChanges;
        }

        private bool ThereIsFreeFrame()
        {
            for(int i = 0; i < Frame.Length; i++)
                if(Frame[i] == 0)
                {
                    frameNumber = i;
                    return true;
                }
            return false;
        }

        private void CallAssignment(int pageCall)
        {
            frameNumber = IndexOf(queue.Dequeue());
            Frame[frameNumber] = pageCall;
            queue.Enqueue(pageCall);
            NumberOfPageChanges++;
        }

        private int IndexOf(object value)
        {
            for (int i = 0; i < Frame.Length; i++)
                if (Frame[i] == (int)value) return i;
            return 0;
        }
        protected override bool IsCallAbsent(int pageCall)
        {
            for (int i = 0; i < Frame.Length; i++)
                if (Frame[i] == pageCall)
                {
                    if (queue.Contains(pageCall)) ModifyQueue(pageCall);
                    return false;
                }
            return true;
        }

        private void ModifyQueue(int pageCall)
        {
            if((int)queue.Peek() == pageCall)
            {
                queue.Enqueue(queue.Dequeue());
                return;
            }
            Queue temp = new Queue();
            foreach(int p in queue)
            {
                if (p != pageCall) temp.Enqueue(p);
            }
            temp.Enqueue(pageCall);
            queue = temp;
        }
    }
}
