using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PowerSetCalculator
{
    public class Calculator
    {
        private readonly string[] _initialSet;
        private readonly IConsoleWrapper _consoleWrapper;

        public Calculator(string[] initialSet):this(initialSet, new ConsoleWrapper()){}

        public Calculator(string[] initialSet,IConsoleWrapper consoleWrapper)
        {
            _initialSet = initialSet;
            _consoleWrapper = consoleWrapper;
        }

        

        public void PrintPowerSet()
        {
            string[] strings = CalculatePowerSets()
                .Select(n => n.Print())
                .ToArray();
            _consoleWrapper.Write(string.Join(",", strings));
        }

        private List<IPowerSet> CalculatePowerSets()
        {
            int initialSetLength = _initialSet.Length;
            int totalNumberOfSets = 1 << initialSetLength;
            
            List<IPowerSet> powerSets = new List<IPowerSet>();
            for (int setMask = 0; setMask < totalNumberOfSets; setMask++)
            {
                List<string> currentLettersInSet = new List<string>();
                for (int currentIndex = 0; currentIndex < initialSetLength; currentIndex++)
                {
                    if ((setMask & (1 << currentIndex)) <= 0) continue;
                    currentLettersInSet.Add(_initialSet[currentIndex]);
                }
                powerSets.Add( new PowerSet(currentLettersInSet.ToArray()));
            }
            powerSets.Sort();
            return powerSets;
        }
    }
}