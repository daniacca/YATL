using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using ReadWriteCsv;
using System.Globalization;
using System.Text.RegularExpressions;

/*
 * Yet Another Tcp Logger - Microsoft .NET 
 * 
 * This program open a Tcp Socket connection and log every byte received on
 * this connection. On the open connection, you could sent to the open socket 
 * Tcp Message as well. 
 * 
 * Support for the following data format (receveing and sending):
 * Binary, Hex, ASCII;
 */

namespace TcpLogger
{
    public partial class TCPLoggerMain : Form
    {
        // Working Thread for continuos receiving byte
        Thread ReceivingThread;
        
        // TcpClient object for Socket connection and communication
        TcpClient myHost;

        // Global counter used for connection animation
        int counter = 0;

        // Application global running State Flag
        bool isConnected = false;
        bool connectionFinish = false;
        bool threadRunning = false;
        bool threadFinish = false;
        bool ShouldStop = false;
        bool isSending = false;

        // Connection global parameter
        int READ_BUFFER_SIZE = 512;
        string fileLogPath = @"E:\SystemLog\log.csv";
        string delimiter = "\r\n";
        int ConnectionPort;
        
        public TCPLoggerMain()
        {
            InitializeComponent();
            ConnectionPort = Convert.ToUInt16(txtConnectionPort.Text);
            myHost = new TcpClient();

            txtPathFileLog.Text = fileLogPath;
            txtPathFileLog.ReadOnly = true;
            txtPathFileLog.BackColor = System.Drawing.SystemColors.Window;

            cmbDelimiter.SelectedIndex = 3;
            cmbBufferSize.SelectedIndex = 4;
            updateByteViewDataGrid(READ_BUFFER_SIZE);
        }

        #region Connection
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (!isConnected)
                Connect();
            else
                Disconnect();
        }

        private void Connect()
        {
            try
            {
                // Get the connection Port
                ConnectionPort = Convert.ToUInt16(txtConnectionPort.Text);
                if (ConnectionPort < 1025)
                    throw new OverflowException();

                // Reset the connection finish Flag
                connectionFinish = false;

                // Activate the timer for animation during connection
                animationConnectionTimer.Enabled = true;

                // Start the connection
                myHost.BeginConnect(ipAddressRemote.IPAddress, ConnectionPort, connectionFinishCallback, new object());
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format of the port number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Insert a number in the valid range, between 1024 and 65536!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during Connection.\nError Message:\n" + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connectionFinishCallback(IAsyncResult ar)
        {
            // End connect
            try
            {
                myHost.EndConnect(ar);
            }
            catch
            { }

            // Set the connection flag
            connectionFinish = true;
            isConnected = myHost.Connected;

            // If the system succesfully connect, set the receiving timeout
            if (isConnected)
                myHost.ReceiveTimeout = 100;
            
            // Invoke the update of the GUI status
            this.Invoke(new MethodInvoker(delegate { updateConnectionGUI(isConnected); }));
        }

        private void Disconnect()
        {
            // If the receiving thread was running, stop it
            if (threadRunning)
                stopReceivingThread();

            // Close the actual connection and make new TcpClien
            myHost.GetStream().Close();
            myHost.Close();
            myHost = new TcpClient();

            // Reset the connection flag and update the GUI
            isConnected = false;
            updateConnectionGUI(isConnected);
        }
        #endregion

        #region Receiving 
        private void btnStartLog_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!threadRunning)
            {
                Start();
                btnStartLog.Text = "Stop Log";
                statusLabel.ForeColor = Color.DarkOliveGreen;
                statusLabel.Text = "Receiving Data on the connected Thread port!";
            }
            else
            {
                Stop();
                btnStartLog.Text = "Start Log";
                statusLabel.ForeColor = Color.ForestGreen;
                statusLabel.Text = "Connected to the remote Host OK!";
            }
            updateItemGUI(threadRunning, "s");
            updateItemGUI(!threadRunning, "f");
            updateItemGUI((isConnected && threadRunning && asciiOutput.Checked), "del");
            updateItemGUI((isConnected && threadRunning && !asciiOutput.Checked), "checksum");
            this.Cursor = Cursors.Default;
        }

        private void Start()
        {
            // Reset the thread flag
            ShouldStop = false;
            threadFinish = false;

            // Start new Thread for receiving byte data
            ReceivingThread = new Thread(ReceivingTaskThread);
            ReceivingThread.Start();

            // Set the threadRunning flag
            threadRunning = true;
        }

