using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using con2d;
using con2d.Graphics;
using con2d.Utils;

namespace con2d.Test {

    class Program {

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        static int x = 100;
        static int y = 100;
        static ConsoleKey key;
        static bool run = false;
        static int speed = 1;
        static bool russia = false;
        static Con2D con2d;

        static void Main(string[] args) {
            if(con2d == null) {
                con2d = new Con2D();
                con2d.Initialize();
            }
            con2d.Title = "purplesnek";
            Console.Clear();
            Console.CursorLeft = 50;
            Console.CursorTop = 10;
            Console.WriteLine("purplesnek");
            Console.CursorLeft = 40;
            Console.CursorTop = 11;
            Console.WriteLine("choose difficulty");
            Console.CursorLeft = 40;
            Console.CursorTop = 12;
            Console.WriteLine("1. baby mode");
            Console.CursorLeft = 40;
            Console.CursorTop = 13;
            Console.WriteLine("2. easy");
            Console.CursorLeft = 40;
            Console.CursorTop = 14;
            Console.WriteLine("3. medium");
            Console.CursorLeft = 40;
            Console.CursorTop = 15;
            Console.WriteLine("4. hard");
            Console.CursorLeft = 40;
            Console.CursorTop = 16;
            Console.WriteLine("5. hell");
            Console.CursorLeft = 40;
            Console.CursorTop = 17;
            Console.WriteLine("6. russia");
            key = Console.ReadKey().Key;

            switch(key) {
                case ConsoleKey.D1:
                    speed = 1;
                    break;
                case ConsoleKey.D2:
                    speed = 3;
                    break;
                case ConsoleKey.D3:
                    speed = 5;
                    break;
                case ConsoleKey.D4:
                    speed = 9;
                    break;
                case ConsoleKey.D5:
                    speed = 15;
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    Console.CursorLeft = 30;
                    Console.CursorTop = 15;
                    
                    Console.WriteLine("epilepsy warning are u sure u want to continue? y/n");
                    key = Console.ReadKey().Key;
                    switch(key) {
                        case ConsoleKey.Y:
                            russia = true;
                            break;
                        case ConsoleKey.N:
                            MessageBox(new IntPtr(0), "no", "purplesnek", 0);
                            Main(null);
                            break;
                        default:
                            MessageBox(new IntPtr(0), "no", "purplesnek", 0);
                            Main(null);
                            break;
                    }
                    break;
                default:
                    MessageBox(new IntPtr(0), "no", "purplesnek", 0);
                    Main(null);
                    break;
            }

            Console.Clear();

            Console.CursorLeft = 40;
            Console.CursorTop = 10;
            Console.Write("wsad to move press any key to start");
            key = Console.ReadKey().Key;
            Console.Clear();
            run = true;
            if (russia) RussianLoop(); else Loop();
        }

        static Direction dir;

