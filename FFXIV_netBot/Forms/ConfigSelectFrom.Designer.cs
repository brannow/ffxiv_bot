namespace FFXIV_netBot.Forms
{
    partial class ConfigSelectFrom
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
            this.label7 = new System.Windows.Forms.Label();
            this.existFileSelector = new System.Windows.Forms.ComboBox();
            this.newFishingButton = new System.Windows.Forms.Button();
            this.newGatheringButton = new System.Windows.Forms.Button();
            this.newCombatButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Config - Select";
            // 
            // existFileSelector
            // 
            this.existFileSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.existFileSelector.FormattingEnabled = true;
            this.existFileSelector.Location = new System.Drawing.Point(12, 208);
            this.existFileSelector.Name = "existFileSelector";
            this.existFileSelector.Size = new System.Drawing.Size(226, 21);
            this.existFileSelector.TabIndex = 11;
            this.existFileSelector.SelectedIndexChanged += new System.EventHandler(this.existFileSelector_SelectedIndexChanged);
            // 
            // newFishingButton
            // 
            this.newFishingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newFishingButton.Location = new System.Drawing.Point(12, 140);
            this.newFishingButton.Name = "newFishingButton";
            this.newFishingButton.Size = new System.Drawing.Size(226, 28);
            this.newFishingButton.TabIndex = 12;
            this.newFishingButton.Text = "Fishing";
            this.newFishingButton.UseVisualStyleBackColor = true;
            this.newFishingButton.Click += new System.EventHandler(this.newFishingButton_Click);
            // 
            // newGatheringButton
            // 
            this.newGatheringButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newGatheringButton.Location = new System.Drawing.Point(12, 106);
            this.newGatheringButton.Name = "newGatheringButton";
            this.newGatheringButton.Size = new System.Drawing.Size(226, 28);
            this.newGatheringButton.TabIndex = 12;
            this.newGatheringButton.Text = "Gathering";
            this.newGatheringButton.UseVisualStyleBackColor = true;
            this.newGatheringButton.Click += new System.EventHandler(this.newGatheringButton_Click);
            // 
            // newCombatButton
            // 
            this.newCombatButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newCombatButton.Location = new System.Drawing.Point(12, 72);
            this.newCombatButton.Name = "newCombatButton";
            this.newCombatButton.Size = new System.Drawing.Size(226, 28);
            this.newCombatButton.TabIndex = 12;
            this.newCombatButton.Text = "Combat";
            this.newCombatButton.UseVisualStyleBackColor = true;
            this.newCombatButton.Click += new System.EventHandler(this.newCombatButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "or load exist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "New";
            // 
            // ConfigSelectFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newCombatButton);
            this.Controls.Add(this.newGatheringButton);
            this.Controls.Add(this.newFishingButton);
            this.Controls.Add(this.existFileSelector);
            this.Controls.Add(this.label7);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "ConfigSelectFrom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ConfigSelectFrom_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox existFileSelector;
        private System.Windows.Forms.Button newFishingButton;
        private System.Windows.Forms.Button newGatheringButton;
        private System.Windows.Forms.Button newCombatButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}