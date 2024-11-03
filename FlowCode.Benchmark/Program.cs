// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using FlowCode.Benchmarks;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<OperationResultBenchmarks>();
Console.WriteLine(summary);
Console.WriteLine("Goodbye, World!");
Console.ReadLine();