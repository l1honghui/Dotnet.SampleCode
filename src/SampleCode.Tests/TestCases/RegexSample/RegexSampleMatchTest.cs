using System.Collections.Generic;
using SampleCode.RegexSample;
using Xunit;
using Xunit.Abstractions;

namespace SampleCode.Tests.TestCases.RegexSample
{
    public class RegexSampleMatchTest
    {
        private readonly ITestOutputHelper _output;
        
        public RegexSampleMatchTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void MatchTest()
        {
            var source = "测试名称{{name}},测试年纪{{age}}";
            var dic = new Dictionary<string, string>();
            dic.Add("name", "阿飞");
            dic.Add("age", "26");
            var result = RegexSampleMatch.GetFormatString(source, dic);
            _output.WriteLine(result);
            Assert.NotEmpty(result);
        }
    }
}