namespace TranslationApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            comboLanguageSelect = new ComboBox();
            comboTranslatedLanguage = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Location = new Point(562, 438);
            button1.Name = "button1";
            button1.Size = new Size(294, 59);
            button1.TabIndex = 0;
            button1.Text = "Translate";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_ClickAsync;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(129, 240);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(409, 120);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(794, 240);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(409, 120);
            richTextBox2.TabIndex = 2;
            richTextBox2.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 191);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 3;
            label1.Text = "Text You want to Translate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(794, 191);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 4;
            label2.Text = "Translated Text";
            // 
            // comboLanguageSelect
            // 
            comboLanguageSelect.FormattingEnabled = true;
            comboLanguageSelect.Location = new Point(387, 103);
            comboLanguageSelect.Name = "comboLanguageSelect";
            comboLanguageSelect.Size = new Size(151, 28);
            comboLanguageSelect.TabIndex = 5;
            comboLanguageSelect.Text = "Chose Language";
            // 
            // comboTranslatedLanguage
            // 
            comboTranslatedLanguage.FormattingEnabled = true;
            comboTranslatedLanguage.Location = new Point(1031, 103);
            comboTranslatedLanguage.Name = "comboTranslatedLanguage";
            comboTranslatedLanguage.Size = new Size(151, 28);
            comboTranslatedLanguage.TabIndex = 6;
            comboTranslatedLanguage.Text = "Choose Language";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 111);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 7;
            label3.Text = "Source Language";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(794, 111);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 8;
            label4.Text = "Targeted Language";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1520, 1068);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboTranslatedLanguage);
            Controls.Add(comboLanguageSelect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Label label1;
        private Label label2;
        private ComboBox comboLanguageSelect;
        private ComboBox comboTranslatedLanguage;
        private Label label3;
        private Label label4;
    }
}
