using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Visioner.IO;
using Visioner.Dictionary;

namespace Visioner
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        private BindingList<string> _predictions;
        private readonly string path = $"{Environment.CurrentDirectory}\\Cases.json";
        private FileIOService _fileIOService;

        string language = "rus";

        public Form1()
        {
            InitializeComponent();
            _predictions = new BindingList<string>();
            _fileIOService = new FileIOService(path);
            LoadCases();
        }

        private void UpdateProgressBar(int i)
        {
            if (i == progressBar1.Maximum)
            {
                progressBar1.Maximum = i + 1;
                progressBar1.Value = i + 1;
                progressBar1.Maximum = i;
            }
            else
            {
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = i;
            
        }
        
        private async void ButtonPredict_Click(object sender, EventArgs e)
        {
            if (_predictions.Count == 0)
            {
                if (language == "rus")
                {
                    textBox1.Text = TranslateRusEng.Russian["Empty predicts"]; ;
                }
                else
                {
                    textBox1.Text = TranslateRusEng.English["Empty predicts"];
                }
                return;
            }

            bPredict.Enabled = false;

            if (language == "rus")
            {
                textBox1.Text = TranslateRusEng.Russian["Predict."]; ;
            }
            else
            {
                textBox1.Text = TranslateRusEng.English["Predict."];
            }

            progressBar1.Focus();

            await Task.Run(() =>
            {
                
                for (int i = 0; i <= 100; i++)
                {
                    Invoke(new Action(() =>
                    {
                        UpdateProgressBar(i);
                    }));
                    Thread.Sleep(10);                   
                }

            });

            int rnd = _random.Next(_predictions.Count);
            textBox1.Text = _predictions[rnd];

            progressBar1.Value = 0;
            bPredict.Enabled = true;
        }

        private void LoadCases()
        {
            try
            {
                _predictions = _fileIOService.LoadData();
                listBox1.DataSource = _predictions;
            }
            catch { }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string newCases = textBox2.Text;
                if (newCases != "")
                {
                    _predictions.Add(newCases);
                    _fileIOService.SaveData(_predictions);
                    textBox2.Clear();
                }                
            }
            catch { }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfListBox = listBox1.SelectedIndex;
                _predictions.RemoveAt(indexOfListBox);
                _fileIOService.SaveData(_predictions);

            }
            catch { }   
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (language == "rus")
            {
                MessageBox.Show(TranslateRusEng.Russian["Help Message"]);
            }
            else
            {
                MessageBox.Show(TranslateRusEng.English["Help Message"]);
            }
        }

        private void RussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            language = "rus";
            textBox1.Text = TranslateRusEng.Russian["Initial Text"];

            bPredict.Text = TranslateRusEng.TranslateRus("Predict");
            buttonAdd.Text = TranslateRusEng.TranslateRus("Add");
            buttonDelete.Text = TranslateRusEng.TranslateRus("Delete");
            tabPage1.Text = TranslateRusEng.TranslateRus("Main Tab");
            tabPage2.Text = TranslateRusEng.TranslateRus("Edit");
            languageToolStripMenuItem.Text = TranslateRusEng.TranslateRus("Language");
            helpToolStripMenuItem.Text = TranslateRusEng.TranslateRus("Help");
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            language = "eng";
            textBox1.Text = TranslateRusEng.English["Initial Text"];

            bPredict.Text = TranslateRusEng.TranslateEng("Predict");
            buttonAdd.Text = TranslateRusEng.TranslateEng("Add");
            buttonDelete.Text = TranslateRusEng.TranslateEng("Delete");
            tabPage1.Text = TranslateRusEng.TranslateEng("Main Tab");
            tabPage2.Text = TranslateRusEng.TranslateEng("Edit");
            languageToolStripMenuItem.Text = TranslateRusEng.TranslateEng("Language");
            helpToolStripMenuItem.Text = TranslateRusEng.TranslateEng("Help");
        }

    }
}
