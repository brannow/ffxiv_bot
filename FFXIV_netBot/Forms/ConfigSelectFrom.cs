using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using System.Runtime.InteropServices;


namespace FFXIV_netBot.Forms
{
    public partial class ConfigSelectFrom : Form
    {
        private Controls.ImageButton closeButton;
        private LoadConfigForm loadFormDelegate;

        private String currentDirectory;

        public ConfigSelectFrom(LoadConfigForm loadFormDelegate)
        {
            this.currentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            this.loadFormDelegate = loadFormDelegate;
            this.TopMost = true;
            InitializeComponent();
            this.closeButton = new Controls.ImageButton();
            this.closeButton.Parent = this;
            this.closeButton.ForeColor = Color.Transparent;
            this.closeButton.BackgroundImage = global::FFXIV_netBot.Properties.Resources.closeBtn;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Location = new System.Drawing.Point(220, 11);
            this.closeButton.Name = "buttonClose";
            this.closeButton.Size = new System.Drawing.Size(19, 18);
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.Controls.Add(this.closeButton);

            this.scanDirectoryForConfig();
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
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigSelectFrom_Load(object sender, EventArgs e)
        {

        }

        private void scanDirectoryForConfig()
        {
            string[] wprs = Directory.GetFiles(this.currentDirectory, "*.cfg");
            if (wprs.Length > 0)
            {
                string[] fileName = new string[wprs.Length + 1];
                fileName[0] = "";
                for (int i = 0; i < wprs.Length; ++i)
                {
                    fileName[i + 1] = Path.GetFileNameWithoutExtension(wprs[i]);
                }
                this.existFileSelector.DataSource = fileName;
                this.existFileSelector.Enabled = true;
            }
            else
            {
                this.existFileSelector.DataSource = wprs;
                this.existFileSelector.Enabled = false;
            }
        }

        private void newCombatButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Module.SaveConfigHolder configHolder = new Module.SaveConfigHolder();
            configHolder.type = Module.ConfigType.Combat;
            this.loadFormDelegate(configHolder);
        }

        private void newGatheringButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Module.SaveConfigHolder configHolder = new Module.SaveConfigHolder();
            configHolder.type = Module.ConfigType.Gathering;
            this.loadFormDelegate(configHolder);
        }

        private void newFishingButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Module.SaveConfigHolder configHolder = new Module.SaveConfigHolder();
            configHolder.type = Module.ConfigType.Fishing;
            this.loadFormDelegate(configHolder);
        }

        private void existFileSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            String fileName = (string)this.existFileSelector.SelectedItem;
            if (fileName != null && fileName.Length > 0)
            {
                this.loadConfigFile(fileName);
            }
        }

        private void loadConfigFile(String fileName)
        {
            bool successSave = false;
            bool invalidData = false;
            long fileSize = 0;
            Module.SaveConfigHolder configHolder = null;
            
            if (fileName != null && fileName.Length > 0)
            {
                try
                {
                    string regexSearch = new string(Path.GetInvalidPathChars());
                    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                    String validFileName = r.Replace(fileName, "");

                    String fullPath = Path.Combine(this.currentDirectory, validFileName);
                    fullPath = Path.ChangeExtension(fullPath, "cfg");

                    if (File.Exists(fullPath))
                    {
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                        {
                            using (BinaryReader binReader = new BinaryReader(fs))
                            {
                                byte[] bytes = binReader.ReadBytes((int)binReader.BaseStream.Length);
                                configHolder = new Module.SaveConfigHolder();
                                configHolder.parseBytes(bytes, true);
                                binReader.Close();
                                successSave = true;
                            }
                            fs.Close();
                        }
                    }
                    else
                    {
                        successSave = false;
                    }
                }
                catch
                {
                    successSave = false;
                    MessageBox.Show("Unknown Error\n\nabort loading", "Loading Error");
                }
            }

            if (invalidData)
            {
                if (fileSize > 0)
                    MessageBox.Show("corrupt file detected\n\nabort loading", "Loading Error");
                else
                    MessageBox.Show("empty detected\n\nabort loading", "Loading Error");
            }

            if (successSave && !invalidData)
            {
                this.Dispose();
                configHolder.fileName = fileName;
                this.loadFormDelegate(configHolder);
            }
            else
            {
                this.scanDirectoryForConfig();
            }
        }
    }
}
