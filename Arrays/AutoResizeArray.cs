using System;

namespace Arrays
{
    public class AutoResizeArray <T>
    {

        private const int minArraySize = 5;

        private int allocatedSize;

        public int AllocatedSize
        {
            get { return allocatedSize; }
        }

        private int usedSize;

        public int UsedSize
        {
            get { return usedSize; }
        }

        private T[] storedData;

        public AutoResizeArray(int allocatedSize = minArraySize)
        {
            if (allocatedSize <= 0)
            {
                throw new Exception("Invalid array size.");
            }
            if (allocatedSize < minArraySize)
            {
                this.allocatedSize = minArraySize;
            } else
            {
                this.allocatedSize = allocatedSize;
            }
            storedData = new T[this.allocatedSize];
            usedSize = 0;
        }

        public T this[int index] 
        {
            get
            {
                if (index < 0 || index >= usedSize)
                {
                    throw new IndexOutOfRangeException("Index out of bounds.");
                }
                return storedData[index]; 
            }
            set
            {
                if (index >= usedSize)
                {
                    usedSize = index + 1;
                    if (index >= allocatedSize)
                    {
                        ResizeArray();
                    }
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index out of bounds.");
                }
                storedData[index] = value;
            }
        }


        private void ResizeArray()
        {
            int newSize = usedSize * 2;
            if (newSize < allocatedSize)
            {
                return;
            }
            Array.Resize(ref storedData, newSize);
            allocatedSize = newSize;
        }

        public void Add(T newDataObject)
        {
            this[usedSize] = newDataObject;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < usedSize; ++i)
            {
                result += i.ToString() + ".| " +  storedData[i] + "\n";
            }
            return result;
        }
    }
}
