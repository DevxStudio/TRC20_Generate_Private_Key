using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TronWalletTools.Tron;

namespace TronWalletTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                ;
                saveFileDialog1.Filter = ".txt (*.txt)|*.txt";
                saveFileDialog1.InitialDirectory = Application.StartupPath;
                saveFileDialog1.OverwritePrompt = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(AdressGenerate);
            thread.Start();
        }

        public void AdressGenerate()
        {
            button3.Enabled = false;
            int value_Adress = 0;
        Found:
            if (value_Adress == numericUpDown1.Value) {button3.Enabled = true; return; }
            var wallet = WalletTRC20.Generate();
            var publickey = wallet.Address;
            var privatekey = wallet.PrivateKey;
            textBox1.Text += publickey + ":" + privatekey + Environment.NewLine;
            value_Adress++;
            label2.Text = value_Adress.ToString();
            goto Found;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
