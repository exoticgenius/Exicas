using EGO.SolidUI;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.EXICAS
{
    public partial class IconImageControl : IControlPanel
    {
        public IconImage Image { get; set; }
        public event EventHandler ShowThumbnail;
        public event EventHandler RemoveCurrent;
        public IconImageControl(IconImage image) : this()
        {
            Image = image;
            if (image.Image.Width > 60)
            {
                pic.Image = API.ResizeImageHQ(image.Image, 70, 70);
            }
            else
            {
                pic.Image = API.ResizeImage(image.Image, 70, 70);
            }
            title.Text = image.Image.Width.ToString();
        }
        public IconImageControl()
        {
            InitializeComponent();
            btn_delete.Inverted = true;
        }
       

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            RemoveCurrent?.Invoke(sender,e);
        }

        private void Title_Click(object sender, EventArgs e)
        {
            ShowThumbnail?.Invoke(sender,e);
        }

        private void panel1_MouseLeave(object sender, EventArgs e) => OnMouseLeave(e);

        private void panel1_MouseEnter(object sender, EventArgs e)  => OnMouseEnter(e);

        private void IconImageControl_MouseEnter(object sender, EventArgs e)
        {
            btn_delete.Inverted = false;
        }

        private void IconImageControl_MouseLeave(object sender, EventArgs e)
        {
            btn_delete.Inverted = true;
        }

    }
}
