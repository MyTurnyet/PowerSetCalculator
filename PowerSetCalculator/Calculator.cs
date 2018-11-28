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
            string output = string.Join(",", CalculatePowerSets().Select(n=>n.Print()).ToArray());
            consoleWrapper.Write(output);
        }

        public List<IPowerSet> CalculatePowerSets()
        {
            List<IPowerSet> powerSets = new List<IPowerSet>(){new PowerSet()};
            foreach (string letter in _initialSet)
            {
                powerSets.Add(new PowerSet(letter));
            }
            return powerSets;
        }
    }
}