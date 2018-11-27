using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSetCalculator;

namespace PowerSetCalculatorTests
{
    [TestClass]
    public class PowerSetTests
    {

        [TestMethod, TestCategory("Unit")]
        public void ShouldTakeString()
        {
            //assign
            IPowerSet powerSet = new PowerSet("");
            //act
            string printOutput = powerSet.Print();
            //assert
            printOutput.Should().Be("{}");
        }
    }
}