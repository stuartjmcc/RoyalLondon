namespace DrivingApplication
{
    partial class SingleForm
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
            this.outputResultsFolderLabel = new System.Windows.Forms.Label();
            this.openSourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.createOutputButton = new System.Windows.Forms.Button();
            this.inputSourceFileDisplayLabel = new System.Windows.Forms.Label();
            this.inputSetSourceFileButton = new System.Windows.Forms.Button();
            this.inputBodyTemplateLabel = new System.Windows.Forms.Label();
            this.inputBodyTemplateButton = new System.Windows.Forms.Button();
            this.outputSetResultsFolderButton = new System.Windows.Forms.Button();
            this.openBodyTemplateFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputResultsFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputResultsFolderLabel
            // 
            this.outputResultsFolderLabel.AutoSize = true;
            this.outputResultsFolderLabel.Location = new System.Drawing.Point(135, 117);
            this.outputResultsFolderLabel.Name = "outputResultsFolderLabel";
            this.outputResultsFolderLabel.Size = new System.Drawing.Size(83, 13);
            this.outputResultsFolderLabel.TabIndex = 2;
            this.outputResultsFolderLabel.Text = "<Output Folder>";
            // 
            // openSourceFileDialog
            // 
            this.openSourceFileDialog.FileName = "C:\\RoyalLondon\\Test Data\\Customer.csv";
            // 
            // createOutputButton
            // 
            this.createOutputButton.Location = new System.Drawing.Point(12, 154);
            this.createOutputButton.Name = "createOutputButton";
            this.createOutputButton.Size = new System.Drawing.Size(405, 32);
            this.createOutputButton.TabIndex = 3;
            this.createOutputButton.Text = "Create Output";
            this.createOutputButton.UseVisualStyleBackColor = true;
            this.createOutputButton.Click += new System.EventHandler(this.createOutputButton_Click);
            // 
            // inputSourceFileDisplayLabel
            // 
            this.inputSourceFileDisplayLabel.AutoSize = true;
            this.inputSourceFileDisplayLabel.Location = new System.Drawing.Point(135, 67);
            this.inputSourceFileDisplayLabel.Name = "inputSourceFileDisplayLabel";
            this.inputSourceFileDisplayLabel.Size = new System.Drawing.Size(72, 13);
            this.inputSourceFileDisplayLabel.TabIndex = 4;
            this.inputSourceFileDisplayLabel.Text = "<Source File>";
            // 
            // inputSetSourceFileButton
            // 
            this.inputSetSourceFileButton.Location = new System.Drawing.Point(12, 62);
            this.inputSetSourceFileButton.Name = "inputSetSourceFileButton";
            this.inputSetSourceFileButton.Size = new System.Drawing.Size(105, 23);
            this.inputSetSourceFileButton.TabIndex = 5;
            this.inputSetSourceFileButton.Text = "Set Source File";
            this.inputSetSourceFileButton.UseVisualStyleBackColor = true;
            this.inputSetSourceFileButton.Click += new System.EventHandler(this.inputSetSourceFileButton_Click);
            // 
            // inputBodyTemplateLabel
            // 
            this.inputBodyTemplateLabel.AutoSize = true;
            this.inputBodyTemplateLabel.Location = new System.Drawing.Point(135, 17);
            this.inputBodyTemplateLabel.Name = "inputBodyTemplateLabel";
            this.inputBodyTemplateLabel.Size = new System.Drawing.Size(90, 13);
            this.inputBodyTemplateLabel.TabIndex = 4;
            this.inputBodyTemplateLabel.Text = "<Body Template>";
            // 
            // inputBodyTemplateButton
            // 
            this.inputBodyTemplateButton.Location = new System.Drawing.Point(12, 12);
            this.inputBodyTemplateButton.Name = "inputBodyTemplateButton";
            this.inputBodyTemplateButton.Size = new System.Drawing.Size(105, 23);
            this.inputBodyTemplateButton.TabIndex = 5;
            this.inputBodyTemplateButton.Text = "Set Body Template";
            this.inputBodyTemplateButton.UseVisualStyleBackColor = true;
            this.inputBodyTemplateButton.Click += new System.EventHandler(this.inputBodyTemplateButton_Click);
            // 
            // outputSetResultsFolderButton
            // 
            this.outputSetResultsFolderButton.Location = new System.Drawing.Point(12, 112);
            this.outputSetResultsFolderButton.Name = "outputSetResultsFolderButton";
            this.outputSetResultsFolderButton.Size = new System.Drawing.Size(105, 23);
            this.outputSetResultsFolderButton.TabIndex = 5;
            this.outputSetResultsFolderButton.Text = "Set Results Folder";
            this.outputSetResultsFolderButton.UseVisualStyleBackColor = true;
            this.outputSetResultsFolderButton.Click += new System.EventHandler(this.outputSetResultsFolderButton_Click);
            // 
            // openBodyTemplateFileDialog
            // 
            this.openBodyTemplateFileDialog.FileName = "C:\\RoyalLondon\\Letter Template\\BodyTextTemplate.txt";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 201);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(429, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(414, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "<Status>";
            // 
            // SingleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 223);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.outputSetResultsFolderButton);
            this.Controls.Add(this.inputBodyTemplateButton);
            this.Controls.Add(this.inputSetSourceFileButton);
            this.Controls.Add(this.inputBodyTemplateLabel);
            this.Controls.Add(this.inputSourceFileDisplayLabel);
            this.Controls.Add(this.createOutputButton);
            this.Controls.Add(this.outputResultsFolderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SingleForm";
            this.Text = "Royal London Test Application";
            this.Load += new System.EventHandler(this.SingleForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label outputResultsFolderLabel;
        private System.Windows.Forms.OpenFileDialog openSourceFileDialog;
        private System.Windows.Forms.Button createOutputButton;
        private System.Windows.Forms.Label inputSourceFileDisplayLabel;
        private System.Windows.Forms.Button inputSetSourceFileButton;
        private System.Windows.Forms.Label inputBodyTemplateLabel;
        private System.Windows.Forms.Button inputBodyTemplateButton;
        private System.Windows.Forms.Button outputSetResultsFolderButton;
        private System.Windows.Forms.OpenFileDialog openBodyTemplateFileDialog;
        private System.Windows.Forms.FolderBrowserDialog outputResultsFolderBrowserDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

