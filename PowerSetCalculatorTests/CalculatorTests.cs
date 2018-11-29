using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSetCalculator;

namespace PowerSetCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSetsForSingleLetter_a()
        {
            //assign
            Calculator calculator = new Calculator(new[] {"a"});
            FakeConsoleWrapper fakeConsoleWrapper = new FakeConsoleWrapper();

            //act        
            calculator.PrintPowerSet(fakeConsoleWrapper);
            //assert
            string output = fakeConsoleWrapper.Output();
            output.Should().Be("{},{a}");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSetsForSingleLetter_b()
        {
            //assign
            Calculator calculator = new Calculator(new[] {"b"});
            FakeConsoleWrapper fakeConsoleWrapper = new FakeConsoleWrapper();

            //act        
            calculator.PrintPowerSet(fakeConsoleWrapper);
            //assert
            string output = fakeConsoleWrapper.Output();
            output.Should().Be("{},{b}");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSetsForLetters_ab()
        {
            //assign
            Calculator calculator = new Calculator(new[] {"a", "b"});
            FakeConsoleWrapper fakeConsoleWrapper = new FakeConsoleWrapper();

            //act        
            calculator.PrintPowerSet(fakeConsoleWrapper);
            //assert
            string output = fakeConsoleWrapper.Output();
            output.Should().Be("{},{a},{b},{a,b}");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSetsForLetters_abc()
        {
            //assign
            Calculator calculator = new Calculator(new[] {"a", "b", "c"});
            FakeConsoleWrapper fakeConsoleWrapper = new FakeConsoleWrapper();

            //act        
            calculator.PrintPowerSet(fakeConsoleWrapper);
            //assert
            string output = fakeConsoleWrapper.Output();
            output.Should().Be("{},{a},{b},{c},{a,b},{a,c},{b,c},{a,b,c}");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSetsForLetters_abcd()
        {
            //assign
            Calculator calculator = new Calculator(new[] {"a", "b", "c", "d"});
            FakeConsoleWrapper fakeConsoleWrapper = new FakeConsoleWrapper();

            //act        
            calculator.PrintPowerSet(fakeConsoleWrapper);
            //assert
            string output = fakeConsoleWrapper.Output();
            output.Should().Be("{},{a},{b},{c},{d},{a,b},{a,c},{a,d},{b,c},{b,d},{c,d},{a,b,c}," +
                               "{a,b,d},{a,c,d},{b,c,d},{a,b,c,d}");
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