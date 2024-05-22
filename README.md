# BenchmarkDotNet

This repository contains benchmarks for various methods of extracting the year from a `DateTime` string in .NET. The benchmarks are implemented using BenchmarkDotNet and target both .NET 6.0 and .NET 8.0 to compare performance across different runtime versions.

## Benchmark Methods

The following methods are benchmarked to extract the year from a `DateTime` string:

- **GetYearFromDate()**: Parses the entire `DateTime` string using `DateTime.Parse` and returns the year.
- **GetYearFromSplit()**: Splits the `DateTime` string by the '-' character and parses the year.
- **GetYearFromSubStr()**: Uses `Substring` to extract the year part from the `DateTime` string and parses it.
- **GetYearFromSpan()**: Utilizes `ReadOnlySpan<char>` to slice the `DateTime` string and manually converts the year part to an integer.
- **GetYearFromSpanWithManualConversion()**: Uses `ReadOnlySpan<char>` to slice the `DateTime` string and converts the year part using `int.Parse`.

## Project Setup

Ensure you have .NET 6.0 and .NET 8.0 SDKs installed. You can check installed SDKs using:

```bash
dotnet --list-sdks
```
Clone the repository:
```bash-
git clone https://github.com/omertayhan/BenchmarkDotNet.git
cd BenchmarkDotNet
```
Restore the dependencies:
```bash
dotnet restore
```
Run the benchmarks:
```bash
dotnet run -c Release
```
Sample Output
BenchmarkDotNet will output the benchmark results, comparing the performance of each method across .NET 6.0 and .NET 8.0. The results will include metrics such as mean execution time, memory usage, and more.

![1](https://github.com/omertayhan/BenchmarkDotNet/assets/62504339/879ee444-b876-47d8-b62d-9ba281f2dbd3)
