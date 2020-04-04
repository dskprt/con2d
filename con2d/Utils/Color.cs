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

        public uint ToUInt() {
            return uint.Parse($"{this.red:X2}{this.green:X2}{this.blue:X2}");
        }
    }
}
