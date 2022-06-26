using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using GemCard;
using SmartCardPlayer;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;


namespace TestGemCard
{
    delegate void   EnableButtonDelegate(Button btn, bool state);

	/// <summary>
	/// MainForm of the Application
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Button btnTransmit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboApdu;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textData;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textClass;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textIns;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textP1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textP2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textLe;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textDOut;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comboReader;
        private IContainer components;
        private CardBase	m_iCard = null;
		private	APDUPlayer	m_apduPlayer = null;
		private	APDUParam	m_apduParam = null;
        const string DefaultReader = "Gemplus USB Smart Card Reader 0";
        private TextBox txtboxATR;
        private Label label10;
        private GroupBox admin_panel;
        private NotifyIcon mynotifyicon;
        private Timer timer1;
        private PictureBox pictureBox2;
        private Label amin;
        private Panel panel1;
        private StatusBar statusBar;
        private StatusBarPanel statusBarPanel_Sw;
        private StatusBarPanel statusBarPanel_Info;
        private Panel panel2;
        private Label token;
        private Panel master_panel;
        private PictureBox seting_btn;
        private PictureBox user_login_btn;
        private Button close_seting_btn;
        private Label label14;
        private Label label13;
        const string	ApduListFile = "ApduList.xml";

		public MainForm()
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Setup the panels
			statusBarPanel_Info.BorderStyle = StatusBarPanelBorderStyle.Sunken;
			statusBarPanel_Info.AutoSize = StatusBarPanelAutoSize.Spring;

			statusBarPanel_Sw.BorderStyle = StatusBarPanelBorderStyle.Raised;
			statusBarPanel_Sw.AutoSize = StatusBarPanelAutoSize.Spring;

			statusBar.ShowPanels = true;

            SelectICard();

