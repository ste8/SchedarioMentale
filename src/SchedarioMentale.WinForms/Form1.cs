namespace SchedarioMentale.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var v = new SchedarioMentale.Core.SchedarioEngine();
            MessageBox.Show(v.Greet());
        }
    }
}