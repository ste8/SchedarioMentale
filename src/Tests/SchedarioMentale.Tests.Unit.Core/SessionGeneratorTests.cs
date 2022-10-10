using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SchedarioMentale.Core;

namespace SchedarioMentale.Tests.Unit.Core
{
    [TestFixture]
    public class SessionGeneratorTests
    {
        [TestCase(0, 100)]
        [TestCase(1, 101)]
        [TestCase(51, 50)]
        [TestCase(101, 101)]
        public void Generate_ForInvalidRange_ThrowException(int fromNumber, int toNumber)
        {
            var generator = CreateGenerator();
            Assert.Throws<InvalidRangeForSessionGeneration>(() => {
                generator.Generate(fromNumber, toNumber);
            });
        }

        private static SessionGenerator CreateGenerator()
        {
            return new SessionGenerator();
        }

        [TestCase(1, 10)]
        [TestCase(1, 100)]
        [TestCase(21, 100)]
        public void Generate_ForValidRange_ReturnUniqueCardsInRandomOrder(int fromNumber, int toNumber)
        {
            var generator = CreateGenerator();
            var actual = generator.Generate(fromNumber, toNumber);

            var expectedCount = toNumber - fromNumber + 1;
            Assert.AreEqual(expectedCount, actual.Cards.Length);
            AssertAllNumbersAreGenerated(fromNumber, toNumber, actual);

            var actualNumbers = actual.Cards.Select(x => x.Number).ToArray();
            var sortedNumbers = actualNumbers.OrderBy(x => x).ToArray();
            Assert.AreNotEqual(sortedNumbers, actualNumbers);
        }

        private static void AssertAllNumbersAreGenerated(int fromNumber, int toNumber, Session actual)
        {
            for (int i = fromNumber; i <= toNumber; i++) {
                bool exitNumber = actual.Cards.Any(x => x.Number == i);
                Assert.IsTrue(exitNumber, $"Number {i} has not been generated.");
            }
        }
    }
}