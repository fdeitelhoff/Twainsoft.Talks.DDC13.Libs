using System;
using System.Windows.Forms;
using Twainsoft.Talks.DDC13.Libs.LibZ.Module1;
using Twainsoft.Talks.DDC13.Libs.LibZ.Module2;

namespace Twainsoft.Talks.DDC13.Libs.LibZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void doIt_Click(object sender, EventArgs e)
        {
            var firstModule = new FirstModule();
            var secondModule = new SecondModule();

            textBox.Text += firstModule.DoIt() + "\n";
            textBox.Text += secondModule.DoIt() + "\n";
        }
    }
}
