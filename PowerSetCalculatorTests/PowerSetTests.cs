using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSetCalculator;

namespace PowerSetCalculatorTests
{
    [TestClass]
    public class PowerSetTests
    {

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnEmptySet()
        {
            //assign
            IPowerSet powerSet = new PowerSet();
            //act
            string printOutput = powerSet.Print();
            //assert
            printOutput.Should().Be("{}");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSetFromSingleCharacter()
        {
            //assign
            IPowerSet powerSet = new PowerSet("a");
            //act
            string printOutput = powerSet.Print();
            //assert
            printOutput.Should().Be("{a}");
        }
        
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSetFromArrayOfStrings()
        {
            //assign
            IPowerSet powerSet = new PowerSet(new []{"a","b"});
            //act
            string printOutput = powerSet.Print();
            //assert
            printOutput.Should().Be("{a,b}");
        }
    }
}