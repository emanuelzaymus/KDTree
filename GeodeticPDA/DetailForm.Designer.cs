namespace GeodeticPDA
{
    partial class DetailForm
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
            this.numberLabel = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.descriptTextBox = new System.Windows.Forms.TextBox();
            this.descriptLabel = new System.Windows.Forms.Label();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.gpsCoordinatesLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.relatedObjectsLabel = new System.Windows.Forms.Label();
            this.relatedObjectsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(14, 7);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(62, 17);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.Text = "Number:";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(102, 4);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(368, 22);
            this.numberTextBox.TabIndex = 1;
            // 
            // descriptTextBox
            // 
            this.descriptTextBox.Location = new System.Drawing.Point(102, 29);
            this.descriptTextBox.Name = "descriptTextBox";
            this.descriptTextBox.Size = new System.Drawing.Size(368, 22);
            this.descriptTextBox.TabIndex = 3;
            // 
            // descriptLabel
            // 
            this.descriptLabel.AutoSize = true;
            this.descriptLabel.Location = new System.Drawing.Point(13, 32);
            this.descriptLabel.Name = "descriptLabel";
            this.descriptLabel.Size = new System.Drawing.Size(83, 17);
            this.descriptLabel.TabIndex = 2;
            this.descriptLabel.Text = "Description:";
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(239, 79);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(75, 17);
            this.longitudeLabel.TabIndex = 10;
            this.longitudeLabel.Text = "Longitude:";
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Location = new System.Drawing.Point(320, 76);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.Size = new System.Drawing.Size(150, 22);
            this.longitudeTextBox.TabIndex = 8;
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(14, 79);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(63, 17);
            this.latitudeLabel.TabIndex = 9;
            this.latitudeLabel.Text = "Latitude:";
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Location = new System.Drawing.Point(81, 76);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.Size = new System.Drawing.Size(150, 22);
            this.latitudeTextBox.TabIndex = 7;
            // 
            // gpsCoordinatesLabel
            // 
            this.gpsCoordinatesLabel.AutoSize = true;
            this.gpsCoordinatesLabel.Location = new System.Drawing.Point(14, 58);
            this.gpsCoordinatesLabel.Name = "gpsCoordinatesLabel";
            this.gpsCoordinatesLabel.Size = new System.Drawing.Size(117, 17);
            this.gpsCoordinatesLabel.TabIndex = 6;
            this.gpsCoordinatesLabel.Text = "GPS Coordinates";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(350, 318);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(16, 318);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(120, 23);
            this.removeButton.TabIndex = 13;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // relatedObjectsLabel
            // 
            this.relatedObjectsLabel.AutoSize = true;
            this.relatedObjectsLabel.Location = new System.Drawing.Point(14, 106);
            this.relatedObjectsLabel.Name = "relatedObjectsLabel";
            this.relatedObjectsLabel.Size = new System.Drawing.Size(61, 17);
            this.relatedObjectsLabel.TabIndex = 14;
            this.relatedObjectsLabel.Text = "Related:";
            // 
            // relatedObjectsListBox
            // 
            this.relatedObjectsListBox.FormattingEnabled = true;
            this.relatedObjectsListBox.ItemHeight = 16;
            this.relatedObjectsListBox.Location = new System.Drawing.Point(17, 126);
            this.relatedObjectsListBox.Name = "relatedObjectsListBox";
            this.relatedObjectsListBox.Size = new System.Drawing.Size(453, 180);
            this.relatedObjectsListBox.TabIndex = 15;
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 353);
            this.Controls.Add(this.relatedObjectsListBox);
            this.Controls.Add(this.relatedObjectsLabel);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.longitudeLabel);
            this.Controls.Add(this.longitudeTextBox);
            this.Controls.Add(this.latitudeLabel);
            this.Controls.Add(this.latitudeTextBox);
            this.Controls.Add(this.gpsCoordinatesLabel);
            this.Controls.Add(this.descriptTextBox);
            this.Controls.Add(this.descriptLabel);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.numberLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "DetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox descriptTextBox;
        private System.Windows.Forms.Label descriptLabel;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.TextBox latitudeTextBox;
        private System.Windows.Forms.Label gpsCoordinatesLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label relatedObjectsLabel;
        private System.Windows.Forms.ListBox relatedObjectsListBox;
    }
}