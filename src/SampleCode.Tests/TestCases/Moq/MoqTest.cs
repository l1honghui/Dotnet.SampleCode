using System;
using System.Diagnostics.Contracts;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace SampleCode.Tests.TestCases.Moq
{
    public class MoqTest
    {
        private readonly ITestOutputHelper _output;

        public MoqTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void MockTest1()
        {
            var mock = new Mock<IFoo>();
            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);
            var result1 = mock.Object.TryParse("ping", out var outputValue1); 
            // result1 : True, outputValue : ack
            _output.WriteLine($"result1 : {result1}, outputValue : {outputValue1}");
            var result2 = mock.Object.TryParse("hello", out var outputValue2); 
            // result1 : False, outputValue :
            _output.WriteLine($"result1 : {result2}, outputValue : {outputValue2}");
            
            // access invocation arguments when returning a value
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                .Returns((string s) => s.ToLower());
            var result3 = mock.Object.DoSomethingStringy("hElLo"); 
            // result3 : hello
            _output.WriteLine($"result3 : {result3}");
            
            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);
            var tempInstance = new Bar();
            var result4 = mock.Object.Submit(ref instance);
            var result5 = mock.Object.Submit(ref tempInstance);
            // result4 : True，result5 : False
            _output.WriteLine($"result4 : {result4}，result5 : {result5}");
            
            // lazy evaluating return value
            mock.Setup(foo => foo.GetCount()).Returns(() => 1);
            var result6 = mock.Object.GetCount();
            // result6 : 1
            _output.WriteLine($"result6 : {result6}");
            
            

            // throwing when invoked with specific parameters
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));
            mock.Object.DoSomething("reset");
        }
    }

    public interface IFoo
    {
        Bar Bar { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        bool DoSomething(string value);
        bool DoSomething(int number, string value);
        string DoSomethingStringy(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int value);
    }

    public class Bar
    {
        public virtual Baz Baz { get; set; }

        public virtual bool Submit()
        {
            return false;
        }
    }

    public class Baz
    {
        public virtual string Name { get; set; }
    }
}