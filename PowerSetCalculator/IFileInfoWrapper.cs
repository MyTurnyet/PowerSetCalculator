namespace PowerSetCalculator
{
    public interface IFileInfoWrapper
    {
        string ReadFile();
        bool Exists();
    }
}