using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSetCalculator;

namespace PowerSetCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {

        [TestMethod, TestCategory("Unit")]
        public void ShouldTakeArrayOfIntegers()
        {
            //assign
            Calculator calculator = new Calculator(new []{"a"});
            FakeConsoleWrapper fakeConsoleWrapper = new FakeConsoleWrapper();
            
            //act        
            calculator.printPowerSet(fakeConsoleWrapper);
            //assert
            string output = fakeConsoleWrapper.Output();
            output.Should().Be("{},{a}");

        }
    }

    public class FakeConsoleWrapper : IConsoleWrapper
    {
        private string _output;

        public string Output()
        {
            return _output;
        }

        public void Write(string format, params object[] parameters)
        {
            _output = format;
        }

        public void WriteLine(string format, params object[] parameters)
        {
            _output = format;
        }
    }
}