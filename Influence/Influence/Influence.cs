using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influence
{
    public abstract class Influence
    {
        int width = 512;
        int height = 512;

        string title;

        public Influence(int width, int height, string title)
        {
            this.width = width;
            this.height = height;

            this.title = title;
        }
    }
}
