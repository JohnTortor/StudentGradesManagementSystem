using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesManagementSystem
{
    internal class Test
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Console Gradient Test";

            string[] art =
            {
            "██████╗ ██████╗      ██╗     ██╗",
            "██╔══██╗██╔══██╗     ██║     ██║",
            "██████╔╝██████╔╝     ██║     ██║",
            "██╔══██╗██╔══██╗██   ██║██   ██║",
            "██████╔╝██║  ██║╚█████╔╝╚█████╔╝",
            "╚═════╝ ╚═╝  ╚═╝ ╚════╝  ╚════╝"
        };

            Gradient("FIRE GRADIENT", art, new ConsoleColor[]
            {
            ConsoleColor.DarkRed,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Yellow,
            ConsoleColor.White,
            ConsoleColor.White
            });

            Gradient("OCEAN GRADIENT", art, new ConsoleColor[]
            {
            ConsoleColor.DarkBlue,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Cyan,
            ConsoleColor.Gray,
            ConsoleColor.White
            });

            Gradient("NEON CYBER", art, new ConsoleColor[]
            {
            ConsoleColor.DarkMagenta,
            ConsoleColor.Magenta,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.White,
            ConsoleColor.White
            });

            Gradient("FOREST", art, new ConsoleColor[]
            {
            ConsoleColor.DarkGreen,
            ConsoleColor.Green,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.Gray,
            ConsoleColor.White
            });

            Gradient("ROYAL", art, new ConsoleColor[]
            {
            ConsoleColor.DarkBlue,
            ConsoleColor.Blue,
            ConsoleColor.Magenta,
            ConsoleColor.DarkMagenta,
            ConsoleColor.Gray,
            ConsoleColor.White
            });

            Gradient("SUNSET", art, new ConsoleColor[]
            {
            ConsoleColor.DarkRed,
            ConsoleColor.Red,
            ConsoleColor.DarkYellow,
            ConsoleColor.Yellow,
            ConsoleColor.Gray,
            ConsoleColor.White
            });

            Gradient("ICE", art, new ConsoleColor[]
            {
            ConsoleColor.DarkCyan,
            ConsoleColor.Cyan,
            ConsoleColor.Gray,
            ConsoleColor.White,
            ConsoleColor.White,
            ConsoleColor.White
            });

            Gradient("MATRIX", art, new ConsoleColor[]
            {
            ConsoleColor.Black,
            ConsoleColor.DarkGreen,
            ConsoleColor.Green,
            ConsoleColor.Green,
            ConsoleColor.Gray,
            ConsoleColor.White
            });

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void Gradient(string title, string[] art, ConsoleColor[] colors)
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine(title);
            Console.WriteLine("========================================");
            Console.WriteLine();

            for (int y = 0; y < art.Length; y++)
            {
                //string line = art[y];

                //for (int x = 0; x < line.Length; x++)
                //{
                //    int colorIndex = x * colors.Length / line.Length;

                //    Console.ForegroundColor = colors[colorIndex];
                //    Console.Write(line[x]);
                //}

                Console.ForegroundColor = colors[y];
                Console.WriteLine(art[y]);
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
