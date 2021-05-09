using Fractal;
using Fractal.Extensions;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.EXICAS
{
    public class IconImage : Node
    {
        private Image _cache = null;
        public IconImage()
        {
            SetTypeName(this.GetType());
            for (int i = Features.Count; i < 1; i++) Features.Add(string.Empty);
        }

        public Image Image
        {
            get
            {
                return _cache ?? ConvertFeature();
            }
            set
            {
                _cache = value;
                using (MemoryStream m = new MemoryStream())
                {
                    value.Save(m, value.RawFormat);

                    string base64String = Convert.ToBase64String(m.ToArray());
                    this.SetFeature(0, base64String);
                }
            }
        }

        private Image ConvertFeature()
        {
            byte[] bytes = Convert.FromBase64String(Features[0]);
            try
            {
                using (var ms = new MemoryStream(bytes))
                {
                    Image img = Image.FromStream(ms);
                    _cache = img;
                    return img;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                Task.Run(GC.Collect);
            }
        }
    }
}
