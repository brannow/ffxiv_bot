using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Text;

using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;

using FFXIV_netBot.Module;
using FFXIV_netBot.Bot;

namespace FFXIV_netBot
{
    public delegate void ChangeSettingsFinished();
    public delegate void LoadConfigForm(SaveConfigHolder configHolder);

    public partial class FFXIV_netBot : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private FinalFantasyXIVMemory memory;

        private Boolean settingsLoaded = false;
        private Boolean rescanDirectory = false;
        private String defaultFileName = "settings.bst";

        private Controls.ImageButton closeButton;

        private CoreBot bot;

        public FFXIV_netBot()
        {
            this.settingsLoaded = this.loadFileTimings();
            InitializeComponent();
            this.loadConfigCombobox.Enabled = false;
            this.loadWaypointCombobox.Enabled = false;
            this.rescanDirectory = true;

            this.closeButton = new Controls.ImageButton();
            this.closeButton.Parent = this;
            this.closeButton.ForeColor = Color.Transparent;
            this.closeButton.BackgroundImage = global::FFXIV_netBot.Properties.Resources.closeBtn;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Location = new System.Drawing.Point(245, 11);
            this.closeButton.Name = "buttonClose";
            this.closeButton.Size = new System.Drawing.Size(19, 18);
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.Controls.Add(this.closeButton);

            if (this.settingsLoaded)
            {
                this.initBotHandler();
                this.MainDataCollector.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Activated(object sender, System.EventArgs e)
        {
            if (this.settingsLoaded && this.rescanDirectory && this.memory != null && this.memory.isUseable())
            {
                this.rescanDirectory = false;
                this.scanDirectoryForConfig();
                this.scanDirectoryForWaypoints();
            }
        }


        private void scanDirectoryForConfig()
        {
            string[] wprs = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath), "*.cfg");
            if (wprs.Length > 0)
            {
                string[] fileName = new string[wprs.Length + 1];
                fileName[0] = "";
                int selected = 0;
                string currentSelectedItem = (string)this.loadConfigCombobox.SelectedItem;
                for (int i = 0; i < wprs.Length; ++i)
                {
                    string tmpString = Path.GetFileNameWithoutExtension(wprs[i]);
                    fileName[i + 1] = tmpString;
                    if (tmpString == currentSelectedItem)
                    {
                        selected = i + 1;
                    }
                }
                this.loadConfigCombobox.DataSource = fileName;
                this.loadConfigCombobox.SelectedItem = fileName[selected];
                this.loadConfigCombobox.Enabled = true;
            }
            else
            {
                this.loadConfigCombobox.DataSource = wprs;
                this.loadConfigCombobox.Enabled = false;
            }
        }

