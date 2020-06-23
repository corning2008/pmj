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

        public PLCSerialPort _plcSerialPort { get; private set; }

        private string _pmjPort;
        private string _plcPort;

        public FormSetting(PmjSerialPort serialPort,string pmjPort,PLCSerialPort plcSerialPort,string plcPort)
        {
            this._serialPort = serialPort;
            this._plcSerialPort = plcSerialPort;
            this._pmjPort = pmjPort;
            this._plcPort = plcPort;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            var setting = new ParameterSetting(_serialPort,_pmjPort,_plcSerialPort,_plcPort);
            setting.Dock = DockStyle.Fill;
            panel1.Controls.Add(setting);
        }
    }
}
