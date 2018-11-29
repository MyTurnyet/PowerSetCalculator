using System.IO;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSetCalculator;

namespace PowerSetCalculatorTests
{
    [TestClass]
    public class FileInfoWrapperTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldNotExist()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            IFileInfoWrapper fileInfoWrapper = new FileInfoWrapper($"{solutionDir}\\blah.txt");

            //act
            bool fileExists = fileInfoWrapper.Exists();
            //assert
            fileExists.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldExist()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            IFileInfoWrapper fileInfoWrapper = new FileInfoWrapper($"{solutionDir}\\powerset-input.txt");

            //act
            bool fileExists = fileInfoWrapper.Exists();
            //assert
            fileExists.Should().BeTrue();
        }
    }
}