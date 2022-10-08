﻿namespace SchedarioMentale.Core
{
    public class SessionGenerator
    {
        public SessionGeneratorOutput Generate(int fromNumber, int toNumber)
        {
            var range = new SessionGenerationRange(fromNumber, toNumber);
            ValidateRange(range);

            var cards = new List<Card>();

            for (int i = fromNumber; i <= toNumber; i++) {
                var card = new Card(i);
                cards.Add(card);
            }

            var output = new SessionGeneratorOutput(cards.ToArray());
            return output;
        }

        private void ValidateRange(SessionGenerationRange range)
        {
            if (range.FromNumber is < 1 or > 100) ThrowInvalidRange(range);
            if (range.ToNumber is < 1 or > 100) ThrowInvalidRange(range);
            if (range.FromNumber > range.ToNumber) ThrowInvalidRange(range);
        }

        private void ThrowInvalidRange(SessionGenerationRange range)
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

    public class SessionGeneratorOutput
    {
        public Card[] Cards { get; }

        public SessionGeneratorOutput(Card[] cards)
        {
            Cards = cards;
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
