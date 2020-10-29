namespace GeodeticPDA
{
    partial class MainForm
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
            this.gpsCoordinates1Label = new System.Windows.Forms.Label();
            this.latitude1TextBox = new System.Windows.Forms.TextBox();
            this.findPropertiesButton = new System.Windows.Forms.Button();
            this.latitude1Label = new System.Windows.Forms.Label();
            this.longitude1Label = new System.Windows.Forms.Label();
            this.longitude1TextBox = new System.Windows.Forms.TextBox();
            this.secondGpsCoordinateCheckBox = new System.Windows.Forms.CheckBox();
            this.longitude2Label = new System.Windows.Forms.Label();
            this.longitude2TextBox = new System.Windows.Forms.TextBox();
            this.latitude2Label = new System.Windows.Forms.Label();
            this.latitude2TextBox = new System.Windows.Forms.TextBox();
            this.gpsCoordinates2Label = new System.Windows.Forms.Label();
            this.findParcelsButton = new System.Windows.Forms.Button();
            this.findAllButton = new System.Windows.Forms.Button();
            this.addPropertyButton = new System.Windows.Forms.Button();
            this.addParcelButton = new System.Windows.Forms.Button();
            this.populateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gpsCoordinates1Label
            // 
            this.gpsCoordinates1Label.AutoSize = true;
            this.gpsCoordinates1Label.Location = new System.Drawing.Point(12, 9);
            this.gpsCoordinates1Label.Name = "gpsCoordinates1Label";
            this.gpsCoordinates1Label.Size = new System.Drawing.Size(117, 17);
            this.gpsCoordinates1Label.TabIndex = 0;
            this.gpsCoordinates1Label.Text = "GPS Coordinates";
            // 
            // latitude1TextBox
            // 
            this.latitude1TextBox.Location = new System.Drawing.Point(81, 29);
            this.latitude1TextBox.Name = "latitude1TextBox";
            this.latitude1TextBox.Size = new System.Drawing.Size(100, 22);
            this.latitude1TextBox.TabIndex = 1;
            // 
            // findPropertiesButton
            // 
            this.findPropertiesButton.Location = new System.Drawing.Point(15, 129);
            this.findPropertiesButton.Name = "findPropertiesButton";
            this.findPropertiesButton.Size = new System.Drawing.Size(355, 23);
            this.findPropertiesButton.TabIndex = 2;
            this.findPropertiesButton.Text = "Find properties";
            this.findPropertiesButton.UseVisualStyleBackColor = true;
            this.findPropertiesButton.Click += new System.EventHandler(this.findPropertiesButton_Click);
            // 
            // latitude1Label
            // 
            this.latitude1Label.AutoSize = true;
            this.latitude1Label.Location = new System.Drawing.Point(12, 32);
            this.latitude1Label.Name = "latitude1Label";
            this.latitude1Label.Size = new System.Drawing.Size(63, 17);
            this.latitude1Label.TabIndex = 3;
            this.latitude1Label.Text = "Latitude:";
            // 
            // longitude1Label
            // 
            this.longitude1Label.AutoSize = true;
            this.longitude1Label.Location = new System.Drawing.Point(189, 32);
            this.longitude1Label.Name = "longitude1Label";
            this.longitude1Label.Size = new System.Drawing.Size(75, 17);
            this.longitude1Label.TabIndex = 5;
            this.longitude1Label.Text = "Longitude:";
            // 
            // longitude1TextBox
            // 
            this.longitude1TextBox.Location = new System.Drawing.Point(270, 29);
            this.longitude1TextBox.Name = "longitude1TextBox";
            this.longitude1TextBox.Size = new System.Drawing.Size(100, 22);
            this.longitude1TextBox.TabIndex = 4;
            // 
            // secondGpsCoordinateCheckBox
            // 
            this.secondGpsCoordinateCheckBox.AutoSize = true;
            this.secondGpsCoordinateCheckBox.Location = new System.Drawing.Point(15, 57);
            this.secondGpsCoordinateCheckBox.Name = "secondGpsCoordinateCheckBox";
            this.secondGpsCoordinateCheckBox.Size = new System.Drawing.Size(230, 21);
            this.secondGpsCoordinateCheckBox.TabIndex = 6;
            this.secondGpsCoordinateCheckBox.Text = "Search by two GPS coordinates";
            this.secondGpsCoordinateCheckBox.UseVisualStyleBackColor = true;
            this.secondGpsCoordinateCheckBox.CheckedChanged += new System.EventHandler(this.secondGpsCoordinateCheckBox_CheckedChanged);
            // 
            // longitude2Label
            // 
            this.longitude2Label.AutoSize = true;
            this.longitude2Label.Enabled = false;
            this.longitude2Label.Location = new System.Drawing.Point(189, 104);
            this.longitude2Label.Name = "longitude2Label";
            this.longitude2Label.Size = new System.Drawing.Size(75, 17);
            this.longitude2Label.TabIndex = 11;
            this.longitude2Label.Text = "Longitude:";
            // 
            // longitude2TextBox
            // 
            this.longitude2TextBox.Enabled = false;
            this.longitude2TextBox.Location = new System.Drawing.Point(270, 101);
            this.longitude2TextBox.Name = "longitude2TextBox";
            this.longitude2TextBox.Size = new System.Drawing.Size(100, 22);
            this.longitude2TextBox.TabIndex = 10;
            // 
            // latitude2Label
            // 
            this.latitude2Label.AutoSize = true;
            this.latitude2Label.Enabled = false;
            this.latitude2Label.Location = new System.Drawing.Point(12, 104);
            this.latitude2Label.Name = "latitude2Label";
            this.latitude2Label.Size = new System.Drawing.Size(63, 17);
            this.latitude2Label.TabIndex = 9;
            this.latitude2Label.Text = "Latitude:";
            // 
            // latitude2TextBox
            // 
            this.latitude2TextBox.Enabled = false;
            this.latitude2TextBox.Location = new System.Drawing.Point(81, 101);
            this.latitude2TextBox.Name = "latitude2TextBox";
            this.latitude2TextBox.Size = new System.Drawing.Size(100, 22);
            this.latitude2TextBox.TabIndex = 8;
            // 
            // gpsCoordinates2Label
            // 
            this.gpsCoordinates2Label.AutoSize = true;
            this.gpsCoordinates2Label.Enabled = false;
            this.gpsCoordinates2Label.Location = new System.Drawing.Point(12, 81);
            this.gpsCoordinates2Label.Name = "gpsCoordinates2Label";
            this.gpsCoordinates2Label.Size = new System.Drawing.Size(129, 17);
            this.gpsCoordinates2Label.TabIndex = 7;
            this.gpsCoordinates2Label.Text = "GPS Coordinates 2";
            // 
            // findParcelsButton
            // 
            this.findParcelsButton.Location = new System.Drawing.Point(15, 158);
            this.findParcelsButton.Name = "findParcelsButton";
            this.findParcelsButton.Size = new System.Drawing.Size(355, 23);
            this.findParcelsButton.TabIndex = 12;
            this.findParcelsButton.Text = "Find parcels";
            this.findParcelsButton.UseVisualStyleBackColor = true;
            // 
            // findAllButton
            // 
            this.findAllButton.Location = new System.Drawing.Point(15, 187);
            this.findAllButton.Name = "findAllButton";
            this.findAllButton.Size = new System.Drawing.Size(355, 23);
            this.findAllButton.TabIndex = 13;
            this.findAllButton.Text = "Find all";
            this.findAllButton.UseVisualStyleBackColor = true;
            // 
            // addPropertyButton
            // 
            this.addPropertyButton.Location = new System.Drawing.Point(15, 218);
            this.addPropertyButton.Name = "addPropertyButton";
            this.addPropertyButton.Size = new System.Drawing.Size(166, 23);
            this.addPropertyButton.TabIndex = 14;
            this.addPropertyButton.Text = "Add property";
            this.addPropertyButton.UseVisualStyleBackColor = true;
            this.addPropertyButton.Click += new System.EventHandler(this.addPropertyButton_Click);
            // 
            // addParcelButton
            // 
            this.addParcelButton.Location = new System.Drawing.Point(192, 218);
            this.addParcelButton.Name = "addParcelButton";
            this.addParcelButton.Size = new System.Drawing.Size(178, 23);
            this.addParcelButton.TabIndex = 15;
            this.addParcelButton.Text = "Add parcel";
            this.addParcelButton.UseVisualStyleBackColor = true;
            this.addParcelButton.Click += new System.EventHandler(this.addParcelButton_Click);
            // 
            // populateButton
            // 
            this.populateButton.Location = new System.Drawing.Point(12, 247);
            this.populateButton.Name = "populateButton";
            this.populateButton.Size = new System.Drawing.Size(355, 23);
            this.populateButton.TabIndex = 16;
            this.populateButton.Text = "Populate with random data";
            this.populateButton.UseVisualStyleBackColor = true;
            this.populateButton.Click += new System.EventHandler(this.populateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 283);
            this.Controls.Add(this.populateButton);
            this.Controls.Add(this.addParcelButton);
            this.Controls.Add(this.addPropertyButton);
            this.Controls.Add(this.findAllButton);
            this.Controls.Add(this.findParcelsButton);
            this.Controls.Add(this.longitude2Label);
            this.Controls.Add(this.longitude2TextBox);
            this.Controls.Add(this.latitude2Label);
            this.Controls.Add(this.latitude2TextBox);
            this.Controls.Add(this.gpsCoordinates2Label);
            this.Controls.Add(this.secondGpsCoordinateCheckBox);
            this.Controls.Add(this.longitude1Label);
            this.Controls.Add(this.longitude1TextBox);
            this.Controls.Add(this.latitude1Label);
            this.Controls.Add(this.findPropertiesButton);
            this.Controls.Add(this.latitude1TextBox);
            this.Controls.Add(this.gpsCoordinates1Label);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 330);
            this.MinimumSize = new System.Drawing.Size(400, 330);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geodetic PDA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gpsCoordinates1Label;
        private System.Windows.Forms.TextBox latitude1TextBox;
        private System.Windows.Forms.Button findPropertiesButton;
        private System.Windows.Forms.Label latitude1Label;
        private System.Windows.Forms.Label longitude1Label;
        private System.Windows.Forms.TextBox longitude1TextBox;
        private System.Windows.Forms.CheckBox secondGpsCoordinateCheckBox;
        private System.Windows.Forms.Label longitude2Label;
        private System.Windows.Forms.TextBox longitude2TextBox;
        private System.Windows.Forms.Label latitude2Label;
        private System.Windows.Forms.TextBox latitude2TextBox;
        private System.Windows.Forms.Label gpsCoordinates2Label;
        private System.Windows.Forms.Button findParcelsButton;
        private System.Windows.Forms.Button findAllButton;
        private System.Windows.Forms.Button addPropertyButton;
        private System.Windows.Forms.Button addParcelButton;
        private System.Windows.Forms.Button populateButton;
    }
}

