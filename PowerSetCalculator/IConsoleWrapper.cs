namespace PowerSetCalculator
{
    public interface IConsoleWrapper
    {
        void Write(string format, params object[] parameters);
        void WriteLine(string format, params object[] parameters);
    }
}