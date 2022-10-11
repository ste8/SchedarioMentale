namespace SchedarioMentale.Core
{
    public interface IPlayfieldUi
    {
        void SetupForNewGame();
        void ShowCard(Card card);
        void ShowMatchAsFinished(MatchSummaryInfo matchSummaryInfo);
    }
}
