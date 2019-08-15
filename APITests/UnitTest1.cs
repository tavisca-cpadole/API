using System;
using Xunit;
using TestAPI2.Controllers;

namespace APITests
{
    public class TESTAPI
    {
        [Fact]
        public void Check_GetResponse_For_HELLO()
        {
            ValuesController values = new ValuesController();
            var result = values.Get("hello");
            Assert.Equal("hi",result);
        }

        [Fact]
        public void Check_GetResponse_For_HI()
        {
            ValuesController values = new ValuesController();
            var result = values.Get("hi");
            Assert.Equal("hello", result);
        }

      
    }
}
