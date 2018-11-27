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
    }
}