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
            Calculator calculator = new Calculator(new []{"a"});
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
            Calculator calculator = new Calculator(new []{"b"});
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
            Calculator calculator = new Calculator(new []{"a","b"});
            FakeConsoleWrapper fakeConsoleWrapper = new FakeConsoleWrapper();
            
            //act        
            calculator.PrintPowerSet(fakeConsoleWrapper);
            //assert
            string output = fakeConsoleWrapper.Output();
            output.Should().Be("{},{a},{b},{a,b}");
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