
using BenchmarkDotNet.Running;
using System;

var summary = BenchmarkRunner.Run(typeof(Program).Assembly);