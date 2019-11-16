using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace xdelta3.net.Tests
{
    [TestFixture]
    public class Xdelta3LibTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void TestDecodeEncodeRandom(int size)
        {
            var source = CreateRandomArray(size);
            var target = CreateRandomArray(size);

            var delta = Xdelta3Lib.Encode(source: source, target: target);
            delta.Should().NotBeNull();
            delta.Length.Should().BePositive();

            var decoded = Xdelta3Lib.Decode(source: source, delta: delta);
            decoded.Should().NotBeNull();

            decoded.ToArray().Should().BeEquivalentTo(target);
        }

        private static byte[] CreateRandomArray(int size)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var result = new byte[size];
            random.NextBytes(result);
            return result;
        }
    }
}
