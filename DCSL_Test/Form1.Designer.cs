namespace DCSL_Test
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
            this.btnSource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnDestination = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.rtxtAnything = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fbdSource = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdDestination = new System.Windows.Forms.FolderBrowserDialog();
            this.txtCopyStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSource
            // 
            this.btnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSource.Location = new System.Drawing.Point(284, 87);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(80, 27);
            this.btnSource.TabIndex = 5;
            this.btnSource.Text = "Select";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Source Folder";
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(43, 87);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(235, 27);
            this.txtSource.TabIndex = 3;
            // 
            // btnDestination
            // 
            this.btnDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestination.Location = new System.Drawing.Point(647, 87);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(80, 27);
            this.btnDestination.TabIndex = 8;
            this.btnDestination.Text = "Select";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(402, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Destination Folder";
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(406, 87);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(235, 27);
            this.txtDestination.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(308, 145);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(154, 47);
            this.btnCopy.TabIndex = 9;
            this.btnCopy.Text = "Start Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // rtxtAnything
            // 
            this.rtxtAnything.Location = new System.Drawing.Point(43, 245);
            this.rtxtAnything.Name = "rtxtAnything";
            this.rtxtAnything.Size = new System.Drawing.Size(419, 193);
            this.rtxtAnything.TabIndex = 10;
            this.rtxtAnything.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type anything to check that UI isn\'t blocking";
            // 
            // txtCopyStatus
            // 
            this.txtCopyStatus.Location = new System.Drawing.Point(468, 245);
            this.txtCopyStatus.Multiline = true;
            this.txtCopyStatus.Name = "txtCopyStatus";
            this.txtCopyStatus.ReadOnly = true;
            this.txtCopyStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCopyStatus.Size = new System.Drawing.Size(267, 193);
            this.txtCopyStatus.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCopyStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxtAnything);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.RichTextBox rtxtAnything;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog fbdSource;
        private System.Windows.Forms.FolderBrowserDialog fbdDestination;
        private System.Windows.Forms.TextBox txtCopyStatus;
    }
}

