namespace FFXIV_netBot.Forms
{
    partial class WaypointEditForm
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
            this.AbortlButton = new System.Windows.Forms.Button();
            this.Change = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.posXTextField = new System.Windows.Forms.TextBox();
            this.posYTextField = new System.Windows.Forms.TextBox();
            this.posZTextField = new System.Windows.Forms.TextBox();
            this.rotationTextField = new System.Windows.Forms.TextBox();
            this.indexTextField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rangeTextField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AbortlButton
            // 
            this.AbortlButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AbortlButton.Location = new System.Drawing.Point(34, 225);
            this.AbortlButton.Name = "AbortlButton";
            this.AbortlButton.Size = new System.Drawing.Size(75, 23);
            this.AbortlButton.TabIndex = 0;
            this.AbortlButton.Text = "Cancel";
            this.AbortlButton.UseVisualStyleBackColor = true;
            this.AbortlButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Change
            // 
            this.Change.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Change.Location = new System.Drawing.Point(138, 225);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(75, 23);
            this.Change.TabIndex = 0;
            this.Change.Text = "Change";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Default",
            "Fishing",
            "Gathering"});
            this.typeComboBox.Location = new System.Drawing.Point(118, 68);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 21);
            this.typeComboBox.TabIndex = 1;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            // 
            // posXTextField
            // 
            this.posXTextField.Location = new System.Drawing.Point(118, 93);
            this.posXTextField.MaxLength = 10;
            this.posXTextField.Name = "posXTextField";
            this.posXTextField.Size = new System.Drawing.Size(121, 20);
            this.posXTextField.TabIndex = 2;
            this.posXTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // posYTextField
            // 
            this.posYTextField.Location = new System.Drawing.Point(118, 118);
            this.posYTextField.MaxLength = 10;
            this.posYTextField.Name = "posYTextField";
            this.posYTextField.Size = new System.Drawing.Size(121, 20);
            this.posYTextField.TabIndex = 3;
            this.posYTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // posZTextField
            // 
            this.posZTextField.Location = new System.Drawing.Point(118, 143);
            this.posZTextField.MaxLength = 10;
            this.posZTextField.Name = "posZTextField";
            this.posZTextField.Size = new System.Drawing.Size(121, 20);
            this.posZTextField.TabIndex = 4;
            this.posZTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // rotationTextField
            // 
            this.rotationTextField.Location = new System.Drawing.Point(118, 169);
            this.rotationTextField.MaxLength = 10;
            this.rotationTextField.Name = "rotationTextField";
            this.rotationTextField.Size = new System.Drawing.Size(121, 20);
            this.rotationTextField.TabIndex = 5;
            this.rotationTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // indexTextField
            // 
            this.indexTextField.Location = new System.Drawing.Point(118, 44);
            this.indexTextField.MaxLength = 10;
            this.indexTextField.Name = "indexTextField";
            this.indexTextField.Size = new System.Drawing.Size(121, 20);
            this.indexTextField.TabIndex = 6;
            this.toolTip1.SetToolTip(this.indexTextField, "change position to Insert this waypoint on other index");
            this.indexTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Index";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.toolTip1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolTip1.ToolTipTitle = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Position X";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Position Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Position Z";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Rotation (Radian)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Waypoint - Edit";
            // 
            // rangeTextField
            // 
            this.rangeTextField.Location = new System.Drawing.Point(118, 194);
            this.rangeTextField.MaxLength = 10;
            this.rangeTextField.Name = "rangeTextField";
            this.rangeTextField.Size = new System.Drawing.Size(121, 20);
            this.rangeTextField.TabIndex = 5;
            this.rangeTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(67, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Range";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WaypointEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(250, 260);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.indexTextField);
            this.Controls.Add(this.rangeTextField);
            this.Controls.Add(this.rotationTextField);
            this.Controls.Add(this.posZTextField);
            this.Controls.Add(this.posYTextField);
            this.Controls.Add(this.posXTextField);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.AbortlButton);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 260);
            this.Name = "WaypointEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.WaypointEditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.KeyPreview = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AbortlButton;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.TextBox posXTextField;
        private System.Windows.Forms.TextBox posYTextField;
        private System.Windows.Forms.TextBox posZTextField;
        private System.Windows.Forms.TextBox rotationTextField;
        private System.Windows.Forms.TextBox indexTextField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rangeTextField;
        private System.Windows.Forms.Label label8;
    }
}