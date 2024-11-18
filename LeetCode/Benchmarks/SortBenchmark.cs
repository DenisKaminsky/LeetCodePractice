using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser(false)]
    public class SortBenchmark
    {
        private const int DATASET_SIZE = 100;
        private Random _random = new Random();

        [Benchmark]
        public Guid[] GuidLinqSort()
        {
            var data = Enumerable.Range(0, DATASET_SIZE).Select(x => Guid.NewGuid());
            return data.Order().ToArray();
        }

        [Benchmark]
        public Guid[] GuidArraySort()
        {
            var data = Enumerable.Range(0, DATASET_SIZE).Select(x => Guid.NewGuid()).ToArray();
            Array.Sort(data);
            return data;
        }

        [Benchmark]
        public int[] IntLinqSort()
        {
            var data = Enumerable.Range(0, DATASET_SIZE).Select(x => _random.Next());
            return data.Order().ToArray();
        }

        [Benchmark]
        public int[] IntArraySort()
        {
            var data = Enumerable.Range(0, DATASET_SIZE).Select(x => _random.Next()).ToArray();
            Array.Sort(data);
            return data;
        }
    }
}