        private void scanDirectoryForWaypoints()
        {
            string[] wprs = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath), "*.wpr");
            if (wprs.Length > 0)
            {
                string[] fileName = new string[wprs.Length + 1];
                fileName[0] = "";
                int selected = 0;
                string currentSelectedItem = (string)this.loadWaypointCombobox.SelectedItem;
                for (int i = 0; i < wprs.Length; ++i)
                {
                    string tmpString = Path.GetFileNameWithoutExtension(wprs[i]);
                    fileName[i + 1] = tmpString;
                    if (tmpString == currentSelectedItem)
                    {
                        selected = i + 1;
                    }
                }
                this.loadWaypointCombobox.DataSource = fileName;
                this.loadWaypointCombobox.SelectedItem = fileName[selected];
                this.loadWaypointCombobox.Enabled = true;
            }
            else
            {
                this.loadWaypointCombobox.DataSource = wprs;
                this.loadWaypointCombobox.Enabled = false;
            }
        }

        private bool loadFileTimings()
        {
            bool loadSave = false;
            bool invalidData = false;

            if (this.defaultFileName != null && this.defaultFileName.Length > 0)
            {
                try
                {
                    string regexSearch = new string(Path.GetInvalidPathChars());
                    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                    String validFileName = r.Replace(this.defaultFileName, "");

                    String fullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), validFileName);
                    fullPath = Path.ChangeExtension(fullPath, "bst");

                    if (File.Exists(fullPath))
                    {
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                        {
                            using (BinaryReader binReader = new BinaryReader(fs))
                            {
                                long fileSize = binReader.BaseStream.Length;
                                int timingSize = Marshal.SizeOf(new Timings());
                                if (fileSize == timingSize)
                                {


                                    byte[] readedBytes = binReader.ReadBytes(timingSize);
                                    SettingsSingleton.Instance.timings = this.timinsgFromBytes(readedBytes);
                                }
                                else
                                {
                                    invalidData = true;
                                }
                                binReader.Close();
                            }
                            fs.Close();
                        }
                        loadSave = true;
                    }
                    else
                    {
                        loadSave = false;
                    }
                }
                catch
                {
                    loadSave = false;
                    MessageBox.Show("Unknown Error\n\nabort loading", "Loading Error");
                }
            }
            if (invalidData)
            {
                loadSave = false;
                MessageBox.Show("corrupt file detected\nRestore Default Settings under Settings\n\nabort loading", "Loading Error");
            }
                
            return loadSave;
        }

        Timings timinsgFromBytes(byte[] arr)
        {
            Timings str = new Timings();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (Timings)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        private void initBotHandler()
        {
            if (this.settingsLoaded)
            {
                this.memory = new FinalFantasyXIVMemory();
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         Color.FromArgb(1, 86, 77, 52), 2, ButtonBorderStyle.Outset,
                                         Color.FromArgb(1, 86, 77, 52), 2, ButtonBorderStyle.Outset,
                                         Color.FromArgb(1, 86, 77, 52), 2, ButtonBorderStyle.Inset,
                                         Color.FromArgb(1, 86, 77, 52), 2, ButtonBorderStyle.Inset);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.memory != null)
            {
                this.rescanDirectory = true;
                WaypointForm wpfrom = new WaypointForm(this, this.memory);
                wpfrom.Location = new Point(this.Location.X + 10, this.Location.Y + 40);
                wpfrom.ShowDialog();
            }
        }

        private void MainDataCollector_Tick(object sender, EventArgs e)
        {

            this.MainDataCollector.Stop();
            if (this.memory != null && this.memory.isUseable())
            {
                this.MainDataCollector.Interval = SettingsSingleton.Instance.timings.activeMainViewUpdate;
                String playerName = this.memory.playerName(); //"あなたの名前"; //
                UInt32 playerHP = (UInt32)this.memory.playerHP();
                UInt32 playerHPMax = (UInt32)this.memory.playerMaxHP();

                UInt32 playerMP = (UInt32)this.memory.playerMP();
                UInt32 playerMPMax = (UInt32)this.memory.playerMaxMP();

                UInt32 playerTP = (UInt32)this.memory.playerTP();
                UInt32 playerTPMax = (UInt32)this.memory.playerMaxTP();

                if (playerName.Length == 0)
                    playerName = "待ってください...";

                this.playerName.Text = playerName;
                this.hpBar.Maximum = (int)playerHPMax;
                this.hpBar.Value = (int)playerHP;

                this.mpBar.Maximum = (int)playerMPMax;
                this.mpBar.Value = (int)playerMP;

                this.tpBar.Maximum = (int)playerTPMax;
                this.tpBar.Value = (int)playerTP;
            }
            else
            {
                this.MainDataCollector.Interval = SettingsSingleton.Instance.timings.inactiveMainViewUpdate;
                this.playerName.Text = "---";
                this.hpBar.Maximum = 1;
                this.hpBar.Value = 0;
                this.mpBar.Maximum = 1;
                this.mpBar.Value = 0;
                this.tpBar.Maximum = 1;
                this.tpBar.Value = 0;
                this.memory.initConnection();
            }
            this.MainDataCollector.Start();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            this.rescanDirectory = true;
            Forms.SettingForm form = new Forms.SettingForm(this.changeSettingsFinished);
            form.Location = new Point(this.Location.X + 10, this.Location.Y + 40);
            form.ShowDialog();
        }

        private void changeSettingsFinished()
        {
            this.settingsLoaded = this.loadFileTimings();
            if (this.settingsLoaded)
            {
                this.initBotHandler();
                this.MainDataCollector.Start();
            }
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            if(this.settingsLoaded)
            {
                this.rescanDirectory = true;
                Forms.ConfigSelectFrom configForm = new Forms.ConfigSelectFrom(this.loadConfigForm);
                configForm.Location = new Point(this.Location.X + 10, this.Location.Y + 40);
                configForm.ShowDialog();
            }
        }

        private void loadConfigForm(SaveConfigHolder configHolder)
        {

            if (this.settingsLoaded && configHolder != null && configHolder.type != ConfigType.None)
            {
                this.rescanDirectory = true;
                if(configHolder.type == ConfigType.Combat)
                {
                    SaveConfigHolder holder = configHolder;
                    Forms.ConfigCombatForm form = new Forms.ConfigCombatForm(configHolder);
                    form.Location = new Point(this.Location.X + 10, this.Location.Y + 40);
                    form.ShowDialog();
                } 
                else if (configHolder.type == ConfigType.Gathering)
                {
                    SaveConfigHolder holder = configHolder;
                    Forms.ConfigGatheringForm form = new Forms.ConfigGatheringForm(configHolder);
                    form.Location = new Point(this.Location.X + 10, this.Location.Y + 40);
                    form.ShowDialog();
                }
                else if (configHolder.type == ConfigType.Fishing)
                {
                    SaveConfigHolder holder = configHolder;
                    Forms.ConfigFishingForm form = new Forms.ConfigFishingForm(configHolder);
                    form.Location = new Point(this.Location.X + 10, this.Location.Y + 40);
                    form.ShowDialog();
                }
            }
        }

        private void loadConfigCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String currentSelecteWaypointName = (string)this.loadWaypointCombobox.SelectedItem;
            String currentSelecteConfigName = (string)this.loadConfigCombobox.SelectedItem;
            this.startButton.Enabled = (currentSelecteWaypointName != null && currentSelecteWaypointName.Length > 0 && currentSelecteConfigName != null && currentSelecteConfigName.Length > 0);
        }

        private void loadWaypointCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String currentSelecteWaypointName = (string)this.loadWaypointCombobox.SelectedItem;
            String currentSelecteConfigName = (string)this.loadConfigCombobox.SelectedItem;
            this.startButton.Enabled = (currentSelecteWaypointName != null && currentSelecteWaypointName.Length > 0 && currentSelecteConfigName != null && currentSelecteConfigName.Length > 0);
        }

        private void entitiesButton_Click(object sender, EventArgs e)
        {
            if (this.settingsLoaded && this.memory != null && this.memory.isUseable())
            {
                this.rescanDirectory = true;
                Forms.EntityForm entityForm = new Forms.EntityForm(this.memory);
                entityForm.Location = new Point(this.Location.X + 10, this.Location.Y + 40);
                entityForm.Show();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(this.memory != null && this.memory.isUseable())
            {
                String currentSelecteWaypointName = (string)this.loadWaypointCombobox.SelectedItem;
                String currentSelecteConfigName = (string)this.loadConfigCombobox.SelectedItem;
                if (currentSelecteWaypointName != null && currentSelecteWaypointName.Length > 0 && currentSelecteConfigName != null && currentSelecteConfigName.Length > 0)
                {
                    if (this.bot == null)
                    {
                        this.bot = BotLoader.loadBotModule(currentSelecteConfigName, currentSelecteWaypointName);
                        if (this.bot != null)
                        {
                            SetForegroundWindow(this.memory.processMainWindowHandle());
                            this.bot.setCoreObjects(this.memory);
                            this.bot.run();
                        }
                    }
                    else
                    {
                        this.bot.stop();
                        this.bot = null;
                    }
                }
            }
        }
    }
}