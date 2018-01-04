namespace FFXIV_netBot
{
    partial class FFXIV_netBot
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFXIV_netBot));
            this.configButton = new System.Windows.Forms.Button();
            this.waypointButton = new System.Windows.Forms.Button();
            this.entitiesButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hpBar = new System.Windows.Forms.ProgressBar();
            this.playerName = new System.Windows.Forms.Label();
            this.MainDataCollector = new System.Windows.Forms.Timer(this.components);
            this.mpBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tpBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.loadConfigCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.loadWaypointCombobox = new System.Windows.Forms.ComboBox();
            this.settingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // configButton
            // 
            this.configButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configButton.Location = new System.Drawing.Point(11, 400);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(131, 41);
            this.configButton.TabIndex = 13;
            this.configButton.Text = "Config";
            this.configButton.UseVisualStyleBackColor = true;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // waypointButton
            // 
            this.waypointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waypointButton.Location = new System.Drawing.Point(11, 447);
            this.waypointButton.Name = "waypointButton";
            this.waypointButton.Size = new System.Drawing.Size(131, 41);
            this.waypointButton.TabIndex = 14;
            this.waypointButton.Text = "Waypoint";
            this.waypointButton.UseVisualStyleBackColor = true;
            this.waypointButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // entitiesButton
            // 
            this.entitiesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.entitiesButton.Location = new System.Drawing.Point(12, 306);
            this.entitiesButton.Name = "entitiesButton";
            this.entitiesButton.Size = new System.Drawing.Size(131, 41);
            this.entitiesButton.TabIndex = 15;
            this.entitiesButton.Text = "Entites";
            this.entitiesButton.UseVisualStyleBackColor = true;
            this.entitiesButton.Click += new System.EventHandler(this.entitiesButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.Location = new System.Drawing.Point(11, 493);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(131, 41);
            this.startButton.TabIndex = 17;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Enabled = false;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(144, 333);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(10, 10);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(129, 23);
            this.title.TabIndex = 19;
            this.title.Text = "Tenryuu  (天龍)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(56, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "HP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hpBar
            // 
            this.hpBar.Enabled = false;
            this.hpBar.ForeColor = System.Drawing.Color.Red;
            this.hpBar.Location = new System.Drawing.Point(86, 80);
            this.hpBar.MarqueeAnimationSpeed = 0;
            this.hpBar.Name = "hpBar";
            this.hpBar.Size = new System.Drawing.Size(164, 10);
            this.hpBar.Step = 1;
            this.hpBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.hpBar.TabIndex = 21;
            // 
            // playerName
            // 
            this.playerName.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerName.ForeColor = System.Drawing.SystemColors.Control;
            this.playerName.Location = new System.Drawing.Point(6, 44);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(263, 32);
            this.playerName.TabIndex = 23;
            this.playerName.Text = "---";
            this.playerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainDataCollector
            // 
            this.MainDataCollector.Interval = 800;
            this.MainDataCollector.Tick += new System.EventHandler(this.MainDataCollector_Tick);
            // 
            // mpBar
            // 
            this.mpBar.Enabled = false;
            this.mpBar.ForeColor = System.Drawing.Color.Red;
            this.mpBar.Location = new System.Drawing.Point(86, 99);
            this.mpBar.MarqueeAnimationSpeed = 0;
            this.mpBar.Name = "mpBar";
            this.mpBar.Size = new System.Drawing.Size(164, 10);
            this.mpBar.Step = 1;
            this.mpBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.mpBar.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(54, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "MP:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpBar
            // 
            this.tpBar.Enabled = false;
            this.tpBar.ForeColor = System.Drawing.Color.Red;
            this.tpBar.Location = new System.Drawing.Point(86, 118);
            this.tpBar.MarqueeAnimationSpeed = 0;
            this.tpBar.Name = "tpBar";
            this.tpBar.Size = new System.Drawing.Size(164, 10);
            this.tpBar.Step = 1;
            this.tpBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.tpBar.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(57, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "TP:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loadConfigCombobox
            // 
            this.loadConfigCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loadConfigCombobox.FormattingEnabled = true;
            this.loadConfigCombobox.Location = new System.Drawing.Point(86, 178);
            this.loadConfigCombobox.Name = "loadConfigCombobox";
            this.loadConfigCombobox.Size = new System.Drawing.Size(164, 21);
            this.loadConfigCombobox.TabIndex = 28;
            this.loadConfigCombobox.SelectedIndexChanged += new System.EventHandler(this.loadConfigCombobox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(34, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Config:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(38, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Route:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loadWaypointCombobox
            // 
            this.loadWaypointCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loadWaypointCombobox.FormattingEnabled = true;
            this.loadWaypointCombobox.Location = new System.Drawing.Point(86, 205);
            this.loadWaypointCombobox.Name = "loadWaypointCombobox";
            this.loadWaypointCombobox.Size = new System.Drawing.Size(164, 21);
            this.loadWaypointCombobox.TabIndex = 30;
            this.loadWaypointCombobox.SelectedIndexChanged += new System.EventHandler(this.loadWaypointCombobox_SelectedIndexChanged);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(11, 353);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(131, 41);
            this.settingsButton.TabIndex = 15;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // FFXIV_netBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(275, 550);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loadWaypointCombobox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loadConfigCombobox);
            this.Controls.Add(this.tpBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mpBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.hpBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.entitiesButton);
            this.Controls.Add(this.waypointButton);
            this.Controls.Add(this.configButton);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(275, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(275, 550);
            this.Name = "FFXIV_netBot";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.Button waypointButton;
        private System.Windows.Forms.Button entitiesButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar hpBar;
        private System.Windows.Forms.Label playerName;
        private System.Windows.Forms.Timer MainDataCollector;
        private System.Windows.Forms.ProgressBar mpBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar tpBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox loadConfigCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox loadWaypointCombobox;
        private System.Windows.Forms.Button settingsButton;

    }
}

