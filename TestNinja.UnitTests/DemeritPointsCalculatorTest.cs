using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class DemeritPointsCalculatorTest
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.That(() => calculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        
        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int expectedResult)
        {
            var calculator = new DemeritPointsCalculator();

            var points = calculator.CalculateDemeritPoints(speed);

            Assert.That(points, Is.EqualTo(expectedResult));
        }
    }
}
