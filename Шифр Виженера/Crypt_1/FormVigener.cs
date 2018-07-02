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
    public partial class FormVigener : Form
    {
        public FormVigener()
        {
            InitializeComponent();
        }
        private static FormVigener f;
        public static FormVigener fd
        {
            get
            {
                if (f == null || f.IsDisposed) f = new FormVigener();
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
            string alphabet = "abcdefghijklmnopqrstuvwxyz ";
            string alphabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            richTextBoxOut.Text = "";
            if (richTextBoxIn.Text.Length == 0)
            {
                MessageBox.Show("Введите исходный текст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string Key = textBoxA.Text;
                Key = Key.ToUpper();
                if (Key.Length == 0)
                {
                    throw new Exception();
                }
                for (int i = 0; i <= richTextBoxIn.Text.Length - 1; i++)
                {
                    if (alphabetUp.IndexOf(richTextBoxIn.Text[i]) != -1)
                    {
                        int buf = alphabetUp.IndexOf(richTextBoxIn.Text[i]);
                        int buf_key = alphabetUp.IndexOf(Key[i%Key.Length]);
                        buf = (buf + buf_key) % 27;
                        richTextBoxOut.Text = richTextBoxOut.Text + alphabetUp[buf];
                    }
                    else
                    {
                        if (alphabet.IndexOf(richTextBoxIn.Text[i]) != -1)
                        {
                            int buf = alphabet.IndexOf(richTextBoxIn.Text[i]);
                            int buf_key = alphabetUp.IndexOf(Key[i % Key.Length]);
                            buf = (buf + buf_key) % 27;
                            richTextBoxOut.Text = richTextBoxOut.Text + alphabet[buf];
                        }
                        else { richTextBoxOut.Text = richTextBoxOut.Text + richTextBoxIn.Text[i]; }
                    }
                }
            }
            catch { MessageBox.Show("Введите корректный ключ шифрования!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonUncrypt_Click(object sender, EventArgs e)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz ";
            string alphabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            richTextBoxIn.Text = "";
            if (richTextBoxOut.Text.Length == 0)
            {
                MessageBox.Show("Введите шифртекст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string Key = textBoxA.Text;
                Key = Key.ToUpper();
                if (Key.Length == 0)
                {
                    throw new Exception();
                }
                for (int i = 0; i <= richTextBoxOut.Text.Length - 1; i++)
                {
                    if (alphabetUp.IndexOf(richTextBoxOut.Text[i]) != -1)
                    {
                        int buf = alphabetUp.IndexOf(richTextBoxOut.Text[i]);
                        int buf_key = alphabetUp.IndexOf(Key[i % Key.Length]);
                        if (buf < buf_key)
                        {
                            buf = 27-(buf_key - buf);
                        }
                        else
                        {
                            buf = (buf - buf_key) % 27;
                        }
                        richTextBoxIn.Text = richTextBoxIn.Text + alphabetUp[buf];
                    }
                    else
                    {
                        if (alphabet.IndexOf(richTextBoxOut.Text[i]) != -1)
                        {
                            int buf = alphabet.IndexOf(richTextBoxOut.Text[i]);
                            int buf_key = alphabetUp.IndexOf(Key[i % Key.Length]);
                            if (buf < buf_key)
                            {
                                buf = 27 - (buf_key - buf);
                            }
                            else
                            {
                                buf = (buf - buf_key) % 27;
                            }
                            richTextBoxIn.Text = richTextBoxIn.Text + alphabet[buf];
                        }
                        else { richTextBoxIn.Text = richTextBoxIn.Text + richTextBoxOut.Text[i]; }
                    }
                }
            }
            catch { MessageBox.Show("Введите корректный ключ шифрования!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonDe_Click(object sender, EventArgs e)
        {   
            int Alpha = 17;
            int Beta = 25;
            int[] arrayAlpha = new int[] { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            int[,] arrayAlphaPr = new int[3,10000];
            int num = 0;
            int[] arrayNum = new int[] { 4, 19, 0,14,8,13,18,7,17,3,11,2,20,12,22,5,6,24,15,1,21,10,23,9,16,25};
            int[,] arrayAlphabet = new int[2, 26];
            richTextBoxOut.Text = richTextBoxOut.Text.ToLower();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string alphabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i <= richTextBoxOut.Text.Length - 1; i++)
            {
                if (alphabet.IndexOf(richTextBoxOut.Text[i]) != -1)
                {
                    arrayAlphabet[0, alphabet.IndexOf(richTextBoxOut.Text[i])]++;
                    arrayAlphabet[1, alphabet.IndexOf(richTextBoxOut.Text[i])] = alphabet.IndexOf(richTextBoxOut.Text[i]);
                }
            }
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++) 
                {
                    if (arrayAlphabet[0, j] > arrayAlphabet[0, j + 1]) 
                    {
                        int a = arrayAlphabet[0, j];
                        arrayAlphabet[0, j] = arrayAlphabet[0, j + 1];
                        arrayAlphabet[0, j + 1] = a;
                        a = arrayAlphabet[1, j];
                        arrayAlphabet[1, j] = arrayAlphabet[1, j + 1];
                        arrayAlphabet[1, j + 1] = a;
                    }
                }
            }
            for (int d = 0; d < 3; d++)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (Beta = 26; Beta != 0; Beta--)
                    {
                        double buff = arrayAlpha[i];
                        for (int j = 0; j < 26; j++)
                        {
                            if ((26 * j + arrayAlphabet[1, 25-d] - Beta) / (arrayNum[d] * buff) == 1)
                            {
                                arrayAlphaPr[0, num] = arrayAlpha[i];
                                arrayAlphaPr[1, num] = Beta;
                                num++;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i <= num; i++) 
            {
                for (int j = 0; j <= num; j++)
                {
                    if ((arrayAlphaPr[0, i] == arrayAlphaPr[0, j]) && (arrayAlphaPr[1, i] == arrayAlphaPr[1, j]) && i != j)
                    {
                        arrayAlphaPr[2, i]++;
                    }
                }       
            }
            int max = arrayAlphaPr[2, 0];
            int imax = arrayAlphaPr[1, 0];
            for (int i = 1; i < num; i++) 
            {
                label4.Text = label4.Text + arrayAlphaPr[0, i].ToString();
                label4.Text = label4.Text + " ";
                label4.Text = label4.Text + arrayAlphaPr[1, i].ToString();
                label4.Text = label4.Text + " ";
                label4.Text = label4.Text + arrayAlphaPr[2, i].ToString();
                label4.Text = label4.Text + "|";
                if (max < arrayAlphaPr[2, i]) 
                {
                    max = arrayAlphaPr[2, i];
                    imax = i;
                }
            }
            label5.Text = arrayAlphaPr[0, imax] +" "+ arrayAlphaPr[1, imax];
        }
    }
}
