using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmj
{
    public partial class FormSetting : Form
    {
        Form1 _form;

        public FormSetting(Form1 form)
        {
            this._form = form;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            var setting = new ParameterSetting(_form);
            setting.Dock = DockStyle.Fill;
            panel1.Controls.Add(setting);
        }
    }
}
