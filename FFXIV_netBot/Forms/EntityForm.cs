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
    public partial class EntityForm : Form
    {
        private FinalFantasyXIVMemory memory;
        private EntityList list;

        private Controls.ImageButton closeButton;

        private bool isClosed = false;

        public EntityForm(FinalFantasyXIVMemory memory)
        {
            this.memory = memory;
            this.TopMost = true;
            InitializeComponent();
            this.closeButton = new Controls.ImageButton();
            this.closeButton.Parent = this;
            this.closeButton.ForeColor = Color.Transparent;
            this.closeButton.BackgroundImage = global::FFXIV_netBot.Properties.Resources.closeBtn;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Location = new System.Drawing.Point(740, 11);
            this.closeButton.Name = "button1";
            this.closeButton.Size = new System.Drawing.Size(19, 18);
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.exitPressed);
            this.Controls.Add(this.closeButton);
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

        private void EntityForm_Activated(object sender, System.EventArgs e)
        {
            this.Opacity = 1;
        }

        private void EntityForm_Deactivated(object sender, System.EventArgs e)
        {
            if (!isClosed) {
                this.Opacity = 0.5;
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

        private void exitPressed(object sender, EventArgs e)
        {
            isClosed = true;
            this.Close();
        }

        private void EntityForm_Load(object sender, EventArgs e)
        {
            isClosed = false;
            this.list = new EntityList(this.memory);
        }

        private void updateListView()
        {
            this.list.update();
            int count = this.list.Count;
            this.countLabel.Text = count.ToString();

            this.entityListView.Items.Clear();

            for (int i = 0; i < count; ++i)
            {
                EntityItem eItem = this.list.itemAtIndex(i);
                if (eItem != null)
                {

                    ListViewItem item = new ListViewItem(eItem.uniqueId.ToString());
                    item.SubItems.Add(eItem.name);
                    item.SubItems.Add(eItem.visibleStatus.ToString());
                    item.SubItems.Add(eItem.typeId.ToString());
                    item.SubItems.Add(eItem.interacrtionId.ToString());

                    item.SubItems.Add(eItem.position.x.ToString());
                    item.SubItems.Add(eItem.position.y.ToString());
                    item.SubItems.Add(eItem.position.z.ToString());
                    item.SubItems.Add(eItem.position.r.ToString());
                    item.SubItems.Add(eItem.distance.ToString());

                    item.ForeColor = Color.LightGray;
                    this.entityListView.Items.Add(item);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
                this.listUpdateTimer.Start();
            else
            {
                this.listUpdateTimer.Stop();
                this.updateListView();
            }
        }

        private void listUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.listUpdateTimer.Stop();
            this.list.update();
            int count = this.list.Count;
            this.countLabel.Text = count.ToString();

            this.entityListView.Items.Clear();

            if (count > 15)
                count = 15;

            for (int i = 0; i < count; ++i)
            {
                EntityItem eItem = this.list.itemAtIndex(i);
                if (eItem != null)
                {

                    ListViewItem item = new ListViewItem(eItem.uniqueId.ToString());
                    item.SubItems.Add(eItem.name);
                    item.SubItems.Add(eItem.visibleStatus.ToString());
                    item.SubItems.Add(eItem.typeId.ToString());
                    item.SubItems.Add(eItem.interacrtionId.ToString());

                    item.SubItems.Add(eItem.position.x.ToString());
                    item.SubItems.Add(eItem.position.y.ToString());
                    item.SubItems.Add(eItem.position.z.ToString());
                    item.SubItems.Add(eItem.position.r.ToString());
                    item.SubItems.Add(eItem.distance.ToString());

                    item.ForeColor = Color.LightGray;
                    this.entityListView.Items.Add(item);
                }
            }
            if (this.checkBox1.Checked)
            {
                this.listUpdateTimer.Start();
            }
        }
    }
}
