namespace PowerSetCalculator
{
    public interface IFileReader
    {
        bool IsValidPath();
        string[] GetArrayFromFile();
    }
}