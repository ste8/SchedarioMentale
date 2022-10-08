using NUnit.Framework;
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
            var generator = new SessionGenerator();
            Assert.Throws<InvalidRangeForSessionGeneration>(() => {
                generator.Generate(fromNumber, toNumber);
            });
        }


        [TestCase(1, 10)]
        public void Generate_ForValidRange_ReturnUniqueCardsInRandomOrder(int fromNumber, int toNumber)
        {

        } 

    }
}