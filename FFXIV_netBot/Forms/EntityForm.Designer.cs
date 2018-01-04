namespace FFXIV_netBot.Forms
{
    partial class EntityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.entityListView = new System.Windows.Forms.ListView();
            this.uniqueId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.visibleStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.interactionId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.x = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.z = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.r = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.distance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Entity List";
            // 
            // entityListView
            // 
            this.entityListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entityListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.entityListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uniqueId,
            this.name,
            this.visibleStatus,
            this.typeId,
            this.interactionId,
            this.x,
            this.y,
            this.z,
            this.r,
            this.distance});
            this.entityListView.FullRowSelect = true;
            this.entityListView.Location = new System.Drawing.Point(12, 78);
            this.entityListView.MultiSelect = false;
            this.entityListView.Name = "entityListView";
            this.entityListView.Size = new System.Drawing.Size(746, 310);
            this.entityListView.TabIndex = 2;
            this.entityListView.UseCompatibleStateImageBehavior = false;
            this.entityListView.View = System.Windows.Forms.View.Details;
            // 
            // uniqueId
            // 
            this.uniqueId.Text = "uID";
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 140;
            // 
            // visibleStatus
            // 
            this.visibleStatus.Text = "Visible";
            // 
            // typeId
            // 
            this.typeId.Text = "Type";
            // 
            // interactionId
            // 
            this.interactionId.Text = "interactId";
            // 
            // x
            // 
            this.x.Text = "X";
            this.x.Width = 65;
            // 
            // y
            // 
            this.y.Text = "Y";
            this.y.Width = 65;
            // 
            // z
            // 
            this.z.Text = "Z";
            this.z.Width = 65;
            // 
            // r
            // 
            this.r.Text = "Rotation";
            this.r.Width = 65;
            // 
            // distance
            // 
            this.distance.Text = "Distance";
            this.distance.Width = 70;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(12, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Count:";
            // 
            // countLabel
            // 
            this.countLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.countLabel.Location = new System.Drawing.Point(61, 58);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(15, 17);
            this.countLabel.TabIndex = 17;
            this.countLabel.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(667, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(91, 21);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "autoUpdate";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listUpdateTimer
            // 
            this.listUpdateTimer.Enabled = true;
            this.listUpdateTimer.Interval = 500;
            this.listUpdateTimer.Tick += new System.EventHandler(this.listUpdateTimer_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(655, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "15 nearest shown";
            // 
            // EntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(770, 400);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.entityListView);
            this.Controls.Add(this.label7);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(770, 400);
            this.Name = "EntityForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.EntityForm_Activated);
            this.Deactivate += new System.EventHandler(this.EntityForm_Deactivated);
            this.Load += new System.EventHandler(this.EntityForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView entityListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader x;
        private System.Windows.Forms.ColumnHeader y;
        private System.Windows.Forms.ColumnHeader z;
        private System.Windows.Forms.ColumnHeader r;
        private System.Windows.Forms.ColumnHeader distance;
        private System.Windows.Forms.ColumnHeader uniqueId;
        private System.Windows.Forms.ColumnHeader visibleStatus;
        private System.Windows.Forms.ColumnHeader typeId;
        private System.Windows.Forms.ColumnHeader interactionId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer listUpdateTimer;
        private System.Windows.Forms.Label label1;
    }
}