        static void RussianLoop() {
            Random r = new Random();
            do {
                Console.CursorLeft = 1;
                Console.CursorTop = Console.WindowHeight - 2;
                Console.Write("points: " + points);
                if (Console.KeyAvailable) {
                    key = Console.ReadKey(true).Key;
                }

                if (key == ConsoleKey.W) {
                    y -= speed;
                    dir = Direction.UP;
                }

                if (key == ConsoleKey.S) {
                    y += speed;
                    dir = Direction.DOWN;
                }

                if (key == ConsoleKey.A) {
                    x -= speed;
                    dir = Direction.LEFT;
                }

                if (key == ConsoleKey.D) {
                    x += speed;
                    dir = Direction.RIGHT;
                }


                if (wapple == 0) {
                    xapple = rx.Next(30, 790);
                    yapple = rx.Next(30, 390);



                    while (Point.GetPoint(xapple, yapple).Compare(new Color(128, 0, 128))) {
                        xapple = rx.Next(30, 790);
                        yapple = rx.Next(30, 390);
                    }

                    wapple = 1;
                }

                if (wapple == 1) {
                    Rectangle.Draw(xapple, yapple, 8, 8, new Color(255, 0, 0));

                    System.Windows.Rect p = new System.Windows.Rect(x, y, 32, 32);
                    System.Windows.Rect a = new System.Windows.Rect(xapple, yapple, 8, 8);

                    if (p.IntersectsWith(a)) {
                        points++;
                        wapple = 0;
                    }
                }


                if ((x <= 20) || (x >= 810) || (y <= 20) || (y >= 410)) {
                    run = false;
                    Console.CursorLeft = 40;
                    Console.CursorTop = 10;
                    Console.Write("ouch ouch u died rip press any key to exit");
                    key = Console.ReadKey().Key;
                    Main(null);
                }


                Rectangle.Draw(20, 20, 800, 400, new Color(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)), true);
                Rectangle.Draw(x, y, 32, 32, new Color(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                Console.Title = string.Format("{0} russiansnake {0}", RandomString(30));
                speed = r.Next(0, 20);
                //Console.Clear();
            } while (run);
        }

        static int walked = 0;
        static ConsoleKey ke;
        static int wapple = 0;
        static int xapple = 0;
        static int yapple = 0;
        static int points = 0;

        static void Loop() {
            do {
                Console.CursorLeft = 1;
                Console.CursorTop = Console.WindowHeight - 2;
                Console.Write("points: " + points);
                if (Console.KeyAvailable) {
                    key = Console.ReadKey(true).Key;
                    ke = key;
                } else {
                    ke = ConsoleKey.Enter;
                }

                if(key == ConsoleKey.W) {
                    walked += speed;
                    dir = Direction.UP;
                    y -= speed;
                }

                if(key == ConsoleKey.S) {
                    walked += speed;
                    dir = Direction.DOWN;
                    y += speed;
                }

                if(key == ConsoleKey.A) {
                    walked += speed;
                    dir = Direction.LEFT;
                    x -= speed;
                }

                if(key == ConsoleKey.D) {
                    walked += speed;
                    dir = Direction.RIGHT;
                    x += speed;
                }

                if (ke == ConsoleKey.W) {
                    walked = 0;
                }

                if (ke == ConsoleKey.S) {
                    walked = 0;
                }

                if (ke == ConsoleKey.A) {
                    walked = 0;
                }

                if (ke == ConsoleKey.D) {
                    walked = 0;
                }

                if ((x <= 20) || (x >= 810) || (y <= 20) || (y >= 410)) {
                    run = false;
                    Console.CursorLeft = 40;
                    Console.CursorTop = 10;
                    Console.Write("ouch ouch u died rip press any key to exit");
                    key = Console.ReadKey().Key;
                    Main(null);
                }

                

                Rectangle.Draw(20, 20, 800, 400, new Color(255, 255, 255), true);
                Rectangle.Draw(x, y, 32, 32, new Color(128, 0, 128));


                if(wapple == 0) {
                    xapple = rx.Next(30, 790);
                    yapple = rx.Next(30, 390);

                    

                    while(Point.GetPoint(xapple, yapple).Compare(new Color(128, 0, 128))) {
                        xapple = rx.Next(30, 790);
                        yapple = rx.Next(30, 390);
                    }

                    wapple = 1;
                }

                if(wapple == 1) {
                    Rectangle.Draw(xapple, yapple, 8, 8, new Color(255, 0, 0));

                    System.Windows.Rect p = new System.Windows.Rect(x, y, 32, 32);
                    System.Windows.Rect a = new System.Windows.Rect(xapple, yapple, 8, 8);

                    if(p.IntersectsWith(a)) {
                        points++;
                        wapple = 0;
                    }
                }

                if(walked > 33) {
                    //walked = 0;
                    switch (dir) {
                        case Direction.UP:
                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + i, y - 1).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x - 1, y + i).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + 32 + 1, y + i).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }
                            break;
                        case Direction.DOWN:

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + i, y + 33).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x - 1, y + i).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + 32 + 1, y + i).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }
                            break;
                        case Direction.LEFT:
                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + i, y - 1).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + i, y + 33).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x - 1, y + i).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }
                            break;
                        case Direction.RIGHT:
                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + i, y - 1).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + i, y + 33).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }

                            for (int i = 0; i < 32; i++) {
                                if (Point.GetPoint(x + 32 + 1, y + i).Compare(new Color(128, 0, 128))) {
                                    run = false;
                                    Console.CursorLeft = 40;
                                    Console.CursorTop = 10;
                                    Console.Write("ouch ouch u died rip press any key to exit");
                                    key = Console.ReadKey().Key;
                                    Main(null);
                                }
                            }
                            break;
                    }
                }


                //Console.Clear();
            } while (run) ;
        }

        static Random rx = new Random();

        public static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()`~-=[]\\;',./_+{}|:\"<>?";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rx.Next(s.Length)]).ToArray());
        }

        enum Direction {

            UP, DOWN, LEFT, RIGHT
        }
    }
}
