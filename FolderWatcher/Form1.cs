using System;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace FolderWatcher
{
    public partial class Form1 : Form
    {
        FileSystemWatcher watcher;

        event HistoryChangedHandler HistoryChanged;
        delegate void HistoryChangedHandler(object sender, EventArgs e);
        event IconChangedHandler IconChanged;
        delegate void IconChangedHandler(object sender, EventArgs e);

        BackgroundWorker bw;

        bool
            folderSelected = false,
            watching = false,
            showHistory = true,
            showNotifications = true,
            saved = true,
            minimized = false,
            iconRed = false,
            unreadNotifications = false;

        bool UnreadNotifications
        {
            get { return unreadNotifications; }
            set
            {
                unreadNotifications = value;

                if (IconChanged != null)
                {
                    EventArgs eventArgs = new EventArgs();
                    IconChanged(this, eventArgs);
                }
            }
        }
        
        //byte l = 0b_0001_1100;

        List<string> history;
        string History
        {
            get { return history[history.Count - 1]; }
            set
            {
                history.Add(value);

                if (HistoryChanged != null)
                {
                    EventArgs eventArgs = new EventArgs();
                    HistoryChanged(this, eventArgs);
                }
            }
        }
        string path = "";

        public Form1()
        {
            InitializeComponent();

            history = new List<string>();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void Form1_Load(object sender, EventArgs e)
        {
            watcher = new FileSystemWatcher();

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            //watcher.Filter = "*.txt";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            HistoryChanged = UpdateHistoryList;
            IconChanged = UpdateNotifyIconText;
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            MI_File_Export.Enabled = history.Count > 0;
            MI_View_History.Checked = showHistory;
            MI_View_Notifications.Checked = CMI_Notifications.Checked = showNotifications;
            this.Text = watching ? "Folder Watcher [watching...]" : "Folder Watcher";
            this.Height = showHistory ? this.MaximumSize.Height : this.MinimumSize.Height;
            notifyIcon.Text = watching ? "Folder Watcher [watching...]" : "Folder Watcher";
            button1.Enabled = !watching;
            button2.Visible = !watching;
            button2.Enabled = folderSelected;
            button3.Visible = button3.Enabled = watching;
            button4.Enabled = folderSelected;
            textBox1.ReadOnly = watching;
            richTextBox1.Enabled = richTextBox1.Visible = showHistory;
        }

        private void UpdateHistoryList(object sender, EventArgs e)
        {
            BeginInvoke
                (
                    new Action
                    (
                        () =>
                            {
                                richTextBox1.Text += History + "\n";
                                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                richTextBox1.ScrollToCaret();
                                saved = false;
                            }
                    )
                );
        }

        private void UpdateNotifyIconText(object sender, EventArgs e)
        {
            BeginInvoke
                (
                    new Action
                    (
                        () =>
                        {
                            notifyIcon.Text = UnreadNotifications ? "You have unread notifications!" : watching ? "Folder Watcher [watching...]" : "Folder Watcher";
                        }
                    )
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (path != "" && history.Count > 0 && !saved)
            {
                DialogResult dr = MessageBox.Show("Save previous watching history?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch(dr)
                {
                    case DialogResult.Yes:
                        {
                            SaveHistory();

                            history.Clear();
                            richTextBox1.Text = "";
                            saved = true;

                            break;
                        }
                    case DialogResult.No:
                        {
                            history.Clear();
                            richTextBox1.Text = "";
                            saved = true;

                            break;
                        }
                }
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            path = fbd.SelectedPath;
            fbd.Dispose();

            if (path == "")
                return;

            textBox1.Text = path;

            folderSelected = true;

            UpdateGUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (watcher == null)
                return;

            try
            {
                watcher.Path = textBox1.Text;
                watcher.EnableRaisingEvents = true;
                History = "Watching folder: " + path + " at " + DateTime.Now.ToString();

                button3.Focus();
                watching = true;
                UpdateGUI();
                Minimize();
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = null;
                folderSelected = false;
                UpdateGUI();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (watcher == null)
                return;

            watcher.EnableRaisingEvents = false;
            watching = false;
            UpdateGUI();
            button2.Focus();
            History = "Stopped at " + DateTime.Now.ToString();
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            ShowBaloon("  " + e.ChangeType + ": " + e.FullPath);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            ShowBaloon("  Renamed: " + e.OldFullPath + " to " + e.FullPath);
        }

        private void ShowBaloon(string _text, int _delay = 3000)
        {
            if (history != null)
            {
                History = _text + " at " + DateTime.Now.ToString();
                
                if (minimized)
                {
                    if (!IsThreadWorking())
                        StartThread();
                }

                UnreadNotifications = true;
            }

            if (showNotifications)
                notifyIcon.ShowBalloonTip(_delay, "Folder Watcher", _text, ToolTipIcon.None);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (history.Count > 0 && !saved)
            {
                DialogResult dr = MessageBox.Show("Save watching history?", "Folder Watcher", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (dr)
                {
                    case DialogResult.Yes:
                        SaveHistory();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void MI_View_Notifications_Click(object sender, EventArgs e)
        {
            showNotifications = !showNotifications;

            UpdateGUI();
        }

        private void MI_File_Export_Click(object sender, EventArgs e)
        {
            SaveHistory();
        }

        private void MI_View_History_Click(object sender, EventArgs e)
        {
            showHistory = !showHistory;

            UpdateGUI();
        }

        private void MI_View_Minimize_Click(object sender, EventArgs e)
        {
            Minimize();
        }

        private void Minimize()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            minimized = true;
            if (showNotifications)
                notifyIcon.ShowBalloonTip(3000, "Folder Watcher", "I'm here and still working!", ToolTipIcon.None);
        }

        private void MI_File_Click(object sender, EventArgs e)
        {
            MI_File_Export.Enabled = history.Count > 0;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (IsThreadWorking())
                            StopThread();
                        notifyIcon.Icon = Properties.Resources.Folder_Watcher1;
                        this.WindowState = FormWindowState.Normal;
                        this.ShowInTaskbar = true;
                        minimized = false;
                        UnreadNotifications = false;

                        UpdateGUI();

                        break;
                    }
                case MouseButtons.Right:
                    {

                        break;
                    }
            }
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CMI_Notifications.Checked = showNotifications;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                Minimize();
            }
        }

        private void CMI_Notifications_Click(object sender, EventArgs e)
        {
            showNotifications = !showNotifications;

            UpdateGUI();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            folderSelected = textBox1.Text.Length > 0;

            UpdateGUI();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            
            if (Directory.Exists(path))
            {
                Cursor.Current = Cursors.AppStarting;
                Process.Start(new ProcessStartInfo("explorer.exe", path));
                Cursor.Current = Cursors.Default;
            }

            path = null;
        }

        void SaveHistory()
        {
            int begin = path.LastIndexOf('\\') + 1;
            string fileName = path.Substring(begin, path.Length - begin);
            fileName += " " + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Normal text file (*.txt)|*.txt",
                FilterIndex = 0,
                Title = "Export history",
                FileName = fileName
            };
            DialogResult dr = sfd.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    {
                        StreamWriter sw = null;

                        try
                        {
                            sw = new StreamWriter(sfd.FileName);

                            foreach (string s in history)
                            {
                                sw.WriteLine(s);
                            }

                            saved = true;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            sw.Dispose();
                        }

                        break;
                    }
            }

            sfd.Dispose();
        }

        private void StartThread()
        {
            //если поток не создан, то создаем его
            if (bw == null)
            {
                bw = new BackgroundWorker
                {
                    //позволяет прерывать поток
                    WorkerSupportsCancellation = true
                };

                bw.DoWork += (s, e) =>
                {
                    BackgroundWorker worker = s as BackgroundWorker;

                    while (true)
                    {
                        if (!worker.CancellationPending)
                        {
                            notifyIcon.Icon = iconRed ? Properties.Resources.Folder_Watcher1 : Properties.Resources.Folder_Watcher2;
                            iconRed = !iconRed;

                            Thread.Sleep(1000);
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                };

                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Cancelled == true)
                    {
                        notifyIcon.Icon = Properties.Resources.Folder_Watcher1;
                        iconRed = false;
                    }
                    else if (e.Error != null)
                    {
                        MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    bw.Dispose();
                };
            }

            //запускаем поток
            bw.RunWorkerAsync();
        }

        private bool IsThreadWorking()
        {
            return bw == null ? false : bw.IsBusy;
        }

        private void StopThread()
        {
            if (bw == null)
                return;

            if (bw.WorkerSupportsCancellation)
                bw.CancelAsync();
        }
    }
}
