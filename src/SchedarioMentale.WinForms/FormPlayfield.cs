using System.Diagnostics;
using System.Text;
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

        private void ShowSummaryInfoForFinishedMatch(MatchSummaryInfo matchSummaryInfo)
        {
            var messageForCardDurations = BuildMessageForSlowestCardDurations(matchSummaryInfo.MatchTimes);
            var totalDuration = matchSummaryInfo.MatchTimes.CalculateDurationForFinishedMatch();
            var message =
@$"Match completato!
Durata (secondi): {MathHelper.Round(totalDuration.TotalSeconds, 0)}

{messageForCardDurations}";

            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string BuildMessageForSlowestCardDurations(IReadOnlyMatchTimes matchTimes)
        {
            var durations = matchTimes.GetCardDurationsBySlowestOrder();
            return BuildMessageForCardDurations(durations);
        }

        private static string BuildMessageForCardDurations(CardDuration[] cardDurations)
        {
            var sb = new StringBuilder();
            foreach (var cardDuration in cardDurations)
            {
                var formattedNumber = cardDuration.Card.FormattedNumber;
                var formattedDuration = cardDuration.FormattedDurationInSeconds;
                sb.AppendLine($"{formattedNumber}\t{formattedDuration}");
            }
            return sb.ToString();
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