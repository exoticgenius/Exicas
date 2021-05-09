using Fractal;
using Fractal.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.EXICAS
{
    public class Collection : Node
    {
        public Collection()
        {
            SetTypeName(this.GetType());
            for (int i = Features.Count; i < 1; i++) Features.Add(string.Empty);
        }

        public string LastSaveLocation
        {
            get
            {
                return Features[0];
            }
            set
            {
                this.SetFeature(0, value);
            } 
        }
    }
}
