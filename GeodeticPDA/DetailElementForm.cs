using GeodeticPDA.Presenter;
using System;
using System.Windows.Forms;

namespace GeodeticPDA
{
    public partial class DetailElementForm : Form
    {
        private readonly GeodeticPdaPresenter _presenter;
        private ElementInputData _elementInputData;

        public DetailElementForm(GeodeticPdaPresenter presenter, ElementInputData elementInputData, bool newElem)
        {
            InitializeComponent();
            _presenter = presenter;
            _elementInputData = elementInputData;
            detailkey1TextBox.Text = elementInputData.Key1;
            detailKey2TextBox.Text = elementInputData.Key2;
            detailValueTextBox.Text = elementInputData.Value;

            removeElementButton.Visible = !newElem;
            saveElementButton.Visible = newElem;
        }

        private void SaveElementButton_Click(object sender, EventArgs e)
        {
            _elementInputData.Key1 = detailkey1TextBox.Text;
            _elementInputData.Key2 = detailKey2TextBox.Text;
            _elementInputData.Value = detailValueTextBox.Text;

            _presenter.Save(_elementInputData);
            Close();
        }

        private void removeElementButton_Click(object sender, EventArgs e)
        {
            _presenter.RemoveElement(_elementInputData);
            Close();
        }
    }
}
