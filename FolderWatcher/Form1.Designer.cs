namespace FolderWatcher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMI_Notifications = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MI_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_File_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_View = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_View_History = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_View_Notifications = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_View_Minimize = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Watch";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(237, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Folder Watcher [watching...]";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMI_Notifications});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(175, 26);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // CMI_Notifications
            // 
            this.CMI_Notifications.Name = "CMI_Notifications";
            this.CMI_Notifications.Size = new System.Drawing.Size(174, 22);
            this.CMI_Notifications.Text = "Show Notifications";
            this.CMI_Notifications.Click += new System.EventHandler(this.CMI_Notifications_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_File,
            this.MI_View});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(324, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MI_File
            // 
            this.MI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_File_Export});
            this.MI_File.Name = "MI_File";
            this.MI_File.Size = new System.Drawing.Size(37, 20);
            this.MI_File.Text = "File";
            this.MI_File.Click += new System.EventHandler(this.MI_File_Click);
            // 
            // MI_File_Export
            // 
            this.MI_File_Export.Name = "MI_File_Export";
            this.MI_File_Export.Size = new System.Drawing.Size(158, 22);
            this.MI_File_Export.Text = "Export History...";
            this.MI_File_Export.Click += new System.EventHandler(this.MI_File_Export_Click);
            // 
            // MI_View
            // 
            this.MI_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_View_History,
            this.MI_View_Notifications,
            this.MI_View_Minimize});
            this.MI_View.Name = "MI_View";
            this.MI_View.Size = new System.Drawing.Size(44, 20);
            this.MI_View.Text = "View";
            // 
            // MI_View_History
            // 
            this.MI_View_History.Name = "MI_View_History";
            this.MI_View_History.Size = new System.Drawing.Size(180, 22);
            this.MI_View_History.Text = "Show History";
            this.MI_View_History.Click += new System.EventHandler(this.MI_View_History_Click);
            // 
            // MI_View_Notifications
            // 
            this.MI_View_Notifications.Name = "MI_View_Notifications";
            this.MI_View_Notifications.Size = new System.Drawing.Size(180, 22);
            this.MI_View_Notifications.Text = "Show Notifications";
            this.MI_View_Notifications.Click += new System.EventHandler(this.MI_View_Notifications_Click);
            // 
            // MI_View_Minimize
            // 
            this.MI_View_Minimize.Name = "MI_View_Minimize";
            this.MI_View_Minimize.Size = new System.Drawing.Size(180, 22);
            this.MI_View_Minimize.Text = "Minimize";
            this.MI_View_Minimize.Visible = false;
            this.MI_View_Minimize.Click += new System.EventHandler(this.MI_View_Minimize_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Open Folder";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 83);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(300, 266);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 361);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 400);
            this.MinimumSize = new System.Drawing.Size(340, 128);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Watcher";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MI_View;
        private System.Windows.Forms.ToolStripMenuItem MI_View_Notifications;
        private System.Windows.Forms.ToolStripMenuItem MI_View_History;
        private System.Windows.Forms.ToolStripMenuItem MI_View_Minimize;
        private System.Windows.Forms.ToolStripMenuItem MI_File;
        private System.Windows.Forms.ToolStripMenuItem MI_File_Export;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CMI_Notifications;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

