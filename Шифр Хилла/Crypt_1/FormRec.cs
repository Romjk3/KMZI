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
            try
            {
                richTextBoxOut.Clear();
                int lng_In = richTextBoxIn.Text.Length;
                bool f1 = true, f2 = true;
                if ((richTextBoxIn.Text.Length % (int)Math.Sqrt(len_key) != 0))
                {
                    int dobl = 0;
                    do
                    {
                        int i = 0;
                        richTextBoxIn.Text = richTextBoxIn.Text + ' ';
                        i++;
                        dobl = i;
                        lng_In++;
                    }
                    while ((lng_In % (int)Math.Sqrt(len_key) != 0));
                    MessageBox.Show("К исходному тексту было добавлено " + dobl + " пробелов.");
                }
                else
                    for (int i = 0; i < richTextBoxIn.Text.Length; i++)
                        if (alph.IndexOf(richTextBoxIn.Text[i]) == -1)
                            f2 = false;
                if (f2 == false)
                    MessageBox.Show("Некоректные ключи");
                else
                {
                    int[,] mass_textBoxAlpha1 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    int t = 0;
                    for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (textBoxAlpha1.Text[t] == ' ')
                                mass_textBoxAlpha1[i, j] = kod_p;
                            else
                                if (textBoxAlpha1.Text[t] == '.')
                                    mass_textBoxAlpha1[i, j] = kod_t;
                                else
                                    if (textBoxAlpha1.Text[t] == ',')
                                        mass_textBoxAlpha1[i, j] = kod_z;
                                    else
                                        mass_textBoxAlpha1[i, j] = (Convert.ToInt32(textBoxAlpha1.Text[t]) - 97);
                            t++;
                        }
                    int[,] mass_textBoxAlpha2 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    t = 0;
                    for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (textBoxAlpha2.Text[t] == ' ')
                                mass_textBoxAlpha2[i, j] = kod_p;
                            else
                                if (textBoxAlpha2.Text[t] == '.')
                                    mass_textBoxAlpha2[i, j] = kod_t;
                                else
                                    if (textBoxAlpha2.Text[t] == ',')
                                        mass_textBoxAlpha2[i, j] = kod_z;
                                    else
                                        mass_textBoxAlpha2[i, j] = (Convert.ToInt32(textBoxAlpha2.Text[t]) - 97);
                            t++;
                        }
                    int[,] text = new int[(int)(richTextBoxIn.Text.Length / (int)Math.Sqrt(len_key)), (int)Math.Sqrt(len_key)];
                    t = 0;
                    for (int i = 0; i < (int)(richTextBoxIn.Text.Length / (int)Math.Sqrt(len_key)); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (richTextBoxIn.Text[t] == '.')
                                text[i, j] = kod_t;
                            else
                                if (richTextBoxIn.Text[t] == ',')
                                    text[i, j] = kod_z;
                                else
                                    if (richTextBoxIn.Text[t] == ' ')
                                        text[i, j] = kod_p;
                                    else
                                        text[i, j] = (Convert.ToInt32(richTextBoxIn.Text[t]) - 97);
                            t++;
                        }
                    int i1 = 0;
                    t = 0;
                    int[,] crypt_text = new int[(int)(richTextBoxIn.Text.Length / (int)Math.Sqrt(len_key)), (int)Math.Sqrt(len_key)];
                    int[,] mass_key_t = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    while (i1 < (int)(richTextBoxIn.Text.Length / (int)Math.Sqrt(len_key)))
                    {
                        for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        {
                            for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                            {
                                crypt_text[i1, i] = crypt_text[i1, i] + mass_textBoxAlpha1[i, j] * text[i1, j];
                            }
                            crypt_text[i1, i] = crypt_text[i1, i] % 29;
                        }
                        i1++;
                        um_matx(mass_textBoxAlpha1, mass_textBoxAlpha2, (int)Math.Sqrt(len_key), mass_key_t);
                        swap_mas(mass_textBoxAlpha1, mass_textBoxAlpha2, (int)Math.Sqrt(len_key));
                        swap_mas(mass_key_t, mass_textBoxAlpha2, (int)Math.Sqrt(len_key));
                        for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                            for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                                mass_key_t[i, j] = 0;

                    }
                    int[] test = new int[(int)richTextBoxIn.Text.Length];
                    for (int i = 0; i < (int)(richTextBoxIn.Text.Length / (int)Math.Sqrt(len_key)); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            test[t] = crypt_text[i, j];
                            t++;
                        }
                    for (int i = 0; i < richTextBoxIn.Text.Length; i++)
                    {
                        if (test[i] == 27)
                            richTextBoxOut.Text += '.';
                        else
                            if (test[i] == 28)
                                richTextBoxOut.Text += ',';
                            else
                                if (test[i] == 26)
                                    richTextBoxOut.Text += ' ';
                                else
                                    richTextBoxOut.Text += Convert.ToChar(test[i] + 97);
                    }
                }
            }
            catch { MessageBox.Show("Ошибка!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonUncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxIn.Clear();
                bool f1 = true, f2 = true;
                if ((richTextBoxOut.Text.Length % (int)Math.Sqrt(len_key) != 0))
                    f1 = false;
                else
                    for (int i = 0; i < richTextBoxOut.Text.Length; i++)
                        if (alph.IndexOf(richTextBoxOut.Text[i]) == -1)
                            f2 = false;
                if ((f2 == false) || (f1 == false))
                    MessageBox.Show("Текст не бьется на блоки того же размера, что и ключевые матрицы. \nДобавьте несколько символов.");
                else
                {
                    int[,] mass_textBoxAlpha1 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    int t = 0;
                    for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (textBoxAlpha1.Text[t] == '.')
                                mass_textBoxAlpha1[i, j] = kod_t;
                            else
                                if (textBoxAlpha1.Text[t] == ',')
                                    mass_textBoxAlpha1[i, j] = kod_z;
                                else
                                    if (textBoxAlpha1.Text[t] == ' ')
                                        mass_textBoxAlpha1[i, j] = kod_p;
                                    else
                                        mass_textBoxAlpha1[i, j] = (Convert.ToInt32(textBoxAlpha1.Text[t]) - 97);
                            t++;
                        }
                    int[,] mass_textBoxAlpha2 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    t = 0;
                    for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (textBoxAlpha2.Text[t] == '.')
                                mass_textBoxAlpha2[i, j] = kod_t;
                            else
                                if (textBoxAlpha2.Text[t] == ',')
                                    mass_textBoxAlpha2[i, j] = kod_z;
                                else
                                    if (textBoxAlpha2.Text[t] == ' ')
                                        mass_textBoxAlpha2[i, j] = kod_p;
                                    else
                                        mass_textBoxAlpha2[i, j] = (Convert.ToInt32(textBoxAlpha2.Text[t]) - 97);
                            t++;
                        }
                    int[,] text = new int[(int)(richTextBoxOut.Text.Length / (int)Math.Sqrt(len_key)), (int)Math.Sqrt(len_key)];
                    t = 0;
                    for (int i = 0; i < (int)(richTextBoxOut.Text.Length / (int)Math.Sqrt(len_key)); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (richTextBoxOut.Text[t] == '.')
                                text[i, j] = kod_t;
                            else
                                if (richTextBoxOut.Text[t] == ',')
                                    text[i, j] = kod_z;
                                else
                                    if (richTextBoxOut.Text[t] == ' ')
                                        text[i, j] = kod_p;
                                    else
                                        text[i, j] = (Convert.ToInt32(richTextBoxOut.Text[t]) - 97);
                            t++;
                        }
                    while (d_1 < 0)
                    {
                        d_1 += 29;
                    }
                    while (d_2 < 0)
                    {
                        d_2 += 29;
                    }
                    int[,] obr_mass_textBoxAlpha1 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    obr_matx(mass_textBoxAlpha1, obr_mass_textBoxAlpha1, (int)Math.Sqrt(len_key), obra(d_1));
                    int[,] obr_mass_textBoxAlpha2 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    obr_matx(mass_textBoxAlpha2, obr_mass_textBoxAlpha2, (int)Math.Sqrt(len_key), obra(d_2));
                    int i1 = 0;
                    t = 0;
                    int[,] crypt_text = new int[(int)(richTextBoxOut.Text.Length / (int)Math.Sqrt(len_key)), (int)Math.Sqrt(len_key)];
                    int[,] mass_key_t = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    while (i1 < (int)(richTextBoxOut.Text.Length / (int)Math.Sqrt(len_key)))
                    {
                        for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        {
                            for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                            {
                                crypt_text[i1, i] = crypt_text[i1, i] + obr_mass_textBoxAlpha1[i, j] * text[i1, j];
                            }
                            //!!!
                            crypt_text[i1, i] = crypt_text[i1, i] % 29;
                        }
                        i1++;
                        um_matx(obr_mass_textBoxAlpha2, obr_mass_textBoxAlpha1, (int)Math.Sqrt(len_key), mass_key_t);
                        swap_mas(obr_mass_textBoxAlpha1, obr_mass_textBoxAlpha2, (int)Math.Sqrt(len_key));
                        swap_mas(mass_key_t, obr_mass_textBoxAlpha2, (int)Math.Sqrt(len_key));
                        for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                            for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                                mass_key_t[i, j] = 0;

                    }
                    int[] test = new int[(int)richTextBoxOut.Text.Length];
                    for (int i = 0; i < (int)(richTextBoxOut.Text.Length / (int)Math.Sqrt(len_key)); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            test[t] = crypt_text[i, j];
                            t++;
                        }
                    for (int i = 0; i < richTextBoxOut.Text.Length; i++)
                    {
                        if (test[i] == 26)
                            richTextBoxIn.Text += ' ';
                        else
                            if (test[i] == 27)
                                richTextBoxIn.Text += '.';
                            else
                                if (test[i] == 28)
                                    richTextBoxIn.Text += ',';
                                else
                                    richTextBoxIn.Text += Convert.ToChar(test[i] + 97);
                    }
                }
            }
            catch { MessageBox.Show("Ошибка!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        int len_key, len_textBoxAlpha2;
        string alph = "abcdefghijklmnopqrstuvwxyz .,";
        int kod_t = 27, kod_z = 28, kod_p = 26, d_1, d_2;


        void get_matx(int[,] mas, int[,] p, int i, int j, int r)
        {
            int ki, kj, di, dj;
            di = 0;
            for (ki = 0; ki < r - 1; ki++)
            { // проверка индекса строки
                if (ki == i) di = 1;
                dj = 0;
                for (kj = 0; kj < r - 1; kj++)
                { // проверка индекса столбца
                    if (kj == j) dj = 1;
                    p[ki, kj] = mas[ki + di, kj + dj];
                }
            }
        }

        int det(int[,] mas, int r)
        {
            int i, d, k, n;
            int[,] p = new int[r, r];
            d = 0;
            k = 1; //(-1) в степени i
            n = r - 1;
            if (r == 2)
            {
                d = mas[0, 0] * mas[1, 1] - (mas[1, 0] * mas[0, 1]);
                return (d);
            }
            if (r > 2)
            {
                for (i = 0; i < r; i++)
                {
                    get_matx(mas, p, i, 0, r);
                    d = d + k * mas[i, 0] * det(p, n);
                    k = -k;
                }
            }
            return (d);
        }

        void transp_matx(int[,] mas, int[,] p, int r)
        {
            for (int i = 0; i < r; i++)
                for (int j = 0; j < r; j++)
                    p[i, j] = mas[j, i];
        }

        void souz_2(int[,] mas, int[,] p)
        {
            p[0, 0] = mas[1, 1];
            p[0, 1] = mas[1, 0];
            p[1, 0] = mas[0, 1];
            p[1, 1] = mas[0, 0];
        }

        void obr_matx(int[,] mas, int[,] mas_new, int r, int d)
        {
            int[,] test = new int[r, r];
            int[,] test_n = new int[r, r];
            if (r > 2)
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        get_matx(mas, test_n, i, j, r);
                        test[i, j] = det(test_n, r - 1);
                    }
                }
            else
                souz_2(mas, test);
            transp_matx(test, test_n, r);
            int k;
            for (int i = 0; i < r; i++)
                for (int j = 0; j < r; j++)
                {
                    if ((i + j) % 2 == 0)
                        k = 1;
                    else k = -1;
                    mas_new[i, j] = k * test_n[i, j] * d;
                    //k = k * (-1);
                }
            for (int i = 0; i < r; i++)
                for (int j = 0; j < r; j++)
                {
                    while (mas_new[i, j] < 0)
                        mas_new[i, j] = mas_new[i, j] + 29;
                }
        }

        int obra(int a)
        {
            int oa = 1;
            while ((a * oa) % 29 != 1)
                oa++;
            return oa;
        }

        void um_matx(int[,] mas1, int[,] mas2, int il, int[,] masr)
        {
            int i1 = 0;
            while (i1 < il)
            {
                for (int i = 0; i < il; i++)
                {
                    for (int j = 0; j < il; j++)
                    {
                        masr[i1, i] = masr[i1, i] + mas1[i1, j] * mas2[j, i];
                    }
                    masr[i1, i] = masr[i1, i] % 29;
                }
                i1++;
            }
        }

        void swap_mas(int[,] mas1, int[,] mas2, int il)
        {
            int[,] mast = new int[il, il];
            for (int i = 0; i < il; i++)
                for (int j = 0; j < il; j++)
                    mast[i, j] = mas2[i, j];
            for (int i = 0; i < il; i++)
                for (int j = 0; j < il; j++)
                    mas2[i, j] = mas1[i, j];
            for (int i = 0; i < il; i++)
                for (int j = 0; j < il; j++)
                    mas1[i, j] = mast[i, j];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool f1 = true, f2 = true, f3 = true, f4 = true;
            len_key = textBoxAlpha1.Text.Length;
            len_textBoxAlpha2 = textBoxAlpha2.Text.Length;
            if ((textBoxAlpha1.Text.Length != 4) && (textBoxAlpha1.Text.Length != 9) && (textBoxAlpha1.Text.Length != 16) && (textBoxAlpha1.Text.Length != 25) && (textBoxAlpha1.Text.Length != 36))
                f1 = false;
            else
                for (int i = 0; i < len_key; i++)
                    if (alph.IndexOf(textBoxAlpha1.Text[i]) == -1)
                        f2 = false;
            if ((textBoxAlpha2.Text.Length != 4) && (textBoxAlpha2.Text.Length != 9) && (textBoxAlpha2.Text.Length != 16) && (textBoxAlpha2.Text.Length != 25) && (textBoxAlpha2.Text.Length != 36))
                f3 = false;
            else
                for (int i = 0; i < len_textBoxAlpha2; i++)
                    if (alph.IndexOf(textBoxAlpha2.Text[i]) == -1)
                        f4 = false;
            if ((f2 == false) || (f1 == false))
                MessageBox.Show("Первый ключ некорректен");
            else
                if ((f3 == false) || (f4 == false))
                    MessageBox.Show("Второй ключ некорректен");
                else
                {
                    int[,] mass_textBoxAlpha1 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    int t = 0;
                    for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (textBoxAlpha1.Text[t] == '.')
                                mass_textBoxAlpha1[i, j] = kod_t;
                            else
                                if (textBoxAlpha1.Text[t] == ',')
                                    mass_textBoxAlpha1[i, j] = kod_z;
                                else
                                    if (textBoxAlpha1.Text[t] == ' ')
                                        mass_textBoxAlpha1[i, j] = kod_p;
                                    else
                                        mass_textBoxAlpha1[i, j] = (Convert.ToInt32(textBoxAlpha1.Text[t]) - 97);
                            t++;
                        }
                    int[,] mass_textBoxAlpha2 = new int[(int)Math.Sqrt(len_key), (int)Math.Sqrt(len_key)];
                    t = 0;
                    for (int i = 0; i < (int)Math.Sqrt(len_key); i++)
                        for (int j = 0; j < (int)Math.Sqrt(len_key); j++)
                        {
                            if (textBoxAlpha2.Text[t] == '.')
                                mass_textBoxAlpha2[i, j] = kod_t;
                            else
                                if (textBoxAlpha2.Text[t] == ',')
                                    mass_textBoxAlpha2[i, j] = kod_z;
                                else
                                    if (textBoxAlpha2.Text[t] == ' ')
                                        mass_textBoxAlpha2[i, j] = kod_p;
                                    else
                                        mass_textBoxAlpha2[i, j] = (Convert.ToInt32(textBoxAlpha2.Text[t]) - 97);
                            t++;
                        }

                    d_1 = det(mass_textBoxAlpha1, (int)Math.Sqrt(len_key));
                    d_2 = det(mass_textBoxAlpha2, (int)Math.Sqrt(len_key));
                    if (d_1 == 0)
                        MessageBox.Show("Первый ключ некорректен");
                    else
                        if (d_2 == 0)
                            MessageBox.Show("Второй ключ некорректен");
                        else
                        {
                            MessageBox.Show("Ключи подошли");
                        }
                }
        }
    }
}
