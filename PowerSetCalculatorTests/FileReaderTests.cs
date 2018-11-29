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
        public void ShouldHave_Exists_true()
        {
            //assign
            IFileInfoWrapper fakeFileInfo = new FakeFileInfo("sometext.txt", true);
            IFileReader fileReader = new FileReader(fakeFileInfo);
            //act
            bool isValid = fileReader.IsValidPath();
            //assert
            isValid.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldHave_Exists_false()
        {
            //assign
            IFileInfoWrapper fakeFileInfo = new FakeFileInfo("sometext.txt", false);
            IFileReader fileReader = new FileReader(fakeFileInfo);
            //act
            bool isValid = fileReader.IsValidPath();
            //assert
            isValid.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnArrayOfLetters_abcd()
        {
            //assign
            IFileInfoWrapper fileInfo = new FakeFileInfo("a,b,c,d");
            IFileReader fileReader = new FileReader(fileInfo);
            //act
            string[] fileContents = fileReader.GetArrayFromFile();
            //assert
            fileContents.Should().BeEquivalentTo("a", "b", "c", "d");
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnEmptyArrayOfLetters_IfFileDoesntExist()
        {
            //assign
            IFileInfoWrapper fileInfo = new FakeFileInfo("a,b,c,d",false);
            IFileReader fileReader = new FileReader(fileInfo);
            //act
            string[] fileContents = fileReader.GetArrayFromFile();
            //assert
            fileContents.Length.Should().Be(0);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnArrayOfLetters_bcd()
        {
            //assign
            IFileInfoWrapper fileInfo = new FakeFileInfo("b,c,d");
            IFileReader fileReader = new FileReader(fileInfo);
            //act
            string[] fileContents = fileReader.GetArrayFromFile();
            //assert
            fileContents.Should().BeEquivalentTo("b", "c", "d");
        }

        [TestMethod, TestCategory("Functional")]
        public void ShouldValidateFileExists()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            IFileReader fileReader = new FileReader($"{solutionDir}\\powerset-input.txt");
            //act
            bool isValid = fileReader.IsValidPath();
            //assert
            isValid.Should().BeTrue();
        }

        [TestMethod, TestCategory("Functional")]
        public void ShouldInvalidate_IfFileDoesntExist()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            IFileReader fileReader = new FileReader($"{solutionDir}\\blah.txt");
            //act
            bool isValid = fileReader.IsValidPath();
            //assert
            isValid.Should().BeFalse();
        }

        [TestMethod, TestCategory("Functional")]
        public void ShouldReturnArray_FromFile()
        {
            //assign
            string solutionDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            IFileReader fileReader = new FileReader($"{solutionDir}\\powerset-input.txt");
            //act
            string[] fileContents = fileReader.GetArrayFromFile();
            //assert
            fileContents.Should().BeEquivalentTo("a", "b", "c", "d","e");
        }
    }

    class FakeFileInfo : IFileInfoWrapper
    {
        private readonly string _fileData;
        private readonly bool _exists;

        public FakeFileInfo(string fileData) : this(fileData, true)
        {
        }

        public FakeFileInfo(string fileData, bool exists)
        {
            _fileData = fileData;
            _exists = exists;
        }

        public string ReadFile()
        {
            return _fileData;
        }

        public bool Exists()
        {
            return _exists;
        }
    }
}