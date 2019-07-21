using controls;

namespace Shiny2
{
    partial class FrmConfiguration : FadeGradientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguration));
            this.vstcSettings = new controls.VisualStudioTabControl();
            this.vstpGTS = new controls.VisualStudioTabControl.VisualStudioTabPage();
            this.btnGtsSave = new System.Windows.Forms.Button();
            this.gbReceive = new System.Windows.Forms.GroupBox();
            this.btnGenVGet = new System.Windows.Forms.Button();
            this.tbGenIVReceive = new System.Windows.Forms.TextBox();
            this.btnGenIVGet = new System.Windows.Forms.Button();
            this.tbGenVReceive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbDistribute = new System.Windows.Forms.GroupBox();
            this.btnGenV = new System.Windows.Forms.Button();
            this.btnGenIV = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGenVSend = new System.Windows.Forms.TextBox();
            this.tbGenIVSend = new System.Windows.Forms.TextBox();
            this.cbRandomized = new System.Windows.Forms.CheckBox();
            this.cbDistribution = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbStepOne = new System.Windows.Forms.GroupBox();
            this.cbGeneration = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOperations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vstpDNS = new controls.VisualStudioTabControl.VisualStudioTabPage();
            this.tBAltWFCIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDnsSave = new System.Windows.Forms.Button();
            this.btnDetect = new System.Windows.Forms.Button();
            this.rtbDirections = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.vstpOptions = new controls.VisualStudioTabControl.VisualStudioTabPage();
            this.cbOnline = new System.Windows.Forms.CheckBox();
            this.cbJargon = new System.Windows.Forms.CheckBox();
            this.cbLog = new System.Windows.Forms.CheckBox();
            this.vstpBrowser = new controls.VisualStudioTabControl.VisualStudioTabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbTable = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbBrowser = new System.Windows.Forms.RichTextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbCustomMsg = new System.Windows.Forms.CheckBox();
            this.cbTemplates = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.vstpRun = new controls.VisualStudioTabControl.VisualStudioTabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBReceivedStatistics = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.gbDnsLog = new System.Windows.Forms.GroupBox();
            this.lbDnsLog = new System.Windows.Forms.ListBox();
            this.gbGtsLog = new System.Windows.Forms.GroupBox();
            this.lbGtsLog = new System.Windows.Forms.ListBox();
            this.gbStatistics = new System.Windows.Forms.GroupBox();
            this.tbGenVStatistics = new System.Windows.Forms.TextBox();
            this.tbGenIVStatistics = new System.Windows.Forms.TextBox();
            this.btnStartGTS = new System.Windows.Forms.Button();
            this.btnStartDNS = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.vstcSettings.SuspendLayout();
            this.vstpGTS.SuspendLayout();
            this.gbReceive.SuspendLayout();
            this.gbDistribute.SuspendLayout();
            this.gbStepOne.SuspendLayout();
            this.vstpDNS.SuspendLayout();
            this.vstpOptions.SuspendLayout();
            this.vstpBrowser.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.vstpRun.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbDnsLog.SuspendLayout();
            this.gbGtsLog.SuspendLayout();
            this.gbStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // vstcSettings
            // 
            this.vstcSettings.Controls.Add(this.vstpGTS);
            this.vstcSettings.Controls.Add(this.vstpDNS);
            this.vstcSettings.Controls.Add(this.vstpOptions);
            this.vstcSettings.Controls.Add(this.vstpBrowser);
            this.vstcSettings.Controls.Add(this.vstpRun);
            this.vstcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vstcSettings.Location = new System.Drawing.Point(0, 0);
            this.vstcSettings.Name = "vstcSettings";
            this.vstcSettings.Size = new System.Drawing.Size(1066, 261);
            this.vstcSettings.Skin.TabPage.MouseHoverTabPage.TabRightBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(151)))), ((int)(((byte)(162)))));
            this.vstcSettings.Skin.TabPage.SelectedTabPage.GradientSettings.EndColor = System.Drawing.Color.White;
            this.vstcSettings.TabIndex = 0;
            // 
            // vstpGTS
            // 
            this.vstpGTS.AutoScroll = true;
            this.vstpGTS.Controls.Add(this.btnGtsSave);
            this.vstpGTS.Controls.Add(this.gbReceive);
            this.vstpGTS.Controls.Add(this.gbDistribute);
            this.vstpGTS.Controls.Add(this.gbStepOne);
            this.vstpGTS.Location = new System.Drawing.Point(101, 6);
            this.vstpGTS.Name = "vstpGTS";
            this.vstpGTS.Padding = new System.Windows.Forms.Padding(6);
            this.vstpGTS.Size = new System.Drawing.Size(959, 249);
            this.vstpGTS.Text = "GTS Operations";
            // 
            // btnGtsSave
            // 
            this.btnGtsSave.Location = new System.Drawing.Point(295, 179);
            this.btnGtsSave.Name = "btnGtsSave";
            this.btnGtsSave.Size = new System.Drawing.Size(278, 46);
            this.btnGtsSave.TabIndex = 3;
            this.btnGtsSave.Text = "S&ave";
            this.btnGtsSave.UseVisualStyleBackColor = true;
            this.btnGtsSave.Click += new System.EventHandler(this.BtnGtsSaveClick);
            // 
            // gbReceive
            // 
            this.gbReceive.Controls.Add(this.btnGenVGet);
            this.gbReceive.Controls.Add(this.tbGenIVReceive);
            this.gbReceive.Controls.Add(this.btnGenIVGet);
            this.gbReceive.Controls.Add(this.tbGenVReceive);
            this.gbReceive.Controls.Add(this.label7);
            this.gbReceive.Controls.Add(this.label6);
            this.gbReceive.Enabled = false;
            this.gbReceive.Location = new System.Drawing.Point(295, 94);
            this.gbReceive.Name = "gbReceive";
            this.gbReceive.Size = new System.Drawing.Size(278, 79);
            this.gbReceive.TabIndex = 2;
            this.gbReceive.TabStop = false;
            this.gbReceive.Text = "Receiving";
            // 
            // btnGenVGet
            // 
            this.btnGenVGet.Enabled = false;
            this.btnGenVGet.Location = new System.Drawing.Point(234, 45);
            this.btnGenVGet.Name = "btnGenVGet";
            this.btnGenVGet.Size = new System.Drawing.Size(38, 23);
            this.btnGenVGet.TabIndex = 0;
            this.btnGenVGet.Text = "...";
            this.btnGenVGet.UseVisualStyleBackColor = true;
            this.btnGenVGet.Click += new System.EventHandler(this.BtnGenVGetClick);
            // 
            // tbGenIVReceive
            // 
            this.tbGenIVReceive.Location = new System.Drawing.Point(63, 21);
            this.tbGenIVReceive.Name = "tbGenIVReceive";
            this.tbGenIVReceive.Size = new System.Drawing.Size(165, 20);
            this.tbGenIVReceive.TabIndex = 3;
            // 
            // btnGenIVGet
            // 
            this.btnGenIVGet.Location = new System.Drawing.Point(234, 19);
            this.btnGenIVGet.Name = "btnGenIVGet";
            this.btnGenIVGet.Size = new System.Drawing.Size(38, 23);
            this.btnGenIVGet.TabIndex = 0;
            this.btnGenIVGet.Text = "...";
            this.btnGenIVGet.UseVisualStyleBackColor = true;
            this.btnGenIVGet.Click += new System.EventHandler(this.BtnGenIVGetClick);
            // 
            // tbGenVReceive
            // 
            this.tbGenVReceive.Enabled = false;
            this.tbGenVReceive.Location = new System.Drawing.Point(63, 47);
            this.tbGenVReceive.Name = "tbGenVReceive";
            this.tbGenVReceive.Size = new System.Drawing.Size(165, 20);
            this.tbGenVReceive.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gen V:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Gen IV:";
            // 
            // gbDistribute
            // 
            this.gbDistribute.Controls.Add(this.btnGenV);
            this.gbDistribute.Controls.Add(this.btnGenIV);
            this.gbDistribute.Controls.Add(this.label5);
            this.gbDistribute.Controls.Add(this.label4);
            this.gbDistribute.Controls.Add(this.tbGenVSend);
            this.gbDistribute.Controls.Add(this.tbGenIVSend);
            this.gbDistribute.Controls.Add(this.cbRandomized);
            this.gbDistribute.Controls.Add(this.cbDistribution);
            this.gbDistribute.Controls.Add(this.label3);
            this.gbDistribute.Enabled = false;
            this.gbDistribute.Location = new System.Drawing.Point(9, 94);
            this.gbDistribute.Name = "gbDistribute";
            this.gbDistribute.Size = new System.Drawing.Size(278, 131);
            this.gbDistribute.TabIndex = 2;
            this.gbDistribute.TabStop = false;
            this.gbDistribute.Text = "Distributing";
            // 
            // btnGenV
            // 
            this.btnGenV.Enabled = false;
            this.btnGenV.Location = new System.Drawing.Point(234, 93);
            this.btnGenV.Name = "btnGenV";
            this.btnGenV.Size = new System.Drawing.Size(38, 23);
            this.btnGenV.TabIndex = 0;
            this.btnGenV.Text = "...";
            this.btnGenV.UseVisualStyleBackColor = true;
            this.btnGenV.Click += new System.EventHandler(this.BtnGenVClick);
            // 
            // btnGenIV
            // 
            this.btnGenIV.Location = new System.Drawing.Point(234, 67);
            this.btnGenIV.Name = "btnGenIV";
            this.btnGenIV.Size = new System.Drawing.Size(38, 23);
            this.btnGenIV.TabIndex = 0;
            this.btnGenIV.Text = "...";
            this.btnGenIV.UseVisualStyleBackColor = true;
            this.btnGenIV.Click += new System.EventHandler(this.BtnGenIVClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Gen V:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gen IV:";
            // 
            // tbGenVSend
            // 
            this.tbGenVSend.Enabled = false;
            this.tbGenVSend.Location = new System.Drawing.Point(63, 95);
            this.tbGenVSend.Name = "tbGenVSend";
            this.tbGenVSend.Size = new System.Drawing.Size(165, 20);
            this.tbGenVSend.TabIndex = 3;
            // 
            // tbGenIVSend
            // 
            this.tbGenIVSend.Location = new System.Drawing.Point(63, 69);
            this.tbGenIVSend.Name = "tbGenIVSend";
            this.tbGenIVSend.Size = new System.Drawing.Size(165, 20);
            this.tbGenIVSend.TabIndex = 3;
            // 
            // cbRandomized
            // 
            this.cbRandomized.AutoSize = true;
            this.cbRandomized.Location = new System.Drawing.Point(187, 46);
            this.cbRandomized.Name = "cbRandomized";
            this.cbRandomized.Size = new System.Drawing.Size(85, 17);
            this.cbRandomized.TabIndex = 2;
            this.cbRandomized.Text = "Randomized";
            this.cbRandomized.UseVisualStyleBackColor = true;
            // 
            // cbDistribution
            // 
            this.cbDistribution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDistribution.FormattingEnabled = true;
            this.cbDistribution.Items.AddRange(new object[] {
            "Individual",
            "Folder"});
            this.cbDistribution.Location = new System.Drawing.Point(63, 19);
            this.cbDistribution.Name = "cbDistribution";
            this.cbDistribution.Size = new System.Drawing.Size(209, 21);
            this.cbDistribution.TabIndex = 1;
            this.cbDistribution.SelectedIndexChanged += new System.EventHandler(this.CbDistributionSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mode:";
            // 
            // gbStepOne
            // 
            this.gbStepOne.Controls.Add(this.cbGeneration);
            this.gbStepOne.Controls.Add(this.label2);
            this.gbStepOne.Controls.Add(this.cbOperations);
            this.gbStepOne.Controls.Add(this.label1);
            this.gbStepOne.Location = new System.Drawing.Point(9, 9);
            this.gbStepOne.Name = "gbStepOne";
            this.gbStepOne.Size = new System.Drawing.Size(564, 79);
            this.gbStepOne.TabIndex = 1;
            this.gbStepOne.TabStop = false;
            this.gbStepOne.Text = "What do you want to do?";
            // 
            // cbGeneration
            // 
            this.cbGeneration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGeneration.FormattingEnabled = true;
            this.cbGeneration.Items.AddRange(new object[] {
            "Diamond, Pearl, Platinum, Heart Gold, and Soul Silver",
            "Black and White",
            "All of them"});
            this.cbGeneration.Location = new System.Drawing.Point(63, 46);
            this.cbGeneration.Name = "cbGeneration";
            this.cbGeneration.Size = new System.Drawing.Size(495, 21);
            this.cbGeneration.TabIndex = 3;
            this.cbGeneration.SelectedIndexChanged += new System.EventHandler(this.CbGenerationSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "On:";
            // 
            // cbOperations
            // 
            this.cbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperations.FormattingEnabled = true;
            this.cbOperations.Items.AddRange(new object[] {
            "Distribute",
            "Receive"});
            this.cbOperations.Location = new System.Drawing.Point(63, 19);
            this.cbOperations.Name = "cbOperations";
            this.cbOperations.Size = new System.Drawing.Size(495, 21);
            this.cbOperations.TabIndex = 1;
            this.cbOperations.SelectedIndexChanged += new System.EventHandler(this.CbOperationsSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "I want to:";
            // 
            // vstpDNS
            // 
            this.vstpDNS.AutoScroll = true;
            this.vstpDNS.Controls.Add(this.tBAltWFCIP);
            this.vstpDNS.Controls.Add(this.label11);
            this.vstpDNS.Controls.Add(this.btnDnsSave);
            this.vstpDNS.Controls.Add(this.btnDetect);
            this.vstpDNS.Controls.Add(this.rtbDirections);
            this.vstpDNS.Controls.Add(this.label8);
            this.vstpDNS.Controls.Add(this.tbIP);
            this.vstpDNS.Location = new System.Drawing.Point(101, 6);
            this.vstpDNS.Name = "vstpDNS";
            this.vstpDNS.Padding = new System.Windows.Forms.Padding(6);
            this.vstpDNS.Size = new System.Drawing.Size(959, 249);
            this.vstpDNS.Text = "DNS Settings";
            // 
            // tBAltWFCIP
            // 
            this.tBAltWFCIP.Location = new System.Drawing.Point(74, 93);
            this.tBAltWFCIP.Name = "tBAltWFCIP";
            this.tBAltWFCIP.Size = new System.Drawing.Size(88, 20);
            this.tBAltWFCIP.TabIndex = 6;
            this.tBAltWFCIP.Text = "104.131.93.87";
            this.tBAltWFCIP.TextChanged += new System.EventHandler(this.tBAltWFCIP_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "AltServer IP:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // btnDnsSave
            // 
            this.btnDnsSave.Location = new System.Drawing.Point(74, 64);
            this.btnDnsSave.Name = "btnDnsSave";
            this.btnDnsSave.Size = new System.Drawing.Size(88, 23);
            this.btnDnsSave.TabIndex = 4;
            this.btnDnsSave.Text = "S&ave Settings";
            this.btnDnsSave.UseVisualStyleBackColor = true;
            this.btnDnsSave.Click += new System.EventHandler(this.BtnDnsSaveClick);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(74, 35);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(88, 23);
            this.btnDetect.TabIndex = 3;
            this.btnDetect.Text = "&Detect IP";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.BtnDetectClick);
            // 
            // rtbDirections
            // 
            this.rtbDirections.Location = new System.Drawing.Point(179, 6);
            this.rtbDirections.Name = "rtbDirections";
            this.rtbDirections.ReadOnly = true;
            this.rtbDirections.Size = new System.Drawing.Size(749, 234);
            this.rtbDirections.TabIndex = 2;
            this.rtbDirections.Text = resources.GetString("rtbDirections.Text");
            this.rtbDirections.TextChanged += new System.EventHandler(this.rtbDirections_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Local IP:";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(74, 9);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(88, 20);
            this.tbIP.TabIndex = 0;
            this.tbIP.Text = "000.000.000.000";
            // 
            // vstpOptions
            // 
            this.vstpOptions.AutoScroll = true;
            this.vstpOptions.Controls.Add(this.cbOnline);
            this.vstpOptions.Controls.Add(this.cbJargon);
            this.vstpOptions.Controls.Add(this.cbLog);
            this.vstpOptions.Location = new System.Drawing.Point(101, 6);
            this.vstpOptions.Name = "vstpOptions";
            this.vstpOptions.Padding = new System.Windows.Forms.Padding(6);
            this.vstpOptions.Size = new System.Drawing.Size(959, 249);
            this.vstpOptions.Text = "Extra Options";
            // 
            // cbOnline
            // 
            this.cbOnline.AutoSize = true;
            this.cbOnline.Location = new System.Drawing.Point(9, 55);
            this.cbOnline.Name = "cbOnline";
            this.cbOnline.Size = new System.Drawing.Size(132, 17);
            this.cbOnline.TabIndex = 2;
            this.cbOnline.Text = "Show Online Message";
            this.cbOnline.UseVisualStyleBackColor = true;
            // 
            // cbJargon
            // 
            this.cbJargon.AutoSize = true;
            this.cbJargon.Location = new System.Drawing.Point(9, 32);
            this.cbJargon.Name = "cbJargon";
            this.cbJargon.Size = new System.Drawing.Size(110, 17);
            this.cbJargon.TabIndex = 1;
            this.cbJargon.Text = "Extra GTS Jargon";
            this.cbJargon.UseVisualStyleBackColor = true;
            // 
            // cbLog
            // 
            this.cbLog.AutoSize = true;
            this.cbLog.Location = new System.Drawing.Point(9, 9);
            this.cbLog.Name = "cbLog";
            this.cbLog.Size = new System.Drawing.Size(75, 17);
            this.cbLog.TabIndex = 0;
            this.cbLog.Text = "Log to File";
            this.cbLog.UseVisualStyleBackColor = true;
            this.cbLog.CheckedChanged += new System.EventHandler(this.CbLogCheckedChanged);
            // 
            // vstpBrowser
            // 
            this.vstpBrowser.AutoScroll = true;
            this.vstpBrowser.Controls.Add(this.groupBox2);
            this.vstpBrowser.Controls.Add(this.groupBox1);
            this.vstpBrowser.Controls.Add(this.btnApply);
            this.vstpBrowser.Controls.Add(this.cbCustomMsg);
            this.vstpBrowser.Controls.Add(this.cbTemplates);
            this.vstpBrowser.Controls.Add(this.label10);
            this.vstpBrowser.Location = new System.Drawing.Point(101, 6);
            this.vstpBrowser.Name = "vstpBrowser";
            this.vstpBrowser.Padding = new System.Windows.Forms.Padding(6);
            this.vstpBrowser.Size = new System.Drawing.Size(959, 249);
            this.vstpBrowser.Text = "Browser Page";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbTable);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(331, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 191);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Table Content";
            // 
            // rtbTable
            // 
            this.rtbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTable.Location = new System.Drawing.Point(3, 16);
            this.rtbTable.Name = "rtbTable";
            this.rtbTable.Size = new System.Drawing.Size(236, 172);
            this.rtbTable.TabIndex = 0;
            this.rtbTable.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbBrowser);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(9, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 191);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browser Message";
            // 
            // rtbBrowser
            // 
            this.rtbBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBrowser.Location = new System.Drawing.Point(3, 16);
            this.rtbBrowser.Name = "rtbBrowser";
            this.rtbBrowser.Size = new System.Drawing.Size(310, 172);
            this.rtbBrowser.TabIndex = 4;
            this.rtbBrowser.Text = "";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(498, 7);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
            // 
            // cbCustomMsg
            // 
            this.cbCustomMsg.AutoSize = true;
            this.cbCustomMsg.Location = new System.Drawing.Point(385, 11);
            this.cbCustomMsg.Name = "cbCustomMsg";
            this.cbCustomMsg.Size = new System.Drawing.Size(107, 17);
            this.cbCustomMsg.TabIndex = 2;
            this.cbCustomMsg.Text = "Custom Message";
            this.cbCustomMsg.UseVisualStyleBackColor = true;
            this.cbCustomMsg.CheckedChanged += new System.EventHandler(this.CbCustomMsgCheckedChanged);
            // 
            // cbTemplates
            // 
            this.cbTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Items.AddRange(new object[] {
            "Default"});
            this.cbTemplates.Location = new System.Drawing.Point(69, 9);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(310, 21);
            this.cbTemplates.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Template:";
            // 
            // vstpRun
            // 
            this.vstpRun.AutoScroll = true;
            this.vstpRun.Controls.Add(this.label13);
            this.vstpRun.Controls.Add(this.label12);
            this.vstpRun.Controls.Add(this.groupBox3);
            this.vstpRun.Controls.Add(this.linkLabel2);
            this.vstpRun.Controls.Add(this.linkLabel1);
            this.vstpRun.Controls.Add(this.gbDnsLog);
            this.vstpRun.Controls.Add(this.gbGtsLog);
            this.vstpRun.Controls.Add(this.gbStatistics);
            this.vstpRun.Controls.Add(this.btnStartGTS);
            this.vstpRun.Controls.Add(this.btnStartDNS);
            this.vstpRun.Controls.Add(this.label9);
            this.vstpRun.Location = new System.Drawing.Point(101, 6);
            this.vstpRun.Name = "vstpRun";
            this.vstpRun.Padding = new System.Windows.Forms.Padding(6);
            this.vstpRun.Size = new System.Drawing.Size(959, 249);
            this.vstpRun.Text = "Run!";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(281, 39);
            this.label13.TabIndex = 7;
            this.label13.Text = "MAKE SURE YOU HAVE A FULL PARTY OF 6\r\nBEFORE ENTERING, OR THE RESULTING POKEMON \r" +
    "\nMAY BE VERY HARD TO REMOVE!\r\n";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(730, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(220, 26);
            this.label12.TabIndex = 6;
            this.label12.Text = "Original Shiny2 by formlesstree4/ShinyJirachi.\r\nModifications for alternate serve" +
    "rs by Gannio.";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBReceivedStatistics);
            this.groupBox3.Location = new System.Drawing.Point(186, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(116, 75);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistics";
            // 
            // tBReceivedStatistics
            // 
            this.tBReceivedStatistics.Location = new System.Drawing.Point(6, 19);
            this.tBReceivedStatistics.Name = "tBReceivedStatistics";
            this.tBReceivedStatistics.ReadOnly = true;
            this.tBReceivedStatistics.Size = new System.Drawing.Size(110, 20);
            this.tBReceivedStatistics.TabIndex = 3;
            this.tBReceivedStatistics.Text = "Received: 0";
            this.tBReceivedStatistics.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(124, 180);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(56, 13);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Clear GTS";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 180);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(57, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Clear DNS";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
            // 
            // gbDnsLog
            // 
            this.gbDnsLog.Controls.Add(this.lbDnsLog);
            this.gbDnsLog.Location = new System.Drawing.Point(666, 44);
            this.gbDnsLog.Name = "gbDnsLog";
            this.gbDnsLog.Size = new System.Drawing.Size(287, 183);
            this.gbDnsLog.TabIndex = 3;
            this.gbDnsLog.TabStop = false;
            this.gbDnsLog.Text = "DNS Log";
            // 
            // lbDnsLog
            // 
            this.lbDnsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDnsLog.FormattingEnabled = true;
            this.lbDnsLog.Location = new System.Drawing.Point(3, 16);
            this.lbDnsLog.Name = "lbDnsLog";
            this.lbDnsLog.Size = new System.Drawing.Size(281, 164);
            this.lbDnsLog.TabIndex = 0;
            this.lbDnsLog.DoubleClick += new System.EventHandler(this.LbDnsLogDoubleClick);
            // 
            // gbGtsLog
            // 
            this.gbGtsLog.Controls.Add(this.lbGtsLog);
            this.gbGtsLog.Location = new System.Drawing.Point(305, 44);
            this.gbGtsLog.Name = "gbGtsLog";
            this.gbGtsLog.Size = new System.Drawing.Size(355, 183);
            this.gbGtsLog.TabIndex = 3;
            this.gbGtsLog.TabStop = false;
            this.gbGtsLog.Text = "GTS Log";
            // 
            // lbGtsLog
            // 
            this.lbGtsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGtsLog.FormattingEnabled = true;
            this.lbGtsLog.Location = new System.Drawing.Point(3, 16);
            this.lbGtsLog.Name = "lbGtsLog";
            this.lbGtsLog.Size = new System.Drawing.Size(349, 164);
            this.lbGtsLog.TabIndex = 0;
            this.lbGtsLog.SelectedIndexChanged += new System.EventHandler(this.lbGtsLog_SelectedIndexChanged);
            this.lbGtsLog.DoubleClick += new System.EventHandler(this.LbGtsLogDoubleClick);
            // 
            // gbStatistics
            // 
            this.gbStatistics.Controls.Add(this.tbGenVStatistics);
            this.gbStatistics.Controls.Add(this.tbGenIVStatistics);
            this.gbStatistics.Location = new System.Drawing.Point(9, 102);
            this.gbStatistics.Name = "gbStatistics";
            this.gbStatistics.Size = new System.Drawing.Size(171, 75);
            this.gbStatistics.TabIndex = 2;
            this.gbStatistics.TabStop = false;
            this.gbStatistics.Text = "Statistics";
            // 
            // tbGenVStatistics
            // 
            this.tbGenVStatistics.Location = new System.Drawing.Point(6, 45);
            this.tbGenVStatistics.Name = "tbGenVStatistics";
            this.tbGenVStatistics.ReadOnly = true;
            this.tbGenVStatistics.Size = new System.Drawing.Size(159, 20);
            this.tbGenVStatistics.TabIndex = 3;
            this.tbGenVStatistics.Text = "Sent Gen V: 0";
            this.tbGenVStatistics.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbGenIVStatistics
            // 
            this.tbGenIVStatistics.Location = new System.Drawing.Point(6, 19);
            this.tbGenIVStatistics.Name = "tbGenIVStatistics";
            this.tbGenIVStatistics.ReadOnly = true;
            this.tbGenIVStatistics.Size = new System.Drawing.Size(159, 20);
            this.tbGenIVStatistics.TabIndex = 3;
            this.tbGenIVStatistics.Text = "Sent Gen IV: 0";
            this.tbGenIVStatistics.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbGenIVStatistics.TextChanged += new System.EventHandler(this.tbGenIVStatistics_TextChanged);
            // 
            // btnStartGTS
            // 
            this.btnStartGTS.Location = new System.Drawing.Point(9, 73);
            this.btnStartGTS.Name = "btnStartGTS";
            this.btnStartGTS.Size = new System.Drawing.Size(171, 23);
            this.btnStartGTS.TabIndex = 1;
            this.btnStartGTS.Text = "Ini&tialize GTS";
            this.btnStartGTS.UseVisualStyleBackColor = true;
            this.btnStartGTS.Click += new System.EventHandler(this.BtnStartGtsClick);
            // 
            // btnStartDNS
            // 
            this.btnStartDNS.Location = new System.Drawing.Point(9, 44);
            this.btnStartDNS.Name = "btnStartDNS";
            this.btnStartDNS.Size = new System.Drawing.Size(171, 23);
            this.btnStartDNS.TabIndex = 1;
            this.btnStartDNS.Text = "&Initialize DNS";
            this.btnStartDNS.UseVisualStyleBackColor = true;
            this.btnStartDNS.Click += new System.EventHandler(this.BtnStartDnsClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(500, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Before starting the GTS or DNS, please make sure all options in the previous tabs" +
    " have been configured.";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Shiny²";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // FrmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 261);
            this.Controls.Add(this.vstcSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.GradientBegin = System.Drawing.SystemColors.ActiveCaption;
            this.GradientEnabled = true;
            this.GradientEnd = System.Drawing.SystemColors.GradientActiveCaption;
            this.GradientMiddle = System.Drawing.SystemColors.GradientInactiveCaption;
            this.GradientPreset = controls.GradientPresets.Custom;
            this.MaximizeBox = false;
            this.Name = "FrmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shiny²⁺ ½";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConfigurationFormClosing);
            this.Load += new System.EventHandler(this.FrmConfigurationLoad);
            this.Resize += new System.EventHandler(this.FrmConfiguration_Resize);
            this.vstcSettings.ResumeLayout(false);
            this.vstpGTS.ResumeLayout(false);
            this.gbReceive.ResumeLayout(false);
            this.gbReceive.PerformLayout();
            this.gbDistribute.ResumeLayout(false);
            this.gbDistribute.PerformLayout();
            this.gbStepOne.ResumeLayout(false);
            this.gbStepOne.PerformLayout();
            this.vstpDNS.ResumeLayout(false);
            this.vstpDNS.PerformLayout();
            this.vstpOptions.ResumeLayout(false);
            this.vstpOptions.PerformLayout();
            this.vstpBrowser.ResumeLayout(false);
            this.vstpBrowser.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.vstpRun.ResumeLayout(false);
            this.vstpRun.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDnsLog.ResumeLayout(false);
            this.gbGtsLog.ResumeLayout(false);
            this.gbStatistics.ResumeLayout(false);
            this.gbStatistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VisualStudioTabControl vstcSettings;
        private VisualStudioTabControl.VisualStudioTabPage vstpGTS;
        private VisualStudioTabControl.VisualStudioTabPage vstpDNS;
        private System.Windows.Forms.GroupBox gbStepOne;
        private System.Windows.Forms.ComboBox cbGeneration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOperations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbReceive;
        private System.Windows.Forms.GroupBox gbDistribute;
        private System.Windows.Forms.ComboBox cbDistribution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbRandomized;
        private System.Windows.Forms.TextBox tbGenVSend;
        private System.Windows.Forms.TextBox tbGenIVSend;
        private System.Windows.Forms.Button btnGenV;
        private System.Windows.Forms.Button btnGenIV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenVGet;
        private System.Windows.Forms.TextBox tbGenIVReceive;
        private System.Windows.Forms.Button btnGenIVGet;
        private System.Windows.Forms.TextBox tbGenVReceive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGtsSave;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.RichTextBox rtbDirections;
        private System.Windows.Forms.Button btnDnsSave;
        private VisualStudioTabControl.VisualStudioTabPage vstpRun;
        private System.Windows.Forms.Label label9;
        private VisualStudioTabControl.VisualStudioTabPage vstpOptions;
        private System.Windows.Forms.CheckBox cbLog;
        private System.Windows.Forms.Button btnStartGTS;
        private System.Windows.Forms.Button btnStartDNS;
        private System.Windows.Forms.GroupBox gbStatistics;
        private System.Windows.Forms.TextBox tbGenVStatistics;
        private System.Windows.Forms.TextBox tbGenIVStatistics;
        private System.Windows.Forms.GroupBox gbDnsLog;
        private System.Windows.Forms.GroupBox gbGtsLog;
        private System.Windows.Forms.ListBox lbDnsLog;
        private System.Windows.Forms.ListBox lbGtsLog;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox cbJargon;
        private VisualStudioTabControl.VisualStudioTabPage vstpBrowser;
        private System.Windows.Forms.CheckBox cbCustomMsg;
        private System.Windows.Forms.ComboBox cbTemplates;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.RichTextBox rtbBrowser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbOnline;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox tBAltWFCIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tBReceivedStatistics;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}