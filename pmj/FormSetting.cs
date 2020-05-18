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
        private PmjSerialPort _serialPort;

        public FormSetting(PmjSerialPort serialPort)
        {
            this._serialPort = serialPort;
           
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            var setting = new ParameterSetting();
            setting.Dock = DockStyle.Fill;
            panel1.Controls.Add(setting);
        }
    }
}
