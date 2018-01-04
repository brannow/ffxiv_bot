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
using FFXIV_netBot.Controls;

namespace FFXIV_netBot.Forms
{
    public delegate void SaveConfigDelegate(String fileName);

    public partial class ConfigFishingForm : Form
    {
        private Controls.ImageButton closeButton;

        private SaveConfigHolder configHolder;

        public ConfigFishingForm(SaveConfigHolder configHolder)
        {

            this.TopMost = true;
            InitializeComponent();
            this.closeButton = new Controls.ImageButton();
            this.closeButton.Parent = this;
            this.closeButton.ForeColor = Color.Transparent;
            this.closeButton.BackgroundImage = global::FFXIV_netBot.Properties.Resources.closeBtn;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Location = new System.Drawing.Point(340, 11);
            this.closeButton.Name = "buttonClose";
            this.closeButton.Size = new System.Drawing.Size(19, 18);
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.Controls.Add(this.closeButton);

            /*
             
             */

            if(configHolder == null)
            {
                configHolder = new SaveConfigHolder();
            }

            if(configHolder.fileName.Length == 0)
            {
               configHolder.fishingConfig = RestoreConfigDefault.defaultFishingConfig();
            }

            configHolder.type = ConfigType.Fishing;
            this.fileNameLabel.Text = configHolder.fileName;
            this.renderFishingConfig(configHolder.fishingConfig);
            this.configHolder = configHolder;
        }

        private void renderFishingConfig(FishingConfig config)
        {
            this.biteDelayTextbox.Text = config.biteDelay.ToString();
            this.renderComboboxWithKeys(this.forwardComboBox, config.movement.forward);
            this.renderComboboxWithKeys(this.backwardComboBox, config.movement.backward);
            this.renderComboboxWithKeys(this.rotateLeftComboBox, config.movement.rotateLeft);
            this.renderComboboxWithKeys(this.rotateRightComboBox, config.movement.rotateRight);
            this.renderComboboxWithKeys(this.actionComboBox, config.movement.action);
            this.renderComboboxWithKeys(this.startFishingCombobox, config.fishing.startFishing);
            this.renderComboboxWithKeys(this.catchFishCombobox, config.fishing.catchFish);
        }

        private void renderComboboxWithKeys(ComboBox box, UseableKeys defaultKey) 
        {
            this.renderComboboxWithKeys(box);
            box.SelectedItem = (UseableKeys)defaultKey;
        }

        private void renderComboboxWithKeys(ComboBox box)
        {
            box.DataSource = Enum.GetValues(typeof(UseableKeys));
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
                this.Dispose();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ConfigFishingForm_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GeneralKeys generalKeys = new GeneralKeys();
            generalKeys.forward = (UseableKeys)this.forwardComboBox.SelectedItem;
            generalKeys.backward = (UseableKeys)this.backwardComboBox.SelectedItem;
            generalKeys.rotateLeft = (UseableKeys)this.rotateLeftComboBox.SelectedItem;
            generalKeys.rotateRight = (UseableKeys)this.rotateRightComboBox.SelectedItem;
            generalKeys.action = (UseableKeys)this.actionComboBox.SelectedItem;

            FishingKeys fishingKeys = new FishingKeys();
            fishingKeys.startFishing = (UseableKeys)this.startFishingCombobox.SelectedItem;
            fishingKeys.catchFish = (UseableKeys)this.catchFishCombobox.SelectedItem;

            FishingConfig fishingConfig = new FishingConfig();
            fishingConfig.movement = generalKeys;
            fishingConfig.fishing = fishingKeys;
            fishingConfig.biteDelay = int.Parse(this.biteDelayTextbox.Text);

            this.configHolder.fishingConfig = fishingConfig;

            SaveConfigForm form = new SaveConfigForm(this.configHolder, this.saveConfigFormFinished);
            form.ShowDialog();
        }

        public void saveConfigFormFinished(String fileName) 
        {
            this.configHolder.fileName = fileName;
            //this.fileNameLabel.Text = fileName;
            // insert here Delegate to main From
            this.Dispose();
        }
    }
}
