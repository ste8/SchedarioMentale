namespace SchedarioMentale.Core;

public class MatchSummaryInfo
{
    public IReadOnlyMatchTimes MatchTimes { get; }

    public MatchSummaryInfo(IReadOnlyMatchTimes matchTimes)
    {
        MatchTimes = matchTimes;
    }
}