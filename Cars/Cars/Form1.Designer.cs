namespace Cars
{
    partial class Form1
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
            this.brandCombo = new System.Windows.Forms.ComboBox();
            this.modelCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // brandCombo
            // 
            this.brandCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brandCombo.FormattingEnabled = true;
            this.brandCombo.Location = new System.Drawing.Point(30, 26);
            this.brandCombo.Name = "brandCombo";
            this.brandCombo.Size = new System.Drawing.Size(121, 21);
            this.brandCombo.TabIndex = 0;
            this.brandCombo.SelectedIndexChanged += new System.EventHandler(this.brandCombo_SelectedIndexChanged);
            // 
            // modelCombo
            // 
            this.modelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelCombo.FormattingEnabled = true;
            this.modelCombo.Location = new System.Drawing.Point(191, 27);
            this.modelCombo.Name = "modelCombo";
            this.modelCombo.Size = new System.Drawing.Size(121, 21);
            this.modelCombo.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 270);
            this.Controls.Add(this.modelCombo);
            this.Controls.Add(this.brandCombo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox brandCombo;
        private System.Windows.Forms.ComboBox modelCombo;
    }
}

