
namespace EGO.EXICAS
{
    partial class FloatWindow
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
            this.lst = new EGO.SolidUI.FirstFlowPanel();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AutoScroll = true;
            this.lst.AutoSize = true;
            this.lst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.lst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lst.DarkImage = null;
            this.lst.DarkImageInverted = null;
            this.lst.DarkTheme = false;
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.lst.ForeColor = System.Drawing.Color.Purple;
            this.lst.Inverted = false;
            this.lst.LightImage = null;
            this.lst.LightImageInverted = null;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.ManualDarkTheme = false;
            this.lst.ManualInvert = false;
            this.lst.ManualThemeColor = false;
            this.lst.Name = "lst";
            this.lst.ReverseDarkTheme = false;
            this.lst.ReverseInvertAction = true;
            this.lst.Size = new System.Drawing.Size(300, 300);
            this.lst.TabIndex = 0;
            this.lst.ThemeColor = System.Drawing.Color.Purple;
            this.lst.WrapContents = false;
            // 
            // FloatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.lst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(300, 700);
            this.Name = "FloatWindow";
            this.ReverseDarkTheme = true;
            this.ReverseInvertAction = true;
            this.Text = "FloatWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SolidUI.FirstFlowPanel lst;
    }
}