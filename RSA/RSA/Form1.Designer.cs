namespace RSA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CryptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PTextBox = new System.Windows.Forms.TextBox();
            this.QTextBox = new System.Windows.Forms.TextBox();
            this.ETextBox = new System.Windows.Forms.TextBox();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.InputText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DTextBox = new System.Windows.Forms.TextBox();
            this.UncryptButton = new System.Windows.Forms.Button();
            this.Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CryptButton
            // 
            this.CryptButton.Location = new System.Drawing.Point(174, 223);
            this.CryptButton.Name = "CryptButton";
            this.CryptButton.Size = new System.Drawing.Size(94, 23);
            this.CryptButton.TabIndex = 0;
            this.CryptButton.Text = "Зашифровать";
            this.CryptButton.UseVisualStyleBackColor = true;
            this.CryptButton.Click += new System.EventHandler(this.CryptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "p:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "q:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "e:";
            // 
            // PTextBox
            // 
            this.PTextBox.Location = new System.Drawing.Point(41, 35);
            this.PTextBox.Name = "PTextBox";
            this.PTextBox.Size = new System.Drawing.Size(71, 20);
            this.PTextBox.TabIndex = 4;
            // 
            // QTextBox
            // 
            this.QTextBox.Location = new System.Drawing.Point(161, 35);
            this.QTextBox.Name = "QTextBox";
            this.QTextBox.Size = new System.Drawing.Size(71, 20);
            this.QTextBox.TabIndex = 5;
            // 
            // ETextBox
            // 
            this.ETextBox.Location = new System.Drawing.Point(284, 35);
            this.ETextBox.Name = "ETextBox";
            this.ETextBox.Size = new System.Drawing.Size(71, 20);
            this.ETextBox.TabIndex = 6;
            // 
            // OutputText
            // 
            this.OutputText.Location = new System.Drawing.Point(306, 75);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputText.Size = new System.Drawing.Size(256, 132);
            this.OutputText.TabIndex = 7;
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(12, 75);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputText.Size = new System.Drawing.Size(256, 132);
            this.InputText.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(375, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "d:";
            // 
            // DTextBox
            // 
            this.DTextBox.Location = new System.Drawing.Point(397, 36);
            this.DTextBox.Name = "DTextBox";
            this.DTextBox.ReadOnly = true;
            this.DTextBox.Size = new System.Drawing.Size(71, 20);
            this.DTextBox.TabIndex = 14;
            // 
            // UncryptButton
            // 
            this.UncryptButton.Location = new System.Drawing.Point(306, 223);
            this.UncryptButton.Name = "UncryptButton";
            this.UncryptButton.Size = new System.Drawing.Size(94, 23);
            this.UncryptButton.TabIndex = 15;
            this.UncryptButton.Text = "Расшифровать";
            this.UncryptButton.UseVisualStyleBackColor = true;
            this.UncryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(474, 33);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(75, 23);
            this.Button.TabIndex = 16;
            this.Button.Text = "Рассчитать";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.DButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Генерация ключей";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 260);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.UncryptButton);
            this.Controls.Add(this.DTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.ETextBox);
            this.Controls.Add(this.QTextBox);
            this.Controls.Add(this.PTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CryptButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "КМЗИ_4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CryptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PTextBox;
        private System.Windows.Forms.TextBox QTextBox;
        private System.Windows.Forms.TextBox ETextBox;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DTextBox;
        private System.Windows.Forms.Button UncryptButton;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

