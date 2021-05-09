
namespace EGO.EXICAS
{
    partial class IconImageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_delete = new EGO.SolidUI.FirstButton();
            this.pic = new System.Windows.Forms.PictureBox();
            this.title = new EGO.SolidUI.ThirdButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Crimson;
            this.btn_delete.DarkTheme = false;
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_delete.FontSize = 12F;
            this.btn_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btn_delete.Inverted = false;
            this.btn_delete.Location = new System.Drawing.Point(250, 0);
            this.btn_delete.ManualDarkTheme = false;
            this.btn_delete.ManualInvert = true;
            this.btn_delete.ManualThemeColor = true;
            this.btn_delete.Margin = new System.Windows.Forms.Padding(0);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.ReverseDarkTheme = false;
            this.btn_delete.ReverseInvertAction = false;
            this.btn_delete.Size = new System.Drawing.Size(40, 70);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.ThemeColor = System.Drawing.Color.Crimson;
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            this.btn_delete.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.btn_delete.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // pic
            // 
            this.pic.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Margin = new System.Windows.Forms.Padding(0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 70);
            this.pic.TabIndex = 4;
            this.pic.TabStop = false;
            this.pic.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.pic.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.title.DarkTheme = false;
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.title.FlatAppearance.BorderSize = 0;
            this.title.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.title.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.title.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.FontSize = 20F;
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.title.Inverted = true;
            this.title.Location = new System.Drawing.Point(70, 0);
            this.title.ManualDarkTheme = false;
            this.title.ManualInvert = false;
            this.title.ManualThemeColor = false;
            this.title.MouseDownDegree = ((byte)(180));
            this.title.MouseMoveDegree = ((byte)(0));
            this.title.Name = "title";
            this.title.ReverseDarkTheme = false;
            this.title.ReverseInvertAction = true;
            this.title.Size = new System.Drawing.Size(180, 70);
            this.title.TabIndex = 5;
            this.title.Text = "256";
            this.title.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.title.UseCompatibleTextRendering = true;
            this.title.UseVisualStyleBackColor = false;
            this.title.Click += new System.EventHandler(this.Title_Click);
            this.title.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.title.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // IconImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.title);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.btn_delete);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.Name = "IconImageControl";
            this.Size = new System.Drawing.Size(290, 70);
            this.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.MouseEnter += new System.EventHandler(this.IconImageControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.IconImageControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic;
        private SolidUI.ThirdButton title;
        public SolidUI.FirstButton btn_delete;
    }
}
