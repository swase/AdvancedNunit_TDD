using NUnit.Framework;
using System.Collections.Generic;

namespace AdvancedNUnit
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Add_Always_ReturnsExpectedResult()
        {
            // Arrange
            var expectedResult = 6;
            var subject = new Calculator { Num1 = 2, Num2 = 4 };
            // Act
            var result = subject.Add();
            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "optional failure message");
        }

        [Test]
        [Category("Contraint tests")]
        public void SomeConstraints()
        {
            var subject = new Calculator { Num1 = 6 };
            Assert.That(subject.DivisibleBy3());
            subject.Num1 = 7;
            Assert.That(subject.DivisibleBy3, Is.False);
            Assert.That(subject.ToString(), Does.Contain("Calculator"));
        }

        [Test]

        public void TestArrayOfStrings()
        {
            var characters = new string[] { "James McAvoy", "Tom BillyBomBom", "Lulu Mclovin", "Paul Reverie"};

            Assert.That(characters, Has.Exactly(1).EqualTo("James McAvoy"));
        }

        [Test]
        [Category("Constraint test on random string Array. " +
            "Not realted to app")]
        public void TestArrayOfStrings_differentConstraintType()
        {
            var characters = new string[] { "James McAvoy", "Tom BillyBomBom", "Lulu Mclovin", "Paul Reverie" };

            Assert.That(characters, Does.Contain("James McAvoy"));
        }

        [TestCaseSource("AddCases")]
        public void AddAlways_ReturnsResult_WithDataProvider(int x, int y, int expectedResult)
        {
            var subject = new Calculator { Num1 = x, Num2 = y };
            Assert.That(subject.Add(), Is.EqualTo(expectedResult));
        }

        private static object[] AddCases =
        {
            new int[] {2, 4, 6},
            new int[] {-2, 3, 1},
            new int[] {1, 3, 4},
            new int[] {8, 2, 10},
            new int[] {8, -3, 5},
        };
    }
    
}