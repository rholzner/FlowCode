using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FlowCode.Benchmarks
{
    [MemoryDiagnoser]
    public class OperationResultBenchmarks
    {
        private readonly Exception _exception = new Exception("Test exception");
        private readonly string _data = "Test data";

        [Benchmark]
        public OperationResult<string> CreateSuccessResult()
        {
            return new OperationResult<string>(_data);
        }

        [Benchmark]
        public OperationResult<string> CreateFailureResult()
        {
            return new OperationResult<string>(_exception);
        }

        [Benchmark]
        public bool CheckIsSuccessForSuccessResult()
        {
            var result = new OperationResult<string>(_data);
            return result.IsSuccess;
        }

        [Benchmark]
        public bool CheckIsSuccessForFailureResult()
        {
            var result = new OperationResult<string>(_exception);
            return result.IsSuccess;
        }

        [Benchmark]
        public bool EqualsSuccessResult()
        {
            var result1 = new OperationResult<string>(_data);
            var result2 = new OperationResult<string>(_data);
            return result1.Equals(result2);
        }

        [Benchmark]
        public bool EqualsFailureResult()
        {
            var result1 = new OperationResult<string>(_exception);
            var result2 = new OperationResult<string>(_exception);
            return result1.Equals(result2);
        }

        [Benchmark]
        public int GetHashCodeSuccessResult()
        {
            var result = new OperationResult<string>(_data);
            return result.GetHashCode();
        }

        [Benchmark]
        public int GetHashCodeFailureResult()
        {
            var result = new OperationResult<string>(_exception);
            return result.GetHashCode();
        }

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<OperationResultBenchmarks>();
        }
    }
}
