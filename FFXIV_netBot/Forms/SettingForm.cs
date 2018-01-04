using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;

using FFXIV_netBot.Module;

namespace FFXIV_netBot.Forms
{
    public partial class SettingForm : Form
    {
        private String defaultFileName = "settings.bst";

        private Controls.ImageButton closeButton;

        private Timings currentTimings;
        private ChangeSettingsFinished saveDelegate;

        public SettingForm(ChangeSettingsFinished saveDelegate)
        {
            this.saveDelegate = saveDelegate;
            this.TopMost = true;
            InitializeComponent();
            this.closeButton = new Controls.ImageButton();
            this.closeButton.Parent = this;
            this.closeButton.ForeColor = Color.Transparent;
            this.closeButton.BackgroundImage = global::FFXIV_netBot.Properties.Resources.closeBtn;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Location = new System.Drawing.Point(420, 11);
            this.closeButton.Name = "buttonClose";
            this.closeButton.Size = new System.Drawing.Size(19, 18);
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.Controls.Add(this.closeButton);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (this.loadFileTimings())
            {
                this.renderTimings();
            }
            else
            {
                MessageBox.Show("settings file 'settings.bst' not found\nUse Restore Default and Save to create a new one", "Settings Warning");
            }
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

        byte[] getBytesFromTimings(Timings str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
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
                                    this.currentTimings = this.timinsgFromBytes(readedBytes);
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
                MessageBox.Show("corrupt file detected\n\nabort loading", "Loading Error");

            return loadSave;
        }

        private void renderTimings()
        {
            this.activeMainViewUpdateTextbox.Text = this.currentTimings.activeMainViewUpdate.ToString();
            this.inactiveMainViewUpdateTextbox.Text = this.currentTimings.inactiveMainViewUpdate.ToString();
            this.activeWaypointViewUpdateTextbox.Text = this.currentTimings.activeWaypointViewUpdate.ToString();
            this.inactiveWaypointViewUpdateTextbox.Text = this.currentTimings.inactiveWaypointViewUpdate.ToString();

            this.randomKeyPressMinTextbox.Text = this.currentTimings.randomKeyPressMin.ToString();
            this.randomKeyPressMaxTextbox.Text = this.currentTimings.randomKeyPressMax.ToString();
            this.movementUpdateTickTextbox.Text = this.currentTimings.movementUpdateTick.ToString();
            this.movementRotationSleepUntilMemoryHackTextbox.Text = this.currentTimings.movementRotationSleepUntilMemoryHack.ToString();

            this.minMovementDistanceToNextWaypointTextbox.Text = this.currentTimings.minMovementDistanceToNextWaypoint.ToString();
            this.minRadianDifferanceToMoveTextbox.Text = this.currentTimings.minRadianDifferanceToMove.ToString();
            this.minRadianDifferanceToUseKeysTextbox.Text = this.currentTimings.minRadianDifferanceToUseKeys.ToString();
            this.minRadianDifferanceToUseMemoryHackTextbox.Text = this.currentTimings.minRadianDifferanceToUseMemoryHack.ToString();
        }

        private void updateTimings()
        {
            this.currentTimings.activeMainViewUpdate = Convert.ToInt32(this.activeMainViewUpdateTextbox.Text);
            this.currentTimings.inactiveMainViewUpdate = Convert.ToInt32(this.inactiveMainViewUpdateTextbox.Text);
            this.currentTimings.activeWaypointViewUpdate = Convert.ToInt32(this.activeWaypointViewUpdateTextbox.Text);
            this.currentTimings.inactiveWaypointViewUpdate = Convert.ToInt32(this.inactiveWaypointViewUpdateTextbox.Text);

            this.currentTimings.randomKeyPressMin = Convert.ToInt32(this.randomKeyPressMinTextbox.Text);
            this.currentTimings.randomKeyPressMax = Convert.ToInt32(this.randomKeyPressMaxTextbox.Text);
            this.currentTimings.movementUpdateTick = Convert.ToInt32(this.movementUpdateTickTextbox.Text);
            this.currentTimings.movementRotationSleepUntilMemoryHack = Convert.ToInt32(this.movementRotationSleepUntilMemoryHackTextbox.Text);

            this.currentTimings.minMovementDistanceToNextWaypoint = Convert.ToDouble(this.minMovementDistanceToNextWaypointTextbox.Text);
            this.currentTimings.minRadianDifferanceToMove = Convert.ToDouble(this.minRadianDifferanceToMoveTextbox.Text);
            this.currentTimings.minRadianDifferanceToUseKeys = Convert.ToDouble(this.minRadianDifferanceToUseKeysTextbox.Text);
            this.currentTimings.minRadianDifferanceToUseMemoryHack = Convert.ToDouble(this.minRadianDifferanceToUseMemoryHackTextbox.Text);
            
            // reflect new values
            this.renderTimings();
        }

        private void numOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1) ||
                (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1) ||
                (e.KeyChar == '-'
                && (sender as TextBox).Text.IndexOf('-') == 0))
            {
                e.Handled = true;
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.saveDelegate();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void restoreDefaultButton_Click(object sender, EventArgs e)
        {
            Timings defaultTimings = RestoreTimingDefault.defaultTimings();
            this.currentTimings = defaultTimings;
            this.renderTimings();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool successSave = false;
            this.updateTimings();

            if (this.defaultFileName != null && this.defaultFileName.Length > 0)
            {
                try
                {
                    string regexSearch = new string(Path.GetInvalidPathChars());
                    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                    this.defaultFileName = r.Replace(this.defaultFileName, "");

                    String fullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), this.defaultFileName);
                    fullPath = Path.ChangeExtension(fullPath, "bst");

                    using (FileStream fs = new FileStream(fullPath, FileMode.Create))
                    {
                        using (BinaryWriter binWriter = new BinaryWriter(fs))
                        {
                            byte[] itemByte = this.getBytesFromTimings(this.currentTimings);
                            binWriter.Write(itemByte);
                            binWriter.Close();
                        }
                        fs.Close();
                    }
                    successSave = true;
                }
                catch
                {
                    successSave = false;
                    MessageBox.Show("Unknown Error\n\nabort loading", "Loading Error");
                }

                if (successSave)
                {
                    //this.saveFinishDelegate(fileName);
                    this.Close();
                    this.saveDelegate();
                }
            }
        }
    }
}
