namespace Crypt_1
{
    partial class FormHill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxIn = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOut = new System.Windows.Forms.RichTextBox();
            this.buttonCrypt = new System.Windows.Forms.Button();
            this.buttonUncrypt = new System.Windows.Forms.Button();
            this.button_check = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите ключи шифрования и исходный текст";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(70, 36);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(103, 20);
            this.textBoxA.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ключ:";
            // 
            // richTextBoxIn
            // 
            this.richTextBoxIn.Location = new System.Drawing.Point(21, 74);
            this.richTextBoxIn.Name = "richTextBoxIn";
            this.richTextBoxIn.Size = new System.Drawing.Size(173, 162);
            this.richTextBoxIn.TabIndex = 4;
            this.richTextBoxIn.Text = "";
            // 
            // richTextBoxOut
            // 
            this.richTextBoxOut.Location = new System.Drawing.Point(245, 74);
            this.richTextBoxOut.Name = "richTextBoxOut";
            this.richTextBoxOut.Size = new System.Drawing.Size(173, 162);
            this.richTextBoxOut.TabIndex = 5;
            this.richTextBoxOut.Text = "";
            // 
            // buttonCrypt
            // 
            this.buttonCrypt.Location = new System.Drawing.Point(21, 267);
            this.buttonCrypt.Name = "buttonCrypt";
            this.buttonCrypt.Size = new System.Drawing.Size(99, 22);
            this.buttonCrypt.TabIndex = 6;
            this.buttonCrypt.Text = "Зашифровать";
            this.buttonCrypt.UseVisualStyleBackColor = true;
            this.buttonCrypt.Click += new System.EventHandler(this.buttonCrypt_Click);
            // 
            // buttonUncrypt
            // 
            this.buttonUncrypt.Location = new System.Drawing.Point(150, 267);
            this.buttonUncrypt.Name = "buttonUncrypt";
            this.buttonUncrypt.Size = new System.Drawing.Size(99, 22);
            this.buttonUncrypt.TabIndex = 7;
            this.buttonUncrypt.Text = "Расшифровать";
            this.buttonUncrypt.UseVisualStyleBackColor = true;
            this.buttonUncrypt.Click += new System.EventHandler(this.buttonUncrypt_Click);
            // 
            // button_check
            // 
            this.button_check.Location = new System.Drawing.Point(343, 33);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(75, 23);
            this.button_check.TabIndex = 8;
            this.button_check.Text = "Проверка";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // FormHill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 312);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.buttonUncrypt);
            this.Controls.Add(this.buttonCrypt);
            this.Controls.Add(this.richTextBoxOut);
            this.Controls.Add(this.richTextBoxIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.label1);
            this.Name = "FormHill";
            this.Text = "Аффинный шифр";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxIn;
        private System.Windows.Forms.RichTextBox richTextBoxOut;
        private System.Windows.Forms.Button buttonCrypt;
        private System.Windows.Forms.Button buttonUncrypt;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.Label label3;
    }
}