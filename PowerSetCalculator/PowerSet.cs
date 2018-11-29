using System;
using System.Linq;

namespace PowerSetCalculator
{
    public class PowerSet : IPowerSet
    {
        private readonly string[] _setVariables;
        public PowerSet():this(string.Empty){}

        public PowerSet(string setVariable):this(new []{setVariable}){}

        public PowerSet(string[] setVariables)
        {
            _setVariables = setVariables;
        }

        public string Print()
        {
            return $"{{{ string.Join(",",_setVariables)}}}";
        }

        
        public int CompareTo(IPowerSet other)
        {
            string[] otherSetVariables = ((PowerSet) other)._setVariables;
            int otherSetLength = otherSetVariables.Length;
            int setLength = _setVariables.Length;
            return setLength <= otherSetLength
                ? setLength >= otherSetLength
                    ? _setVariables
                        .Select((t, currentIndex) =>
                            String.CompareOrdinal(t, otherSetVariables[currentIndex]))
                        .FirstOrDefault(compareToNumber => compareToNumber != 0)
                    : -1
                : 1;
        }
    }
}