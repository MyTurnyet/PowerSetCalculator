using System.IO;

namespace PowerSetCalculator
{
    public class FileReader
    {
        private readonly FileInfo _inputFile;

        public FileReader(string filePath) : this(new FileInfo(filePath))
        {
        }

        private FileReader(FileInfo inputFile)
        {
            _inputFile = inputFile;
        }
        public bool IsValidPath() => _inputFile.Exists;
    }
}