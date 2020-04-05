using con2d.Exceptions;
using con2d.Utils;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace con2d {

    public class Con2D {

        private static Con2D con2d;
        public bool initialized = false;

        public IntPtr handle;
        public IntPtr stdHandle;
        public IntPtr dc;

        public string Title {
            get { return Console.Title; }
            set { Console.Title = value; }
        }

        public Con2D() {
            con2d = this;
        }

        public static Con2D GetInstance() {
            return con2d;
        }

        public void Initialize() {
            Console.Title = "con2d";
            Console.CursorVisible = false;

            this.handle = External.GetConsoleWindow();
            this.stdHandle = External.GetStdHandle(External.STD_INPUT_HANDLE);

            uint mode;
            
            if(!External.GetConsoleMode(this.stdHandle, out mode)) {
                throw new InitializationException("Failed to get current console mode.");
            }

            if(!External.SetConsoleMode(this.stdHandle, External.ENABLE_EXTENDED_FLAGS |
                    (mode & ~External.ENABLE_ECHO_INPUT & ~External.ENABLE_QUICK_EDIT_MODE
                    & External.ENABLE_WINDOW_INPUT & External.ENABLE_MOUSE_INPUT))) {
                throw new InitializationException("Failed to set console mode.");
            }

            this.dc = External.GetDC(this.handle);

            AppDomain.CurrentDomain.ProcessExit += (s, e) => Shutdown();
            initialized = true;
        }

        private void Shutdown() {
            External.ReleaseDC(this.handle, this.dc);
        }

        public class External {

            [DllImport("Kernel32.dll")]
            public static extern IntPtr GetConsoleWindow();
            [DllImport("Kernel32.dll")]
            public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
            [DllImport("Kernel32.dll")]
            public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
            [DllImport("Kernel32.dll")]
            public static extern IntPtr GetStdHandle(uint nStdHandle);

            [DllImport("User32.dll")]
            public static extern IntPtr GetDC(IntPtr hWnd);
            [DllImport("User32.dll")]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("Gdi32.dll")]
            public static extern uint SetPixel(IntPtr hDC, int x, int y, uint color);
            [DllImport("Gdi32.dll")]
            public static extern uint GetPixel(IntPtr hDC, int x, int y);
            [DllImport("Gdi32.dll")]
            public static extern bool TextOutA(IntPtr hdc, int x, int y, string lpString, int c);

            public static uint STD_INPUT_HANDLE = 4294967286;

            public static uint ENABLE_ECHO_INPUT = 0x0004;
            public static uint ENABLE_QUICK_EDIT_MODE = 0x0040;
            public static uint ENABLE_WINDOW_INPUT = 0x0008;
            public static uint ENABLE_MOUSE_INPUT = 0x0010;
            public static uint ENABLE_EXTENDED_FLAGS = 0x0080;
        }
    }
}
