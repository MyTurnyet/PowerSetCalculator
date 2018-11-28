using System.Collections.Generic;
using System.Linq;

namespace PowerSetCalculator
{
    public class Calculator
    {
        private readonly string[] _initialSet;

        public Calculator(string[] initialSet)
        {
            _initialSet = initialSet;
        }

        public void PrintPowerSet(IConsoleWrapper consoleWrapper)
        {
            string[] strings = CalculatePowerSets(0, new List<IPowerSet>{new PowerSet("")}, new List<string>())
                .Select(n => n.Print())
                .ToArray();
            consoleWrapper.Write(string.Join(",", strings));
        }

        private List<IPowerSet> CalculatePowerSets(int startingIndex, List<IPowerSet> powerSets,
            List<string> currentLetters)
        {
            for (int currentLetter = startingIndex; currentLetter < _initialSet.Length; currentLetter++)
            {
                currentLetters.Add(_initialSet[currentLetter]);
                powerSets.Add(new PowerSet(currentLetters.ToArray()));
                CalculatePowerSets(currentLetter + 1, powerSets, currentLetters);
            }

            return powerSets;
        }
    }
}