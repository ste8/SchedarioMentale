namespace SchedarioMentale.Core
{
    public class Playfield
    {
        private readonly IPlayfieldUi _playfieldUi;
        private Match _currentMatch;

        public Playfield(IPlayfieldUi playfieldUi)
        {
            _playfieldUi = playfieldUi;
        }

        public void Init()
        {
            _playfieldUi.SetupForNewGame();
        }

        public void StartMatch(int fromNumber, int toNumber)
        {
            var session = SessionGenerator.Generate(fromNumber, toNumber);
            _currentMatch = new Match(session, _playfieldUi);
            _currentMatch.Start();
        }
    }
}
