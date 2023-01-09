using System;
using System.Collections.Generic;

namespace Influence
{
    public class Color
    {
        public byte r;
        public byte g;
        public byte b;

        public byte a;

        public Color()
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;

            this.a = 255;
        }

        public Color(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;

            this.a = 255;
        }

        public Color(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;

            this.a = a;
        }

        public Color(float r, float g, float b)
        {
            this.r = (byte)Math.Clamp(r * 255, 0, 255);
            this.g = (byte)Math.Clamp(g * 255, 0, 255);
            this.b = (byte)Math.Clamp(b * 255, 0, 255);

            this.a = 255;
        }

        public Color(float r, float g, float b, float a)
        {
            this.r = (byte)Math.Clamp(r * 255, 0, 255);
            this.g = (byte)Math.Clamp(g * 255, 0, 255);
            this.b = (byte)Math.Clamp(b * 255, 0, 255);

            this.a = (byte)Math.Clamp(a * 255, 0, 255);
        }

        public static Color Red => new Color(255, 0, 0);
        public static Color Green => new Color(0, 255, 0);
        public static Color Blue => new Color(0, 0, 255);

        public static Color Julie => new Color(255, 86, 0);

        public static Color Black => new Color(0, 0, 0);
        public static Color White => new Color(255, 255, 255);
    }
}
