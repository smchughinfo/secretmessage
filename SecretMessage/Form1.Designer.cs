namespace SecretMessage
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDecode = new System.Windows.Forms.RadioButton();
            this.rbEncode = new System.Windows.Forms.RadioButton();
            this.btnConvert = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEncryption = new System.Windows.Forms.TextBox();
            this.cbUseEncryption = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearchEmbedFile = new System.Windows.Forms.Button();
            this.rbMessage = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.txtEmbedFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(8, 19);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(312, 20);
            this.txtFile.TabIndex = 0;
            this.txtFile.Text = "c:\\path_to_carrier_image\\img.png";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(326, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDecode);
            this.groupBox1.Controls.Add(this.rbEncode);
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 46);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // rbDecode
            // 
            this.rbDecode.AutoSize = true;
            this.rbDecode.Location = new System.Drawing.Point(74, 19);
            this.rbDecode.Name = "rbDecode";
            this.rbDecode.Size = new System.Drawing.Size(63, 17);
            this.rbDecode.TabIndex = 4;
            this.rbDecode.Text = "Decode";
            this.rbDecode.UseVisualStyleBackColor = true;
            this.rbDecode.CheckedChanged += new System.EventHandler(this.rbDecode_CheckedChanged);
            // 
            // rbEncode
            // 
            this.rbEncode.AutoSize = true;
            this.rbEncode.Checked = true;
            this.rbEncode.Location = new System.Drawing.Point(6, 19);
            this.rbEncode.Name = "rbEncode";
            this.rbEncode.Size = new System.Drawing.Size(62, 17);
            this.rbEncode.TabIndex = 3;
            this.rbEncode.Text = "Encode";
            this.rbEncode.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 464);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(101, 42);
            this.btnConvert.TabIndex = 12;
            this.btnConvert.Text = "Execute";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.OrangeRed;
            this.progressBar.Location = new System.Drawing.Point(120, 464);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(298, 41);
            this.progressBar.TabIndex = 13;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Message:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEncryption);
            this.groupBox2.Controls.Add(this.cbUseEncryption);
            this.groupBox2.Location = new System.Drawing.Point(13, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 73);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Encryption";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtEncryption
            // 
            this.txtEncryption.Enabled = false;
            this.txtEncryption.Location = new System.Drawing.Point(7, 43);
            this.txtEncryption.Name = "txtEncryption";
            this.txtEncryption.Size = new System.Drawing.Size(392, 20);
            this.txtEncryption.TabIndex = 6;
            // 
            // cbUseEncryption
            // 
            this.cbUseEncryption.AutoSize = true;
            this.cbUseEncryption.Location = new System.Drawing.Point(7, 20);
            this.cbUseEncryption.Name = "cbUseEncryption";
            this.cbUseEncryption.Size = new System.Drawing.Size(97, 17);
            this.cbUseEncryption.TabIndex = 5;
            this.cbUseEncryption.Text = "Use encryption";
            this.cbUseEncryption.UseVisualStyleBackColor = true;
            this.cbUseEncryption.CheckedChanged += new System.EventHandler(this.cbUseEncryption_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearchEmbedFile);
            this.groupBox3.Controls.Add(this.rbMessage);
            this.groupBox3.Controls.Add(this.rbFile);
            this.groupBox3.Controls.Add(this.txtEmbedFile);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMessage);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(13, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 250);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Message";
            // 
            // btnSearchEmbedFile
            // 
            this.btnSearchEmbedFile.Location = new System.Drawing.Point(325, 59);
            this.btnSearchEmbedFile.Name = "btnSearchEmbedFile";
            this.btnSearchEmbedFile.Size = new System.Drawing.Size(74, 23);
            this.btnSearchEmbedFile.TabIndex = 10;
            this.btnSearchEmbedFile.Text = "Search";
            this.btnSearchEmbedFile.UseVisualStyleBackColor = true;
            this.btnSearchEmbedFile.Click += new System.EventHandler(this.txtSearchEmbedFile_Click);
            // 
            // rbMessage
            // 
            this.rbMessage.AutoSize = true;
            this.rbMessage.Checked = true;
            this.rbMessage.Location = new System.Drawing.Point(54, 20);
            this.rbMessage.Name = "rbMessage";
            this.rbMessage.Size = new System.Drawing.Size(68, 17);
            this.rbMessage.TabIndex = 8;
            this.rbMessage.Text = "Message";
            this.rbMessage.UseVisualStyleBackColor = true;
            this.rbMessage.CheckedChanged += new System.EventHandler(this.rbMessage_CheckedChanged);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(7, 20);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(41, 17);
            this.rbFile.TabIndex = 7;
            this.rbFile.Text = "File";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // txtEmbedFile
            // 
            this.txtEmbedFile.Enabled = false;
            this.txtEmbedFile.Location = new System.Drawing.Point(5, 62);
            this.txtEmbedFile.Name = "txtEmbedFile";
            this.txtEmbedFile.Size = new System.Drawing.Size(314, 20);
            this.txtEmbedFile.TabIndex = 9;
            this.txtEmbedFile.Text = "c:\\path_to_top_secret_file\\myFile.abc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "File:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(5, 101);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(394, 140);
            this.txtMessage.TabIndex = 11;
            this.txtMessage.Text = "top secret message goes here.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFile);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(406, 46);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 518);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Secret Message";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDecode;
        private System.Windows.Forms.RadioButton rbEncode;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEncryption;
        private System.Windows.Forms.CheckBox cbUseEncryption;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbMessage;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.TextBox txtEmbedFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSearchEmbedFile;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

