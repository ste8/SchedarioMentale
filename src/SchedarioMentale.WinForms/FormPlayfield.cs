using System.Diagnostics;
using SchedarioMentale.Core;

namespace SchedarioMentale.WinForms
{
    public partial class FormPlayfield : Form, IPlayfieldUi
    {
        private Playfield _playfield;

        public FormPlayfield()
        {
            InitializeComponent();
            InitPlayfield();
        }

        private void InitPlayfield()
        {
            _playfield = new Playfield(this);
            _playfield.Init();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void Play()
        {
            int fromNumber = 1;
            int toNumber = 5;
            _playfield.StartMatch(fromNumber, toNumber);
        }

        public void SetupForNewGame()
        {
            NumberLabel.Visible = true;
            NumberLabel.Text = string.Empty;
            PlayButton.Visible = true;
            InstructionsForNextNumberLabel.Visible = false;
        }

        public void ShowCard(Card card)
        {
            NumberLabel.Text = card.Number.ToString();
            NumberLabel.Visible = true;
            PlayButton.Visible = false;
            InstructionsForNextNumberLabel.Visible = true;
        }

        public void ShowMatchAsFinished(MatchSummaryInfo matchSummaryInfo)
        {
            SetupForNewGame();
            ShowSummaryInfoForFinishedMatch(matchSummaryInfo);
        }

        private static void ShowSummaryInfoForFinishedMatch(MatchSummaryInfo matchSummaryInfo)
        {
            var duration = matchSummaryInfo.MatchTimes.CalculateDurationForFinishedMatch();
            var message =
@$"Match completato!
Durata (secondi): {Math.Round(duration.TotalSeconds, 0, MidpointRounding.AwayFromZero)}";

            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormPlayfield_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N) {
                if (_playfield.IsMatchRunning) {
                    _playfield.GoToNextCard();
                    e.Handled = true;
                } else {
                    Play();
                }
            }
        }
    }
}