namespace FFXIV_netBot.Forms
{
    partial class SaveWaypointForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.TextBox();
            this.existFileSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButtonn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Waypoint Route - Save";
            // 
            // saveButton
            // 
            this.saveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveButton.Location = new System.Drawing.Point(152, 180);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(12, 144);
            this.FileName.MaxLength = 100;
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(226, 20);
            this.FileName.TabIndex = 11;
            this.FileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FileName_KeyPress);
            // 
            // existFileSelector
            // 
            this.existFileSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.existFileSelector.FormattingEnabled = true;
            this.existFileSelector.Location = new System.Drawing.Point(12, 65);
            this.existFileSelector.Name = "existFileSelector";
            this.existFileSelector.Size = new System.Drawing.Size(226, 21);
            this.existFileSelector.TabIndex = 13;
            this.existFileSelector.SelectedIndexChanged += new System.EventHandler(this.existFileSelector_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Save New Route";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cancelButtonn
            // 
            this.cancelButtonn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButtonn.Location = new System.Drawing.Point(12, 180);
            this.cancelButtonn.Name = "cancelButtonn";
            this.cancelButtonn.Size = new System.Drawing.Size(82, 23);
            this.cancelButtonn.TabIndex = 10;
            this.cancelButtonn.Text = "Cancel";
            this.cancelButtonn.UseVisualStyleBackColor = true;
            this.cancelButtonn.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Overwrite Route";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "or";
            // 
            // SaveWaypointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(250, 220);
            this.Controls.Add(this.existFileSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.cancelButtonn);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 220);
            this.Name = "SaveWaypointForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SaveWaypointForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.ComboBox existFileSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButtonn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}