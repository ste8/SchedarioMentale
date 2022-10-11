namespace SchedarioMentale.Core
{
    public interface IReadOnlyMatchTimes
    {
        DateTime? StartTime { get; }
        DateTime? FinishTime { get; }
        TimeSpan CalculateDurationForFinishedMatch();
    }

    public class MatchTimes : IReadOnlyMatchTimes
    {
        public DateTime? StartTime { get; private set; }
        public DateTime? FinishTime { get; private set; }

        public void Start()
        {
            StartTime = DateTime.Now;
        }

        public void Finish()
        {
            FinishTime = DateTime.Now;
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
    }
}
