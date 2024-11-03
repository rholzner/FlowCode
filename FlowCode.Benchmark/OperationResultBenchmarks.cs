using BenchmarkDotNet.Attributes;

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
        public ValueOperationResult<string> CreateSuccessResultValue()
        {
            return new ValueOperationResult<string>(_data);
        }

        [Benchmark]
        public ValueOperationResult<string> CreateFailureResultValue()
        {
            return new ValueOperationResult<string>(_exception);
        }
    }
}
