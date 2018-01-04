using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFXIV_netBot.Module;

using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;

namespace FFXIV_netBot.Forms
{
    public partial class OpenWaypointForm : Form
    {
        private Controls.ImageButton closeButton;
        private String currentDirectory;

        private List<Waypoint> waypointList;

        private OpenWaypointDelegate openFinishedDelegate;

        public OpenWaypointForm(OpenWaypointDelegate openFinishedDelegate)
        {
            this.openFinishedDelegate = openFinishedDelegate;
            this.TopMost = true;
            InitializeComponent();

            this.currentDirectory = Path.GetDirectoryName(Application.ExecutablePath);

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

            this.waypointList = new List<Waypoint>();
            this.scanDirectoryForWaypointRoute();


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
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void scanDirectoryForWaypointRoute()
        {
            string[] wprs = Directory.GetFiles(this.currentDirectory, "*.wpr");
            if (wprs.Length > 0)
            {
                string[] fileName = new string[wprs.Length];
                for (int i = 0; i < wprs.Length; ++i)
                {
                    fileName[i] = Path.GetFileNameWithoutExtension(wprs[i]);
                }
                this.existFileSelector.DataSource = fileName;
                this.openButton.Enabled = true;
                this.existFileSelector.Enabled = true;
            }
            else
            {
                this.existFileSelector.DataSource = wprs;
                this.openButton.Enabled = false;
                this.existFileSelector.Enabled = false;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Waypoint fromBytes(byte[] arr)
        {
            Waypoint str = new Waypoint();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (Waypoint)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        private void OpenWaypointForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            bool successSave = false;
            bool invalidData = false;
            long fileSize = 0;
            String fileName = (string)this.existFileSelector.SelectedItem;

            if (fileName != null && fileName.Length > 0)
            {
                try
                {
                    string regexSearch = new string(Path.GetInvalidPathChars());
                    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                    String validFileName = r.Replace(fileName, "");

                    String fullPath = Path.Combine(this.currentDirectory, validFileName);
                    fullPath = Path.ChangeExtension(fullPath, "wpr");

                    if (File.Exists(fullPath))
                    {
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                        {
                            using (BinaryReader binReader = new BinaryReader(fs))
                            {
                                this.waypointList.Clear();
                                int waypointSize = Marshal.SizeOf(new Waypoint());
                                fileSize = binReader.BaseStream.Length;
                                if (fileSize > 0 && fileSize % waypointSize == 0)
                                {
                                    double amount = fileSize / waypointSize;
                                    int amountOfWayPoints = (int)Math.Ceiling(amount);

                                    for (int i = 0; i < amountOfWayPoints; ++i)
                                    {
                                        byte[] bytes = binReader.ReadBytes(waypointSize);
                                        waypointList.Add(this.fromBytes(bytes));
                                    }
                                }
                                else
                                {
                                    invalidData = true;
                                }
                                binReader.Close();
                            }
                            fs.Close();
                        }
                        successSave = true;
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
                this.openFinishedDelegate(waypointList.ToArray(), fileName);
                this.Dispose();
            }
            else
            {
                this.scanDirectoryForWaypointRoute();
            }
        }
    }
}
