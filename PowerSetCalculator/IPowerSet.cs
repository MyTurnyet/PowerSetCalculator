using System;

namespace PowerSetCalculator
{
    public interface IPowerSet: IComparable<IPowerSet>
    {
        string Print();
    }
}