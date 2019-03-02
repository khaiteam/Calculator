using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculationTest
    {
        [Test]
        [TestCase("+", 1.5, 0.17, 1.67)]
        [TestCase("-", 1.5, 0.17, 1.33)]
        [TestCase("/", 15, 3, 5)]
        [TestCase("*", 15, 3, 45)]
        public void TestOperation(string operation, double left, double right, double result)
        {
            ICalculator calculator = new Calculator();

            Assert.AreEqual(calculator.Actions[operation].Invoke(left, right), result);
        }
    }
}
