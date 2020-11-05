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
            this.latitude1Label = new System.Windows.Forms.Label();
            this.latitude1TextBox = new System.Windows.Forms.TextBox();
            this.longitude1Label = new System.Windows.Forms.Label();
            this.longitude1TextBox = new System.Windows.Forms.TextBox();
            this.secondGpsCoordinateCheckBox = new System.Windows.Forms.CheckBox();
            this.gpsCoordinates2Label = new System.Windows.Forms.Label();
            this.longitude2Label = new System.Windows.Forms.Label();
            this.longitude2TextBox = new System.Windows.Forms.TextBox();
            this.latitude2Label = new System.Windows.Forms.Label();
            this.latitude2TextBox = new System.Windows.Forms.TextBox();
            this.findPropertiesButton = new System.Windows.Forms.Button();
            this.findParcelsButton = new System.Windows.Forms.Button();
            this.findAllButton = new System.Windows.Forms.Button();
            this.addPropertyButton = new System.Windows.Forms.Button();
            this.addParcelButton = new System.Windows.Forms.Button();
            this.propertiesCountTextBox = new System.Windows.Forms.TextBox();
            this.parcelsCountTextBox = new System.Windows.Forms.TextBox();
            this.populateButton = new System.Windows.Forms.Button();
            this.propertiesCsvFileTextBox = new System.Windows.Forms.TextBox();
            this.savePropertiesButton = new System.Windows.Forms.Button();
            this.loadPropertiesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadParcelsButton = new System.Windows.Forms.Button();
            this.parcelsCsvFileTextBox = new System.Windows.Forms.TextBox();
            this.saveParcelsButton = new System.Windows.Forms.Button();
            this.propertiesCountLabel = new System.Windows.Forms.Label();
            this.parcelsCountLabel = new System.Windows.Forms.Label();
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
            // latitude1Label
            // 
            this.latitude1Label.AutoSize = true;
            this.latitude1Label.Location = new System.Drawing.Point(12, 32);
            this.latitude1Label.Name = "latitude1Label";
            this.latitude1Label.Size = new System.Drawing.Size(63, 17);
            this.latitude1Label.TabIndex = 3;
            this.latitude1Label.Text = "Latitude:";
            // 
            // latitude1TextBox
            // 
            this.latitude1TextBox.Location = new System.Drawing.Point(81, 29);
            this.latitude1TextBox.Name = "latitude1TextBox";
            this.latitude1TextBox.Size = new System.Drawing.Size(100, 22);
            this.latitude1TextBox.TabIndex = 1;
            this.latitude1TextBox.Text = "0";
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
            this.longitude1TextBox.TabIndex = 2;
            this.longitude1TextBox.Text = "0";
            // 
            // secondGpsCoordinateCheckBox
            // 
            this.secondGpsCoordinateCheckBox.AutoSize = true;
            this.secondGpsCoordinateCheckBox.Checked = true;
            this.secondGpsCoordinateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.secondGpsCoordinateCheckBox.Location = new System.Drawing.Point(15, 57);
            this.secondGpsCoordinateCheckBox.Name = "secondGpsCoordinateCheckBox";
            this.secondGpsCoordinateCheckBox.Size = new System.Drawing.Size(230, 21);
            this.secondGpsCoordinateCheckBox.TabIndex = 3;
            this.secondGpsCoordinateCheckBox.Text = "Search by two GPS coordinates";
            this.secondGpsCoordinateCheckBox.UseVisualStyleBackColor = true;
            this.secondGpsCoordinateCheckBox.CheckedChanged += new System.EventHandler(this.SecondGpsCoordinateCheckBox_CheckedChanged);
            // 
            // gpsCoordinates2Label
            // 
            this.gpsCoordinates2Label.AutoSize = true;
            this.gpsCoordinates2Label.Location = new System.Drawing.Point(12, 81);
            this.gpsCoordinates2Label.Name = "gpsCoordinates2Label";
            this.gpsCoordinates2Label.Size = new System.Drawing.Size(129, 17);
            this.gpsCoordinates2Label.TabIndex = 7;
            this.gpsCoordinates2Label.Text = "GPS Coordinates 2";
            // 
            // longitude2Label
            // 
            this.longitude2Label.AutoSize = true;
            this.longitude2Label.Location = new System.Drawing.Point(189, 104);
            this.longitude2Label.Name = "longitude2Label";
            this.longitude2Label.Size = new System.Drawing.Size(75, 17);
            this.longitude2Label.TabIndex = 11;
            this.longitude2Label.Text = "Longitude:";
            // 
            // longitude2TextBox
            // 
            this.longitude2TextBox.Location = new System.Drawing.Point(270, 101);
            this.longitude2TextBox.Name = "longitude2TextBox";
            this.longitude2TextBox.Size = new System.Drawing.Size(100, 22);
            this.longitude2TextBox.TabIndex = 5;
            this.longitude2TextBox.Text = "1000";
            // 
            // latitude2Label
            // 
            this.latitude2Label.AutoSize = true;
            this.latitude2Label.Location = new System.Drawing.Point(12, 104);
            this.latitude2Label.Name = "latitude2Label";
            this.latitude2Label.Size = new System.Drawing.Size(63, 17);
            this.latitude2Label.TabIndex = 9;
            this.latitude2Label.Text = "Latitude:";
            // 
            // latitude2TextBox
            // 
            this.latitude2TextBox.Location = new System.Drawing.Point(81, 101);
            this.latitude2TextBox.Name = "latitude2TextBox";
            this.latitude2TextBox.Size = new System.Drawing.Size(100, 22);
            this.latitude2TextBox.TabIndex = 4;
            this.latitude2TextBox.Text = "1000";
            // 
            // findPropertiesButton
            // 
            this.findPropertiesButton.Location = new System.Drawing.Point(15, 129);
            this.findPropertiesButton.Name = "findPropertiesButton";
            this.findPropertiesButton.Size = new System.Drawing.Size(355, 23);
            this.findPropertiesButton.TabIndex = 6;
            this.findPropertiesButton.Text = "Find properties";
            this.findPropertiesButton.UseVisualStyleBackColor = true;
            this.findPropertiesButton.Click += new System.EventHandler(this.FindPropertiesButton_Click);
            // 
            // findParcelsButton
            // 
            this.findParcelsButton.Location = new System.Drawing.Point(15, 158);
            this.findParcelsButton.Name = "findParcelsButton";
            this.findParcelsButton.Size = new System.Drawing.Size(355, 23);
            this.findParcelsButton.TabIndex = 7;
            this.findParcelsButton.Text = "Find parcels";
            this.findParcelsButton.UseVisualStyleBackColor = true;
            this.findParcelsButton.Click += new System.EventHandler(this.FindParcelsButton_Click);
            // 
            // findAllButton
            // 
            this.findAllButton.Location = new System.Drawing.Point(15, 187);
            this.findAllButton.Name = "findAllButton";
            this.findAllButton.Size = new System.Drawing.Size(355, 23);
            this.findAllButton.TabIndex = 8;
            this.findAllButton.Text = "Find all";
            this.findAllButton.UseVisualStyleBackColor = true;
            this.findAllButton.Click += new System.EventHandler(this.FindAllButton_Click);
            // 
            // addPropertyButton
            // 
            this.addPropertyButton.Location = new System.Drawing.Point(15, 218);
            this.addPropertyButton.Name = "addPropertyButton";
            this.addPropertyButton.Size = new System.Drawing.Size(166, 23);
            this.addPropertyButton.TabIndex = 9;
            this.addPropertyButton.Text = "Add property";
            this.addPropertyButton.UseVisualStyleBackColor = true;
            this.addPropertyButton.Click += new System.EventHandler(this.AddPropertyButton_Click);
            // 
            // addParcelButton
            // 
            this.addParcelButton.Location = new System.Drawing.Point(192, 218);
            this.addParcelButton.Name = "addParcelButton";
            this.addParcelButton.Size = new System.Drawing.Size(178, 23);
            this.addParcelButton.TabIndex = 10;
            this.addParcelButton.Text = "Add parcel";
            this.addParcelButton.UseVisualStyleBackColor = true;
            this.addParcelButton.Click += new System.EventHandler(this.AddParcelButton_Click);
            // 
            // propertiesCountTextBox
            // 
            this.propertiesCountTextBox.Location = new System.Drawing.Point(93, 248);
            this.propertiesCountTextBox.Name = "propertiesCountTextBox";
            this.propertiesCountTextBox.Size = new System.Drawing.Size(88, 22);
            this.propertiesCountTextBox.TabIndex = 11;
            this.propertiesCountTextBox.Text = "10000";
            // 
            // parcelsCountTextBox
            // 
            this.parcelsCountTextBox.Location = new System.Drawing.Point(270, 248);
            this.parcelsCountTextBox.Name = "parcelsCountTextBox";
            this.parcelsCountTextBox.Size = new System.Drawing.Size(100, 22);
            this.parcelsCountTextBox.TabIndex = 13;
            this.parcelsCountTextBox.Text = "10000";
            // 
            // populateButton
            // 
            this.populateButton.Location = new System.Drawing.Point(15, 277);
            this.populateButton.Name = "populateButton";
            this.populateButton.Size = new System.Drawing.Size(355, 23);
            this.populateButton.TabIndex = 14;
            this.populateButton.Text = "Populate with random data";
            this.populateButton.UseVisualStyleBackColor = true;
            this.populateButton.Click += new System.EventHandler(this.PopulateButton_Click);
            // 
            // propertiesCsvFileTextBox
            // 
            this.propertiesCsvFileTextBox.Location = new System.Drawing.Point(270, 306);
            this.propertiesCsvFileTextBox.Name = "propertiesCsvFileTextBox";
            this.propertiesCsvFileTextBox.Size = new System.Drawing.Size(100, 22);
            this.propertiesCsvFileTextBox.TabIndex = 15;
            this.propertiesCsvFileTextBox.Text = "properties.csv";
            // 
            // savePropertiesButton
            // 
            this.savePropertiesButton.Location = new System.Drawing.Point(15, 306);
            this.savePropertiesButton.Name = "savePropertiesButton";
            this.savePropertiesButton.Size = new System.Drawing.Size(60, 23);
            this.savePropertiesButton.TabIndex = 16;
            this.savePropertiesButton.Text = "Save";
            this.savePropertiesButton.UseVisualStyleBackColor = true;
            // 
            // loadPropertiesButton
            // 
            this.loadPropertiesButton.Location = new System.Drawing.Point(81, 306);
            this.loadPropertiesButton.Name = "loadPropertiesButton";
            this.loadPropertiesButton.Size = new System.Drawing.Size(60, 23);
            this.loadPropertiesButton.TabIndex = 17;
            this.loadPropertiesButton.Text = "Load";
            this.loadPropertiesButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "CSV properties file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "CSV parcels file:";
            // 
            // loadParcelsButton
            // 
            this.loadParcelsButton.Location = new System.Drawing.Point(81, 336);
            this.loadParcelsButton.Name = "loadParcelsButton";
            this.loadParcelsButton.Size = new System.Drawing.Size(60, 23);
            this.loadParcelsButton.TabIndex = 20;
            this.loadParcelsButton.Text = "Load";
            this.loadParcelsButton.UseVisualStyleBackColor = true;
            // 
            // parcelsCsvFileTextBox
            // 
            this.parcelsCsvFileTextBox.Location = new System.Drawing.Point(270, 336);
            this.parcelsCsvFileTextBox.Name = "parcelsCsvFileTextBox";
            this.parcelsCsvFileTextBox.Size = new System.Drawing.Size(100, 22);
            this.parcelsCsvFileTextBox.TabIndex = 18;
            this.parcelsCsvFileTextBox.Text = "parcels.csv";
            // 
            // saveParcelsButton
            // 
            this.saveParcelsButton.Location = new System.Drawing.Point(15, 336);
            this.saveParcelsButton.Name = "saveParcelsButton";
            this.saveParcelsButton.Size = new System.Drawing.Size(60, 23);
            this.saveParcelsButton.TabIndex = 19;
            this.saveParcelsButton.Text = "Save";
            this.saveParcelsButton.UseVisualStyleBackColor = true;
            // 
            // propertiesCountLabel
            // 
            this.propertiesCountLabel.AutoSize = true;
            this.propertiesCountLabel.Location = new System.Drawing.Point(12, 251);
            this.propertiesCountLabel.Name = "propertiesCountLabel";
            this.propertiesCountLabel.Size = new System.Drawing.Size(77, 17);
            this.propertiesCountLabel.TabIndex = 25;
            this.propertiesCountLabel.Text = "Properties:";
            // 
            // parcelsCountLabel
            // 
            this.parcelsCountLabel.AutoSize = true;
            this.parcelsCountLabel.Location = new System.Drawing.Point(190, 251);
            this.parcelsCountLabel.Name = "parcelsCountLabel";
            this.parcelsCountLabel.Size = new System.Drawing.Size(59, 17);
            this.parcelsCountLabel.TabIndex = 26;
            this.parcelsCountLabel.Text = "Parcels:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 373);
            this.Controls.Add(this.parcelsCountLabel);
            this.Controls.Add(this.propertiesCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadParcelsButton);
            this.Controls.Add(this.parcelsCsvFileTextBox);
            this.Controls.Add(this.saveParcelsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadPropertiesButton);
            this.Controls.Add(this.propertiesCsvFileTextBox);
            this.Controls.Add(this.savePropertiesButton);
            this.Controls.Add(this.parcelsCountTextBox);
            this.Controls.Add(this.populateButton);
            this.Controls.Add(this.propertiesCountTextBox);
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
            this.MaximumSize = new System.Drawing.Size(400, 420);
            this.MinimumSize = new System.Drawing.Size(400, 420);
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
        private System.Windows.Forms.TextBox propertiesCountTextBox;
        private System.Windows.Forms.TextBox parcelsCountTextBox;
        private System.Windows.Forms.Button populateButton;
        private System.Windows.Forms.TextBox propertiesCsvFileTextBox;
        private System.Windows.Forms.Button savePropertiesButton;
        private System.Windows.Forms.Button loadPropertiesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadParcelsButton;
        private System.Windows.Forms.TextBox parcelsCsvFileTextBox;
        private System.Windows.Forms.Button saveParcelsButton;
        private System.Windows.Forms.Label propertiesCountLabel;
        private System.Windows.Forms.Label parcelsCountLabel;
    }
}