			SetupReaderList();
			LoadApduList();

		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnTransmit = new System.Windows.Forms.Button();
            this.comboApdu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textDOut = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textLe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textP2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textP1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textIns = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textData = new System.Windows.Forms.TextBox();
            this.comboReader = new System.Windows.Forms.ComboBox();
            this.txtboxATR = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.admin_panel = new System.Windows.Forms.GroupBox();
            this.close_seting_btn = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel_Sw = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_Info = new System.Windows.Forms.StatusBarPanel();
            this.mynotifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.master_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.user_login_btn = new System.Windows.Forms.PictureBox();
            this.seting_btn = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.token = new System.Windows.Forms.Label();
            this.amin = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.admin_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Sw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Info)).BeginInit();
            this.master_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_login_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seting_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 81);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 26);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reader name";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(116, 80);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(10);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(90, 26);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnTransmit
            // 
            this.btnTransmit.Location = new System.Drawing.Point(535, 127);
            this.btnTransmit.Margin = new System.Windows.Forms.Padding(10);
            this.btnTransmit.Name = "btnTransmit";
            this.btnTransmit.Size = new System.Drawing.Size(99, 27);
            this.btnTransmit.TabIndex = 6;
            this.btnTransmit.Text = "Transmit";
            this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
            // 
            // comboApdu
            // 
            this.comboApdu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboApdu.FormattingEnabled = true;
            this.comboApdu.Location = new System.Drawing.Point(151, 127);
            this.comboApdu.Margin = new System.Windows.Forms.Padding(10);
            this.comboApdu.Name = "comboApdu";
            this.comboApdu.Size = new System.Drawing.Size(364, 27);
            this.comboApdu.TabIndex = 8;
            this.comboApdu.SelectedIndexChanged += new System.EventHandler(this.comboApdu_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "APDU Command";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textDOut);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textLe);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textP2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textP1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textIns);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textClass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textData);
            this.groupBox1.Location = new System.Drawing.Point(17, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 345);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "APDU";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Received Data";
            // 
            // textDOut
            // 
            this.textDOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textDOut.Location = new System.Drawing.Point(319, 177);
            this.textDOut.Multiline = true;
            this.textDOut.Name = "textDOut";
            this.textDOut.ReadOnly = true;
            this.textDOut.Size = new System.Drawing.Size(291, 156);
            this.textDOut.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "Sent Data";
            // 
            // textLe
            // 
            this.textLe.Location = new System.Drawing.Point(65, 111);
            this.textLe.Name = "textLe";
            this.textLe.Size = new System.Drawing.Size(232, 27);
            this.textLe.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "Le";
            // 
            // textP2
            // 
            this.textP2.Location = new System.Drawing.Point(352, 73);
            this.textP2.Name = "textP2";
            this.textP2.Size = new System.Drawing.Size(258, 27);
            this.textP2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "P2";
            // 
            // textP1
            // 
            this.textP1.Location = new System.Drawing.Point(65, 73);
            this.textP1.Name = "textP1";
            this.textP1.Size = new System.Drawing.Size(232, 27);
            this.textP1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "P1";
            // 
            // textIns
            // 
            this.textIns.Location = new System.Drawing.Point(352, 34);
            this.textIns.Name = "textIns";
            this.textIns.ReadOnly = true;
            this.textIns.Size = new System.Drawing.Size(258, 27);
            this.textIns.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ins";
            // 
            // textClass
            // 
            this.textClass.Location = new System.Drawing.Point(65, 34);
            this.textClass.Name = "textClass";
            this.textClass.ReadOnly = true;
            this.textClass.Size = new System.Drawing.Size(232, 27);
            this.textClass.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Class";
            // 
            // textData
            // 
            this.textData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textData.Location = new System.Drawing.Point(6, 177);
            this.textData.Multiline = true;
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(291, 156);
            this.textData.TabIndex = 0;
            // 
            // comboReader
            // 
            this.comboReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReader.FormattingEnabled = true;
            this.comboReader.Location = new System.Drawing.Point(123, 33);
            this.comboReader.Margin = new System.Windows.Forms.Padding(10);
            this.comboReader.Name = "comboReader";
            this.comboReader.Size = new System.Drawing.Size(511, 27);
            this.comboReader.TabIndex = 12;
            this.comboReader.SelectedIndexChanged += new System.EventHandler(this.comboReader_SelectedIndexChanged);
            // 
            // txtboxATR
            // 
            this.txtboxATR.Location = new System.Drawing.Point(277, 80);
            this.txtboxATR.Margin = new System.Windows.Forms.Padding(10);
            this.txtboxATR.Name = "txtboxATR";
            this.txtboxATR.ReadOnly = true;
            this.txtboxATR.Size = new System.Drawing.Size(357, 27);
            this.txtboxATR.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(235, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 19);
            this.label10.TabIndex = 14;
            this.label10.Text = "ATR";
            // 
            // admin_panel
            // 
            this.admin_panel.BackColor = System.Drawing.Color.DarkGray;
            this.admin_panel.Controls.Add(this.close_seting_btn);
            this.admin_panel.Controls.Add(this.statusBar);
            this.admin_panel.Controls.Add(this.label1);
            this.admin_panel.Controls.Add(this.btnConnect);
            this.admin_panel.Controls.Add(this.label10);
            this.admin_panel.Controls.Add(this.btnDisconnect);
            this.admin_panel.Controls.Add(this.txtboxATR);
            this.admin_panel.Controls.Add(this.btnTransmit);
            this.admin_panel.Controls.Add(this.comboReader);
            this.admin_panel.Controls.Add(this.comboApdu);
            this.admin_panel.Controls.Add(this.groupBox1);
            this.admin_panel.Controls.Add(this.label2);
            this.admin_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.admin_panel.Enabled = false;
            this.admin_panel.Font = new System.Drawing.Font("Arial", 10F);
            this.admin_panel.Location = new System.Drawing.Point(0, 0);
            this.admin_panel.Name = "admin_panel";
            this.admin_panel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.admin_panel.Size = new System.Drawing.Size(796, 620);
            this.admin_panel.TabIndex = 16;
            this.admin_panel.TabStop = false;
            this.admin_panel.Text = "admin";
            this.admin_panel.Visible = false;
            // 
            // close_seting_btn
            // 
            this.close_seting_btn.Location = new System.Drawing.Point(261, 543);
            this.close_seting_btn.Name = "close_seting_btn";
            this.close_seting_btn.Size = new System.Drawing.Size(124, 40);
            this.close_seting_btn.TabIndex = 16;
            this.close_seting_btn.Text = "Close";
            this.close_seting_btn.UseVisualStyleBackColor = true;
            this.close_seting_btn.Click += new System.EventHandler(this.close_seting_btn_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(3, 589);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel_Sw,
            this.statusBarPanel_Info});
            this.statusBar.Size = new System.Drawing.Size(790, 28);
            this.statusBar.TabIndex = 15;
            // 
            // statusBarPanel_Sw
            // 
            this.statusBarPanel_Sw.Name = "statusBarPanel_Sw";
            // 
            // statusBarPanel_Info
            // 
            this.statusBarPanel_Info.Name = "statusBarPanel_Info";
            // 
            // mynotifyicon
            // 
            this.mynotifyicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.mynotifyicon.BalloonTipText = "Vizitori Smart Card";
            this.mynotifyicon.BalloonTipTitle = "Vizitori";
            this.mynotifyicon.Icon = ((System.Drawing.Icon)(resources.GetObject("mynotifyicon.Icon")));
            this.mynotifyicon.Text = "System is active";
            this.mynotifyicon.Visible = true;
            this.mynotifyicon.DoubleClick += new System.EventHandler(this.mynotifyicon_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // master_panel
            // 
            this.master_panel.BackgroundImage = global::TestSmartcard.Properties.Resources.card1;
            this.master_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.master_panel.Controls.Add(this.panel1);
            this.master_panel.Controls.Add(this.panel2);
            this.master_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.master_panel.Location = new System.Drawing.Point(0, 0);
            this.master_panel.Name = "master_panel";
            this.master_panel.Size = new System.Drawing.Size(796, 620);
            this.master_panel.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.user_login_btn);
            this.panel1.Controls.Add(this.seting_btn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 68);
            this.panel1.TabIndex = 27;
            // 
            // user_login_btn
            // 
            this.user_login_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.user_login_btn.Image = global::TestSmartcard.Properties.Resources.users;
            this.user_login_btn.Location = new System.Drawing.Point(71, 9);
            this.user_login_btn.Name = "user_login_btn";
            this.user_login_btn.Size = new System.Drawing.Size(55, 55);
            this.user_login_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.user_login_btn.TabIndex = 31;
            this.user_login_btn.TabStop = false;
            this.user_login_btn.Click += new System.EventHandler(this.user_login_btn_Click);
            // 
            // seting_btn
            // 
            this.seting_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seting_btn.Image = global::TestSmartcard.Properties.Resources.process1;
            this.seting_btn.Location = new System.Drawing.Point(10, 9);
            this.seting_btn.Name = "seting_btn";
            this.seting_btn.Size = new System.Drawing.Size(55, 55);
            this.seting_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.seting_btn.TabIndex = 30;
            this.seting_btn.TabStop = false;
            this.seting_btn.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::TestSmartcard.Properties.Resources.delete1;
            this.pictureBox2.Location = new System.Drawing.Point(735, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.token);
            this.panel2.Controls.Add(this.amin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 543);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 77);
            this.panel2.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(13, 8);
            this.label14.Margin = new System.Windows.Forms.Padding(10);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(112, 25);
            this.label14.TabIndex = 31;
            this.label14.Text = "User token:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(13, 42);
            this.label13.Margin = new System.Windows.Forms.Padding(10);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(109, 25);
            this.label13.TabIndex = 30;
            this.label13.Text = "Card code:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // token
            // 
            this.token.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.token.AutoSize = true;
            this.token.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.token.ForeColor = System.Drawing.Color.White;
            this.token.Location = new System.Drawing.Point(122, 8);
            this.token.Margin = new System.Windows.Forms.Padding(10);
            this.token.Name = "token";
            this.token.Size = new System.Drawing.Size(45, 25);
            this.token.TabIndex = 29;
            this.token.Text = "Null";
            this.token.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // amin
            // 
            this.amin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.amin.AutoSize = true;
            this.amin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amin.ForeColor = System.Drawing.Color.White;
            this.amin.Location = new System.Drawing.Point(123, 42);
            this.amin.Margin = new System.Windows.Forms.Padding(10);
            this.amin.Name = "amin";
            this.amin.Size = new System.Drawing.Size(45, 25);
            this.amin.TabIndex = 28;
            this.amin.Text = "Null";
            this.amin.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(12, 39);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(796, 620);
            this.Controls.Add(this.admin_panel);
            this.Controls.Add(this.master_panel);
            this.Font = new System.Drawing.Font("B Roya", 13.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart card";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.admin_panel.ResumeLayout(false);
            this.admin_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Sw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Info)).EndInit();
            this.master_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.user_login_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seting_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
        private void amin_go()
        {
            try
            {
                m_iCard.Connect((string)comboReader.SelectedItem, SHARE.Shared, PROTOCOL.T0orT1);

                try
                {
                    // Get the ATR of the card
                    byte[] atrValue = m_iCard.GetAttribute(SCARD_ATTR_VALUE.ATR_STRING);

                    if(amin.Text == "Null")
                    {
                        amin.Text = ByteArrayToString(atrValue);
                        if (token.Text != "Null" && token.Text != "")
                        {
                            
                            JObject cardReply;
                            var card_obg = new TestSmartcard.ws_login();
                            cardReply = card_obg.Call_card(ByteArrayToString(atrValue).ToString(), "0", token.Text);
                            if (cardReply["message"].ToString() == "ok")
                            {
                                if (cardReply["data"]["url"].ToString() != "")
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                    startInfo.FileName = cardReply["data"]["url"].ToString();
                                    process.StartInfo = startInfo;
                                    process.Start();
                                }
                            }
                            else
                            {
                                MessageBox.Show("کارت معتبر نیست!", "این کارت اعتبار ندارد و یا معیوب است.",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //injaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                            
                        }
                        else
                        {
                            login login_form = new login();
                            login_form.ShowDialog();
                        }
                    }
                    
                }
                catch (Exception)
                {
                    amin.Text = "can't read card!!";
                }
            }
            catch (Exception ex)
            {
                amin.Text = "Null";
            }
        }
        private void btnConnect_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_iCard.Connect((string) comboReader.SelectedItem, SHARE.Shared, PROTOCOL.T0orT1);

                try
                {
                    // Get the ATR of the card
                    byte[] atrValue = m_iCard.GetAttribute(SCARD_ATTR_VALUE.ATR_STRING);
                    txtboxATR.Text = ByteArrayToString(atrValue);
                }
                catch (Exception)
                {
                    txtboxATR.Text = "Cannot get ATR";
                }

				btnConnect.Enabled = false;
				btnDisconnect.Enabled = true;
				btnTransmit.Enabled = true;

				statusBarPanel_Info.Text = "Card connected";
			}
			catch(Exception ex)
			{
				btnConnect.Enabled = true;
				btnDisconnect.Enabled = false;
				btnTransmit.Enabled = false;

				statusBar.Text = ex.Message;
			}
		}

		private void btnDisconnect_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_iCard.Disconnect(DISCONNECT.Unpower);

				btnConnect.Enabled = true;
				btnDisconnect.Enabled = false;
				btnTransmit.Enabled = false;

				statusBarPanel_Info.Text = "Card disconnected";
			}
			catch(Exception ex)
			{
				statusBar.Text = ex.Message;
			}
		}

		private void btnTransmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				APDUResponse	apduResp = m_apduPlayer.ProcessCommand((string) comboApdu.SelectedItem, BuildParam());

				if (apduResp.Data != null)
				{
					StringBuilder	sDataOut = new StringBuilder(apduResp.Data.Length * 2);
					for (int nI = 0; nI < apduResp.Data.Length; nI++)
						sDataOut.AppendFormat("{0:X02}", apduResp.Data[nI]);

                    textDOut.Text = ByteArrayToString(apduResp.Data);
				}
				else
					textDOut.Text = "";

				statusBarPanel_Sw.Text = string.Format("{0:X04}", apduResp.Status);
				statusBarPanel_Info.Text = "Command sent";
			}
			catch(SmartCardException exSC)
			{
				statusBarPanel_Info.Text = exSC.Message;
			}
			catch(Exception ex)
			{
				statusBarPanel_Info.Text = ex.Message;
			}
		}


		private void SelectICard()
		{
			try
			{
				if (m_iCard != null)
					m_iCard.Disconnect(DISCONNECT.Unpower);

				m_iCard = new CardNative();
				statusBarPanel_Info.Text = "CardNative implementation used";

                m_iCard.OnCardInserted += new CardInsertedEventHandler(m_iCard_OnCardInserted);
                m_iCard.OnCardRemoved += new CardRemovedEventHandler(m_iCard_OnCardRemoved);

			}
			catch(Exception ex)
			{
				btnConnect.Enabled = false;
				btnDisconnect.Enabled = false;
				btnTransmit.Enabled = false;

				statusBarPanel_Info.Text = ex.Message;
			}
		}

        /// <summary>
        /// CardRemovedEventHandler
        /// </summary>
        private void m_iCard_OnCardRemoved(string reader)
        {
            btnConnect.Invoke(new EnableButtonDelegate(EnableButton), new object[] {btnConnect, false});
            btnDisconnect.Invoke(new EnableButtonDelegate(EnableButton), new object[] { btnDisconnect, false });
            btnTransmit.Invoke(new EnableButtonDelegate(EnableButton), new object[] { btnTransmit, false });
        }


        protected void    EnableButton(Button btn, bool enable)
        {
            btn.Enabled = enable;
            amin_go();
        }

        /// <summary>
        /// CardInsertedEventHandler
        /// </summary>
        private void m_iCard_OnCardInserted(string reader)
        {
            btnConnect.Invoke(new EnableButtonDelegate(EnableButton), new object[] { btnConnect, true });
            btnDisconnect.Invoke(new EnableButtonDelegate(EnableButton), new object[] { btnDisconnect, false });
            btnTransmit.Invoke(new EnableButtonDelegate(EnableButton), new object[] { btnTransmit, false });
        }

        
        static private string ByteArrayToString(byte[] data)
        {
            StringBuilder sDataOut;

            if (data != null)
            {
                sDataOut = new StringBuilder(data.Length * 2);
                for (int nI = 0; nI < data.Length; nI++)
                    sDataOut.AppendFormat("{0:X02}", data[nI]);
            }
            else
                sDataOut = new StringBuilder();

            return sDataOut.ToString();
        }


        /// <summary>
        /// Loads the APDU list
        /// </summary>
		private void	LoadApduList()
		{
			try
			{
				// Create the APDU player
				m_apduPlayer = new APDUPlayer(ApduListFile, m_iCard);

				// Get the list of APDUs and setup teh combo
				comboApdu.Items.AddRange(m_apduPlayer.APDUNames);
				comboApdu.SelectedIndex = 0;
			}
			catch(Exception ex)
			{
				statusBarPanel_Info.Text = ex.Message;
			}
		}

		private	APDUParam	BuildParam()
		{
			byte	bP1 = byte.Parse(textP1.Text, NumberStyles.AllowHexSpecifier);
			byte	bP2 = byte.Parse(textP2.Text, NumberStyles.AllowHexSpecifier);
			byte	bLe = byte.Parse(textLe.Text);

			APDUParam	apduParam = new APDUParam();
			apduParam.P1 = bP1;
			apduParam.P2 = bP2;
            apduParam.Le = bLe;

			// Update Current param
			m_apduParam = apduParam.Clone();

			return apduParam;
		}

		private void comboApdu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DisplayAPDUCommand(m_apduPlayer.APDUByName((string) comboApdu.SelectedItem));

			statusBarPanel_Info.Text = "Command Ready";
			statusBarPanel_Sw.Text = "";
		}

		private	void DisplayAPDUCommand(APDUCommand apduCmd)
		{
			if (apduCmd != null)
			{
				textClass.Text = string.Format("{0:X02}", apduCmd.Class);
				textIns.Text = string.Format("{0:X02}", apduCmd.Ins);
				textP1.Text = string.Format("{0:X02}", apduCmd.P1);
				textP2.Text = string.Format("{0:X02}", apduCmd.P2);
				textLe.Text = apduCmd.Le.ToString();
				
				if (apduCmd.Data != null)
				{
					StringBuilder	sData = new StringBuilder(apduCmd.Data.Length * 2);
					for (int nI = 0; nI < apduCmd.Data.Length; nI++)
						sData.AppendFormat("{0:X02}", apduCmd.Data[nI]);

					textData.Text = sData.ToString();
				}
				else
					textData.Text = "";

				m_apduParam = new APDUParam();
                
                m_apduParam.P1 = apduCmd.P1;
                m_apduParam.P2 = apduCmd.P2;
                m_apduParam.Le = apduCmd.Le;
			}
		}

		private	void	SetupReaderList()
		{
			try
			{
				string[] sListReaders = m_iCard.ListReaders();
				comboReader.Items.Clear();

				if (sListReaders != null)
				{
					for (int nI = 0; nI < sListReaders.Length; nI++)
						comboReader.Items.Add(sListReaders[nI]);

					comboReader.SelectedIndex = 0;
                    amin.Text = "Null";
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = false;
                    btnTransmit.Enabled = false;

                    //// Start waiting for a card
                    //string reader = (string)comboReader.SelectedItem;
                    //m_iCard.StartCardEvents(reader);

                    //statusBarPanel_Info.Text = "Waiting for a card";
				}
			}
			catch(Exception ex)
			{
				statusBarPanel_Info.Text = ex.Message;
				btnConnect.Enabled = false;
			}
		}


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                m_iCard.Disconnect(DISCONNECT.Unpower);

                m_iCard.StopCardEvents();
            }
            catch
            {
            }
        }

        /// <summary>
        /// If the selection changes, Stop the current Reader event and start the new one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboReader_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                m_iCard.StopCardEvents();

                // Get the current selection
                int idx = comboReader.SelectedIndex;
                if (idx != -1)
                {
                    // Start waiting for a card
                    string reader = (string)comboReader.SelectedItem;
                    m_iCard.StartCardEvents(reader);

                    statusBarPanel_Info.Text = "Waiting for a card";
                }
            }
            catch (Exception ex)
            {
                statusBarPanel_Info.Text = ex.Message;
                btnConnect.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                mynotifyicon.Visible = true;
                mynotifyicon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                mynotifyicon.Visible = false;
            }

        }

        private void mynotifyicon_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
            mynotifyicon.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            timer1.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            mynotifyicon.Visible = true;
            mynotifyicon.ShowBalloonTip(3000);
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public string token_value
        {
            get
            {
                return this.token.Text;
            }
            set
            {
                token.Text = value;
                this.token.Text = value;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(admin_panel.Visible == false)
            {
                admin_panel.Visible = true;
                admin_panel.Enabled = true;
                master_panel.Visible = false;
                master_panel.Enabled = false;
            }
            else
            {
                admin_panel.Visible = false;
                admin_panel.Enabled = false;
                master_panel.Visible = true;
                master_panel.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Width = 590;
            if(token.Text=="Null")
            {
            //===========================================================
                string username = "";
                string password = "";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Vizitori");
                if (key != null)
                {
                    username = key.GetValue("username").ToString();
                    password = key.GetValue("password").ToString();
                    key.Close();
                    JObject loginReply;
                    if (username != "" && password != "")
                    {
                        var login_obg = new TestSmartcard.ws_login();
                        loginReply = login_obg.Call_login(username, password, "0");
                        if (loginReply["message"].ToString() == "ok")
                        {
                            token.Text = loginReply["data"]["token"].ToString();
                        }
                        else
                        {
                            login login_form = new login();
                            login_form.ShowDialog();
                        }
                    }
                    else
                    {
                        login login_form = new login();
                        login_form.ShowDialog();
                    }
                }
                else
                {
                    login login_form = new login();
                    login_form.ShowDialog();
                }
                //===========================================================
            }
            if (token.Text != "Null")
            {
                timer1.Enabled = true;
            }
        }

        private void user_login_btn_Click(object sender, EventArgs e)
        {
            login login_form = new login();
            login_form.ShowDialog();
        }

        private void close_seting_btn_Click(object sender, EventArgs e)
        {
            if (admin_panel.Visible == false)
            {
                admin_panel.Visible = true;
                admin_panel.Enabled = true;
                master_panel.Visible = false;
                master_panel.Enabled = false;
            }
            else
            {
                admin_panel.Visible = false;
                admin_panel.Enabled = false;
                master_panel.Visible = true;
                master_panel.Enabled = true;
            }
        }
    }
}
