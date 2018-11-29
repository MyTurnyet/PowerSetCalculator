using System;

namespace PowerSetCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null) return;
            string filePath = args[0];
            IFileReader fileReader = new FileReader(filePath);
            Calculator calculator = new Calculator(fileReader.GetArrayFromFile());
            calculator.PrintPowerSet();
        }
    }
}