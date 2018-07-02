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
    public partial class FormHill : Form
    {
        public FormHill()
        {
            InitializeComponent();
        }
        private static FormHill f;
        public static FormHill fd
        {
            get
            {
                if (f == null || f.IsDisposed) f = new FormHill();
                return f;
            }
        }

        public void ShowForm()
        {
            Show();
            Activate();
        }

        int len_textBoxA; //длина ключа
        string alphabet = "abcdefghijklmnopqrstuvwxyz .,";
        int kod_p = 26, kod_t = 27, kod_z = 28, d;

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

        int det(int[,] mas, int r) //расчет детерминанта
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
                }
            for (int i = 0; i < r; i++)
                for (int j = 0; j < r; j++)
                {
                    while (mas_new[i, j] < 0)
                        mas_new[i, j] = mas_new[i, j] + 29;
                }
        }

        int obra(int a) // Обратный элемент в кольце по модулю
        {
            int oa = 1;
            while ((a * oa) % 29 != 1)
                oa++;
            return oa;
        }

        private void buttonCrypt_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxOut.Clear();
                int rang_key = (int)Math.Sqrt(len_textBoxA);
                int lng_In= richTextBoxIn.Text.Length;
                string In = richTextBoxIn.Text;
                bool f2 = true;
                if ((lng_In % rang_key != 0)) //Проверка исходного текста на деление на блоки
                {
                    int dobl = 0;
                    do
                    {
                        int i = 0;
                        In = In + ' ';
                        i++;
                        dobl = i;
                        lng_In++;
                    }
                    while ((lng_In % rang_key != 0));
                    MessageBox.Show("К исходному тексту было добавлено " + dobl + " пробелов.");
                }
                else
                    for (int i = 0; i < lng_In; i++)
                        if (alphabet.IndexOf(In[i]) == -1)
                            f2 = false;
                if (f2 == false)
                    MessageBox.Show("Ключ некоректен");
                else
                {
                    int rang_textBoxA = rang_key;
                    int t = 0;
                    int[,] mass_textBoxA = new int[rang_textBoxA, rang_textBoxA];
                    int[,] text = new int[(int)(lng_In / rang_textBoxA), rang_textBoxA];
                    for (int i = 0; i < rang_textBoxA; i++) //Создание матрицы ключа
                        for (int j = 0; j < rang_textBoxA; j++)
                        {
                            if (textBoxA.Text[t] == '.')
                                mass_textBoxA[i, j] = kod_t;
                            else
                                if (textBoxA.Text[t] == ',')
                                    mass_textBoxA[i, j] = kod_z;
                                else
                                    if (textBoxA.Text[t] == ' ')
                                        mass_textBoxA[i, j] = kod_p;
                                    else
                                        mass_textBoxA[i, j] = (Convert.ToInt32(textBoxA.Text[t]) - 97);
                            t++;
                        }
                    t = 0;
                    for (int i = 0; i < (int)(lng_In / rang_textBoxA); i++) //Создание матрицы исходного текста
                        for (int j = 0; j < rang_textBoxA; j++)
                        {
                            if (In[t] == '.')
                                text[i, j] = kod_t;
                            else
                                if (In[t] == ',')
                                    text[i, j] = kod_z;
                                else
                                    if (In[t] == ' ')
                                        text[i, j] = kod_p;
                                    else
                                        text[i, j] = (Convert.ToInt32(In[t]) - 97);
                            t++;
                        }
                    int i1 = 0;
                    t = 0;
                    int[,] crypt_text = new int[(int)(lng_In / rang_textBoxA), rang_textBoxA];
                    while (i1 < (int)(lng_In / rang_textBoxA)) //Перемножение матриц
                    {
                        for (int i = 0; i < rang_textBoxA; i++)
                        {
                            for (int j = 0; j < rang_textBoxA; j++)
                            {
                                crypt_text[i1, i] = crypt_text[i1, i] + mass_textBoxA[i, j] * text[i1, j];
                            }
                            crypt_text[i1, i] = crypt_text[i1, i] % 29;
                        }
                        i1++;
                    }
                    int[] test = new int[(int)lng_In];
                    for (int i = 0; i < (int)(lng_In / rang_textBoxA); i++)
                        for (int j = 0; j < rang_textBoxA; j++)
                        {
                            test[t] = crypt_text[i, j]; //Запись в вектор
                            t++;
                        }
                    for (int i = 0; i < lng_In; i++)
                    {
                        if (test[i] == 26)
                            richTextBoxOut.Text += ' ';
                        else
                            if (test[i] == 27)
                                richTextBoxOut.Text += '.';
                            else
                                if (test[i] == 28)
                                    richTextBoxOut.Text += ',';
                                else
                                    richTextBoxOut.Text += Convert.ToChar(test[i] + 97);
                    }
                }
                richTextBoxIn.Text = In;
            }
            catch { MessageBox.Show("Ошибка!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            int rang_key = (int)Math.Sqrt(len_textBoxA);
            bool f1 = true, f2 = true;
            len_textBoxA = textBoxA.Text.Length;
            if (Math.Sqrt(textBoxA.Text.Length)%1!=0) //Проверка на nxn
                f1 = false;
            else
                for (int i = 0; i < len_textBoxA; i++)
                    if (alphabet.IndexOf(textBoxA.Text[i]) == -1) //Проверка на цифры и сторонние символы
                        f2 = false;
            if ((f2 == false) || (f1 == false))
                MessageBox.Show("Ключ некорректен");
            else
            {
                int[,] mass_textBoxA = new int[rang_key, rang_key];
                int t = 0;
                for (int i = 0; i < rang_key; i++)
                    for (int j = 0; j < rang_key; j++)
                    {
                        if (textBoxA.Text[t] == '.')
                            mass_textBoxA[i, j] = kod_t;
                        else
                            if (textBoxA.Text[t] == ',')
                                mass_textBoxA[i, j] = kod_z;
                            else
                                if (textBoxA.Text[t] == ' ')
                                    mass_textBoxA[i, j] = kod_p;
                                else
                                    mass_textBoxA[i, j] = (Convert.ToInt32(textBoxA.Text[t]) - 97);
                        t++;
                    }
                d = det(mass_textBoxA, rang_key);
                if (d == 0)
                    MessageBox.Show("Ключ некорректен");
                else
                {
                    MessageBox.Show("Ключ подошел");
                }
            }
        }

        private void buttonUncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxIn.Clear();
                int rang_key = (int)Math.Sqrt(len_textBoxA);
                bool f1 = true, f2 = true;
                if ((richTextBoxOut.Text.Length % rang_key != 0))
                    f1 = false;
                else
                    for (int i = 0; i < richTextBoxOut.Text.Length; i++)
                        if (alphabet.IndexOf(richTextBoxOut.Text[i]) == -1)
                            f2 = false;
                if ((f2 == false) || (f1 == false))
                    MessageBox.Show("Введен неверный шифр текст");
                else
                {
                    int t = 0;
                    int[,] mass_textBoxA = new int[rang_key, rang_key]; //Матрица ключа
                    int[,] text = new int[(int)(richTextBoxOut.Text.Length / rang_key), rang_key]; //Матрица шифр текста
                    for (int i = 0; i < rang_key; i++)
                        for (int j = 0; j < rang_key; j++)
                        {
                            if (textBoxA.Text[t] == '.')
                                mass_textBoxA[i, j] = kod_t;
                            else
                                if (textBoxA.Text[t] == ',')
                                    mass_textBoxA[i, j] = kod_z;
                                else
                                    if (textBoxA.Text[t] == ' ')
                                        mass_textBoxA[i, j] = kod_p;
                                    else
                                        mass_textBoxA[i, j] = (Convert.ToInt32(textBoxA.Text[t]) - 97);
                            t++;
                        }
                    while (d < 0)
                    {
                        d += 29;
                    }
                    int[,] obr_mass_textBoxA = new int[rang_key, rang_key];
                    obr_matx(mass_textBoxA, obr_mass_textBoxA, rang_key, obra(d)); //получение обратной матрицы
                    t = 0;
                    for (int i = 0; i < (int)(richTextBoxOut.Text.Length / rang_key); i++)
                        for (int j = 0; j < rang_key; j++)
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
                    int i1 = 0;
                    t = 0;
                    int[,] crypt_text = new int[(int)(richTextBoxOut.Text.Length / rang_key), rang_key]; ;
                    while (i1 < (int)(richTextBoxOut.Text.Length / rang_key))
                    {
                        for (int i = 0; i < rang_key; i++)
                        {
                            for (int j = 0; j < rang_key; j++)
                            {
                                crypt_text[i1, i] = crypt_text[i1, i] + obr_mass_textBoxA[i, j] * text[i1, j]; //Получение матрицы исходного текста
                            }
                            crypt_text[i1, i] = crypt_text[i1, i] % 29;
                        }
                        i1++;
                    }
                    int[] test = new int[(int)richTextBoxOut.Text.Length];
                    for (int i = 0; i < (int)(richTextBoxOut.Text.Length / rang_key); i++)
                        for (int j = 0; j < rang_key; j++)
                        {
                            test[t] = crypt_text[i, j]; //Создание вектора исходного текста
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
    }
}
