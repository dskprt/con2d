using con2d.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace con2d.Graphics {

    public class Rectangle {

        public static void Draw(int x, int y, int w, int h, Color color, bool outline) {
            if(!outline) {
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

        public static void Draw(int x, int y, int w, int h, Color color) {
            for(int i = 0; i < w; i++) {
                for(int j = 0; j < h; j++) {
                    Point.Draw(x + i, y + j, color);
                }
            }
        }
    }
}
