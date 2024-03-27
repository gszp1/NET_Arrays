using System;

namespace Arrays
{
    public class AutoResizeArray <T>
    {

        private const int minArraySize = 5;

        private T[] storedData;

        public int AllocatedSize
        {
            get { return storedData.Length; }
        }

        private int usedSize;

        public int UsedSize
        {
            get { return usedSize; }
        }

        public AutoResizeArray(int size = minArraySize)
        {
            if (size< 0)
            {
                throw new Exception("Invalid array size.");
            }
            storedData = new T[size >= minArraySize ? size : minArraySize];
            usedSize = 0;
        }

        public T this[int index] 
        {
            get
            {
                if ((index < 0) || (index >= usedSize))
                {
                    throw new IndexOutOfRangeException("Index out of bounds.");
                }
                return storedData[index]; 
            }
            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index out of bounds.");
                }
                if (index >= usedSize)
                {
                    usedSize = index + 1;
                    if (index >= storedData.Length)
                    {
                        ResizeArray();
                    }
                }
                storedData[index] = value;
            }
        }


        private void ResizeArray()
        {
            int newSize = usedSize * 2;
            if (newSize < storedData.Length)
            {
                return;
            }
            Array.Resize(ref storedData, newSize);
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
                result += $"{i}.| {storedData[i]}\n";
            }
            return result;
        }
    }
}
