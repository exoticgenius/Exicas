namespace IconMaker
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
            this.lst_Images = new System.Windows.Forms.ListBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Make = new System.Windows.Forms.Button();
            this.pic_Preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // lst_Images
            // 
            this.lst_Images.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_Images.FormattingEnabled = true;
            this.lst_Images.Location = new System.Drawing.Point(12, 12);
            this.lst_Images.Name = "lst_Images";
            this.lst_Images.Size = new System.Drawing.Size(298, 290);
            this.lst_Images.TabIndex = 0;
            this.lst_Images.SelectedIndexChanged += new System.EventHandler(this.lst_Images_SelectedIndexChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Location = new System.Drawing.Point(316, 281);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(67, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "Add image";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Remove.Location = new System.Drawing.Point(389, 281);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(103, 23);
            this.btn_Remove.TabIndex = 2;
            this.btn_Remove.Text = "Remove selected";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Make
            // 
            this.btn_Make.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Make.Location = new System.Drawing.Point(498, 281);
            this.btn_Make.Name = "btn_Make";
            this.btn_Make.Size = new System.Drawing.Size(74, 23);
            this.btn_Make.TabIndex = 3;
            this.btn_Make.Text = "Make";
            this.btn_Make.UseVisualStyleBackColor = true;
            this.btn_Make.Click += new System.EventHandler(this.btn_Make_Click);
            // 
            // pic_Preview
            // 
            this.pic_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Preview.Location = new System.Drawing.Point(316, 12);
            this.pic_Preview.Name = "pic_Preview";
            this.pic_Preview.Size = new System.Drawing.Size(256, 256);
            this.pic_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Preview.TabIndex = 4;
            this.pic_Preview.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.pic_Preview);
            this.Controls.Add(this.btn_Make);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lst_Images);
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "Form1";
            this.Text = "IconMaker";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_Images;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Make;
        private System.Windows.Forms.PictureBox pic_Preview;
    }
}

