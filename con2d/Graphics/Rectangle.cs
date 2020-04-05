using con2d.Exceptions;
using con2d.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace con2d.Graphics {

    public class Rectangle {

        public static void Draw(int x, int y, int w, int h, Color color, bool outline = false) {
            if (!Con2D.GetInstance().initialized) throw new InitializationException("Con2D not initialized.");

            if (!outline) {
                Draw(x, y, w, h, color);
            } else {
                for(int i = 0; i < w; i++) {
                    Point.Draw(x + i, y, color);
                }

                for (int i = 0; i < w; i++) {
                    Point.Draw(x + i, y + h, color);
                }

                for (int i = 0; i < h; i++) {
                    Point.Draw(x, y + i, color);
                }

                for (int i = 0; i < h; i++) {
                    Point.Draw(x + w, y + i, color);
                }
            }
        }
    }
}
