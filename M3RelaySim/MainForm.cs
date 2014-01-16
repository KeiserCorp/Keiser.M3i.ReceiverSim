using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace M3RelaySim
{
    public partial class MainForm : Form
    {
        private Relay relay;
        private Log log;

        public MainForm()
        {
            InitializeComponent();
            log = new Log(this.outputBox);
            relay = new Relay(log);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.setRunState();
        }

        private void setErrorMessage(string message)
        {
            this.errorStatus.ForeColor = System.Drawing.Color.Red;
            this.errorStatus.Text = message;
        }

        private void clearErrorMessage()
        {
            this.errorStatus.Text = "";
        }

        private void ipAddressBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string errorMessage = "Invalid IPv4 Address";

            if (ipAddress_isValid(tb.Text))
            {
                tb.Tag = true;
                tb.BackColor = System.Drawing.SystemColors.Window;
                if (this.errorStatus.Text == errorMessage)
                    clearErrorMessage();
            }
            else
            {
                tb.Tag = false;
                tb.BackColor = Color.Red;
                setErrorMessage(errorMessage);
            }
        }

        private void portBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string errorMessage = "Invalid Port (Range 1 - 65535)";

            if (portBox_isValid(tb.Text))
            {
                tb.Tag = true;
                tb.BackColor = System.Drawing.SystemColors.Window;
                if (this.errorStatus.Text == errorMessage)
                    clearErrorMessage();
            }
            else
            {
                tb.Tag = false;
                tb.BackColor = Color.Red;
                setErrorMessage(errorMessage);
            }
        }

        private bool portBox_isValid(string portString)
        {
            int port = Convert.ToInt32(portString);
            return (port > 0 && port < 65535);
        }

        private static bool ipAddress_isValid(string ipAddress)
        {
            IPAddress unused;
            return IPAddress.TryParse(ipAddress, out unused)
              &&
              (
                  unused.AddressFamily != AddressFamily.InterNetwork
                  ||
                  ipAddress.Count(c => c == '.') == 3
              );
        }

        private bool isFormValid()
        {
            if (ipAddress_isValid(this.ipAddressBox.Text) && portBox_isValid(this.portBox.Text))
                return true;
            ipAddressBox_Validating(this.ipAddressBox, null);
            portBox_Validating(this.portBox, null);
            return false;
        }

        private void ipAddressBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == '.') && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Left) && !(e.KeyChar == (char)Keys.Right))
            {
                e.Handled = true;
            }
        }

        private void portBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Left) && !(e.KeyChar == (char)Keys.Right))
            {
                e.Handled = true;
            }
        }

        private void threadToggleButton_Click(object sender, EventArgs e)
        {
            if ((!relay.running && isFormValid()) || relay.running)
            {
                if (!relay.running)
                {
                    DisableControls(this);
                    log.add("Started", true);
                    setRelayAtts();
                    relay.start(Convert.ToInt32(this.numOfBikesNumeric.Value));
                }
                else
                {
                    log.add("Stopped", true);
                    relay.stop();
                    EnableControls(this);
                }
                setRunState();
            }
        }

        private void setRelayAtts()
        {
            relay.uuidLong = this.idLongCheckbox.Checked;
            relay.rpmLong = this.rpmLongCheckbox.Checked;
            relay.hrLong = this.hrLongCheckbox.Checked;
            relay.kcalSend = this.kcalSendCheckbox.Checked;
            relay.clockSend = this.clockSendCheckbox.Checked;
            relay.rssiSend = this.rssiSendCheckbox.Checked;
            relay.ipAddress = this.ipAddressBox.Text;
            relay.ipPort = Convert.ToUInt16(this.portBox.Text);
        }

        private void setRunState()
        {
            if (relay.running)
            {
                this.threadToggleButton.Text = "Stop";
                this.statusBarCurrentState.BackColor = System.Drawing.Color.Green;
                this.statusBarCurrentState.Text = "Running";
            }
            else
            {
                this.threadToggleButton.Text = "Start";
                this.statusBarCurrentState.BackColor = System.Drawing.Color.Red;
                this.statusBarCurrentState.Text = "Stopped";
            }
        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            if (con is CheckBox || con is TextBox)
                con.Enabled = false;
        }

        private void EnableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                EnableControls(c);
            }
            if (con is CheckBox || con is TextBox)
                con.Enabled = true;
        }

        private void statusBarSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|log files (*.log)|*.log";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    sw.Write(log.get());
            }
        }

        private void statusBarClearButton_Click(object sender, EventArgs e)
        {
            log.clear();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://manuals.keiser.com/downloads/m3relay/Keiser_M3_Relay_Transmission.pdf");
            Process.Start(sInfo);
        }

    }

    public class Log
    {
        private string _log = "";
        private ListBox _outputBox;
        Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

        public Log(ListBox realBox)
        {
            _outputBox = realBox;
        }

        public string get()
        {
            return _log;
        }

        public void add(string message, bool timeEncode = false)
        {
            if (!dispatcher.CheckAccess())
            {
                dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate() { add(message, timeEncode); });
            }
            else
            {
                if (timeEncode)
                    message = "[ " + message + ": " + DateTime.Now + " ]";
                _outputBox.Items.Add(message);
                _outputBox.SelectedIndex = _outputBox.Items.Count - 1;
                _log += message + "\n";
            }
        }

        public void clear()
        {
            _outputBox.Items.Clear();
            _log = "";
        }

    }
}
