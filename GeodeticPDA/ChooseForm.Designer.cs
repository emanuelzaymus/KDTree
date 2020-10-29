namespace GeodeticPDA
{
    partial class ChooseForm
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
            this.chooseFromComboBox = new System.Windows.Forms.ComboBox();
            this.chooseButton = new System.Windows.Forms.Button();
            this.chooseFromFoundLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chooseFromComboBox
            // 
            this.chooseFromComboBox.FormattingEnabled = true;
            this.chooseFromComboBox.Location = new System.Drawing.Point(12, 29);
            this.chooseFromComboBox.Name = "chooseFromComboBox";
            this.chooseFromComboBox.Size = new System.Drawing.Size(338, 24);
            this.chooseFromComboBox.TabIndex = 0;
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(275, 228);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(75, 23);
            this.chooseButton.TabIndex = 1;
            this.chooseButton.Text = "Choose";
            this.chooseButton.UseVisualStyleBackColor = true;
            // 
            // chooseFromFoundLabel
            // 
            this.chooseFromFoundLabel.AutoSize = true;
            this.chooseFromFoundLabel.Location = new System.Drawing.Point(12, 9);
            this.chooseFromFoundLabel.Name = "chooseFromFoundLabel";
            this.chooseFromFoundLabel.Size = new System.Drawing.Size(132, 17);
            this.chooseFromFoundLabel.TabIndex = 2;
            this.chooseFromFoundLabel.Text = "Choose from found:";
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 263);
            this.Controls.Add(this.chooseFromFoundLabel);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.chooseFromComboBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 310);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 310);
            this.Name = "ChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Found";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseFromComboBox;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Label chooseFromFoundLabel;
    }
}