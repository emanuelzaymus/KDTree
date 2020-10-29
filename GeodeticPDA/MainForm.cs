using GeodeticPDA.Model;
using GeodeticPDA.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticPDA
{
    public partial class MainForm : Form
    {
        private readonly GeodeticPdaPresenter _presenter = new GeodeticPdaPresenter();

        public MainForm()
        {
            InitializeComponent();
        }

        private void populateButton_Click(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void addPropertyButton_Click(object sender, EventArgs e)
        {
            latitude1TextBox.Text = "Ahoj";
        }

        private void addParcelButton_Click(object sender, EventArgs e)
        {
            longitude1TextBox.Text = latitude1TextBox.Text;
        }

        private void secondGpsCoordinateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool secondGpsChecked = secondGpsCoordinateCheckBox.Checked;
            gpsCoordinates2Label.Enabled = secondGpsChecked;
            latitude2Label.Enabled = secondGpsChecked;
            latitude2TextBox.Enabled = secondGpsChecked;
            longitude2Label.Enabled = secondGpsChecked;
            longitude2TextBox.Enabled = secondGpsChecked;
        }

        private void findPropertiesButton_Click(object sender, EventArgs e)
        {
            ICollection<Property> foundProperties;
            if (!secondGpsCoordinateCheckBox.Checked)
            {
                foundProperties = _presenter.FindProperties(latitude1TextBox.Text, longitude1TextBox.Text);
            }
            else
            {
                foundProperties = _presenter.FindProperties(latitude1TextBox.Text, longitude1TextBox.Text,
                    latitude2TextBox.Text, longitude2TextBox.Text);
            }

            var chooseForm = new ChooseForm(_presenter, foundProperties);
            chooseForm.ShowDialog();
        }

    }
}
