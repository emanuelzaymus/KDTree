using GeodeticPDA.Model;
using GeodeticPDA.Presenter;
using System;
using System.Windows.Forms;

namespace GeodeticPDA
{
    /// <summary>
    /// Window for choosing/selecting from found properties or parcels.
    /// </summary>
    public partial class ChooseForm : Form
    {
        private readonly GeodeticPdaPresenter _presenter;

        /// <summary>
        /// Window for choosing/selecting from found properties or parcels.
        /// </summary>
        /// <param name="presenter">Presenter of the program</param>
        /// <param name="foundItems">Found objects to show</param>
        public ChooseForm(GeodeticPdaPresenter presenter, object[] foundItems)
        {
            InitializeComponent();
            _presenter = presenter;
            chooseFromListBox.Items.AddRange(foundItems);
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            object o = chooseFromListBox.SelectedItem;
            if (o != null)
            {
                Close();
                var detailForm = new DetailForm(_presenter, UserInputDataFactory.GetUserInputData(o));
                detailForm.ShowDialog();
            }
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

        private void ChooseElementButton_Click(object sender, EventArgs e)
        {
            object o = chooseFromListBox.SelectedItem;
            if (o != null)
            {
                Close();
                Element elem = (Element)o;
                ElementInputData input = new ElementInputData(elem.Key1, elem.Key2, elem.Value.ToString()) { OriginalElement = elem };
                var detailForm = new DetailElementForm(_presenter, input, newElem: false);
                detailForm.ShowDialog();
            }
        }
    }
}
