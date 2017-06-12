namespace MarkovText
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
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.btnAnalyzeText = new System.Windows.Forms.Button();
            this.txtGeneratedText = new System.Windows.Forms.TextBox();
            this.btnGenerateText = new System.Windows.Forms.Button();
            this.txtCharsToGenerate = new System.Windows.Forms.TextBox();
            this.txtCharGroupLength = new System.Windows.Forms.TextBox();
            this.lblCharGroupSize = new System.Windows.Forms.Label();
            this.lblCharsToGenerate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInputText
            // 
            this.txtInputText.Location = new System.Drawing.Point(12, 77);
            this.txtInputText.MaxLength = 1048544;
            this.txtInputText.Multiline = true;
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.Size = new System.Drawing.Size(350, 443);
            this.txtInputText.TabIndex = 0;
            // 
            // btnAnalyzeText
            // 
            this.btnAnalyzeText.Location = new System.Drawing.Point(12, 529);
            this.btnAnalyzeText.Name = "btnAnalyzeText";
            this.btnAnalyzeText.Size = new System.Drawing.Size(350, 23);
            this.btnAnalyzeText.TabIndex = 1;
            this.btnAnalyzeText.Text = "Analyze";
            this.btnAnalyzeText.UseVisualStyleBackColor = true;
            this.btnAnalyzeText.Click += new System.EventHandler(this.btnAnalyzeText_Click);
            // 
            // txtGeneratedText
            // 
            this.txtGeneratedText.Location = new System.Drawing.Point(381, 77);
            this.txtGeneratedText.MaxLength = 1048544;
            this.txtGeneratedText.Multiline = true;
            this.txtGeneratedText.Name = "txtGeneratedText";
            this.txtGeneratedText.Size = new System.Drawing.Size(352, 443);
            this.txtGeneratedText.TabIndex = 2;
            // 
            // btnGenerateText
            // 
            this.btnGenerateText.Enabled = false;
            this.btnGenerateText.Location = new System.Drawing.Point(381, 529);
            this.btnGenerateText.Name = "btnGenerateText";
            this.btnGenerateText.Size = new System.Drawing.Size(352, 23);
            this.btnGenerateText.TabIndex = 3;
            this.btnGenerateText.Text = "Generate";
            this.btnGenerateText.UseVisualStyleBackColor = true;
            this.btnGenerateText.Click += new System.EventHandler(this.btnGenerateText_Click);
            // 
            // txtCharsToGenerate
            // 
            this.txtCharsToGenerate.Location = new System.Drawing.Point(106, 42);
            this.txtCharsToGenerate.Name = "txtCharsToGenerate";
            this.txtCharsToGenerate.Size = new System.Drawing.Size(46, 20);
            this.txtCharsToGenerate.TabIndex = 4;
            this.txtCharsToGenerate.Text = "1000";
            // 
            // txtCharGroupLength
            // 
            this.txtCharGroupLength.Location = new System.Drawing.Point(106, 13);
            this.txtCharGroupLength.Name = "txtCharGroupLength";
            this.txtCharGroupLength.Size = new System.Drawing.Size(37, 20);
            this.txtCharGroupLength.TabIndex = 5;
            this.txtCharGroupLength.Text = "2";
            // 
            // lblCharGroupSize
            // 
            this.lblCharGroupSize.AutoSize = true;
            this.lblCharGroupSize.Location = new System.Drawing.Point(20, 16);
            this.lblCharGroupSize.Name = "lblCharGroupSize";
            this.lblCharGroupSize.Size = new System.Drawing.Size(80, 13);
            this.lblCharGroupSize.TabIndex = 6;
            this.lblCharGroupSize.Text = "Char group size";
            // 
            // lblCharsToGenerate
            // 
            this.lblCharsToGenerate.AutoSize = true;
            this.lblCharsToGenerate.Location = new System.Drawing.Point(9, 45);
            this.lblCharsToGenerate.Name = "lblCharsToGenerate";
            this.lblCharsToGenerate.Size = new System.Drawing.Size(91, 13);
            this.lblCharsToGenerate.TabIndex = 7;
            this.lblCharsToGenerate.Text = "Chars to generate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 564);
            this.Controls.Add(this.lblCharsToGenerate);
            this.Controls.Add(this.lblCharGroupSize);
            this.Controls.Add(this.txtCharGroupLength);
            this.Controls.Add(this.txtCharsToGenerate);
            this.Controls.Add(this.btnGenerateText);
            this.Controls.Add(this.txtGeneratedText);
            this.Controls.Add(this.btnAnalyzeText);
            this.Controls.Add(this.txtInputText);
            this.Name = "Form1";
            this.Text = "Markov Text Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtInputText;
		private System.Windows.Forms.Button btnAnalyzeText;
		private System.Windows.Forms.TextBox txtGeneratedText;
		private System.Windows.Forms.Button btnGenerateText;
		private System.Windows.Forms.TextBox txtCharsToGenerate;
		private System.Windows.Forms.TextBox txtCharGroupLength;
        private System.Windows.Forms.Label lblCharGroupSize;
        private System.Windows.Forms.Label lblCharsToGenerate;
    }
}

