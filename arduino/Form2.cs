using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;

namespace arduino
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SpeechSynthesizer myvoice = new SpeechSynthesizer();
        PromptBuilder mypromp = new PromptBuilder();
        SpeechRecognitionEngine myspeech = new SpeechRecognitionEngine();


        private void riRaCorpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://rishicentury.wix.com/rira-corp?fb_ref=Default");
        }

        private void rishabhRobotFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 myform1 = new Form1();
            myform1.Show();
        }

        private void arduinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.arduino.cc/");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choices mychoise = new Choices();
            mychoise.Add(new string[] { "What's your name", "what's you like", "are you know who i am" });
            Grammar myeng = new Grammar(new GrammarBuilder(mychoise));
            try
            {
                myspeech.RequestRecognizerUpdate();
                myspeech.LoadGrammar(myeng);
                myspeech.SpeechRecognized += myspeech_myrecognizedvoice;
                myspeech.SetInputToDefaultAudioDevice();
                myspeech.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
        }
        private void myspeech_myrecognizedvoice(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "what your name":
                    textBox1.Text = "My name is Dell Computer";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);

                    break;



                case "what you like":
                    textBox1.Text = "I like the Rishabh";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);

                    break;



                case "are you know who i am":
                    textBox1.Text = "I Think Rishabh";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);

                    break;




            }
        }
    }
}
