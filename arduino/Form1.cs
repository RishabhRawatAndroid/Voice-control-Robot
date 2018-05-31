using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Media;
using System.Diagnostics;

namespace arduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            serialPort1.Open();
        }
        SpeechSynthesizer myvoice = new SpeechSynthesizer();
        PromptBuilder mypromp = new PromptBuilder();
        SpeechRecognitionEngine myspeech = new SpeechRecognitionEngine(); 

        private void button1_Click(object sender, EventArgs e)
        {

            serialPort1.Write("1");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myvoice.Speak("Your project has been started");
            Choices mychoise = new Choices();
            mychoise.Add(new string[] { "rishabh forward","rishabh stop","rishabh backward","rishabh left","rishabh right","talk to computer"});
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
                case "rishabh stop":
                    textBox1.Text = "dinker are you ready";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);
                    serialPort1.Write("0");
                    break;



                case "rishabh left":
                    textBox1.Text = "Rishabh Move left";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);
                    serialPort1.Write("1");
                    break;



                case "rishabh right":
                    textBox1.Text = "Rishabh Move right";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);
                    serialPort1.Write("2");
                    break;


                case "rishabh backward":
                    textBox1.Text = "Rishabh Move backward";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);
                    serialPort1.Write("3");
                    break;



                case "rishabh forward":
                    textBox1.Text = "Rishabh Move forward";
                    mypromp.ClearContent();
                    mypromp.AppendText(textBox1.Text);
                    myvoice.Speak(mypromp);
                    serialPort1.Write("4");
                    break;
               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void projectInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VOICE CONTROLLED ROBOT USING ARDUINO","Information",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }

        private void riRaWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.Start("http://rishicentury.wix.com/rira-corp?fb_ref=Default");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 myform = new Form2();
            myform.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void arduinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.arduino.cc/");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void arduinoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("Notepad.exe");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
