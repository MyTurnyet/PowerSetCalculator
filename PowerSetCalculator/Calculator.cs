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

        public void PrintPowerSet(IConsoleWrapper consoleWrapper) =>
            consoleWrapper.Write(string.Join(",", CalculatePowerSets().Select(n => n.Print()).ToArray()));

        private IEnumerable<IPowerSet> CalculatePowerSets()
        {
            List<IPowerSet> powerSets = new List<IPowerSet> {new PowerSet()};
            powerSets.AddRange(_initialSet.Select(letter => new PowerSet(letter)));
            int length = _initialSet.Length;
            if (length == 1) return powerSets;
            if (length == 3)
            {
                for (int firstLetterIndex = 0; firstLetterIndex < _initialSet.Length; firstLetterIndex++)
                {
                    for (int secondLetterIndex = firstLetterIndex + 1;
                        secondLetterIndex < _initialSet.Length;
                        secondLetterIndex++)
                    {
                        powerSets.Add(
                            new PowerSet(new[] {_initialSet[firstLetterIndex], _initialSet[secondLetterIndex]}));
                    }
                }
            }

            PowerSet allLettersPowerSet = new PowerSet(_initialSet);
            powerSets.Add(allLettersPowerSet);
            return powerSets;
        }
    }
}