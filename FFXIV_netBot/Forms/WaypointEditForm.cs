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

namespace FFXIV_netBot.Forms
{
    public partial class WaypointEditForm : Form
    {

        private Controls.ImageButton closeButton;
        private Waypoint waypoint;

        private EditWaypointDelegate callback;

        public WaypointEditForm(Waypoint wp, EditWaypointDelegate changeCallback)
        {
            this.callback = changeCallback;
            this.TopMost = true;
            InitializeComponent();
            this.typeComboBox.DataSource = Enum.GetValues(typeof(WaypointType));
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
            this.initWithWaypoint(wp);
        }

        private void initWithWaypoint(Waypoint wp)
        {
            this.waypoint = wp;
            this.indexTextField.Text = wp.id.ToString();
            this.posXTextField.Text = wp.position.x.ToString();
            this.posYTextField.Text = wp.position.y.ToString();
            this.posZTextField.Text = wp.position.z.ToString();
            this.rotationTextField.Text = wp.position.r.ToString();

            this.typeComboBox.SelectedItem = (WaypointType)wp.type;
            this.rangeTextField.Text = wp.range.ToString();
            if (wp.type == WaypointType.Gathering)
            {
                this.rangeTextField.Enabled = true;
            } 
            else
            {
                this.rangeTextField.Enabled = false;
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
        }

        private void WaypointEditForm_Load(object sender, EventArgs e)
        {

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            PlayerPosition pos = new PlayerPosition();
            pos.x = Convert.ToSingle(this.posXTextField.Text);
            pos.y = Convert.ToSingle(this.posYTextField.Text);
            pos.z = Convert.ToSingle(this.posZTextField.Text);
            pos.r = Convert.ToSingle(this.rotationTextField.Text);
            Waypoint newWp = new Waypoint();
            newWp.id = Convert.ToUInt32(this.indexTextField.Text);
            newWp.position = pos;
            newWp.range = Convert.ToSingle(this.rangeTextField.Text);
            newWp.type = (WaypointType)this.typeComboBox.SelectedItem;
            
            this.callback(this.waypoint, newWp);

            this.Close();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WaypointType wpt = (WaypointType)this.typeComboBox.SelectedItem;
            if (wpt == WaypointType.Gathering)
            {
                this.rangeTextField.Enabled = true;
            }
            else
            {
                this.rangeTextField.Enabled = false;
            }
        }
    }
}
