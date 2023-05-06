using System;
using System.Security.Authentication;

namespace BloomFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BloomFilter<string> bloomFilter = new BloomFilter<string>(15);

            //bloomFilter.LoadHashFunc(hashFunc1);
            //bloomFilter.LoadHashFunc(hashFunc2);
            //bloomFilter.LoadHashFunc(hashFunc3);

            bloomFilter.Insert("mountain");
            Console.WriteLine(bloomFilter.HashFuncOne("mountain"));
            Console.WriteLine(bloomFilter.HashFuncTwo("mountain"));
            Console.WriteLine(bloomFilter.HashFuncThree("mountain"));
            Console.WriteLine();

            bloomFilter.Insert("flower");
            Console.WriteLine(bloomFilter.HashFuncOne("flower"));
            Console.WriteLine(bloomFilter.HashFuncTwo("flower"));
            Console.WriteLine(bloomFilter.HashFuncThree("flower"));
            Console.WriteLine();

            bloomFilter.Insert("lol");
            Console.WriteLine(bloomFilter.HashFuncOne("lol"));
            Console.WriteLine(bloomFilter.HashFuncTwo("lol"));
            Console.WriteLine(bloomFilter.HashFuncThree("lol"));
            Console.WriteLine();

            ;
        }
    }
}