using System.Globalization;

namespace SchedarioMentale.Core
{
    public interface IReadOnlyMatchTimes
    {
        DateTime? StartTime { get; }
        DateTime? FinishTime { get; }
        TimeSpan CalculateDurationForFinishedMatch();
        CardDuration[] GetCardDurationsByNaturalOrder();
        CardDuration[] GetCardDurationsBySlowestOrder();
    }

    public class MatchTimes : IReadOnlyMatchTimes
    {
        public DateTime? StartTime { get; private set; }
        public DateTime? FinishTime { get; private set; }

        private Card? _currentCard;
        private DateTime _currentCardStartTime;
        private List<CardDuration> CardDurations { get; } = new();

        public void Start()
        {
            _currentCard = null;
            CardDurations.Clear();
            StartTime = GetCurrentTime();
        }

        public void Finish()
        {
            RecordTimeForCurrentCard();
            FinishTime = GetCurrentTime();
        }

        public TimeSpan? Duration
        {
            get
            {
                if (!StartTime.HasValue) return null;
                if (!FinishTime.HasValue) return null;

                var result = FinishTime.Value.Subtract(StartTime.Value);
                return result;
            }
        }

        public TimeSpan CalculateDurationForFinishedMatch()
        {
            var duration = Duration;
            if (duration == null) {
                throw new Exception("Match is not finished yet");
            }
            return duration.Value;
        }

        public void StartCard(Card card)
        {
            RecordTimeForCurrentCard();
            _currentCard = card;
            _currentCardStartTime = GetCurrentTime();
        }

        private void RecordTimeForCurrentCard()
        {
            if (_currentCard == null) return;
            var cardFinishTime = GetCurrentTime();
            var duration = cardFinishTime.Subtract(_currentCardStartTime);
            var cardDuration = new CardDuration(_currentCard, duration);
            CardDurations.Add(cardDuration);
        }

        private static DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        public CardDuration[] GetCardDurationsByNaturalOrder()
        {
            return CardDurations.ToArray();
        }

        public CardDuration[] GetCardDurationsBySlowestOrder()
        {
            return CardDurations.OrderByDescending(x => x.Duration).ToArray();
        }
    }

    public class CardDuration
    {
        public Card Card { get; }
        public TimeSpan Duration { get; }

        public CardDuration(Card card, TimeSpan duration)
        {
            Card = card;
            Duration = duration;
        }

        public string FormattedDurationInSeconds =>
            Math.Round(Duration.TotalSeconds, 1).ToString("##,#0.0");
    }
}
