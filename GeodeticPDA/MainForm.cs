using GeodeticPDA.Model;
using GeodeticPDA.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GeodeticPDA
{
    public partial class MainForm : Form
    {
        private readonly GeodeticPdaPresenter _presenter;

        public MainForm(GeodeticPdaPresenter geodeticPdaPresenter)
        {
            InitializeComponent();
            _presenter = geodeticPdaPresenter;
        }

        private void SecondGpsCoordinateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool secondGpsChecked = secondGpsCoordinateCheckBox.Checked;
            gpsCoordinates2Label.Enabled = secondGpsChecked;
            latitude2Label.Enabled = secondGpsChecked;
            latitude2TextBox.Enabled = secondGpsChecked;
            longitude2Label.Enabled = secondGpsChecked;
            longitude2TextBox.Enabled = secondGpsChecked;
        }

        private void FindPropertiesButton_Click(object sender, EventArgs e)
        {
            ICollection<Property> foundProperties = !secondGpsCoordinateCheckBox.Checked
                ? _presenter.FindProperties(latitude1TextBox.Text, longitude1TextBox.Text)
                : _presenter.FindProperties(latitude1TextBox.Text, longitude1TextBox.Text,
                    latitude2TextBox.Text, longitude2TextBox.Text);
            CreateChooseForm(foundProperties.ToArray());
        }

        private void FindParcelsButton_Click(object sender, EventArgs e)
        {
            ICollection<Parcel> foundParcels = !secondGpsCoordinateCheckBox.Checked
                ? _presenter.FindParcels(latitude1TextBox.Text, longitude1TextBox.Text)
                : _presenter.FindParcels(latitude1TextBox.Text, longitude1TextBox.Text,
                    latitude2TextBox.Text, longitude2TextBox.Text);
            CreateChooseForm(foundParcels.ToArray());
        }

        private void FindAllButton_Click(object sender, EventArgs e)
        {
            ICollection<GpsLocationObject> foundAllObjects = !secondGpsCoordinateCheckBox.Checked
               ? _presenter.FindAll(latitude1TextBox.Text, longitude1TextBox.Text)
               : _presenter.FindAll(latitude1TextBox.Text, longitude1TextBox.Text,
                   latitude2TextBox.Text, longitude2TextBox.Text);
            CreateChooseForm(foundAllObjects.ToArray());
        }

        private void CreateChooseForm(object[] foundItems)
        {
            var chooseForm = new ChooseForm(_presenter, foundItems);
            chooseForm.ShowDialog();
        }

        private void AddPropertyButton_Click(object sender, EventArgs e) => CreateDetailForm(new PropertyInputData());

        private void AddParcelButton_Click(object sender, EventArgs e) => CreateDetailForm(new ParcelInputData());

        private void CreateDetailForm(UserInputData data)
        {
            var detailForm = new DetailForm(_presenter, data);
            detailForm.ShowDialog();
        }

        private void PopulateButton_Click(object sender, EventArgs e)
        {
            _presenter.Populate(propertiesCountTextBox.Text, parcelsCountTextBox.Text);
        }

        private void SavePropertiesButton_Click(object sender, EventArgs e)
        {
            _presenter.SavePropertiesToFile(propertyCsvFileTextBox.Text);
        }

        private void SaveParcelsButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveParcelsToFile(parcelCsvFileTextBox.Text);
        }

        private void LoadPropertiesButton_Click(object sender, EventArgs e)
        {
            _presenter.LoadPropertiesFromFile(propertyCsvFileTextBox.Text);
        }

        private void LoadParcelsButton_Click(object sender, EventArgs e)
        {
            _presenter.LoadParcelsFromFile(parcelCsvFileTextBox.Text);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
