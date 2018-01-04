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

namespace FFXIV_netBot
{
    public delegate void EditWaypointDelegate(Waypoint orgWaypoint, Waypoint newWaypoint);
    public delegate void OpenWaypointDelegate(Waypoint[] waypointArray, String filename);
    public delegate void SaveWaypointDelegate(String fileName);

    public partial class WaypointForm : Form
    {
        private FFXIV_netBot mainForm;
        private FinalFantasyXIVMemory memory;

        private Controls.ImageButton closeButton;

        private List <Waypoint> waypointList;

        private Boolean exclusiveAlphaSkip = false;

        // awp
        private Boolean awpToggle = false;
        private Waypoint lastAwpWaypoint;

        public WaypointForm(FFXIV_netBot mainForm, FinalFantasyXIVMemory memory)
        {
            this.TopMost = true;
            InitializeComponent();
            this.closeButton = new Controls.ImageButton();
            this.closeButton.Parent = this;
            this.closeButton.ForeColor = Color.Transparent;
            this.closeButton.BackgroundImage = global::FFXIV_netBot.Properties.Resources.closeBtn;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Location = new System.Drawing.Point(590, 11);
            this.closeButton.Name = "button1";
            this.closeButton.Size = new System.Drawing.Size(19, 18);
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.exitPressed);
            this.Controls.Add(this.closeButton);

            this.mainForm = mainForm;
            this.memory = memory;
            this.fileNameLabel.Text = "";
            this.waypointList = new List<Waypoint>();
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

        private void WaypointForm_Load(object sender, EventArgs e)
        {

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
        
        private void WaypointForm_Activated(object sender, System.EventArgs e)
        {
            this.exclusiveAlphaSkip = false;
            this.Opacity = 1;
        }

        private void WaypointForm_Deactivated(object sender, System.EventArgs e)
        {
            if (!this.exclusiveAlphaSkip)
                this.Opacity = 0.5;
            this.exclusiveAlphaSkip = false;
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

        private void exitPressed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void waypointListView_mouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ListContextMenu.Show(listView, e.Location);
                }
            }
        }

