using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public double Left { get; set; }
        public double Right { get; set; }
        public Dictionary<string, Func<double, double, double>> Actions { get; } = new Dictionary<string, Func<double, double, double>>()
        {
            {"+", (a, b) => a + b },
            {"-", (a, b) => a - b },
            {"/", (a, b) => a / b },
            {"*", (a, b) => a * b },
        };
    }
}
