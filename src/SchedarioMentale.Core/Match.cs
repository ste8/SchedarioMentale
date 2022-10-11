namespace SchedarioMentale.Core
{
    public class Match
    {
        private readonly Session _session;
        private readonly IPlayfieldUi _playfieldUi;
        private int _currentCardIndex;
        private MatchTimes _matchTimes;

        public Match(Session session, IPlayfieldUi playfieldUi)
        {
            _session = session;
            _playfieldUi = playfieldUi;
            _matchTimes = new MatchTimes();
        }

        public void Start()
        {
            _currentCardIndex = 0;
            ShowCard();
            IsMatchRunning = true;
            _matchTimes.Start();
        }

        private void ShowCard()
        {
            var card = GetCurrentCard();
            _playfieldUi.ShowCard(card);
        }

        private Card GetCurrentCard()
        {
            return _session.Cards[_currentCardIndex];
        }

        public bool IsMatchRunning { get; private set; }

        public void GoToNextCard()
        {
            _currentCardIndex++;
            if (AreCardsFinished()) {
                MarkMatchAsFinished();
                return;
            }
            ShowCard();
        }

        private bool AreCardsFinished()
        {
            return _currentCardIndex >= _session.Cards.Length;
        }

        private void MarkMatchAsFinished()
        {
            IsMatchRunning = false;
            _matchTimes.Finish();
            var matchSummaryInfo = new MatchSummaryInfo(_matchTimes);
            _playfieldUi.ShowMatchAsFinished(matchSummaryInfo);
        }

    }
}
