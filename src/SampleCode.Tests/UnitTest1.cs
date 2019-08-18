using System;
using System.Collections.Generic;
using Xunit;

namespace SampleCode.Tests
{
    struct MutableStruct { public int Value; }
    class MutableReference { public int Value; }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Span<MutableStruct> spanOfStructs = new MutableStruct[1];
            spanOfStructs[0].Value = 42;
            Assert.Equal(42, spanOfStructs[0].Value);
            var listOfStructs = new List<MutableStruct> { new MutableStruct() };
            var val = listOfStructs[0];
            val.Value = 123;
            Assert.Equal(123, listOfStructs[0].Value);
        }

        [Fact]
        public void Test2()
        {
            List<MutableReference> mutables = new List<MutableReference> { new MutableReference() };
            var val = mutables[0];
            val.Value = 123;
            Assert.Equal(123, mutables[0].Value);
        }
    }
}
