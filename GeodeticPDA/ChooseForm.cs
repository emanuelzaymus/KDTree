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
    public partial class ChooseForm : Form
    {
        private GeodeticPdaPresenter _presenter;
        private ICollection<Property> _foundProperties;

        public ChooseForm(GeodeticPdaPresenter presenter, ICollection<Property> foundProperties)
        {
            InitializeComponent();

            _presenter = presenter;
            _foundProperties = foundProperties;
        }

    }
}
