using System;
using System.IO.Ports;
using System.Windows.Forms;
using NKH.MindSqualls;

namespace Lego
{
    public partial class MainForm : Form
    {
        private NxtBrick _brick;
        private Single _cmd = 5;
        private Single _power = 0;

        public MainForm()
        {
            InitializeComponent();
            SetEnableContriols(false);
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string portName = comboBoxPort.Text.ToUpper();
            if (portName.StartsWith("COM")) portName = portName.Remove(0, 3);
            byte comPort = byte.Parse(portName);
            _brick = new NxtBrick(NxtCommLinkType.Bluetooth, comPort);
            _brick.Connect();
            SetEnableContriols(true);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (_brick != null && _brick.IsConnected)
                _brick.Disconnect();

            _brick = null;

            SetEnableContriols(false);
        }

        private void cmd_Click(object sender, EventArgs e)
        {
            try
            {
                _cmd = Convert.ToSingle(((Button) sender).Tag);
                // Команда - Число одинарной точности (IEEE 754)
                _brick.CommLink.MessageWrite(NxtMailbox.Box0, BitConverter.GetBytes(_cmd));
                // Отпрвляем Power
                trackBarPower_ValueChanged(trackBarPower, EventArgs.Empty);
            }
            catch (Exception)
            {
                Disconnect();
            }
        }
        
        private void trackBarPower_ValueChanged(object sender, EventArgs e)
        {
            _power = Convert.ToSingle(((TrackBar)sender).Value);
            // Мощность - Число одинарной точности (IEEE 754)
            _brick.CommLink.MessageWrite(NxtMailbox.Box1, BitConverter.GetBytes(Convert.ToSingle(_power)));
        }

        private void SetEnableContriols(bool isEnable)
        {
            foreach (Control conrtol in this.Controls)
                conrtol.Enabled = isEnable;
            btnConnect.Enabled = !isEnable;
            comboBoxPort.Enabled = !isEnable;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            try
            {
                // Команда - Число одинарной точности (IEEE 754)
                _brick.CommLink.MessageWrite(NxtMailbox.Box2, BitConverter.GetBytes((Single)1));
            }
            catch (Exception)
            {
                Disconnect();
            }
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            try
            {
                // Команда - Число одинарной точности (IEEE 754)
                _brick.CommLink.MessageWrite(NxtMailbox.Box2, BitConverter.GetBytes((Single)2));
            }
            catch (Exception)
            {
                Disconnect();
            }
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            try
            {
                // Команда - Число одинарной точности (IEEE 754)
                _brick.CommLink.MessageWrite(NxtMailbox.Box2, BitConverter.GetBytes((Single)3));
            }
            catch (Exception)
            {
                Disconnect();
            }
        }

        private void btnLightOff_Click(object sender, EventArgs e)
        {
            try
            {
                // Команда - Число одинарной точности (IEEE 754)
                _brick.CommLink.MessageWrite(NxtMailbox.Box2, BitConverter.GetBytes((Single)0));
            }
            catch (Exception)
            {
                Disconnect();
            }
        }
    }
}