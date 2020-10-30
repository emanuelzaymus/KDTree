using GeodeticPDA.Presenter;
using System;
using System.Windows.Forms;

namespace GeodeticPDA
{
    public partial class DetailForm : Form
    {
        private readonly GeodeticPdaPresenter _presenter;
        private readonly UserInputData _userInputData;

        public DetailForm(GeodeticPdaPresenter presenter, UserInputData userInputData)
        {
            InitializeComponent();
            _presenter = presenter;
            _userInputData = userInputData;

            bool isEditingMode = !userInputData.IsNew;
            relatedObjectsLabel.Enabled = isEditingMode;
            relatedObjectsListBox.Enabled = isEditingMode;
            removeButton.Visible = isEditingMode;

            numberTextBox.Text = userInputData.Number;
            descriptTextBox.Text = userInputData.Description;
            latitudeTextBox.Text = userInputData.GpsLatitude;
            longitudeTextBox.Text = userInputData.GpsLongitude;
            relatedObjectsListBox.Items.AddRange(userInputData.RelatedObjects);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _userInputData.Number = numberTextBox.Text;
            _userInputData.Description = descriptTextBox.Text;
            _userInputData.GpsLatitude = latitudeTextBox.Text;
            _userInputData.GpsLongitude = longitudeTextBox.Text;

            _presenter.Save(_userInputData);
            Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            _presenter.Remove(_userInputData);
            Close();
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
