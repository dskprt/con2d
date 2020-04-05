using System;
using System.Collections.Generic;
using System.Text;

namespace con2d.Utils {

    public class Color {

        public int red;
        public int green;
        public int blue;

        public Color(int r, int g, int b) {
            this.red = r;
            this.green = g;
            this.blue = b;
        }

        // (byte)(nValue & 0xFF)

        public static Color FromUInt(uint input) {
            int r = (int)(input & 0xFF);
            int g = (int)((input >> 8) & 0xFF);
            int b = (int)((input >> 16) & 0xFF);

            return new Color(r, g, b);
        }

        public uint ToUInt() {
            return (byte)(this.red) | ((uint)((byte)(this.green)) << 8) | (((uint)(byte)(this.blue)) << 16);
        }

        public bool Compare(Color other) {
            return (this.red == other.red) && (this.blue == other.blue) && (this.green == other.green);
        }
    }
}
