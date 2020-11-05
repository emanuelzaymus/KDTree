using GeodeticPDA.Presenter;
using System;
using System.Windows.Forms;

namespace GeodeticPDA
{
    /// <summary>
    /// Detail window for viewing, editing or creating <c>Property</c> and <c>Parcel</c>.
    /// </summary>
    public partial class DetailForm : Form
    {
        private readonly GeodeticPdaPresenter _presenter;
        private readonly UserInputData _userInputData;

        /// <summary>
        /// Detail window for viewing, editing or creating <c>Property</c> and <c>Parcel</c>.
        /// </summary>
        /// <param name="presenter">Presenter of the program</param>
        /// <param name="userInputData">User Input Data to view, edit or create</param>
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _userInputData.Number = numberTextBox.Text;
            _userInputData.Description = descriptTextBox.Text;
            _userInputData.GpsLatitude = latitudeTextBox.Text;
            _userInputData.GpsLongitude = longitudeTextBox.Text;

            _presenter.Save(_userInputData);
            Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
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
