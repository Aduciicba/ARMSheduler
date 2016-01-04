using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARMShedulerApp
{
    public partial class fmEmailEdit : Form
    {
        public EventEmail EditingEmail;
        public fmEmailEdit()
        {
            InitializeComponent();
        }

        private void fmEmailEdit_Load(object sender, EventArgs e)
        {
            Binding email = new Binding("Text", EditingEmail, "email", false, DataSourceUpdateMode.OnPropertyChanged);
            teEmail.DataBindings.Add(email);
        }

        bool Validate()
        {
            if (teEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email адрес недолжен быть пустым", "Ошибка");
                return false;
            }
            if (teEmail.Text.IndexOf('@') == -1)
            {
                MessageBox.Show("Email адрес должен содержать знак @", "Ошибка");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
