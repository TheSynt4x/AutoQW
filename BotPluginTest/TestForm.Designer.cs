namespace BotPluginTest
{
    partial class TestForm
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
            if (disposing && (components != null)) {
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
            this.lblPluginDescription = new System.Windows.Forms.Label();
            this.lblPluginName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPluginDescription
            // 
            this.lblPluginDescription.AutoSize = true;
            this.lblPluginDescription.Location = new System.Drawing.Point(12, 32);
            this.lblPluginDescription.Name = "lblPluginDescription";
            this.lblPluginDescription.Size = new System.Drawing.Size(95, 13);
            this.lblPluginDescription.TabIndex = 1;
            this.lblPluginDescription.Text = "Plugin Description:";
            // 
            // lblPluginName
            // 
            this.lblPluginName.AutoSize = true;
            this.lblPluginName.Location = new System.Drawing.Point(12, 9);
            this.lblPluginName.Name = "lblPluginName";
            this.lblPluginName.Size = new System.Drawing.Size(73, 13);
            this.lblPluginName.TabIndex = 2;
            this.lblPluginName.Text = "Plugin Name: ";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 246);
            this.Controls.Add(this.lblPluginName);
            this.Controls.Add(this.lblPluginDescription);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPluginDescription;
        private System.Windows.Forms.Label lblPluginName;
    }
}