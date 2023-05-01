using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visioner
{
    public partial class EditCasesForm : Form
    {
        private List<string> _list;
        
        public EditCasesForm(List<string> cases)
        {
            InitializeComponent();
            _list = cases;
            listBox1.DataSource = _list;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
