namespace PowerSetCalculator
{
    public class Calculator
    {
        private readonly string[] _initialSet;

        public Calculator(string[] initialSet)
        {
            _initialSet = initialSet;
        }

        public void printPowerSet(IConsoleWrapper consoleWrapper)
        {
            consoleWrapper.Write("{},{a}");
        }
    }
}