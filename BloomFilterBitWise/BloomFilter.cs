using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilterBitWise
{
    public class BloomFilter<T>
    {
        private int capacity;                       //m
        private byte[] bitSet;
        private HashSet<Func<T, int>> hashSet;

        public int hashCount => hashSet.Count;      //k
        public int count { get; set; }              //n

        public BloomFilter(int c)
        {
            capacity = c;
            bitSet = new byte[capacity];
            hashSet = new HashSet<Func<T, int>>();
        }

        public void LoadHashFunc(Func<T, int> hashFunc)
        {
            if (hashFunc != null)
            {
                hashSet.Add(hashFunc);
            }
        }

        public void Insert(T item)
        {
            if (hashCount <= 0)
            {
                LoadHashFunc(HashFuncOne);
                LoadHashFunc(HashFuncTwo);
                LoadHashFunc(HashFuncThree);
            }

            foreach (var func in hashSet)
            {
                int index = Math.Abs(func(item) % capacity) & 7;
                var bit = 1 << (index & 7);
                bitSet[index] = bit;
            }
            count++;
        }

        public bool ProbablyContains(T item)
        {
            if (hashCount <= 0)
            {
                LoadHashFunc(HashFuncOne);
                LoadHashFunc(HashFuncTwo);
                LoadHashFunc(HashFuncThree);
            }

            foreach (var func in hashSet)
            {
                int index = Math.Abs(func(item) % capacity);

                if (!bitSet[index])
                {
                    return false;
                }
            }
            return true;
        }

        public int HashFuncOne(T item)
        {
            return item.GetHashCode();
        }

        public int HashFuncTwo(T item)
        {
            return item.GetHashCode() + "woah".GetHashCode();
        }

        public int HashFuncThree(T item)
        {
            return item.GetHashCode() / 2 + 3;
        }
    }
}
