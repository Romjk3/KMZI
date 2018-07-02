using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                InputText.Text = InputText.Text.ToLower();
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                string binary_block= "", binary_block_last = "", binary_letter = "", binary_text = "";
                int n = 0, F = 0, k = 0;
                int p = Convert.ToInt32(PTextBox.Text);
                int q = Convert.ToInt32(QTextBox.Text);
                int E = Convert.ToInt32(ETextBox.Text);
                OutputText.Clear();
                n = p * q;
                F = (p - 1) * (q - 1);

                //Проверка p и q на простоту
                int a = 0, b = 0;
                for (int i = 1; i <= p; i++)
                { if (p % i == 0) { a++; } }
                for (int i = 1; i <= q; i++)
                { if (q % i == 0) { b++; } }
                if (q == p)
                {
                    MessageBox.Show("p=q!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    QTextBox.Clear(); PTextBox.Clear();
                }
                else
                {
                    //проверка e
                    int nod = 0;
                    for (int i = 1; i <= F; i++)
                    { if ((E % i == 0) && (F % i == 0)) { nod++; } }
                    if (nod != 1)
                    { MessageBox.Show("Введена некорректная экспонента зашифрования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ETextBox.Clear(); E = 0; }
                    else
                    {
                        int n1 = n;
                        // переведем n в двоичную, дабы определить необходимые размеры блоков
                        while (n1 != 0)
                        {
                            binary_letter = binary_letter + Convert.ToString(n1 % 2);
                            n1 = n1 / 2;
                        }
                        int length_of_block = binary_letter.Length - 1;

                        /* Теперь заменяем каждую букву соответствующим элементом 
                         кольца классов вычетов по модулю 26 и переводим получившееся число
                         в двоичную `систему счисления*/
                        for (int i = 0; i <= InputText.Text.Length - 1; i++)
                        {
                            if (alphabet.IndexOf(InputText.Text[i]) != -1)
                            {
                                //если символ - буква - работаем
                                int j = alphabet.IndexOf(InputText.Text[k]) % 26;
                                binary_letter = "";

                                // Погнали переводить в двоичную систему
                                while (j != 0)
                                {
                                    binary_letter = binary_letter + Convert.ToString(j % 2);
                                    j = j / 2;
                                }

                                /*предусматриваем случай, если длина битового слова < 5 
                                добавляем незначащие нули, пока длина не станет равна 5 */
                                while (binary_letter.Length < 5)
                                { binary_letter = binary_letter + "0"; }

                                //инициализировали бинарный текст
                                binary_text = binary_text.Insert(0, binary_letter);
                                k++;
                            }
                            // Иначе просто пропускаем символ
                            else { k++; }
                        }
                        //самое время побить бинарный текст на блоки длиной length_of block
                        for (int i = 0; i <= binary_text.Length - 1; i = i + length_of_block)
                        {
                            if (i + length_of_block <= binary_text.Length - 1)
                            {
                                double dec_block = 0, crypt_dec_block = 1;
                                binary_block = binary_text.Substring(i, length_of_block);
                                //сразу переводим блок в дек систему
                                for (int l = 0; l <= binary_block.Length - 1; l++)
                                {
                                    int arg = 2 * (Convert.ToInt32(binary_block[l]) - 48);
                                    if (arg != 0) { dec_block = dec_block + Math.Pow(arg, l); }
                                }
                                for (int h = 1; h <= E; h++)
                                { crypt_dec_block = (crypt_dec_block * dec_block) % n; }
                                OutputText.Text = " " + OutputText.Text.Insert(0, Convert.ToString(crypt_dec_block));

                            }
                            else
                            {
                                // Последний блок
                                binary_block_last = binary_text.Substring(i, binary_text.Length - i);
                                double dec_block_last = 0, crypt_dec_block_last = 1;
                                //сразу переводим блок в дек систему
                                for (int l = 0; l <= binary_block_last.Length - 1; l++)
                                {
                                    int arg = 2 * (Convert.ToInt32(binary_block_last[l]) - 48);
                                    if (arg != 0) { dec_block_last = dec_block_last + Math.Pow(arg, l); }
                                }
                                for (int h = 1; h <= E; h++)
                                {
                                    crypt_dec_block_last = (crypt_dec_block_last * dec_block_last) % n;
                                }
                                OutputText.Text = OutputText.Text.Insert(0, Convert.ToString(crypt_dec_block_last));
                            }
                        }
                    }
                }
            }
            catch { MessageBox.Show("Ошибка!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void DButton_Click(object sender, EventArgs e)
        {
            try
            {
                int F = 0, d = 0, a = 0, b = 0;
                int p = Convert.ToInt32(PTextBox.Text);
                int q = Convert.ToInt32(QTextBox.Text);
                int E = Convert.ToInt32(ETextBox.Text);
                F = (p - 1) * (q - 1);
                //Проверка p и q на простоту
                for (int i = 1; i <= p; i++)
                { if (p % i == 0) { a++; } }
                for (int i = 1; i <= q; i++)
                { if (q % i == 0) { b++; } }
                if (p == q)
                {
                    MessageBox.Show("Рассчитать экспоненту расшифрования невозможно. p=q!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    QTextBox.Clear(); PTextBox.Clear();
                }
                else
                {
                    if ((a != 2) || (b != 2))
                    {
                        MessageBox.Show("Рассчитать экспоненту расшифрования невозможно. Может быть, введенные числа не простые", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        QTextBox.Clear(); PTextBox.Clear();
                    }
                    else
                    {
                        //проверка e
                        int nod = 0;
                        for (int i = 1; i <= F; i++)
                        { if ((E % i == 0) && (F % i == 0)) { nod++; } }
                        if (nod != 1)
                        { MessageBox.Show("Рассчитать экспоненту расшифрования невозможно. Введена некорректная экспонента зашифрования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ETextBox.Clear(); E = 0; }
                        else
                        {
                            // задаем экспоненту расшифрования
                            while (((E * d) % F) != 1)
                            {
                                d++;
                            }
                            DTextBox.Text = Convert.ToString(d);
                        }
                    }
                }
            }
            catch { MessageBox.Show("Ошибка!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                OutputText.Clear();
                string numbers = "1234567890", alphabet = "abcdefghijklmnopqrstuvwxyz";
                string binary_block = "", str_crypt_dec_block = "", binary_text = "", binary_letter = "";
                int n = 0, k = 0, crypt_dec_block = 0, count = 0; ;
                double numb_of_letter = 0;
                int p = Convert.ToInt32(PTextBox.Text);
                int q = Convert.ToInt32(QTextBox.Text);
                int d = Convert.ToInt32(DTextBox.Text);
                n = p * q;
                InputText.Text = InputText.Text + " ";
                int n1 = n;
                // переведем n в двоичную, дабы определить необходимые размеры блоков
                while (n1 != 0)
                {
                    binary_letter = binary_letter + Convert.ToString(n1 % 2);
                    n1 = n1 / 2;
                }
                int length_of_block = binary_letter.Length - 1;
                binary_letter = "";
                for (int i = 0; i <= InputText.Text.Length - 1; i++)
                {
                    if (numbers.IndexOf(InputText.Text[i]) != -1)
                    //если символ строки - цифра, то наполняем переменную str_crypt_dec_block
                    {str_crypt_dec_block = str_crypt_dec_block + InputText.Text[k]; k++; }
                    else
                    {
                        count++;
                        crypt_dec_block = int.Parse(Convert.ToString(InputText.Text[k]));
                        k++;
                        str_crypt_dec_block = "";
                        int decrypt_dec_block = 1;
                        // Расшифрование блока  в десятичной системе
                        for (int h = 1; h <= d; h++)
                        {
                            decrypt_dec_block = (decrypt_dec_block * crypt_dec_block) % n;
                            OutputText.Text = "3";
                        }

                        //Перевод найденного блока в бинарную систему
                        while (decrypt_dec_block != 0)
                        {
                            binary_block = binary_block + Convert.ToString(decrypt_dec_block % 2);
                            decrypt_dec_block = decrypt_dec_block / 2;
                        }

                        //если был не первый блок, то добавляем незначащие нули, пока длина блока не станет нужной
                        if (count != 1)
                        {
                            while (binary_block.Length < length_of_block)
                            { binary_block = binary_block + "0"; }
                        }
                        binary_text = binary_text.Insert(0, Convert.ToString(binary_block));
                        binary_block = "";
                        k++;
                        OutputText.Text = "5";
                    }
                }
                while (binary_text.Length % 5 != 0) { binary_text = binary_text + "0"; }
                for (int i = 0; i <= binary_text.Length - 1; i = i + 5)
                {
                    binary_letter = binary_text.Substring(i, 5);
                    numb_of_letter = 0;
                    for (int l = 0; l <= binary_letter.Length - 1; l++)
                    {
                        int arg = 2 * (Convert.ToInt32(binary_letter[l]) - 48);
                        if (arg == 0) { numb_of_letter = numb_of_letter + 0; }
                        else { numb_of_letter = numb_of_letter + Math.Pow(arg, l); }
                    }
                  OutputText.Text = OutputText.Text.Insert(0, Convert.ToString(alphabet[Convert.ToInt32(numb_of_letter)]));
                }
            }
            catch
            {
                OutputText.Text = InputText.Text;
            }
        }

    }
}