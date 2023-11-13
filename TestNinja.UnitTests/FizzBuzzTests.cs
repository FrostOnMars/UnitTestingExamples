using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class FizzBuzzTests
    {
        
        [Test]
        public void GetOutput_InputIsDivisibleBy3and5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }
        [Test]
        public void GetOutput_InputIsNotDivisibleBy3or5_ReturnsString()
        {
            var result = FizzBuzz.GetOutput(4);

            Assert.That(result, Is.EqualTo("4"));
        }
        
    }
}
