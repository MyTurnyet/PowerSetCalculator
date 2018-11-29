using System.IO;
using System.Net;
using System.Net.Mime;
using System.Reflection;
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
            string solutionDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FileReader fileReader = new FileReader($"{solutionDir}\\powerset-input.txt");
            //act
            bool isValid = fileReader.IsValidPath();
            //assert
            isValid.Should().BeTrue();
        }
        
        [TestMethod, TestCategory("Unit")]
        public void ShouldInvalidate_IfFileDoesntExist()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            FileReader fileReader = new FileReader($"{solutionDir}\\blah.txt");
            //act
            bool isValid = fileReader.IsValidPath();
            //assert
            isValid.Should().BeFalse();
        }
        
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnArrayOfLetters()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            FileReader fileReader = new FileReader($"{solutionDir}\\powerset-input.txt");
            //act
            string[] fileContents = fileReader.GetArrayFromFile();
            //assert
            fileContents.Should().BeEquivalentTo("a", "b", "c", "d");
        }
    }
}