        private void Stop()
        {
            // Stop the reciving thread
            stopReceivingThread();

            // Reset the thread running flag
            threadRunning = false;
            threadFinish = false;
        }

        private void ReceivingTaskThread()
        {
            while (!ShouldStop)
            {
                try
                {
                    byte[] buffer = new byte[READ_BUFFER_SIZE];
                    if (myHost.GetStream().DataAvailable)
                    {
                        myHost.GetStream().Read(buffer, 0, READ_BUFFER_SIZE);
                        if (CheckNonZeroByteData(buffer))
                        {
                            string[] readBufferBinary = new string[READ_BUFFER_SIZE + 2];
                            string[] readBufferHex = new string[READ_BUFFER_SIZE + 2];
                            string[] readBufferASCII = new string[READ_BUFFER_SIZE + 2];
                            char[] readCharsASCII = Encoding.ASCII.GetChars(buffer);

                            for (int i = 0; i < buffer.Length + 2; i++)
                            {
                                if (i > 1)
                                {
                                    readBufferBinary[i] = (Convert.ToString(buffer[i - 2], 2).PadLeft(8, '0') + " ");
                                    readBufferHex[i] = (Convert.ToString(buffer[i - 2], 16).PadLeft(2, '0') + " ");
                                    readBufferASCII[i] = replaceSpecialCharacter(readCharsASCII[i - 2].ToString());
                                }
                                else if (i == 0)
                                {
                                    readBufferBinary[i] = "binary";
                                    readBufferHex[i] = "Hex";
                                    readBufferASCII[i] = "ASCII";
                                }
                                else
                                {
                                    string stamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss.fffff", CultureInfo.InvariantCulture);
                                    readBufferBinary[i] = stamp;
                                    readBufferHex[i] = stamp;
                                    readBufferASCII[i] = stamp;
                                }
                            }
                            this.Invoke(new MethodInvoker(delegate { updateListLog(readBufferBinary, readBufferHex, readBufferASCII); }));
                        }
                    }
                }
                catch
                {

                }
            }
            if (ShouldStop)
                threadFinish = true;
        }

        private bool CheckNonZeroByteData(byte[] buffer)
        {
            foreach (byte b in buffer)
                if (b > 0)
                    return true;
            return false;
        }

        private void stopReceivingThread()
        {
            // Set the stop flag for the thread cycle
            ShouldStop = true;

            // wait for thread to regulary stop its loop
            Thread.Sleep(500);

            // if after the time the thread is not finished yet, force it stop with abort
            if (!threadFinish)
            {
                ReceivingThread.Abort();
                ReceivingThread.Join();
            }

            // reset the thread state flag
            threadFinish = false;
            threadRunning = false;
        }
        #endregion

        #region Sending
        private void btnSend_Click(object sender, EventArgs e)
        {
            sendData();
        }

        private void updateSendingState(bool isSending)
        {
            btnSend.Enabled = !isSending;
            txtSend.Enabled = !isSending;
        }

