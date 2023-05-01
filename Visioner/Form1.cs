using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Visioner
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        private List<string> cases = new List<string>() { "Kek", "Lol", "Cheburek" };

        public Form1()
        {
            InitializeComponent();
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
        
        private async void bPredict_Click(object sender, EventArgs e)
        {
            bPredict.Enabled = false;
            textBox1.Text = ("Гадаю...");
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
            textBox1.Text = ("");
            int rnd = _random.Next(cases.Count);
            MessageBox.Show(cases[rnd].ToString());

            bPredict.Enabled = true;
        }
        private void btnEditList_Click(object sender, EventArgs e)
        {
            
            EditCasesForm secondForm = new EditCasesForm(cases);
            secondForm.Show();
        }


        private void buttonSpravka_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Хули тут непонятного? Тыкаешь на кнопку, прога предсказывает твоё будущее. Не злоупотреблять, отвалятся яйца. Если ты девочка, отвалятся твои девчачьи яйца!");
        }

        
    }


}