        private void waypointListView_mouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                this.ListContextMenuEdit_Click(null, null);
            }
        }

        

        private void ListContextMenuDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.waypointListView.SelectedIndices;
            if (indexes.Count > 0 && indexes.Count < 2)
            {
                int index = indexes[0];
                if (index >= 0 && index < this.waypointList.Count)
                {
                    this.waypointList.RemoveAt(index);
                    this._rerenderList();
                    if (this.waypointListView.Items.Count > index)
                        this.waypointListView.EnsureVisible(index);
                }
            }
        }

        private void ListContextMenuEdit_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.waypointListView.SelectedIndices;

            if (indexes.Count > 0 && indexes.Count < 2)
            {
                int index = indexes[0];
                if (index >= 0 && index < this.waypointList.Count)
                {
                    this.awpTimer.Stop();
                    this.awpToggle = false;
                    this.awpStartButton.Text = "Start AutoWaypoint (awp)";

                    Waypoint wp = this.waypointList[index];
                    this.exclusiveAlphaSkip = true;
                    Forms.WaypointEditForm wpEditfrom = new Forms.WaypointEditForm(wp, this.editWaypointFinished);
                    wpEditfrom.ShowDialog();
                }
            }
        }

        public void editWaypointFinished(Waypoint orgWaypoint, Waypoint newWaypoint)
        {
            // validate id
            if (newWaypoint.id < 0 || newWaypoint.id >= this.waypointList.Count)
                newWaypoint.id = orgWaypoint.id;

            if(newWaypoint.id < this.waypointList.Count)
            {
                this.waypointList.RemoveAt((int)orgWaypoint.id);
                this.waypointList.Insert((int)newWaypoint.id, newWaypoint);
                for(int i = 0; i < this.waypointList.Count; ++i)
                {
                    Waypoint item = this.waypointList[i];
                    item.id = (uint)i;
                    this.waypointList[i] = item;
                }
                this._rerenderList();
                if (this.waypointListView.Items.Count > newWaypoint.id)
                    this.waypointListView.EnsureVisible((int)newWaypoint.id);
            }
        }

        private void awpDistanceLimitInputField_KeyPress(object sender, KeyPressEventArgs e)
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

        private void positionTimer_Tick(object sender, EventArgs e)
        {
            this.positionTimer.Stop();
            if (this.memory.isUseable())
            {
                this.positionTimer.Interval = SettingsSingleton.Instance.timings.activeWaypointViewUpdate;
                PlayerPosition p = this.memory.position();
                this.xlabel.Text = p.x.ToString();
                this.ylabel.Text = p.y.ToString();
                this.zlabel.Text = p.z.ToString();
                this.rlabel.Text = p.r.ToString();
            }
            else
            {
                this.awpTimer.Stop();
                this.awpToggle = false;
                this.awpStartButton.Text = "Start AutoWaypoint (awp)";

                this.positionTimer.Interval = SettingsSingleton.Instance.timings.inactiveWaypointViewUpdate;
                this.xlabel.Text = "---";
                this.ylabel.Text = "---";
                this.zlabel.Text = "---";
                this.rlabel.Text = "---";
                this.memory.initConnection();
            }
            this.positionTimer.Start();
        }

        private void _rerenderList()
        {
            this.waypointListView.Items.Clear();

            for (int i = 0; i < this.waypointList.Count; ++i)
            {
                Waypoint wp = this.waypointList[i];
                this.addWaypointToList(wp);
            }
        }

        private void addWaypointToList(Waypoint wp)
        {
            ListViewItem item = new ListViewItem(wp.id.ToString());
            item.SubItems.Add(wp.type.ToString());
            item.SubItems.Add(wp.position.x.ToString());
            item.SubItems.Add(wp.position.y.ToString());
            item.SubItems.Add(wp.position.z.ToString());
            item.SubItems.Add(wp.position.r.ToString());
            item.SubItems.Add(wp.range.ToString());
            item.ForeColor = Color.LightGray;
            this.waypointListView.Items.Add(item);
            this.waypointListView.EnsureVisible(this.waypointListView.Items.Count - 1);
        }

        private void addWaypointByType(WaypointType type)
        {
            if (this.memory.isUseable())
            {
                PlayerPosition p = this.memory.position();
                Waypoint wp = new Waypoint();

                wp.position = p;
                wp.type = type;
                wp.id = (uint)this.waypointList.Count;

                Single range = Convert.ToSingle(gatheringRangeInputField.Text);

                if (type == WaypointType.Gathering && range >= 1)
                    wp.range = range;
                else
                    wp.range = 0;

                if (type == WaypointType.Default)
                    this.lastAwpWaypoint = wp;
                this.waypointList.Add(wp);
                this.addWaypointToList(wp);
            }
        }

        private void addDefaultWaypoint_Click(object sender, EventArgs e)
        {
            this.addWaypointByType(WaypointType.Default);
        }

        private void addGatheringWaypoint_Click(object sender, EventArgs e)
        {
            this.addWaypointByType(WaypointType.Gathering);
        }

        private void addFishingWaypoint_Click(object sender, EventArgs e)
        {
            this.addWaypointByType(WaypointType.Fishing);
        }

        private void awpStartButton_Click(object sender, EventArgs e)
        {
            if (this.memory.isUseable())
            {
                this.awpToggle = !this.awpToggle;
                Button btn = sender as Button;
                if (this.awpToggle)
                {
                    if (this.waypointList.Count > 0)
                    {
                        this.lastAwpWaypoint = this.waypointList[this.waypointList.Count - 1];
                    }
                    else
                    {
                        this.addWaypointByType(WaypointType.Default);
                    }
                    this.awpTimer.Start();
                    btn.Text = "Stop AutoWaypoint (awp)";
                }
                else
                {
                    this.awpTimer.Stop();
                    btn.Text = "Start AutoWaypoint (awp)";
                }
            }
        }

        private void awp_Tick(object sender, EventArgs e)
        {
            this.awpTimer.Stop();

            this.addAutoWayPoint();

            this.awpTimer.Start();
        }

        private void addAutoWayPoint()
        {
            if (this.memory.isUseable())
            {
                PlayerPosition p = this.memory.position();

                if(p.distanceBetweenPosition(this.lastAwpWaypoint.position) > 6)
                {
                    this.addWaypointByType(WaypointType.Default);
                }
            }
        }

        private void newRouteButton_Click(object sender, EventArgs e)
        {
            this.awpTimer.Stop();
            this.awpToggle = false;
            this.awpStartButton.Text = "Start AutoWaypoint (awp)";
            this.waypointList.Clear();
            this._rerenderList();
            this.fileNameLabel.Text = "";
        }

        private void saveRouteButton_Click(object sender, EventArgs e)
        {
            this.awpTimer.Stop();
            this.awpToggle = false;
            this.awpStartButton.Text = "Start AutoWaypoint (awp)";

            this.exclusiveAlphaSkip = true;
            Forms.SaveWaypointForm saveForm = new Forms.SaveWaypointForm(this.waypointList, this.waypointFileSavingFinished, this.fileNameLabel.Text);
            saveForm.ShowDialog();
        }

        public void waypointFileSavingFinished(String fileName)
        {
            this.fileNameLabel.Text = fileName;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            this.awpTimer.Stop();
            this.awpToggle = false;
            this.awpStartButton.Text = "Start AutoWaypoint (awp)";

            this.exclusiveAlphaSkip = true;
            Forms.OpenWaypointForm openForm = new Forms.OpenWaypointForm(this.waypointFileOpeningFinished);
            openForm.ShowDialog();
        }

        public void waypointFileOpeningFinished(Waypoint[] waypointList, String fileName)
        {
            this.waypointList.Clear();
            this.waypointList.AddRange(waypointList);
            this._rerenderList();
            this.fileNameLabel.Text = fileName;
        }
    }
}
