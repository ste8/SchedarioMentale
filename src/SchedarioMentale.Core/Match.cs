namespace SchedarioMentale.Core
{
    public class Match
    {
        private readonly Session _session;
        private readonly IPlayfieldUi _playfieldUi;
        private int _currentCardIndex;

        public Match(Session session, IPlayfieldUi playfieldUi)
        {
            _session = session;
            _playfieldUi = playfieldUi;
        }

        public void Start()
        {
            _currentCardIndex = 0;
            ShowCard();
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
    }
}
