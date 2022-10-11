namespace SchedarioMentale.WinForms
{
    partial class FormPlayfield
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
            this.NumberLabel = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.InstructionsForNextNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NumberLabel
            // 
            this.NumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumberLabel.Font = new System.Drawing.Font("Segoe UI", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumberLabel.Location = new System.Drawing.Point(50, 34);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(400, 220);
            this.NumberLabel.TabIndex = 0;
            this.NumberLabel.Text = "100";
            this.NumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(200, 280);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(100, 40);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "▶️  Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // InstructionsForNextNumberLabel
            // 
            this.InstructionsForNextNumberLabel.Location = new System.Drawing.Point(50, 280);
            this.InstructionsForNextNumberLabel.Name = "InstructionsForNextNumberLabel";
            this.InstructionsForNextNumberLabel.Size = new System.Drawing.Size(400, 40);
            this.InstructionsForNextNumberLabel.TabIndex = 2;
            this.InstructionsForNextNumberLabel.Text = "❱❱ Premi \'N\' per andare al prossimo numero";
            this.InstructionsForNextNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPlayfield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.InstructionsForNextNumberLabel);
            this.KeyPreview = true;
            this.Name = "FormPlayfield";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedario Mentale";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPlayfield_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Label NumberLabel;
        private Button PlayButton;
        private Label InstructionsForNextNumberLabel;
    }
}