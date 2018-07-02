namespace Crypt_1
{
    partial class FormRec
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
            this.buttonCrypt = new System.Windows.Forms.Button();
            this.buttonUncrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAlpha1 = new System.Windows.Forms.TextBox();
            this.textBoxAlpha2 = new System.Windows.Forms.TextBox();
            this.richTextBoxIn = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOut = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCrypt
            // 
            this.buttonCrypt.Location = new System.Drawing.Point(39, 293);
            this.buttonCrypt.Name = "buttonCrypt";
            this.buttonCrypt.Size = new System.Drawing.Size(97, 23);
            this.buttonCrypt.TabIndex = 0;
            this.buttonCrypt.Text = "Зашифровать";
            this.buttonCrypt.UseVisualStyleBackColor = true;
            this.buttonCrypt.Click += new System.EventHandler(this.buttonCrypt_Click);
            // 
            // buttonUncrypt
            // 
            this.buttonUncrypt.Location = new System.Drawing.Point(236, 293);
            this.buttonUncrypt.Name = "buttonUncrypt";
            this.buttonUncrypt.Size = new System.Drawing.Size(97, 23);
            this.buttonUncrypt.TabIndex = 1;
            this.buttonUncrypt.Text = "Расшифровать";
            this.buttonUncrypt.UseVisualStyleBackColor = true;
            this.buttonUncrypt.Click += new System.EventHandler(this.buttonUncrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите ключи шифрования и текст";
            // 
            // textBoxAlpha1
            // 
            this.textBoxAlpha1.Location = new System.Drawing.Point(99, 42);
            this.textBoxAlpha1.Name = "textBoxAlpha1";
            this.textBoxAlpha1.Size = new System.Drawing.Size(161, 20);
            this.textBoxAlpha1.TabIndex = 3;
            // 
            // textBoxAlpha2
            // 
            this.textBoxAlpha2.Location = new System.Drawing.Point(99, 79);
            this.textBoxAlpha2.Name = "textBoxAlpha2";
            this.textBoxAlpha2.Size = new System.Drawing.Size(161, 20);
            this.textBoxAlpha2.TabIndex = 4;
            // 
            // richTextBoxIn
            // 
            this.richTextBoxIn.Location = new System.Drawing.Point(12, 116);
            this.richTextBoxIn.Name = "richTextBoxIn";
            this.richTextBoxIn.Size = new System.Drawing.Size(171, 156);
            this.richTextBoxIn.TabIndex = 7;
            this.richTextBoxIn.Text = "";
            // 
            // richTextBoxOut
            // 
            this.richTextBoxOut.Location = new System.Drawing.Point(203, 116);
            this.richTextBoxOut.Name = "richTextBoxOut";
            this.richTextBoxOut.Size = new System.Drawing.Size(169, 156);
            this.richTextBoxOut.TabIndex = 8;
            this.richTextBoxOut.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Первый ключ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Второй ключ:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Проверить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxOut);
            this.Controls.Add(this.richTextBoxIn);
            this.Controls.Add(this.textBoxAlpha2);
            this.Controls.Add(this.textBoxAlpha1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUncrypt);
            this.Controls.Add(this.buttonCrypt);
            this.Name = "FormRec";
            this.Text = "Аффинный рекуррентный шифр";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCrypt;
        private System.Windows.Forms.Button buttonUncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAlpha1;
        private System.Windows.Forms.TextBox textBoxAlpha2;
        private System.Windows.Forms.RichTextBox richTextBoxIn;
        private System.Windows.Forms.RichTextBox richTextBoxOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}