namespace TcpLogger
{
    partial class TCPLoggerMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ipAddressRemote = new IPAddressControlLib.IPAddressControl();
            this.txtConnectionPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.animationConnectionTimer = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            this.btnStartLog = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBoxSaveFile = new System.Windows.Forms.CheckBox();
            this.lstLog = new System.Windows.Forms.DataGridView();
            this.chkBoxBinary = new System.Windows.Forms.CheckBox();
            this.chkBoxHex = new System.Windows.Forms.CheckBox();
            this.chkBoxAscii = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBufferSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBoxCheckSum = new System.Windows.Forms.CheckBox();
            this.BinRawOutput = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDelimiter = new System.Windows.Forms.ComboBox();
            this.hexRawOutput = new System.Windows.Forms.RadioButton();
            this.asciiOutput = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.txtPathFileLog = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.lstLog)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAddressRemote
            // 
            this.ipAddressRemote.AllowInternalTab = false;
            this.ipAddressRemote.AutoHeight = true;
            this.ipAddressRemote.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressRemote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressRemote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressRemote.Location = new System.Drawing.Point(164, 28);
            this.ipAddressRemote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipAddressRemote.MinimumSize = new System.Drawing.Size(114, 24);
            this.ipAddressRemote.Name = "ipAddressRemote";
            this.ipAddressRemote.ReadOnly = false;
            this.ipAddressRemote.Size = new System.Drawing.Size(139, 24);
            this.ipAddressRemote.TabIndex = 0;
            this.ipAddressRemote.Tag = "c";
            this.ipAddressRemote.Text = "192.168.1.10";
            // 
            // txtConnectionPort
            // 
            this.txtConnectionPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectionPort.Location = new System.Drawing.Point(164, 60);
            this.txtConnectionPort.Name = "txtConnectionPort";
            this.txtConnectionPort.Size = new System.Drawing.Size(68, 24);
            this.txtConnectionPort.TabIndex = 2;
            this.txtConnectionPort.Tag = "c";
            this.txtConnectionPort.Text = "8190";
            this.txtConnectionPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 201);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(297, 48);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Tag = "";
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(239, 59);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(65, 28);
            this.btnRandom.TabIndex = 4;
            this.btnRandom.Tag = "c";
            this.btnRandom.Text = "random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(228, 183);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 29);
            this.btnSend.TabIndex = 5;
            this.btnSend.Tag = "s";
            this.btnSend.Text = "send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Enabled = false;
            this.txtSend.Location = new System.Drawing.Point(6, 186);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(216, 22);
            this.txtSend.TabIndex = 6;
            this.txtSend.Tag = "s";
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // animationConnectionTimer
            // 
            this.animationConnectionTimer.Interval = 300;
            this.animationConnectionTimer.Tick += new System.EventHandler(this.animationConnectionTimer_Tick);
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.statusLabel.Location = new System.Drawing.Point(3, 265);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(308, 142);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "System ready...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStartLog
            // 
            this.btnStartLog.Enabled = false;
            this.btnStartLog.Location = new System.Drawing.Point(6, 214);
            this.btnStartLog.Name = "btnStartLog";
            this.btnStartLog.Size = new System.Drawing.Size(145, 49);
            this.btnStartLog.TabIndex = 8;
            this.btnStartLog.Tag = "l";
            this.btnStartLog.Text = "Start Log";
            this.btnStartLog.UseVisualStyleBackColor = true;
            this.btnStartLog.Click += new System.EventHandler(this.btnStartLog_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Enabled = false;
            this.btnClearLog.Location = new System.Drawing.Point(164, 214);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(139, 49);
            this.btnClearLog.TabIndex = 9;
            this.btnClearLog.Tag = "l";
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Port";
            // 
            // chkBoxSaveFile
            // 
            this.chkBoxSaveFile.AutoSize = true;
            this.chkBoxSaveFile.Checked = true;
            this.chkBoxSaveFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxSaveFile.Enabled = false;
            this.chkBoxSaveFile.Location = new System.Drawing.Point(6, 29);
            this.chkBoxSaveFile.Name = "chkBoxSaveFile";
            this.chkBoxSaveFile.Size = new System.Drawing.Size(128, 21);
            this.chkBoxSaveFile.TabIndex = 12;
            this.chkBoxSaveFile.Tag = "f";
            this.chkBoxSaveFile.Text = "Save Log to file";
            this.chkBoxSaveFile.UseVisualStyleBackColor = true;
            // 
            // lstLog
            // 
            this.lstLog.AllowUserToAddRows = false;
            this.lstLog.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lstLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.lstLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.Location = new System.Drawing.Point(323, 3);
            this.lstLog.Name = "lstLog";
            this.lstLog.ReadOnly = true;
            this.lstLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lstLog.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.lstLog.RowTemplate.Height = 24;
            this.lstLog.Size = new System.Drawing.Size(1042, 682);
            this.lstLog.TabIndex = 13;
            // 
            // chkBoxBinary
            // 
            this.chkBoxBinary.AutoSize = true;
            this.chkBoxBinary.Checked = true;
            this.chkBoxBinary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxBinary.Location = new System.Drawing.Point(9, 174);
            this.chkBoxBinary.Name = "chkBoxBinary";
            this.chkBoxBinary.Size = new System.Drawing.Size(93, 21);
            this.chkBoxBinary.TabIndex = 14;
            this.chkBoxBinary.Tag = "c";
            this.chkBoxBinary.Text = "binary out";
            this.chkBoxBinary.UseVisualStyleBackColor = true;
            this.chkBoxBinary.CheckedChanged += new System.EventHandler(this.chkBoxOutput_CheckedChanged);
            // 
            // chkBoxHex
            // 
            this.chkBoxHex.AutoSize = true;
            this.chkBoxHex.Checked = true;
            this.chkBoxHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxHex.Location = new System.Drawing.Point(109, 174);
            this.chkBoxHex.Name = "chkBoxHex";
            this.chkBoxHex.Size = new System.Drawing.Size(76, 21);
            this.chkBoxHex.TabIndex = 15;
            this.chkBoxHex.Tag = "c";
            this.chkBoxHex.Text = "hex out";
            this.chkBoxHex.UseVisualStyleBackColor = true;
            this.chkBoxHex.CheckedChanged += new System.EventHandler(this.chkBoxOutput_CheckedChanged);
            // 
            // chkBoxAscii
            // 
            this.chkBoxAscii.AutoSize = true;
            this.chkBoxAscii.Checked = true;
            this.chkBoxAscii.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxAscii.Location = new System.Drawing.Point(191, 174);
            this.chkBoxAscii.Name = "chkBoxAscii";
            this.chkBoxAscii.Size = new System.Drawing.Size(63, 21);
            this.chkBoxAscii.TabIndex = 16;
            this.chkBoxAscii.Tag = "c";
            this.chkBoxAscii.Text = "ASCII";
            this.chkBoxAscii.UseVisualStyleBackColor = true;
            this.chkBoxAscii.CheckedChanged += new System.EventHandler(this.chkBoxOutput_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbBufferSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkBoxAscii);
            this.groupBox1.Controls.Add(this.ipAddressRemote);
            this.groupBox1.Controls.Add(this.chkBoxHex);
            this.groupBox1.Controls.Add(this.txtConnectionPort);
            this.groupBox1.Controls.Add(this.chkBoxBinary);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnRandom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 255);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Enabled Byte Received decoding";
            // 
            // cmbBufferSize
            // 
            this.cmbBufferSize.FormattingEnabled = true;
            this.cmbBufferSize.Items.AddRange(new object[] {
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048"});
            this.cmbBufferSize.Location = new System.Drawing.Point(164, 93);
            this.cmbBufferSize.Name = "cmbBufferSize";
            this.cmbBufferSize.Size = new System.Drawing.Size(139, 24);
            this.cmbBufferSize.TabIndex = 18;
            this.cmbBufferSize.Tag = "c";
            this.cmbBufferSize.SelectedIndexChanged += new System.EventHandler(this.cmbBufferSize_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Buffer Lenght (byte)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBoxCheckSum);
            this.groupBox2.Controls.Add(this.BinRawOutput);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbDelimiter);
            this.groupBox2.Controls.Add(this.hexRawOutput);
            this.groupBox2.Controls.Add(this.asciiOutput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnFileSelect);
            this.groupBox2.Controls.Add(this.txtPathFileLog);
            this.groupBox2.Controls.Add(this.chkBoxSaveFile);
            this.groupBox2.Controls.Add(this.txtSend);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.btnClearLog);
            this.groupBox2.Controls.Add(this.btnStartLog);
            this.groupBox2.Location = new System.Drawing.Point(3, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 269);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logger Settings";
            // 
            // chkBoxCheckSum
            // 
            this.chkBoxCheckSum.AutoSize = true;
            this.chkBoxCheckSum.Enabled = false;
            this.chkBoxCheckSum.Location = new System.Drawing.Point(202, 153);
            this.chkBoxCheckSum.Name = "chkBoxCheckSum";
            this.chkBoxCheckSum.Size = new System.Drawing.Size(101, 21);
            this.chkBoxCheckSum.TabIndex = 21;
            this.chkBoxCheckSum.Tag = "checksum";
            this.chkBoxCheckSum.Text = "Check Sum";
            this.chkBoxCheckSum.UseVisualStyleBackColor = true;
            // 
            // BinRawOutput
            // 
            this.BinRawOutput.AutoSize = true;
            this.BinRawOutput.Enabled = false;
            this.BinRawOutput.Location = new System.Drawing.Point(136, 123);
            this.BinRawOutput.Name = "BinRawOutput";
            this.BinRawOutput.Size = new System.Drawing.Size(49, 21);
            this.BinRawOutput.TabIndex = 20;
            this.BinRawOutput.TabStop = true;
            this.BinRawOutput.Tag = "s";
            this.BinRawOutput.Text = "Bin";
            this.BinRawOutput.UseVisualStyleBackColor = true;
            this.BinRawOutput.Click += new System.EventHandler(this.asciiOutput_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(6, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 19;
            this.label7.Tag = "s";
            this.label7.Text = "Delimiter";
            // 
            // cmbDelimiter
            // 
            this.cmbDelimiter.Enabled = false;
            this.cmbDelimiter.FormattingEnabled = true;
            this.cmbDelimiter.Items.AddRange(new object[] {
            "<EMPTY>",
            "<NULL>",
            "<LF>",
            "<CR><LF>"});
            this.cmbDelimiter.Location = new System.Drawing.Point(75, 151);
            this.cmbDelimiter.Name = "cmbDelimiter";
            this.cmbDelimiter.Size = new System.Drawing.Size(109, 24);
            this.cmbDelimiter.TabIndex = 18;
            this.cmbDelimiter.Tag = "del";
            this.cmbDelimiter.SelectedIndexChanged += new System.EventHandler(this.cmbDelimiter_SelectedIndexChanged);
            // 
            // hexRawOutput
            // 
            this.hexRawOutput.AutoSize = true;
            this.hexRawOutput.Enabled = false;
            this.hexRawOutput.Location = new System.Drawing.Point(77, 123);
            this.hexRawOutput.Name = "hexRawOutput";
            this.hexRawOutput.Size = new System.Drawing.Size(53, 21);
            this.hexRawOutput.TabIndex = 17;
            this.hexRawOutput.Tag = "s";
            this.hexRawOutput.Text = "Hex";
            this.hexRawOutput.UseVisualStyleBackColor = true;
            this.hexRawOutput.Click += new System.EventHandler(this.asciiOutput_CheckedChanged);
            // 
            // asciiOutput
            // 
            this.asciiOutput.AutoSize = true;
            this.asciiOutput.Checked = true;
            this.asciiOutput.Enabled = false;
            this.asciiOutput.Location = new System.Drawing.Point(9, 123);
            this.asciiOutput.Name = "asciiOutput";
            this.asciiOutput.Size = new System.Drawing.Size(62, 21);
            this.asciiOutput.TabIndex = 16;
            this.asciiOutput.TabStop = true;
            this.asciiOutput.Tag = "s";
            this.asciiOutput.Text = "ASCII\r\n";
            this.asciiOutput.UseVisualStyleBackColor = true;
            this.asciiOutput.Click += new System.EventHandler(this.asciiOutput_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 15;
            this.label4.Tag = "s";
            this.label4.Text = "Send Command";
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Enabled = false;
            this.btnFileSelect.Location = new System.Drawing.Point(228, 52);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(75, 30);
            this.btnFileSelect.TabIndex = 14;
            this.btnFileSelect.Tag = "f";
            this.btnFileSelect.Text = "select";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // txtPathFileLog
            // 
            this.txtPathFileLog.Enabled = false;
            this.txtPathFileLog.Location = new System.Drawing.Point(6, 56);
            this.txtPathFileLog.Name = "txtPathFileLog";
            this.txtPathFileLog.Size = new System.Drawing.Size(215, 22);
            this.txtPathFileLog.TabIndex = 13;
            this.txtPathFileLog.Tag = "f";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lstLog, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1368, 688);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.statusLabel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(314, 682);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // TCPLoggerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TCPLoggerMain";
            this.Tag = "";
            this.Text = "TCP Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPLoggerMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.lstLog)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IPAddressControlLib.IPAddressControl ipAddressRemote;
        private System.Windows.Forms.TextBox txtConnectionPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Timer animationConnectionTimer;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button btnStartLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBoxSaveFile;
        private System.Windows.Forms.DataGridView lstLog;
        private System.Windows.Forms.CheckBox chkBoxBinary;
        private System.Windows.Forms.CheckBox chkBoxHex;
        private System.Windows.Forms.CheckBox chkBoxAscii;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbBufferSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox txtPathFileLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton asciiOutput;
        private System.Windows.Forms.RadioButton hexRawOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDelimiter;
        private System.Windows.Forms.RadioButton BinRawOutput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkBoxCheckSum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

