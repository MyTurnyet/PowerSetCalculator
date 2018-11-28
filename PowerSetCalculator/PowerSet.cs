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
            
            for (int currentIndex = 0; currentIndex < _setVariables.Length; currentIndex++)
            {
                int compareToNumber = string.Compare( _setVariables[currentIndex], ((PowerSet)other)._setVariables[currentIndex]);
                if(compareToNumber == 0) continue;
                return compareToNumber;
            }

            return 0;
        }
    }
}