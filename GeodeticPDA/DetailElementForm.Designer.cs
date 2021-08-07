namespace GeodeticPDA
{
    partial class DetailElementForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.detailKey2TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.detailkey1TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detailValueTextBox = new System.Windows.Forms.TextBox();
            this.removeElementButton = new System.Windows.Forms.Button();
            this.saveElementButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Element";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Key2:";
            // 
            // detailKey2TextBox
            // 
            this.detailKey2TextBox.Location = new System.Drawing.Point(366, 32);
            this.detailKey2TextBox.Name = "detailKey2TextBox";
            this.detailKey2TextBox.Size = new System.Drawing.Size(205, 22);
            this.detailKey2TextBox.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "Key1:";
            // 
            // detailkey1TextBox
            // 
            this.detailkey1TextBox.Location = new System.Drawing.Point(82, 32);
            this.detailkey1TextBox.Name = "detailkey1TextBox";
            this.detailkey1TextBox.Size = new System.Drawing.Size(205, 22);
            this.detailkey1TextBox.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Value:";
            // 
            // detailValueTextBox
            // 
            this.detailValueTextBox.Location = new System.Drawing.Point(82, 60);
            this.detailValueTextBox.Name = "detailValueTextBox";
            this.detailValueTextBox.Size = new System.Drawing.Size(489, 22);
            this.detailValueTextBox.TabIndex = 38;
            // 
            // removeElementButton
            // 
            this.removeElementButton.Location = new System.Drawing.Point(15, 88);
            this.removeElementButton.Name = "removeElementButton";
            this.removeElementButton.Size = new System.Drawing.Size(272, 23);
            this.removeElementButton.TabIndex = 40;
            this.removeElementButton.Text = "Remove";
            this.removeElementButton.UseVisualStyleBackColor = true;
            this.removeElementButton.Click += new System.EventHandler(this.removeElementButton_Click);
            // 
            // saveElementButton
            // 
            this.saveElementButton.Location = new System.Drawing.Point(293, 88);
            this.saveElementButton.Name = "saveElementButton";
            this.saveElementButton.Size = new System.Drawing.Size(278, 23);
            this.saveElementButton.TabIndex = 41;
            this.saveElementButton.Text = "Save";
            this.saveElementButton.UseVisualStyleBackColor = true;
            this.saveElementButton.Click += new System.EventHandler(this.SaveElementButton_Click);
            // 
            // DetailElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 123);
            this.Controls.Add(this.saveElementButton);
            this.Controls.Add(this.removeElementButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detailValueTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.detailKey2TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.detailkey1TextBox);
            this.MaximumSize = new System.Drawing.Size(600, 170);
            this.MinimumSize = new System.Drawing.Size(600, 170);
            this.Name = "DetailElementForm";
            this.Text = "DetailElementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox detailKey2TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox detailkey1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox detailValueTextBox;
        private System.Windows.Forms.Button removeElementButton;
        private System.Windows.Forms.Button saveElementButton;
    }
}