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

        private void FormPlayfield_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) {
                if (_playfield.IsMatchRunning) {
                    _playfield.GoToNextCard();
                    e.Handled = true;
                }
            }
        }
    }
}