using System;
using System.Collections.Generic;

namespace Calculator
{
    public interface ICalculator
    {
        double Left { get; set; }
        double Right { get; set; }
        Dictionary<string, Func<double, double, double>> Actions { get; }
    }
}
