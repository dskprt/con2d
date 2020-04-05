using con2d.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace con2d.Graphics {

    public class Text {

        public static bool Render(string text, int x, int y) {
            if (!Con2D.GetInstance().initialized) throw new InitializationException("Con2D not initialized.");
            return Con2D.External.TextOutA(Con2D.GetInstance().dc, x, y, text, text.Length);
        }
    }
}
