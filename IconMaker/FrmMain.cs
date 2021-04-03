using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IconMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in ofd.FileNames)
                    {
                        lst_Images.Items.Add(item);
                    }
                }
            }

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (lst_Images.SelectedIndex > -1)
            {
                lst_Images.Items.RemoveAt(lst_Images.SelectedIndex);
            }
        }

        private void lst_Images_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_Images.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(lst_Images.SelectedItem.ToString());

                pic_Preview.Image = ResizeImage(bmp, 256, 256);
            }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceOver;
                graphics.CompositingQuality = CompositingQuality.GammaCorrected;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            }

            return destImage;
        }
        private void btn_Make_Click(object sender, EventArgs e)
        {
            
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "untitled.ico";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    MultiIcon icons = new MultiIcon();
                    SingleIcon si = icons.Add("pack");
                    icons.SelectedName = "pack";
                    foreach (string item in lst_Images.Items)
                    {
                        var newImage = new Bitmap(Bitmap.FromFile(item));
                        if (newImage.Width > 256 || newImage.Height > 256)
                        {
                            MessageBox.Show($"icon with size larger than 256px width or 256px height cannot be added");
                            continue;
                        }
                        bool notExist = true;
                        foreach (var ei in si)
                        {
                            if (ei.Size.Width == newImage.Width && ei.Size.Height == newImage.Height) notExist = false;
                        }
                        if (notExist)
                        {
                            si.Add(newImage);
                        }
                        else
                        {
                            MessageBox.Show($"icon with same size cannot be added\r\nkeep one of images with size{newImage.Width}*{newImage.Height}");
                        }
                    }


                    icons.Save(sfd.FileName, MultiIconFormat.ICO);
                }
            }
        }

        private static Bitmap AnotherDepth(Bitmap image, long depth)
        {
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                ImageCodecInfo myImageCodecInfo;
                System.Drawing.Imaging.Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;

                // Get encoder for tiff type
                myImageCodecInfo = GetEncoderInfo("image/tiff");

                // Create an Encoder object based on the GUID
                // for the ColorDepth parameter category.
                myEncoder = System.Drawing.Imaging.Encoder.ColorDepth;

                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one
                // EncoderParameter object in the array.
                myEncoderParameters = new EncoderParameters(1);

                // Save the image with a color depth of 24 bits per pixel.
                myEncoderParameter = new EncoderParameter(myEncoder, depth);
                myEncoderParameters.Param[0] = myEncoderParameter;
                image.Save(ms, myImageCodecInfo, myEncoderParameters);
                data = ms.ToArray();
            }
            using (MemoryStream ms = new MemoryStream(data))
            {
                var img = new Bitmap(ms);
                return img;
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        public Icon ConvertToIco(Image img)
        {
            Icon icon;
            using (var msImg = new MemoryStream())
            using (var msIco = new MemoryStream())
            {
                img.Save(msImg, ImageFormat.Png);
                using (var bw = new BinaryWriter(msIco))
                {
                    bw.Write((short)0);           //0-1 reserved
                    bw.Write((short)1);           //2-3 image type, 1 = icon, 2 = cursor
                    bw.Write((short)1);           //4-5 number of images
                    bw.Write((byte)img.Width);         //6 image width
                    bw.Write((byte)img.Width);         //7 image height
                    bw.Write((byte)0);            //8 number of colors
                    bw.Write((byte)0);            //9 reserved
                    bw.Write((short)0);           //10-11 color planes
                    bw.Write((short)32);          //12-13 bits per pixel
                    bw.Write((int)msImg.Length);  //14-17 size of image data
                    bw.Write(22);                 //18-21 offset of image data
                    bw.Write(msImg.ToArray());    // write image data
                    bw.Flush();
                    bw.Seek(0, SeekOrigin.Begin);
                    icon = new Icon(msIco);
                }
            }
            return icon;
        }

    }
}
