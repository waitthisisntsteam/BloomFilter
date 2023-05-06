using BloomFilter;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void LoadHashFuncTest()
        {
            BloomFilter<string> bloomFilter = new BloomFilter<string>(5);

            bloomFilter.LoadHashFunc(bloomFilter.HashFuncOne);

            Assert.True(bloomFilter.hashCount > 0);
        }

        [Fact] 
        public void InsertTest()
        {
            BloomFilter<string> bloomFilter = new BloomFilter<string>(5);

            bloomFilter.Insert("string");

            Assert.True(bloomFilter.count > 0);
        }

        [Fact]
        public void ProbablyContainsTest() 
        {
            BloomFilter<string> bloomFilter = new BloomFilter<string>(5);

            bloomFilter.Insert("string");

            Assert.True(bloomFilter.ProbablyContains("string"));
        }
    }
}