using System.IO;

namespace PowerSetCalculator
{
    public class FileInfoWrapper : IFileInfoWrapper
    {
        private readonly FileInfo _fileInfo;

        public FileInfoWrapper(string filePath):this(new FileInfo(filePath)){}
        private FileInfoWrapper(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public string ReadFile() => File.ReadAllText(_fileInfo.FullName);
        public bool Exists() => _fileInfo.Exists;
    }
}