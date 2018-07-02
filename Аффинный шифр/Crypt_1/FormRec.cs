using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypt_1
{
    public partial class FormRec : Form
    {
        public FormRec()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private static FormRec f;
        public static FormRec fd
        {
            get
            {
                if (f == null || f.IsDisposed) f = new FormRec();
                return f;
            }
        }

        public void ShowForm()
        {
            Show();
            Activate();
        }

        private void buttonCrypt_Click(object sender, EventArgs e)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string alphabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            richTextBoxOut.Text = "";
            if (richTextBoxIn.Text.Length == 0)
            {
                MessageBox.Show("Введите исходный текст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                int Alpha1 = int.Parse(textBoxAlpha1.Text);
                int Beta1 = int.Parse(textBoxBeta1.Text);
                int Alpha2 = int.Parse(textBoxAlpha2.Text);
                int Beta2 = int.Parse(textBoxBeta2.Text);
                int [,] arrayKeys = new int [2,richTextBoxIn.Text.Length];
                arrayKeys[0,0] = Alpha1; arrayKeys[1,0] = Beta1;
                arrayKeys[0,1] = Alpha2; arrayKeys[1,1] = Beta2;
                if ((Alpha1 % 13 == 0) || (Alpha1 % 2 == 0) || (Alpha2 % 2 == 0) || (Alpha2 % 13 == 0))
                {
                    throw new Exception();
                }
                for (int i = 0; i <= richTextBoxIn.Text.Length - 1; i++)
                {
                    if (alphabetUp.IndexOf(richTextBoxIn.Text[i]) != -1)
                    {
                        if (i == 0) 
                        {
                            int buf = alphabetUp.IndexOf(richTextBoxIn.Text[i]);
                            buf = (Alpha1 * buf + Beta1) % 26;
                            richTextBoxOut.Text = richTextBoxOut.Text + alphabetUp[buf];   
                        }
                        if (i == 1) 
                        {
                            int buf = alphabetUp.IndexOf(richTextBoxIn.Text[i]);
                            buf = (Alpha2 * buf + Beta2) % 26;
                            richTextBoxOut.Text = richTextBoxOut.Text + alphabetUp[buf];                        
                        }

                        if (i > 1)
                        {
                            arrayKeys[0, i] = (arrayKeys[0, i - 1] * arrayKeys[0, i - 2]) % 26;
                            arrayKeys[1, i] = (arrayKeys[1, i - 1] + arrayKeys[1, i - 2]) % 26;
                            int buf = alphabetUp.IndexOf(richTextBoxIn.Text[i]);
                            buf = (arrayKeys[0, i] * buf + arrayKeys[1, i]) % 26;
                            richTextBoxOut.Text = richTextBoxOut.Text + alphabetUp[buf];
                        }
                    }
                    else
                    {
                        if (alphabet.IndexOf(richTextBoxIn.Text[i]) != -1)
                        {
                            if (i == 0)
                            {
                                int buf = alphabet.IndexOf(richTextBoxIn.Text[i]);
                                buf = (Alpha1 * buf + Beta1) % 26;
                                richTextBoxOut.Text = richTextBoxOut.Text + alphabet[buf];
                            }
                            if (i == 1)
                            {
                                int buf = alphabet.IndexOf(richTextBoxIn.Text[i]);
                                buf = (Alpha2 * buf + Beta2) % 26;
                                richTextBoxOut.Text = richTextBoxOut.Text + alphabet[buf];
                            }

                            if (i > 1)
                            {
                                arrayKeys[0, i] = (arrayKeys[0, i - 1] * arrayKeys[0, i - 2]) % 26;
                                arrayKeys[1, i] = (arrayKeys[1, i - 1] + arrayKeys[1, i - 2]) % 26;
                                int buf = alphabet.IndexOf(richTextBoxIn.Text[i]);
                                buf = (arrayKeys[0, i] * buf + arrayKeys[1, i]) % 26;
                                richTextBoxOut.Text = richTextBoxOut.Text + alphabet[buf];
                            }
                        }
                        else { richTextBoxOut.Text = richTextBoxOut.Text + richTextBoxIn.Text[i]; }
                    }
                }
            }
            catch { MessageBox.Show("Введите корректные ключи шифрования!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonUncrypt_Click(object sender, EventArgs e)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string alphabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            richTextBoxIn.Text = "";
            if (richTextBoxOut.Text.Length == 0)
            {
                MessageBox.Show("Введите зашифрованный текст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                int Alpha1 = int.Parse(textBoxAlpha1.Text);
                int Beta1 = int.Parse(textBoxBeta1.Text);
                int Alpha2 = int.Parse(textBoxAlpha2.Text);
                int Beta2 = int.Parse(textBoxBeta2.Text);
                int[,] arrayKeys = new int[2, richTextBoxOut.Text.Length];
                arrayKeys[0, 0] = Alpha1; arrayKeys[1, 0] = Beta1;
                arrayKeys[0, 1] = Alpha2; arrayKeys[1, 1] = Beta2;
                if ((Alpha1 % 13 == 0) || (Alpha1 % 2 == 0) || (Alpha2 % 2 == 0) || (Alpha2 % 13 == 0))
                {
                   throw new Exception();
                }
                for (int i = 0; i <= richTextBoxOut.Text.Length - 1; i++)
                {
                    if (alphabetUp.IndexOf(richTextBoxOut.Text[i]) != -1)
                    {
                        if (i == 0) 
                        {   
                            int k = 0;
                            while ((26 * k + 1) % Alpha1 != 0)
                            {
                                k++;
                            }
                            int Alphabuf = (26 * k + 1) / Alpha1;
                            int buf = alphabetUp.IndexOf(richTextBoxOut.Text[i]);
                            buf = (Alphabuf * (buf - Beta1)) % 26;
                            if (buf < 0) { buf = buf + 26; }
                            richTextBoxIn.Text = richTextBoxIn.Text + alphabetUp[buf];   
                        }
                        if (i == 1)
                        {
                            int k = 0;
                            while ((26 * k + 1) % Alpha2 != 0)
                            {
                                k++;
                            }
                            int Alphabuf = (26 * k + 1) / Alpha2;
                            int buf = alphabetUp.IndexOf(richTextBoxOut.Text[i]);
                            buf = (Alphabuf * (buf - Beta2)) % 26;
                            if (buf < 0) { buf = buf + 26; }
                            richTextBoxIn.Text = richTextBoxIn.Text + alphabetUp[buf];
                        }
                        if (i > 1)
                        {
                            arrayKeys[0, i] = (arrayKeys[0, i - 1] * arrayKeys[0, i - 2]) % 26;
                            arrayKeys[1, i] = (arrayKeys[1, i - 1] + arrayKeys[1, i - 2]) % 26;
                            int k = 0;
                            while ((26 * k + 1) % arrayKeys[0,i] != 0)
                            {
                                k++;
                            }
                            int Alphabuf = (26 * k + 1) / arrayKeys[0,i];
                            int buf = alphabetUp.IndexOf(richTextBoxOut.Text[i]);
                            buf = (Alphabuf * (buf - arrayKeys[1,i])) % 26;
                            if (buf < 0) { buf = buf + 26; }
                            richTextBoxIn.Text = richTextBoxIn.Text + alphabetUp[buf];
                        }
                    }
                    else
                    {
                        if (alphabet.IndexOf(richTextBoxOut.Text[i]) != -1)
                        {
                            if (i == 0)
                            {
                                int k = 0;
                                while ((26 * k + 1) % Alpha1 != 0)
                                {
                                    k++;
                                }
                                int Alphabuf = (26 * k + 1) / Alpha1;
                                int buf = alphabet.IndexOf(richTextBoxOut.Text[i]);
                                buf = (Alphabuf * (buf - Beta1)) % 26;
                                if (buf < 0) { buf = buf + 26; }
                                richTextBoxIn.Text = richTextBoxIn.Text + alphabet[buf];
                            }
                            if (i == 1)
                            {
                                int k = 0;
                                while ((26 * k + 1) % Alpha2 != 0)
                                {
                                    k++;
                                }
                                int Alphabuf = (26 * k + 1) / Alpha2;
                                int buf = alphabet.IndexOf(richTextBoxOut.Text[i]);
                                buf = (Alphabuf * (buf - Beta2)) % 26;
                                if (buf < 0) { buf = buf + 26; }
                                richTextBoxIn.Text = richTextBoxIn.Text + alphabet[buf];
                            }
                            if (i > 1)
                            {
                                arrayKeys[0, i] = (arrayKeys[0, i - 1] * arrayKeys[0, i - 2]) % 26;
                                arrayKeys[1, i] = (arrayKeys[1, i - 1] + arrayKeys[1, i - 2]) % 26;
                                int k = 0;
                                while ((26 * k + 1) % arrayKeys[0, i] != 0)
                                {
                                    k++;
                                }
                                int Alphabuf = (26 * k + 1) / arrayKeys[0, i];
                                int buf = alphabet.IndexOf(richTextBoxOut.Text[i]);
                                buf = (Alphabuf * (buf - arrayKeys[1, i])) % 26;
                                if (buf < 0) { buf = buf + 26; }
                                richTextBoxIn.Text = richTextBoxIn.Text + alphabet[buf];
                            }
                        }
                        else { richTextBoxIn.Text = richTextBoxIn.Text + richTextBoxOut.Text[i]; }
                    }
                }
            }
            catch { MessageBox.Show("Введите корректные ключи шифрования!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
