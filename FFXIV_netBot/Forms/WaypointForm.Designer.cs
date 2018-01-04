namespace FFXIV_netBot
{
    partial class WaypointForm
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
            this.waypointListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.x = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.z = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.r = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.range = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ListContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ListContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xlabel = new System.Windows.Forms.Label();
            this.ylabel = new System.Windows.Forms.Label();
            this.zlabel = new System.Windows.Forms.Label();
            this.rlabel = new System.Windows.Forms.Label();
            this.newRouteButton = new System.Windows.Forms.Button();
            this.awpDistanceLimitInputField = new System.Windows.Forms.TextBox();
            this.addDefaultWaypoint = new System.Windows.Forms.Button();
            this.awpStartButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveRouteButton = new System.Windows.Forms.Button();
            this.addFishingWaypoint = new System.Windows.Forms.Button();
            this.addGatheringWaypoint = new System.Windows.Forms.Button();
            this.positionTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.gatheringRangeInputField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.awpTimer = new System.Windows.Forms.Timer(this.components);
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.ListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // waypointListView
            // 
            this.waypointListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waypointListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.waypointListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.type,
            this.x,
            this.y,
            this.z,
            this.r,
            this.range});
            this.waypointListView.FullRowSelect = true;
            this.waypointListView.Location = new System.Drawing.Point(12, 147);
            this.waypointListView.MultiSelect = false;
            this.waypointListView.Name = "waypointListView";
            this.waypointListView.Size = new System.Drawing.Size(596, 241);
            this.waypointListView.TabIndex = 0;
            this.waypointListView.UseCompatibleStateImageBehavior = false;
            this.waypointListView.View = System.Windows.Forms.View.Details;
            this.waypointListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.waypointListView_mouseClick);
            this.waypointListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.waypointListView_mouseDoubleClick);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 50;
            // 
            // type
            // 
            this.type.Text = "Type";
            this.type.Width = 70;
            // 
            // x
            // 
            this.x.Text = "X";
            this.x.Width = 80;
            // 
            // y
            // 
            this.y.Text = "Y";
            this.y.Width = 80;
            // 
            // z
            // 
            this.z.Text = "Z";
            this.z.Width = 80;
            // 
            // r
            // 
            this.r.Text = "Rotation";
            this.r.Width = 80;
            // 
            // range
            // 
            this.range.Text = "Range";
            this.range.Width = 80;
            // 
            // ListContextMenu
            // 
            this.ListContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListContextMenuEdit,
            this.ListContextMenuDelete});
            this.ListContextMenu.Name = "contextMenuStrip1";
            this.ListContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ListContextMenu.ShowImageMargin = false;
            this.ListContextMenu.Size = new System.Drawing.Size(83, 48);
            // 
            // ListContextMenuEdit
            // 
            this.ListContextMenuEdit.ForeColor = System.Drawing.SystemColors.Control;
            this.ListContextMenuEdit.Name = "ListContextMenuEdit";
            this.ListContextMenuEdit.Size = new System.Drawing.Size(82, 22);
            this.ListContextMenuEdit.Text = "Edit";
            this.ListContextMenuEdit.Click += new System.EventHandler(this.ListContextMenuEdit_Click);
            // 
            // ListContextMenuDelete
            // 
            this.ListContextMenuDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ListContextMenuDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.ListContextMenuDelete.Name = "ListContextMenuDelete";
            this.ListContextMenuDelete.Size = new System.Drawing.Size(82, 22);
            this.ListContextMenuDelete.Text = "Delete";
            this.ListContextMenuDelete.Click += new System.EventHandler(this.ListContextMenuDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(148, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(289, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(427, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "R:";
            // 
            // xlabel
            // 
            this.xlabel.AutoSize = true;
            this.xlabel.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xlabel.ForeColor = System.Drawing.SystemColors.Control;
            this.xlabel.Location = new System.Drawing.Point(35, 130);
            this.xlabel.Name = "xlabel";
            this.xlabel.Size = new System.Drawing.Size(20, 17);
            this.xlabel.TabIndex = 5;
            this.xlabel.Text = "---";
            // 
            // ylabel
            // 
            this.ylabel.AutoSize = true;
            this.ylabel.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ylabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ylabel.Location = new System.Drawing.Point(170, 130);
            this.ylabel.Name = "ylabel";
            this.ylabel.Size = new System.Drawing.Size(20, 17);
            this.ylabel.TabIndex = 5;
            this.ylabel.Text = "---";
            // 
            // zlabel
            // 
            this.zlabel.AutoSize = true;
            this.zlabel.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zlabel.ForeColor = System.Drawing.SystemColors.Control;
            this.zlabel.Location = new System.Drawing.Point(311, 130);
            this.zlabel.Name = "zlabel";
            this.zlabel.Size = new System.Drawing.Size(20, 17);
            this.zlabel.TabIndex = 5;
            this.zlabel.Text = "---";
            // 
            // rlabel
            // 
            this.rlabel.AutoSize = true;
            this.rlabel.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlabel.ForeColor = System.Drawing.SystemColors.Control;
            this.rlabel.Location = new System.Drawing.Point(451, 130);
            this.rlabel.Name = "rlabel";
            this.rlabel.Size = new System.Drawing.Size(20, 17);
            this.rlabel.TabIndex = 5;
            this.rlabel.Text = "---";
            // 
            // newRouteButton
            // 
            this.newRouteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newRouteButton.Location = new System.Drawing.Point(178, 45);
            this.newRouteButton.Name = "newRouteButton";
            this.newRouteButton.Size = new System.Drawing.Size(75, 23);
            this.newRouteButton.TabIndex = 6;
            this.newRouteButton.Text = "New Route";
            this.newRouteButton.UseVisualStyleBackColor = true;
            this.newRouteButton.Click += new System.EventHandler(this.newRouteButton_Click);
            // 
            // awpDistanceLimitInputField
            // 
            this.awpDistanceLimitInputField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.awpDistanceLimitInputField.Location = new System.Drawing.Point(557, 73);
            this.awpDistanceLimitInputField.MaxLength = 5;
            this.awpDistanceLimitInputField.Name = "awpDistanceLimitInputField";
            this.awpDistanceLimitInputField.Size = new System.Drawing.Size(51, 20);
            this.awpDistanceLimitInputField.TabIndex = 7;
            this.awpDistanceLimitInputField.Text = "6";
            this.awpDistanceLimitInputField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.awpDistanceLimitInputField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.awpDistanceLimitInputField_KeyPress);
            // 
            // addDefaultWaypoint
            // 
            this.addDefaultWaypoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addDefaultWaypoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addDefaultWaypoint.Location = new System.Drawing.Point(16, 99);
            this.addDefaultWaypoint.Name = "addDefaultWaypoint";
            this.addDefaultWaypoint.Size = new System.Drawing.Size(135, 23);
            this.addDefaultWaypoint.TabIndex = 8;
            this.addDefaultWaypoint.Text = "add Default Waypoint";
            this.addDefaultWaypoint.UseVisualStyleBackColor = true;
            this.addDefaultWaypoint.Click += new System.EventHandler(this.addDefaultWaypoint_Click);
            // 
            // awpStartButton
            // 
            this.awpStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.awpStartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.awpStartButton.Location = new System.Drawing.Point(454, 99);
            this.awpStartButton.Name = "awpStartButton";
            this.awpStartButton.Size = new System.Drawing.Size(154, 23);
            this.awpStartButton.TabIndex = 9;
            this.awpStartButton.Text = "Start AutoWaypoint (awp)";
            this.awpStartButton.UseVisualStyleBackColor = true;
            this.awpStartButton.Click += new System.EventHandler(this.awpStartButton_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(373, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "distance to last waypoint (awp)";
            // 
            // loadButton
            // 
            this.loadButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadButton.Location = new System.Drawing.Point(16, 45);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 11;
            this.loadButton.Text = "Load Route";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveRouteButton
            // 
            this.saveRouteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveRouteButton.Location = new System.Drawing.Point(97, 45);
            this.saveRouteButton.Name = "saveRouteButton";
            this.saveRouteButton.Size = new System.Drawing.Size(75, 23);
            this.saveRouteButton.TabIndex = 12;
            this.saveRouteButton.Text = "Save Route";
            this.saveRouteButton.UseVisualStyleBackColor = true;
            this.saveRouteButton.Click += new System.EventHandler(this.saveRouteButton_Click);
            // 
            // addFishingWaypoint
            // 
            this.addFishingWaypoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFishingWaypoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addFishingWaypoint.Location = new System.Drawing.Point(298, 99);
            this.addFishingWaypoint.Name = "addFishingWaypoint";
            this.addFishingWaypoint.Size = new System.Drawing.Size(135, 23);
            this.addFishingWaypoint.TabIndex = 13;
            this.addFishingWaypoint.Text = "add Fishing Waypoint";
            this.addFishingWaypoint.UseVisualStyleBackColor = true;
            this.addFishingWaypoint.Click += new System.EventHandler(this.addFishingWaypoint_Click);
            // 
            // addGatheringWaypoint
            // 
            this.addGatheringWaypoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addGatheringWaypoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addGatheringWaypoint.Location = new System.Drawing.Point(157, 99);
            this.addGatheringWaypoint.Name = "addGatheringWaypoint";
            this.addGatheringWaypoint.Size = new System.Drawing.Size(135, 23);
            this.addGatheringWaypoint.TabIndex = 14;
            this.addGatheringWaypoint.Text = "add Gathering Waypoint";
            this.addGatheringWaypoint.UseVisualStyleBackColor = true;
            this.addGatheringWaypoint.Click += new System.EventHandler(this.addGatheringWaypoint_Click);
            // 
            // positionTimer
            // 
            this.positionTimer.Enabled = true;
            this.positionTimer.Interval = 1000;
            this.positionTimer.Tick += new System.EventHandler(this.positionTimer_Tick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(435, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "range for gathering";
            // 
            // gatheringRangeInputField
            // 
            this.gatheringRangeInputField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gatheringRangeInputField.Location = new System.Drawing.Point(557, 47);
            this.gatheringRangeInputField.MaxLength = 5;
            this.gatheringRangeInputField.Name = "gatheringRangeInputField";
            this.gatheringRangeInputField.Size = new System.Drawing.Size(51, 20);
            this.gatheringRangeInputField.TabIndex = 15;
            this.gatheringRangeInputField.Text = "12";
            this.gatheringRangeInputField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gatheringRangeInputField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.awpDistanceLimitInputField_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Waypoint Route - Setup";
            // 
            // awpTimer
            // 
            this.awpTimer.Interval = 300;
            this.awpTimer.Tick += new System.EventHandler(this.awp_Tick);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.CausesValidation = false;
            this.fileNameLabel.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Location = new System.Drawing.Point(208, 12);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(45, 20);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "name";
            // 
            // WaypointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(620, 400);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gatheringRangeInputField);
            this.Controls.Add(this.addGatheringWaypoint);
            this.Controls.Add(this.addFishingWaypoint);
            this.Controls.Add(this.saveRouteButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.awpStartButton);
            this.Controls.Add(this.addDefaultWaypoint);
            this.Controls.Add(this.awpDistanceLimitInputField);
            this.Controls.Add(this.newRouteButton);
            this.Controls.Add(this.rlabel);
            this.Controls.Add(this.zlabel);
            this.Controls.Add(this.ylabel);
            this.Controls.Add(this.xlabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.waypointListView);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 400);
            this.Name = "WaypointForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.WaypointForm_Activated);
            this.Deactivate += new System.EventHandler(this.WaypointForm_Deactivated);
            this.Load += new System.EventHandler(this.WaypointForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView waypointListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label xlabel;
        private System.Windows.Forms.Label ylabel;
        private System.Windows.Forms.Label zlabel;
        private System.Windows.Forms.Label rlabel;
        private System.Windows.Forms.Button newRouteButton;
        private System.Windows.Forms.TextBox awpDistanceLimitInputField;
        private System.Windows.Forms.Button addDefaultWaypoint;
        private System.Windows.Forms.Button awpStartButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveRouteButton;
        private System.Windows.Forms.Button addFishingWaypoint;
        private System.Windows.Forms.Button addGatheringWaypoint;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader x;
        private System.Windows.Forms.ColumnHeader y;
        private System.Windows.Forms.ColumnHeader z;
        private System.Windows.Forms.ColumnHeader r;
        private System.Windows.Forms.Timer positionTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox gatheringRangeInputField;
        private System.Windows.Forms.ContextMenuStrip ListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ListContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ListContextMenuDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer awpTimer;
        private System.Windows.Forms.ColumnHeader range;
        private System.Windows.Forms.Label fileNameLabel;
    }
}