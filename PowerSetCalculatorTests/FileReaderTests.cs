using System.IO;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSetCalculator;

namespace PowerSetCalculatorTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldValidateFileExists()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            FileReader fileReader = new FileReader($"{solutionDir}\\powerset-input.txt");
            //act
            bool isValid = fileReader.isValidPath();
            //assert
            isValid.Should().BeTrue();
        }
    }
}