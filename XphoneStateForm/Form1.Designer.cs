namespace XphoneStateForm
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.State = new System.Windows.Forms.Label();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserHandleFoder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.panelEvent = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelNextState = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonOpenFileLocation = new System.Windows.Forms.Button();
            this.textBoxFileLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSearchState = new System.Windows.Forms.TextBox();
            this.textBoxEvent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(22, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(373, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // State
            // 
            this.State.AutoSize = true;
            this.State.Location = new System.Drawing.Point(22, 121);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(32, 13);
            this.State.TabIndex = 1;
            this.State.Text = "State";
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(1261, 86);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDebug.Size = new System.Drawing.Size(541, 454);
            this.textBoxDebug.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "\"user_handler\" - Fodler";
            // 
            // textBoxUserHandleFoder
            // 
            this.textBoxUserHandleFoder.Location = new System.Drawing.Point(24, 48);
            this.textBoxUserHandleFoder.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUserHandleFoder.Name = "textBoxUserHandleFoder";
            this.textBoxUserHandleFoder.Size = new System.Drawing.Size(371, 20);
            this.textBoxUserHandleFoder.TabIndex = 8;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(24, 70);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(86, 27);
            this.buttonBrowse.TabIndex = 9;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // panel1
            // 
            this.panelEvent.AutoScroll = true;
            this.panelEvent.Location = new System.Drawing.Point(405, 121);
            this.panelEvent.Margin = new System.Windows.Forms.Padding(2);
            this.panelEvent.Name = "panel1";
            this.panelEvent.Size = new System.Drawing.Size(409, 658);
            this.panelEvent.TabIndex = 10;
            this.panelEvent.MouseEnter += new System.EventHandler(this.panelEvent_MouseEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1823, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Debug";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(996, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Next State";
            // 
            // panelNextState
            // 
            this.panelNextState.AutoScroll = true;
            this.panelNextState.Location = new System.Drawing.Point(834, 86);
            this.panelNextState.Margin = new System.Windows.Forms.Padding(2);
            this.panelNextState.Name = "panelNextState";
            this.panelNextState.Size = new System.Drawing.Size(404, 377);
            this.panelNextState.TabIndex = 15;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(253, 31);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "Status";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonOpenFileLocation);
            this.panel2.Controls.Add(this.textBoxFileLocation);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(22, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 100);
            this.panel2.TabIndex = 17;
            // 
            // buttonOpenFileLocation
            // 
            this.buttonOpenFileLocation.Location = new System.Drawing.Point(5, 57);
            this.buttonOpenFileLocation.Name = "buttonOpenFileLocation";
            this.buttonOpenFileLocation.Size = new System.Drawing.Size(76, 23);
            this.buttonOpenFileLocation.TabIndex = 17;
            this.buttonOpenFileLocation.Text = "Open";
            this.buttonOpenFileLocation.UseVisualStyleBackColor = true;
            this.buttonOpenFileLocation.Click += new System.EventHandler(this.ButtonOpenFileLocation_Click);
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Location = new System.Drawing.Point(5, 29);
            this.textBoxFileLocation.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(358, 20);
            this.textBoxFileLocation.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "File Location";
            // 
            // textBoxSearchState
            // 
            this.textBoxSearchState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxSearchState.Location = new System.Drawing.Point(22, 141);
            this.textBoxSearchState.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearchState.Name = "textBoxSearchState";
            this.textBoxSearchState.Size = new System.Drawing.Size(371, 20);
            this.textBoxSearchState.TabIndex = 18;
            this.textBoxSearchState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearchState_KeyDown);
            // 
            // textBoxEvent
            // 
            this.textBoxEvent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxEvent.Location = new System.Drawing.Point(405, 97);
            this.textBoxEvent.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEvent.Name = "textBoxEvent";
            this.textBoxEvent.Size = new System.Drawing.Size(409, 20);
            this.textBoxEvent.TabIndex = 19;
            this.textBoxEvent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxEvent_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Event";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1823, 763);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEvent);
            this.Controls.Add(this.textBoxSearchState);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelNextState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelEvent);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxUserHandleFoder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.State);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GPhone State";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUserHandleFoder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Panel panelEvent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelNextState;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonOpenFileLocation;
        private System.Windows.Forms.TextBox textBoxFileLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSearchState;
        private System.Windows.Forms.TextBox textBoxEvent;
        private System.Windows.Forms.Label label4;
    }
}

