namespace LicenceGenerator
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
            label1 = new Label();
            rbtnSeven = new RadioButton();
            rbtnTen = new RadioButton();
            rbtnFifteen = new RadioButton();
            rbtnThirty = new RadioButton();
            rbtnSixty = new RadioButton();
            rbtnNinety = new RadioButton();
            rbtnSixMonth = new RadioButton();
            rbtnForever = new RadioButton();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            txtSourceFile = new TextBox();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            txtPublicKey = new TextBox();
            txtPrivateKey = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 55);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "ValidFor";
            // 
            // rbtnSeven
            // 
            rbtnSeven.AutoSize = true;
            rbtnSeven.Location = new Point(157, 53);
            rbtnSeven.Name = "rbtnSeven";
            rbtnSeven.Size = new Size(56, 19);
            rbtnSeven.TabIndex = 1;
            rbtnSeven.TabStop = true;
            rbtnSeven.Tag = "7";
            rbtnSeven.Text = "7Days";
            rbtnSeven.UseVisualStyleBackColor = true;
            // 
            // rbtnTen
            // 
            rbtnTen.AutoSize = true;
            rbtnTen.Location = new Point(219, 53);
            rbtnTen.Name = "rbtnTen";
            rbtnTen.Size = new Size(62, 19);
            rbtnTen.TabIndex = 2;
            rbtnTen.TabStop = true;
            rbtnTen.Tag = "10";
            rbtnTen.Text = "10Days";
            rbtnTen.UseVisualStyleBackColor = true;
            // 
            // rbtnFifteen
            // 
            rbtnFifteen.AutoSize = true;
            rbtnFifteen.Location = new Point(287, 53);
            rbtnFifteen.Name = "rbtnFifteen";
            rbtnFifteen.Size = new Size(62, 19);
            rbtnFifteen.TabIndex = 3;
            rbtnFifteen.TabStop = true;
            rbtnFifteen.Tag = "15";
            rbtnFifteen.Text = "15Days";
            rbtnFifteen.UseVisualStyleBackColor = true;
            // 
            // rbtnThirty
            // 
            rbtnThirty.AutoSize = true;
            rbtnThirty.Location = new Point(355, 53);
            rbtnThirty.Name = "rbtnThirty";
            rbtnThirty.Size = new Size(62, 19);
            rbtnThirty.TabIndex = 4;
            rbtnThirty.TabStop = true;
            rbtnThirty.Tag = "30";
            rbtnThirty.Text = "30Days";
            rbtnThirty.UseVisualStyleBackColor = true;
            // 
            // rbtnSixty
            // 
            rbtnSixty.AutoSize = true;
            rbtnSixty.Location = new Point(423, 53);
            rbtnSixty.Name = "rbtnSixty";
            rbtnSixty.Size = new Size(62, 19);
            rbtnSixty.TabIndex = 5;
            rbtnSixty.TabStop = true;
            rbtnSixty.Tag = "60";
            rbtnSixty.Text = "60Days";
            rbtnSixty.UseVisualStyleBackColor = true;
            // 
            // rbtnNinety
            // 
            rbtnNinety.AutoSize = true;
            rbtnNinety.Location = new Point(491, 53);
            rbtnNinety.Name = "rbtnNinety";
            rbtnNinety.Size = new Size(62, 19);
            rbtnNinety.TabIndex = 6;
            rbtnNinety.TabStop = true;
            rbtnNinety.Tag = "90";
            rbtnNinety.Text = "90Days";
            rbtnNinety.UseVisualStyleBackColor = true;
            // 
            // rbtnSixMonth
            // 
            rbtnSixMonth.AutoSize = true;
            rbtnSixMonth.Location = new Point(559, 55);
            rbtnSixMonth.Name = "rbtnSixMonth";
            rbtnSixMonth.Size = new Size(68, 19);
            rbtnSixMonth.TabIndex = 7;
            rbtnSixMonth.TabStop = true;
            rbtnSixMonth.Tag = "180";
            rbtnSixMonth.Text = "180Days";
            rbtnSixMonth.UseVisualStyleBackColor = true;
            // 
            // rbtnForever
            // 
            rbtnForever.AutoSize = true;
            rbtnForever.Location = new Point(633, 55);
            rbtnForever.Name = "rbtnForever";
            rbtnForever.Size = new Size(75, 19);
            rbtnForever.TabIndex = 8;
            rbtnForever.TabStop = true;
            rbtnForever.Tag = "-1";
            rbtnForever.Text = "Indefinite";
            rbtnForever.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 96);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 9;
            label2.Text = "Computer info file";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(564, 96);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnBrowse_Click;
            // 
            // txtSourceFile
            // 
            txtSourceFile.Location = new Point(157, 96);
            txtSourceFile.Name = "txtSourceFile";
            txtSourceFile.Size = new Size(401, 23);
            txtSourceFile.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(654, 96);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "Generate Licence File";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnGenerate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 150);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 13;
            label3.Text = "Public Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 335);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 14;
            label4.Text = "Private Key";
            // 
            // txtPublicKey
            // 
            txtPublicKey.Location = new Point(157, 150);
            txtPublicKey.Multiline = true;
            txtPublicKey.Name = "txtPublicKey";
            txtPublicKey.Size = new Size(401, 175);
            txtPublicKey.TabIndex = 15;
            // 
            // txtPrivateKey
            // 
            txtPrivateKey.Location = new Point(157, 335);
            txtPrivateKey.Multiline = true;
            txtPrivateKey.Name = "txtPrivateKey";
            txtPrivateKey.Size = new Size(401, 175);
            txtPrivateKey.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 569);
            Controls.Add(txtPrivateKey);
            Controls.Add(txtPublicKey);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(txtSourceFile);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(rbtnForever);
            Controls.Add(rbtnSixMonth);
            Controls.Add(rbtnNinety);
            Controls.Add(rbtnSixty);
            Controls.Add(rbtnThirty);
            Controls.Add(rbtnFifteen);
            Controls.Add(rbtnTen);
            Controls.Add(rbtnSeven);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rbtnSeven;
        private RadioButton rbtnTen;
        private RadioButton rbtnFifteen;
        private RadioButton rbtnThirty;
        private RadioButton rbtnSixty;
        private RadioButton rbtnNinety;
        private RadioButton rbtnSixMonth;
        private RadioButton rbtnForever;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private TextBox txtSourceFile;
        private Button button2;
        private Label label3;
        private Label label4;
        private TextBox txtPublicKey;
        private TextBox txtPrivateKey;
    }
}
