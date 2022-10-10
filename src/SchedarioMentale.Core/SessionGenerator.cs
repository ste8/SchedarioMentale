namespace SchedarioMentale.Core
{
    public class SessionGenerator
    {
        public static Session Generate(int fromNumber, int toNumber)
        {
            var range = new SessionGenerationRange(fromNumber, toNumber);
            ValidateRange(range);

            var random = new Random();
            var cards = new List<Card>();

            var sequence = SequenceGenerator.Generate(fromNumber, toNumber);

            foreach ( var number in sequence) {
                var card = new Card(number);
                cards.Add(card);
            }

            var output = new Session(cards.ToArray());
            return output;
        }

        private static void ValidateRange(SessionGenerationRange range)
        {
            if (range.FromNumber is < 1 or > 100) ThrowInvalidRange(range);
            if (range.ToNumber is < 1 or > 100) ThrowInvalidRange(range);
            if (range.FromNumber > range.ToNumber) ThrowInvalidRange(range);
        }

        private static void ThrowInvalidRange(SessionGenerationRange range)
        {
            throw new InvalidRangeForSessionGeneration(range);
        }
    }

    public class SessionGenerationRange
    {
        public int FromNumber { get; }
        public int ToNumber { get; }

        public SessionGenerationRange(int fromNumber, int toNumber)
        {
            FromNumber = fromNumber;
            ToNumber = toNumber;
        }
    }

    public class InvalidRangeForSessionGeneration : Exception
    {
        public InvalidRangeForSessionGeneration(SessionGenerationRange range)
            : this(range.FromNumber, range.ToNumber)
        {

        }
        public InvalidRangeForSessionGeneration(int fromNumber, int toNumber)
            : base($"Range is not valid: {fromNumber} - {toNumber}.")
        {
            
        }
    }


}
