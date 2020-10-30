using GeodeticPDA.Presenter;
using System;
using System.Windows.Forms;

namespace GeodeticPDA
{
    public partial class ChooseForm : Form
    {
        private readonly GeodeticPdaPresenter _presenter;

        public ChooseForm(GeodeticPdaPresenter presenter, object[] foundItems)
        {
            InitializeComponent();
            _presenter = presenter;
            chooseFromListBox.Items.AddRange(foundItems);
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            object o = chooseFromListBox.SelectedItem;
            Close();
            var detailForm = new DetailForm(_presenter, UserInputDataFactory.GetUserInputData(o));
            detailForm.ShowDialog();
        }

    }
}
