namespace RFID
{
    partial class F_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_RFIDCode = new System.Windows.Forms.Label();
            this.group_INFOR = new System.Windows.Forms.GroupBox();
            this.RFID_demo = new System.Windows.Forms.RichTextBox();
            this.lb_stt = new System.Windows.Forms.Label();
            this.but_OpenPort = new System.Windows.Forms.Button();
            this.group_SETTINGS = new System.Windows.Forms.GroupBox();
            this.cmB_Parity = new System.Windows.Forms.ComboBox();
            this.label_Parity = new System.Windows.Forms.Label();
            this.cmB_Baud = new System.Windows.Forms.ComboBox();
            this.label_Baud = new System.Windows.Forms.Label();
            this.cmB_COMport = new System.Windows.Forms.ComboBox();
            this.label_COMport = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.serialPortRFID = new System.IO.Ports.SerialPort(this.components);
            this.but_Send = new System.Windows.Forms.Button();
            this.Rictext1 = new System.Windows.Forms.RichTextBox();
            this.timer1_DL = new System.Windows.Forms.Timer(this.components);
            this.group_STT = new System.Windows.Forms.GroupBox();
            this.ricText2 = new System.Windows.Forms.RichTextBox();
            this.uri_request = new System.Windows.Forms.RichTextBox();
            this.group_INFOR.SuspendLayout();
            this.group_SETTINGS.SuspendLayout();
            this.group_STT.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_RFIDCode
            // 
            this.label_RFIDCode.AutoSize = true;
            this.label_RFIDCode.Location = new System.Drawing.Point(28, 18);
            this.label_RFIDCode.Name = "label_RFIDCode";
            this.label_RFIDCode.Size = new System.Drawing.Size(57, 13);
            this.label_RFIDCode.TabIndex = 1;
            this.label_RFIDCode.Text = "RFIDCode";
            this.label_RFIDCode.Click += new System.EventHandler(this.label_Num_Click);
            // 
            // group_INFOR
            // 
            this.group_INFOR.Controls.Add(this.RFID_demo);
            this.group_INFOR.Controls.Add(this.lb_stt);
            this.group_INFOR.Controls.Add(this.but_OpenPort);
            this.group_INFOR.Controls.Add(this.label_RFIDCode);
            this.group_INFOR.Location = new System.Drawing.Point(14, 12);
            this.group_INFOR.Name = "group_INFOR";
            this.group_INFOR.Size = new System.Drawing.Size(208, 67);
            this.group_INFOR.TabIndex = 2;
            this.group_INFOR.TabStop = false;
            this.group_INFOR.Text = "INFORMATION";
            this.group_INFOR.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // RFID_demo
            // 
            this.RFID_demo.Location = new System.Drawing.Point(110, 36);
            this.RFID_demo.Name = "RFID_demo";
            this.RFID_demo.Size = new System.Drawing.Size(81, 23);
            this.RFID_demo.TabIndex = 11;
            this.RFID_demo.Text = "";
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(118, 18);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(62, 13);
            this.lb_stt.TabIndex = 11;
            this.lb_stt.Text = "RFID_code";
            this.lb_stt.Click += new System.EventHandler(this.label2_Click);
            // 
            // but_OpenPort
            // 
            this.but_OpenPort.Location = new System.Drawing.Point(22, 36);
            this.but_OpenPort.Name = "but_OpenPort";
            this.but_OpenPort.Size = new System.Drawing.Size(71, 23);
            this.but_OpenPort.TabIndex = 5;
            this.but_OpenPort.Text = "Open Port";
            this.but_OpenPort.UseVisualStyleBackColor = true;
            this.but_OpenPort.Click += new System.EventHandler(this.but_OpenPort_Click);
            // 
            // group_SETTINGS
            // 
            this.group_SETTINGS.Controls.Add(this.cmB_Parity);
            this.group_SETTINGS.Controls.Add(this.label_Parity);
            this.group_SETTINGS.Controls.Add(this.cmB_Baud);
            this.group_SETTINGS.Controls.Add(this.label_Baud);
            this.group_SETTINGS.Controls.Add(this.cmB_COMport);
            this.group_SETTINGS.Controls.Add(this.label_COMport);
            this.group_SETTINGS.Location = new System.Drawing.Point(14, 80);
            this.group_SETTINGS.Name = "group_SETTINGS";
            this.group_SETTINGS.Size = new System.Drawing.Size(209, 94);
            this.group_SETTINGS.TabIndex = 3;
            this.group_SETTINGS.TabStop = false;
            this.group_SETTINGS.Text = "SETTINGS";
            // 
            // cmB_Parity
            // 
            this.cmB_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Parity.FormattingEnabled = true;
            this.cmB_Parity.Location = new System.Drawing.Point(87, 67);
            this.cmB_Parity.Name = "cmB_Parity";
            this.cmB_Parity.Size = new System.Drawing.Size(107, 21);
            this.cmB_Parity.TabIndex = 3;
            this.cmB_Parity.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(25, 70);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(33, 13);
            this.label_Parity.TabIndex = 7;
            this.label_Parity.Text = "Parity";
            this.label_Parity.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmB_Baud
            // 
            this.cmB_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Baud.FormattingEnabled = true;
            this.cmB_Baud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cmB_Baud.Location = new System.Drawing.Point(87, 42);
            this.cmB_Baud.Name = "cmB_Baud";
            this.cmB_Baud.Size = new System.Drawing.Size(107, 21);
            this.cmB_Baud.TabIndex = 11;
            this.cmB_Baud.SelectedIndexChanged += new System.EventHandler(this.cmB_Baud_SelectedIndexChanged);
            // 
            // label_Baud
            // 
            this.label_Baud.AutoSize = true;
            this.label_Baud.Location = new System.Drawing.Point(25, 45);
            this.label_Baud.Name = "label_Baud";
            this.label_Baud.Size = new System.Drawing.Size(32, 13);
            this.label_Baud.TabIndex = 5;
            this.label_Baud.Text = "Baud";
            // 
            // cmB_COMport
            // 
            this.cmB_COMport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_COMport.FormattingEnabled = true;
            this.cmB_COMport.Location = new System.Drawing.Point(87, 17);
            this.cmB_COMport.Name = "cmB_COMport";
            this.cmB_COMport.Size = new System.Drawing.Size(107, 21);
            this.cmB_COMport.TabIndex = 4;
            this.cmB_COMport.SelectedIndexChanged += new System.EventHandler(this.cmB_COMport_SelectedIndexChanged);
            // 
            // label_COMport
            // 
            this.label_COMport.AutoSize = true;
            this.label_COMport.Location = new System.Drawing.Point(25, 20);
            this.label_COMport.Name = "label_COMport";
            this.label_COMport.Size = new System.Drawing.Size(49, 13);
            this.label_COMport.TabIndex = 1;
            this.label_COMport.Text = "COMport";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Location = new System.Drawing.Point(33, 0);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(121, 21);
            this.cmbStopBits.TabIndex = 0;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Location = new System.Drawing.Point(33, 0);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(121, 21);
            this.cmbDataBits.TabIndex = 0;
            // 
            // serialPortRFID
            // 
            this.serialPortRFID.PortName = "COM4";
            this.serialPortRFID.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortRFID_DataReceived);
            // 
            // but_Send
            // 
            this.but_Send.Location = new System.Drawing.Point(144, 18);
            this.but_Send.Name = "but_Send";
            this.but_Send.Size = new System.Drawing.Size(53, 22);
            this.but_Send.TabIndex = 7;
            this.but_Send.Text = "POST";
            this.but_Send.UseVisualStyleBackColor = true;
            this.but_Send.Click += new System.EventHandler(this.button2_Click);
            // 
            // Rictext1
            // 
            this.Rictext1.Location = new System.Drawing.Point(17, 18);
            this.Rictext1.Name = "Rictext1";
            this.Rictext1.Size = new System.Drawing.Size(106, 23);
            this.Rictext1.TabIndex = 9;
            this.Rictext1.Text = "";
            // 
            // timer1_DL
            // 
            this.timer1_DL.Interval = 1000;
            // 
            // group_STT
            // 
            this.group_STT.Controls.Add(this.Rictext1);
            this.group_STT.Controls.Add(this.ricText2);
            this.group_STT.Controls.Add(this.but_Send);
            this.group_STT.Location = new System.Drawing.Point(243, 54);
            this.group_STT.Name = "group_STT";
            this.group_STT.Size = new System.Drawing.Size(209, 118);
            this.group_STT.TabIndex = 12;
            this.group_STT.TabStop = false;
            this.group_STT.Text = "STATUS";
            this.group_STT.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // ricText2
            // 
            this.ricText2.Location = new System.Drawing.Point(13, 51);
            this.ricText2.Name = "ricText2";
            this.ricText2.Size = new System.Drawing.Size(184, 61);
            this.ricText2.TabIndex = 10;
            this.ricText2.Text = "";
            this.ricText2.TextChanged += new System.EventHandler(this.ricText2_TextChanged);
            // 
            // uri_request
            // 
            this.uri_request.Location = new System.Drawing.Point(253, 19);
            this.uri_request.Name = "uri_request";
            this.uri_request.Size = new System.Drawing.Size(193, 26);
            this.uri_request.TabIndex = 11;
            this.uri_request.Text = "http://localhost/";
            this.uri_request.TextChanged += new System.EventHandler(this.uri_request_TextChanged);
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 182);
            this.Controls.Add(this.uri_request);
            this.Controls.Add(this.group_STT);
            this.Controls.Add(this.group_SETTINGS);
            this.Controls.Add(this.group_INFOR);
            this.Name = "F_Main";
            this.Text = "REGISTER_EDITION";
            this.group_INFOR.ResumeLayout(false);
            this.group_INFOR.PerformLayout();
            this.group_SETTINGS.ResumeLayout(false);
            this.group_SETTINGS.PerformLayout();
            this.group_STT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_RFIDCode;
        private System.Windows.Forms.GroupBox group_INFOR;
        private System.Windows.Forms.GroupBox group_SETTINGS;
        private System.Windows.Forms.Label label_COMport;
        private System.Windows.Forms.ComboBox cmB_Parity;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.ComboBox cmB_Baud;
        private System.Windows.Forms.Label label_Baud;
        private System.Windows.Forms.ComboBox cmB_COMport;
        private System.Windows.Forms.Button but_OpenPort;
        private System.IO.Ports.SerialPort serialPortRFID;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Button but_Send;
        private System.Windows.Forms.RichTextBox Rictext1;
        private System.Windows.Forms.Timer timer1_DL;
        private System.Windows.Forms.Label lb_stt;
        private System.Windows.Forms.GroupBox group_STT;
        private System.Windows.Forms.RichTextBox ricText2;
        private System.Windows.Forms.RichTextBox RFID_demo;
        private System.Windows.Forms.RichTextBox uri_request;


    }
}

