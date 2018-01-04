namespace FFXIV_netBot.Forms
{
    partial class SettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.activeMainViewUpdateTextbox = new System.Windows.Forms.TextBox();
            this.inactiveMainViewUpdateTextbox = new System.Windows.Forms.TextBox();
            this.activeWaypointViewUpdateTextbox = new System.Windows.Forms.TextBox();
            this.inactiveWaypointViewUpdateTextbox = new System.Windows.Forms.TextBox();
            this.randomKeyPressMinTextbox = new System.Windows.Forms.TextBox();
            this.randomKeyPressMaxTextbox = new System.Windows.Forms.TextBox();
            this.movementUpdateTickTextbox = new System.Windows.Forms.TextBox();
            this.movementRotationSleepUntilMemoryHackTextbox = new System.Windows.Forms.TextBox();
            this.minMovementDistanceToNextWaypointTextbox = new System.Windows.Forms.TextBox();
            this.minRadianDifferanceToMoveTextbox = new System.Windows.Forms.TextBox();
            this.minRadianDifferanceToUseKeysTextbox = new System.Windows.Forms.TextBox();
            this.minRadianDifferanceToUseMemoryHackTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.restoreDefaultButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "System - Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(100, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Main Menu Update Interval (Active)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // activeMainViewUpdateTextbox
            // 
            this.activeMainViewUpdateTextbox.Location = new System.Drawing.Point(310, 79);
            this.activeMainViewUpdateTextbox.MaxLength = 0;
            this.activeMainViewUpdateTextbox.Name = "activeMainViewUpdateTextbox";
            this.activeMainViewUpdateTextbox.Size = new System.Drawing.Size(120, 20);
            this.activeMainViewUpdateTextbox.TabIndex = 11;
            this.activeMainViewUpdateTextbox.TabStop = false;
            this.activeMainViewUpdateTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.activeMainViewUpdateTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // inactiveMainViewUpdateTextbox
            // 
            this.inactiveMainViewUpdateTextbox.Location = new System.Drawing.Point(310, 105);
            this.inactiveMainViewUpdateTextbox.MaxLength = 0;
            this.inactiveMainViewUpdateTextbox.Name = "inactiveMainViewUpdateTextbox";
            this.inactiveMainViewUpdateTextbox.Size = new System.Drawing.Size(120, 20);
            this.inactiveMainViewUpdateTextbox.TabIndex = 11;
            this.inactiveMainViewUpdateTextbox.TabStop = false;
            this.inactiveMainViewUpdateTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inactiveMainViewUpdateTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // activeWaypointViewUpdateTextbox
            // 
            this.activeWaypointViewUpdateTextbox.Location = new System.Drawing.Point(310, 131);
            this.activeWaypointViewUpdateTextbox.MaxLength = 0;
            this.activeWaypointViewUpdateTextbox.Name = "activeWaypointViewUpdateTextbox";
            this.activeWaypointViewUpdateTextbox.Size = new System.Drawing.Size(120, 20);
            this.activeWaypointViewUpdateTextbox.TabIndex = 11;
            this.activeWaypointViewUpdateTextbox.TabStop = false;
            this.activeWaypointViewUpdateTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.activeWaypointViewUpdateTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // inactiveWaypointViewUpdateTextbox
            // 
            this.inactiveWaypointViewUpdateTextbox.Location = new System.Drawing.Point(310, 157);
            this.inactiveWaypointViewUpdateTextbox.MaxLength = 0;
            this.inactiveWaypointViewUpdateTextbox.Name = "inactiveWaypointViewUpdateTextbox";
            this.inactiveWaypointViewUpdateTextbox.Size = new System.Drawing.Size(120, 20);
            this.inactiveWaypointViewUpdateTextbox.TabIndex = 11;
            this.inactiveWaypointViewUpdateTextbox.TabStop = false;
            this.inactiveWaypointViewUpdateTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inactiveWaypointViewUpdateTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // randomKeyPressMinTextbox
            // 
            this.randomKeyPressMinTextbox.Location = new System.Drawing.Point(310, 183);
            this.randomKeyPressMinTextbox.MaxLength = 0;
            this.randomKeyPressMinTextbox.Name = "randomKeyPressMinTextbox";
            this.randomKeyPressMinTextbox.Size = new System.Drawing.Size(120, 20);
            this.randomKeyPressMinTextbox.TabIndex = 11;
            this.randomKeyPressMinTextbox.TabStop = false;
            this.randomKeyPressMinTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.randomKeyPressMinTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // randomKeyPressMaxTextbox
            // 
            this.randomKeyPressMaxTextbox.Location = new System.Drawing.Point(310, 209);
            this.randomKeyPressMaxTextbox.MaxLength = 0;
            this.randomKeyPressMaxTextbox.Name = "randomKeyPressMaxTextbox";
            this.randomKeyPressMaxTextbox.Size = new System.Drawing.Size(120, 20);
            this.randomKeyPressMaxTextbox.TabIndex = 11;
            this.randomKeyPressMaxTextbox.TabStop = false;
            this.randomKeyPressMaxTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.randomKeyPressMaxTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // movementUpdateTickTextbox
            // 
            this.movementUpdateTickTextbox.Location = new System.Drawing.Point(310, 235);
            this.movementUpdateTickTextbox.MaxLength = 0;
            this.movementUpdateTickTextbox.Name = "movementUpdateTickTextbox";
            this.movementUpdateTickTextbox.Size = new System.Drawing.Size(120, 20);
            this.movementUpdateTickTextbox.TabIndex = 11;
            this.movementUpdateTickTextbox.TabStop = false;
            this.movementUpdateTickTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.movementUpdateTickTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // movementRotationSleepUntilMemoryHackTextbox
            // 
            this.movementRotationSleepUntilMemoryHackTextbox.Location = new System.Drawing.Point(310, 261);
            this.movementRotationSleepUntilMemoryHackTextbox.MaxLength = 0;
            this.movementRotationSleepUntilMemoryHackTextbox.Name = "movementRotationSleepUntilMemoryHackTextbox";
            this.movementRotationSleepUntilMemoryHackTextbox.Size = new System.Drawing.Size(120, 20);
            this.movementRotationSleepUntilMemoryHackTextbox.TabIndex = 11;
            this.movementRotationSleepUntilMemoryHackTextbox.TabStop = false;
            this.movementRotationSleepUntilMemoryHackTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.movementRotationSleepUntilMemoryHackTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // minMovementDistanceToNextWaypointTextbox
            // 
            this.minMovementDistanceToNextWaypointTextbox.Location = new System.Drawing.Point(310, 287);
            this.minMovementDistanceToNextWaypointTextbox.MaxLength = 0;
            this.minMovementDistanceToNextWaypointTextbox.Name = "minMovementDistanceToNextWaypointTextbox";
            this.minMovementDistanceToNextWaypointTextbox.Size = new System.Drawing.Size(120, 20);
            this.minMovementDistanceToNextWaypointTextbox.TabIndex = 11;
            this.minMovementDistanceToNextWaypointTextbox.TabStop = false;
            this.minMovementDistanceToNextWaypointTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minMovementDistanceToNextWaypointTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // minRadianDifferanceToMoveTextbox
            // 
            this.minRadianDifferanceToMoveTextbox.Location = new System.Drawing.Point(310, 313);
            this.minRadianDifferanceToMoveTextbox.MaxLength = 0;
            this.minRadianDifferanceToMoveTextbox.Name = "minRadianDifferanceToMoveTextbox";
            this.minRadianDifferanceToMoveTextbox.Size = new System.Drawing.Size(120, 20);
            this.minRadianDifferanceToMoveTextbox.TabIndex = 11;
            this.minRadianDifferanceToMoveTextbox.TabStop = false;
            this.minRadianDifferanceToMoveTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minRadianDifferanceToMoveTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // minRadianDifferanceToUseKeysTextbox
            // 
            this.minRadianDifferanceToUseKeysTextbox.Location = new System.Drawing.Point(310, 339);
            this.minRadianDifferanceToUseKeysTextbox.MaxLength = 0;
            this.minRadianDifferanceToUseKeysTextbox.Name = "minRadianDifferanceToUseKeysTextbox";
            this.minRadianDifferanceToUseKeysTextbox.Size = new System.Drawing.Size(120, 20);
            this.minRadianDifferanceToUseKeysTextbox.TabIndex = 11;
            this.minRadianDifferanceToUseKeysTextbox.TabStop = false;
            this.minRadianDifferanceToUseKeysTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minRadianDifferanceToUseKeysTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // minRadianDifferanceToUseMemoryHackTextbox
            // 
            this.minRadianDifferanceToUseMemoryHackTextbox.Location = new System.Drawing.Point(310, 365);
            this.minRadianDifferanceToUseMemoryHackTextbox.MaxLength = 0;
            this.minRadianDifferanceToUseMemoryHackTextbox.Name = "minRadianDifferanceToUseMemoryHackTextbox";
            this.minRadianDifferanceToUseMemoryHackTextbox.Size = new System.Drawing.Size(120, 20);
            this.minRadianDifferanceToUseMemoryHackTextbox.TabIndex = 11;
            this.minRadianDifferanceToUseMemoryHackTextbox.TabStop = false;
            this.minRadianDifferanceToUseMemoryHackTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minRadianDifferanceToUseMemoryHackTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(89, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Main Menu Update Interval (Inactive)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(72, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Waypoint Setup Update Interval (Active)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(61, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Waypoint Setup Update Interval (Inactive)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(106, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Minimum Key Press Random Time";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(105, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Maximum Key Press Random Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(115, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Update Position Until Movement";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(23, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(273, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Sleep Time After Rotation for MemWrite Rotation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(174, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Waypoint Hitbox Size";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(26, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(270, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "Minimum Radian Difference For Rotate And Move";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(14, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(282, 17);
            this.label12.TabIndex = 9;
            this.label12.Text = "Minimum Radian Difference For Rotate To Use Keys";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(20, 365);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(276, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Minimum Radian Difference For To Use memWrite";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Impact", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(12, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(424, 21);
            this.label14.TabIndex = 9;
            this.label14.Text = "  DON\'T CHANGE THIS, IF YOU DON\'T UNDERSTAND WHAT YOU DO!  ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // restoreDefaultButton
            // 
            this.restoreDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.restoreDefaultButton.Location = new System.Drawing.Point(103, 402);
            this.restoreDefaultButton.Name = "restoreDefaultButton";
            this.restoreDefaultButton.Size = new System.Drawing.Size(104, 23);
            this.restoreDefaultButton.TabIndex = 12;
            this.restoreDefaultButton.Text = "Restore Defaults";
            this.restoreDefaultButton.UseVisualStyleBackColor = true;
            this.restoreDefaultButton.Click += new System.EventHandler(this.restoreDefaultButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveButton.Location = new System.Drawing.Point(247, 402);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(104, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save Settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(450, 440);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.restoreDefaultButton);
            this.Controls.Add(this.minRadianDifferanceToUseMemoryHackTextbox);
            this.Controls.Add(this.minRadianDifferanceToUseKeysTextbox);
            this.Controls.Add(this.movementRotationSleepUntilMemoryHackTextbox);
            this.Controls.Add(this.movementUpdateTickTextbox);
            this.Controls.Add(this.minRadianDifferanceToMoveTextbox);
            this.Controls.Add(this.inactiveWaypointViewUpdateTextbox);
            this.Controls.Add(this.randomKeyPressMaxTextbox);
            this.Controls.Add(this.minMovementDistanceToNextWaypointTextbox);
            this.Controls.Add(this.activeWaypointViewUpdateTextbox);
            this.Controls.Add(this.randomKeyPressMinTextbox);
            this.Controls.Add(this.inactiveMainViewUpdateTextbox);
            this.Controls.Add(this.activeMainViewUpdateTextbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 440);
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox activeMainViewUpdateTextbox;
        private System.Windows.Forms.TextBox inactiveMainViewUpdateTextbox;
        private System.Windows.Forms.TextBox activeWaypointViewUpdateTextbox;
        private System.Windows.Forms.TextBox inactiveWaypointViewUpdateTextbox;
        private System.Windows.Forms.TextBox randomKeyPressMinTextbox;
        private System.Windows.Forms.TextBox randomKeyPressMaxTextbox;
        private System.Windows.Forms.TextBox movementUpdateTickTextbox;
        private System.Windows.Forms.TextBox movementRotationSleepUntilMemoryHackTextbox;
        private System.Windows.Forms.TextBox minMovementDistanceToNextWaypointTextbox;
        private System.Windows.Forms.TextBox minRadianDifferanceToMoveTextbox;
        private System.Windows.Forms.TextBox minRadianDifferanceToUseKeysTextbox;
        private System.Windows.Forms.TextBox minRadianDifferanceToUseMemoryHackTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button restoreDefaultButton;
        private System.Windows.Forms.Button saveButton;
    }
}