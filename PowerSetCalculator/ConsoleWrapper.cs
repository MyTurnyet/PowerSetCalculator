using System;

namespace PowerSetCalculator
{
    public class ConsoleWrapper : IConsoleWrapper
    {

        public void Write(string format, params object[] parameters)
        {
            Console.Write(format, parameters);
        }

        public void WriteLine(string format, params object[] parameters)
        {
            Console.WriteLine(format,parameters);
        }
    }
}