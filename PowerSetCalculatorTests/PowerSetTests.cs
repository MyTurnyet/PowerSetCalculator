using System.Collections.Generic;
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

        [TestMethod, TestCategory("Unit")]
        public void ShouldBeComparable_return0()
        {
            //assign
            IPowerSet powerSet1 = new PowerSet(new []{"a"});
            IPowerSet powerSet2 = new PowerSet(new []{"a"});
            List<IPowerSet> powerSets = new List<IPowerSet>(){powerSet1,powerSet2};
            
            //act
            int compareTo = powerSet1.CompareTo(powerSet2);
            //assert
            compareTo.Should().Be(0);
        }   
        [TestMethod, TestCategory("Unit")]
        public void ShouldBeComparable_return1()
        {
            //assign
            IPowerSet powerSet1 = new PowerSet(new []{"a"});
            IPowerSet powerSet2 = new PowerSet(new []{"b"});
            List<IPowerSet> powerSets = new List<IPowerSet>(){powerSet1,powerSet2};
            
            //act
            int compareTo = powerSet1.CompareTo(powerSet2);
            //assert
            compareTo.Should().Be(-1);
        }
    }
}