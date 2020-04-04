using con2d.Exceptions;
using con2d.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace con2d.Graphics {

    public class Point {

        public static void Draw(int x, int y, Color color) {
            if (!Con2D.GetInstance().initialized) throw new InitializationException("Con2D not initialized.");
            Con2D.External.SetPixel(Con2D.GetInstance().dc, x, y, color.ToUInt());
        }
    }
}
