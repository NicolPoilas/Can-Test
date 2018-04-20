namespace Can_Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonBusOpenorClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CANCHN = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxCanBaudRate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxCanDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byteToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.dataStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.richTextBoxDisplay = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.CANCHN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 640);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "Bus Load:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(371, 605);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.buttonBusOpenorClose);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.CANCHN);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(363, 579);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Can set";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(66, 285);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(190, 96);
            this.richTextBox1.TabIndex = 42;
            this.richTextBox1.Text = "";
            // 
            // buttonBusOpenorClose
            // 
            this.buttonBusOpenorClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBusOpenorClose.Location = new System.Drawing.Point(77, 157);
            this.buttonBusOpenorClose.Name = "buttonBusOpenorClose";
            this.buttonBusOpenorClose.Size = new System.Drawing.Size(164, 25);
            this.buttonBusOpenorClose.TabIndex = 32;
            this.buttonBusOpenorClose.Text = "Bus Off";
            this.buttonBusOpenorClose.UseVisualStyleBackColor = true;
            this.buttonBusOpenorClose.Click += new System.EventHandler(this.buttonBusOpenorClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CANCHN
            // 
            this.CANCHN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CANCHN.Controls.Add(this.label11);
            this.CANCHN.Controls.Add(this.comboBoxCanBaudRate);
            this.CANCHN.Controls.Add(this.label10);
            this.CANCHN.Controls.Add(this.comboBoxCanDevice);
            this.CANCHN.Controls.Add(this.label1);
            this.CANCHN.Controls.Add(this.label2);
            this.CANCHN.Location = new System.Drawing.Point(6, 20);
            this.CANCHN.Name = "CANCHN";
            this.CANCHN.Size = new System.Drawing.Size(349, 104);
            this.CANCHN.TabIndex = 37;
            this.CANCHN.TabStop = false;
            this.CANCHN.Text = "CANCHN";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "Baudrate";
            // 
            // comboBoxCanBaudRate
            // 
            this.comboBoxCanBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCanBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCanBaudRate.FormattingEnabled = true;
            this.comboBoxCanBaudRate.Items.AddRange(new object[] {
            "50",
            "100",
            "125",
            "250",
            "500",
            "1000"});
            this.comboBoxCanBaudRate.Location = new System.Drawing.Point(71, 61);
            this.comboBoxCanBaudRate.Name = "comboBoxCanBaudRate";
            this.comboBoxCanBaudRate.Size = new System.Drawing.Size(258, 20);
            this.comboBoxCanBaudRate.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "Device";
            // 
            // comboBoxCanDevice
            // 
            this.comboBoxCanDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCanDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxCanDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCanDevice.FormattingEnabled = true;
            this.comboBoxCanDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxCanDevice.Location = new System.Drawing.Point(71, 26);
            this.comboBoxCanDevice.Name = "comboBoxCanDevice";
            this.comboBoxCanDevice.Size = new System.Drawing.Size(258, 20);
            this.comboBoxCanDevice.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 12);
            this.label2.TabIndex = 29;
            // 
            // dTCToolStripMenuItem
            // 
            this.dTCToolStripMenuItem.Name = "dTCToolStripMenuItem";
            this.dTCToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            // 
            // viewFormatToolStripMenuItem
            // 
            this.viewFormatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byteToolStripMenuItem});
            this.viewFormatToolStripMenuItem.Name = "viewFormatToolStripMenuItem";
            this.viewFormatToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.viewFormatToolStripMenuItem.Text = "View Format";
            // 
            // byteToolStripMenuItem
            // 
            this.byteToolStripMenuItem.Items.AddRange(new object[] {
            "8 Byte",
            "16 Byte",
            "24 Byte"});
            this.byteToolStripMenuItem.Name = "byteToolStripMenuItem";
            this.byteToolStripMenuItem.Size = new System.Drawing.Size(152, 25);
            this.byteToolStripMenuItem.Text = "8 Byte";
            // 
            // dataStreamToolStripMenuItem
            // 
            this.dataStreamToolStripMenuItem.Name = "dataStreamToolStripMenuItem";
            this.dataStreamToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.dataStreamToolStripMenuItem.Text = "Data Stream Only";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dTCToolStripMenuItem,
            this.viewFormatToolStripMenuItem,
            this.dataStreamToolStripMenuItem});
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton2.Text = "Setting";
            // 
            // richTextBoxDisplay
            // 
            this.richTextBoxDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDisplay.HideSelection = false;
            this.richTextBoxDisplay.Location = new System.Drawing.Point(13, 22);
            this.richTextBoxDisplay.Name = "richTextBoxDisplay";
            this.richTextBoxDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxDisplay.Size = new System.Drawing.Size(293, 580);
            this.richTextBoxDisplay.TabIndex = 40;
            this.richTextBoxDisplay.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxDisplay);
            this.splitContainer1.Size = new System.Drawing.Size(704, 609);
            this.splitContainer1.SplitterDistance = 375;
            this.splitContainer1.TabIndex = 44;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 662);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Can Tool S300";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.CANCHN.ResumeLayout(false);
            this.CANCHN.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem dTCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox byteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton2;
        private System.Windows.Forms.RichTextBox richTextBoxDisplay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox CANCHN;
        private System.Windows.Forms.ComboBox comboBoxCanDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCanBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBusOpenorClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
    }
}

