namespace SchedarioMentale.Core
{
    public class SequenceGenerator
    {
        public static int[] Generate(int fromNumber, int toNumber)
        {
            var random = new Random();
            var generateSequence = new List<int>();
            var expectedCount = toNumber - fromNumber + 1;

            var minValue = fromNumber; //This bound is inclusive in Random.Next
            var maxValue = toNumber + 1; //This bound is exclusive in Random.Next

            while (!AllNumbersAreGenerated(expectedCount, generateSequence)) {
                var next = random.Next(minValue, maxValue);
                if (generateSequence.Contains(next)) continue;
                generateSequence.Add(next);
            }
            return generateSequence.ToArray();
        }

        private static bool AllNumbersAreGenerated(int expectedCount, List<int> generateSequence)
        {
            return expectedCount == generateSequence.Count;
        }
    }
}
