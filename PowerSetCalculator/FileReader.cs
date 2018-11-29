using System;
using System.IO;

namespace PowerSetCalculator
{
    public class FileReader:IFileReader
    {
        private readonly IFileInfoWrapper _fileInfo;

        public FileReader(string filePath) : this(new FileInfoWrapper(filePath)){}

        public FileReader(IFileInfoWrapper fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public bool IsValidPath() => _fileInfo.Exists();

        public string[] GetArrayFromFile() => !IsValidPath() 
            ? new string[]{} 
            : _fileInfo.ReadFile().Replace("\n","").Split(",", StringSplitOptions.RemoveEmptyEntries);
    }
}