        private void SendFinishCallback(IAsyncResult ar)
        {
            try
            {
                myHost.GetStream().EndWrite(ar);
            }
            catch
            {
                //lastSendError = true;
            }
            isSending = false;
            this.Invoke(new MethodInvoker(delegate { updateSendingState(isSending); }));
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendData();
            }
        }

        private void sendData()
        {
            // Variables for enconding format and the byte buffer to send
            byte[] byteData;
            EncodingType type;

            // Get the enconding type from which radio button was selected
            var checkedButton = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch(checkedButton.Name)
            {
                case "asciiOutput":
                    type = EncodingType.ASCII;
                    break;
                case "hexRawOutput":
                    type = EncodingType.Hex;
                    break;
                case "BinRawOutput":
                    type = EncodingType.Binary;
                    break;
                default:
                    MessageBox.Show("No encoding selected to send the byte Data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Encoding the binary data buffer to send
            try
            {
                byteData = EncodeSendingData(txtSend.Text, type, (!asciiOutput.Checked && chkBoxCheckSum.Checked), delimiter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update sending status
            isSending = true;
            updateSendingState(isSending);

            // Begin sending the data to the remote device
            myHost.GetStream().BeginWrite(byteData, 0, byteData.Length, new AsyncCallback(SendFinishCallback), new object());
        }

        private byte[] EncodeSendingData(string text, EncodingType encoding, bool checkSumRequired, string delimiter)
        {
            // Enconding data to send
            byte[] byteData;

            switch(encoding)
            {
                case EncodingType.ASCII:
                    byteData = Encoding.ASCII.GetBytes(text + delimiter);
                    break;
                case EncodingType.Binary:
                    try
                    {
                        byteData = StringToByteArray(text, numberBaseType.baseBinary);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Invalid Binary string format.\nPlease enter a valid binary message!");
                    }
                    break;
                case EncodingType.Hex:
                    try
                    {
                        byteData = StringToByteArray(text, numberBaseType.baseHex);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Invalid Hex string format.\nPlease enter a valid hexadecimal message!");
                    }
                    break;
                default:
                    throw new Exception("Invalid Encoding format!");
            }
            
            if (checkSumRequired)
            {
                byte[] app = byteData;
                byteData = new byte[app.Length + 1];
                Array.Copy(app, byteData, app.Length);
                byteData[app.Length] = ComputeAdditionChecksum(app);
            }

            return byteData;
        }

        public byte[] StringToByteArray(string input, numberBaseType numberBase)
        {
            int singleByteLenght = (numberBase == numberBaseType.baseBinary) ? 8 : 2;
            return Enumerable.Range(0, input.Length)
                             .Where(x => x % singleByteLenght == 0)
                             .Select(x => Convert.ToByte(input.Substring(x, singleByteLenght), Convert.ToInt32(numberBase)))
                             .ToArray();
        }

        public enum numberBaseType
        {
            baseBinary = 2,
            baseHex = 16,
        }

        public enum EncodingType
        {
            ASCII = 1,
            Binary = 2,
            Hex = 3,
        }
        #endregion

        #region GUI updating and Settings
        private void updateByteViewDataGrid(int bufferLenght)
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[bufferLenght + 2];
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = new DataGridViewTextBoxColumn();
                if (i > 1)
                    columns[i].Name = (i - 2).ToString();
                else if (i == 0)
                    columns[i].Name = "Data Type";
                else
                    columns[i].Name = "Time";
                columns[i].FillWeight = 1;
            }

            lstLog.Columns.Clear();
            lstLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            lstLog.Columns.AddRange(columns);
            lstLog.Refresh();
        }

        private void updateConnectionGUI(bool result)
        {
            if (result)
            {
                // System Connected
                btnConnect.Text = "Disconnect";
                statusLabel.ForeColor = Color.ForestGreen;
                statusLabel.Text = "Connected to the remote Host OK!";
            }
            else
            {
                // System Disconnected
                btnConnect.Text = "Connect";
                statusLabel.ForeColor = Color.DarkRed;
                statusLabel.Text = "System Disconnected!";
                ClearLogView();
            }
            updateItemGUI(result, "l");
            updateItemGUI(!result, "c");
            updateItemGUI((result && !threadRunning), "f");
            updateItemGUI((result && threadRunning), "s");
            updateItemGUI((result && threadRunning && asciiOutput.Checked), "del");
            updateItemGUI((result && threadRunning && !asciiOutput.Checked), "checksum");
            btnConnect.Enabled = true;
            btnStartLog.Text = "Start Log";
        }

        private void updateItemGUI(bool enabled, string tag)
        {
            updateItemGUIControls(groupBox1.Controls, tag, enabled);
            updateItemGUIControls(groupBox2.Controls, tag, enabled);
        }

        private void updateItemGUIControls(Control.ControlCollection controlList, string tag, bool enabled)
        {
            foreach (Control x in controlList)
            {
                if (x.Tag != null)
                {
                    if (x.Tag.Equals(tag))
                    {
                        x.Enabled = enabled;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionPort = new Random().Next(1024, 65536);
            txtConnectionPort.Text = ConnectionPort.ToString();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            ClearLogView();
        }

        private void ClearLogView()
        {
            lstLog.Rows.Clear();
            lstLog.Refresh();
        }

        private void TCPLoggerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnected)
            {
                DialogResult res = MessageBox.Show("There is an open connection, are you sure you want to exit?", "Confirm application Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                {
                    if (threadRunning)
                        stopReceivingThread();
                    myHost.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void cmbBufferSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            READ_BUFFER_SIZE = Convert.ToInt32(cmbBufferSize.SelectedItem);
            updateByteViewDataGrid(READ_BUFFER_SIZE);
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            SaveFileDialog openFileDialog1 = new SaveFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Csv Files (.csv)|*.csv|Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathFileLog.Text = openFileDialog1.FileName;
            }
        }

        private void animationConnectionTimer_Tick(object sender, EventArgs e)
        {
            if (!connectionFinish)
            {
                counter = (++counter) % 4;
                statusLabel.ForeColor = Color.DarkOrange;
                string message = "Trying to connect to the remote host";
                for (int i = 0; i < counter; i++)
                    message += ".";
                statusLabel.Text = message;
            }
            else
            {
                animationConnectionTimer.Enabled = false;
            }
        }

        private void updateListLog(string[] readBufferBinary, string[] readBufferHex, string[] readBufferASCII)
        {
            lstLog.SuspendLayout();

            if (chkBoxBinary.Checked)
                lstLog.Rows.Add(readBufferBinary);
            if (chkBoxHex.Checked)
                lstLog.Rows.Add(readBufferHex);
            if (chkBoxAscii.Checked)
                lstLog.Rows.Add(readBufferASCII);

            if (chkBoxSaveFile.Checked)
            {
                using (CsvFileWriter writer = new CsvFileWriter(txtPathFileLog.Text, true))
                {
                    if (chkBoxBinary.Checked)
                    {
                        CsvRow row = new CsvRow();
                        for (int j = 0; j < readBufferBinary.Length; j++)
                            row.Add(String.Format(readBufferBinary[j], j));
                        writer.WriteRow(row);
                    }

                    if (chkBoxHex.Checked)
                    {
                        CsvRow row = new CsvRow();
                        for (int j = 0; j < readBufferHex.Length; j++)
                            row.Add(String.Format(readBufferHex[j], j));
                        writer.WriteRow(row);
                    }

                    if (chkBoxAscii.Checked)
                    {
                        try
                        {
                            CsvRow row = new CsvRow();
                            for (int j = 0; j < readBufferASCII.Length; j++)
                                row.Add(String.Format(readBufferASCII[j], j));
                            writer.WriteRow(row);
                        }
                        catch { }
                    }
                }
            }

            lstLog.ResumeLayout();
        }

        private void cmbDelimiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDelimiter.SelectedIndex > -1)
            {
                string selectedDelimiter = cmbDelimiter.SelectedItem.ToString();
                switch (selectedDelimiter)
                {
                    case "<EMPTY>":
                        delimiter = "";
                        break;
                    case "<NULL>":
                        delimiter = "\0";
                        break;
                    case "<LF>":
                        delimiter = "\n";
                        break;
                    case "<CR><LF>":
                        delimiter = "\r\n";
                        break;
                    default:
                        delimiter = "";
                        break;
                }
            }
        }

        private string replaceSpecialCharacter(string input)
        {
            // Get one single ASCII charcater as input
            string result = "";
            result = Regex.Replace(input, @"\r", "<CR>");
            result = Regex.Replace(result, @"\n", "<LF>");
            result = Regex.Replace(input, @"\0", "<NULL>");
            return result;
        }

        private void chkBoxOutput_CheckedChanged(object sender, EventArgs e)
        {
            checkOutpuReceivedEnabled(sender);
        }

        private void checkOutpuReceivedEnabled(object sender)
        {
            if (!checkIfOutputEnabled())
            {
                MessageBox.Show("You have to enable at least one output enconding format.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckBox chkBox = (CheckBox)sender;
                chkBox.Checked = true;
            }
        }

        private bool checkIfOutputEnabled()
        {
            return (chkBoxAscii.Checked || chkBoxBinary.Checked || chkBoxHex.Checked);
        }

        private void asciiOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (threadRunning)
            {
                RadioButton thisSender = (RadioButton)sender;
                if (thisSender.Name.Contains("ascii") && thisSender.Checked)
                {
                    cmbDelimiter.Enabled = thisSender.Checked;
                    chkBoxCheckSum.Enabled = !thisSender.Checked;
                }
                else if (thisSender.Checked)
                {
                    cmbDelimiter.Enabled = !thisSender.Checked;
                    chkBoxCheckSum.Enabled = thisSender.Checked;
                }
            }
        }

        public static byte ComputeAdditionChecksum(byte[] data)
        {
            long longSum = data.Sum(x => (long)x);
            return unchecked((byte)longSum);
        }
        #endregion
    }
}
