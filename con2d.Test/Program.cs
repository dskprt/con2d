using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using con2d;
using con2d.Graphics;
using con2d.Utils;

namespace con2d.Test {

    class Program {

        static void Main(string[] args) {
            Con2D con2d = new Con2D();
            con2d.Initialize();
            con2d.Title = "Hello world!";

            Loop();
        }

        static void Loop() {
            while(true) {
                for (int x = 0; x < 200; x++) {
                    for (int y = 0; y < 200; y++) {
                        Point.Draw(x, y, new Color(x, x, x));
                    }
                }
            }
        }
    }
}
