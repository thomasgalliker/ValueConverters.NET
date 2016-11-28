using Xunit;

[assembly: TestFramework("Xunit.Parallel.Sdk.Framework.ParallelTestFramework", "xunit.parallel")]
[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 0)]