using System;

namespace StudentGradesManagementSystem
{
    internal class Test2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Console Gradient Test";

            string[] art =
            {
                "██████╗ ██████╗ ██╗   ██╗",
                "██╔══██╗██╔══██╗██║   ██║",
                "██████╔╝██████╔╝██║   ██║",
                "██╔══██╗██╔══██╗██║   ██║",
                "██████╔╝██║  ██║╚██████╔╝",
                "╚═════╝ ╚═╝  ╚═╝ ╚═════╝ "
            };

            // ===== EPIC GRADIENTS =====

            Gradient("🔥 FIRE", art, new ConsoleColor[]
            {
                ConsoleColor.DarkRed,
                ConsoleColor.Red,
                ConsoleColor.DarkYellow,
                ConsoleColor.Yellow,
                ConsoleColor.White
            });

            Gradient("🌊 OCEAN", art, new ConsoleColor[]
            {
                ConsoleColor.DarkBlue,
                ConsoleColor.Blue,
                ConsoleColor.Cyan,
                ConsoleColor.White
            });

            Gradient("🌌 GALAXY", art, new ConsoleColor[]
            {
                ConsoleColor.DarkMagenta,
                ConsoleColor.Magenta,
                ConsoleColor.Blue,
                ConsoleColor.Cyan,
                ConsoleColor.White
            });

            Gradient("🌇 SUNSET", art, new ConsoleColor[]
            {
                ConsoleColor.DarkRed,
                ConsoleColor.Red,
                ConsoleColor.DarkYellow,
                ConsoleColor.Yellow,
                ConsoleColor.White
            });

            Gradient("💚 MATRIX", art, new ConsoleColor[]
            {
                ConsoleColor.Black,
                ConsoleColor.DarkGreen,
                ConsoleColor.Green,
                ConsoleColor.White
            });

            Gradient("🌈 RAINBOW", art, new ConsoleColor[]
            {
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Blue,
                ConsoleColor.Magenta
            });

            Gradient("❄ ICE", art, new ConsoleColor[]
            {
                ConsoleColor.DarkCyan,
                ConsoleColor.Cyan,
                ConsoleColor.White
            });

            Gradient("⚡ ELECTRIC", art, new ConsoleColor[]
            {
                ConsoleColor.DarkBlue,
                ConsoleColor.Blue,
                ConsoleColor.Yellow,
                ConsoleColor.White
            });

            Gradient("👑 GOLD ROYAL", art, new ConsoleColor[]
            {
                ConsoleColor.DarkYellow,
                ConsoleColor.Yellow,
                ConsoleColor.White
            });

            Gradient("🌸 PINK VIBES", art, new ConsoleColor[]
            {
                ConsoleColor.DarkMagenta,
                ConsoleColor.Magenta,
                ConsoleColor.Red,
                ConsoleColor.White
            });

            Gradient("☠ SHADOW", art, new ConsoleColor[]
            {
                ConsoleColor.Black,
                ConsoleColor.DarkGray,
                ConsoleColor.Gray,
                ConsoleColor.White
            });

            Gradient("🟣 ULTRAVIOLET", art, new ConsoleColor[]
            {
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkMagenta,
                ConsoleColor.Magenta,
                ConsoleColor.White
            });

            // 🌋 VOLCANO
            Gradient("🌋 VOLCANO", art, new ConsoleColor[]
            {
    ConsoleColor.Black,
    ConsoleColor.DarkRed,
    ConsoleColor.Red,
    ConsoleColor.Yellow,
    ConsoleColor.White
            });

            // 🌲 FOREST
            Gradient("🌲 FOREST", art, new ConsoleColor[]
            {
    ConsoleColor.DarkGreen,
    ConsoleColor.Green,
    ConsoleColor.DarkYellow,
    ConsoleColor.Yellow
            });

            // 🌌 DEEP SPACE
            Gradient("🌌 DEEP SPACE", art, new ConsoleColor[]
            {
    ConsoleColor.Black,
    ConsoleColor.DarkBlue,
    ConsoleColor.Blue,
    ConsoleColor.DarkMagenta,
    ConsoleColor.Magenta,
    ConsoleColor.White
            });

            // 💎 DIAMOND
            Gradient("💎 DIAMOND", art, new ConsoleColor[]
            {
    ConsoleColor.DarkGray,
    ConsoleColor.Gray,
    ConsoleColor.Cyan,
    ConsoleColor.White
            });

            // ☢ RADIOACTIVE
            Gradient("☢ RADIOACTIVE", art, new ConsoleColor[]
            {
    ConsoleColor.DarkGreen,
    ConsoleColor.Green,
    ConsoleColor.Yellow,
    ConsoleColor.White
            });

            // 🌠 COSMIC
            Gradient("🌠 COSMIC", art, new ConsoleColor[]
            {
    ConsoleColor.DarkBlue,
    ConsoleColor.Blue,
    ConsoleColor.Magenta,
    ConsoleColor.Red,
    ConsoleColor.Yellow,
    ConsoleColor.White
            });

            // 🩸 BLOOD MOON
            Gradient("🩸 BLOOD MOON", art, new ConsoleColor[]
            {
    ConsoleColor.Black,
    ConsoleColor.DarkRed,
    ConsoleColor.Red,
    ConsoleColor.DarkMagenta,
    ConsoleColor.White
            });

            // 🧊 FROST
            Gradient("🧊 FROST", art, new ConsoleColor[]
            {
    ConsoleColor.DarkBlue,
    ConsoleColor.Blue,
    ConsoleColor.Cyan,
    ConsoleColor.Gray,
    ConsoleColor.White
            });

            // 🔮 MYSTIC
            Gradient("🔮 MYSTIC", art, new ConsoleColor[]
            {
    ConsoleColor.DarkMagenta,
    ConsoleColor.Magenta,
    ConsoleColor.Blue,
    ConsoleColor.Cyan
            });

            // 🌋 LAVA FLOW
            Gradient("🌋 LAVA FLOW", art, new ConsoleColor[]
            {
    ConsoleColor.DarkRed,
    ConsoleColor.Red,
    ConsoleColor.DarkYellow,
    ConsoleColor.Yellow,
    ConsoleColor.White
            });

            // 🌃 NIGHT CITY
            Gradient("🌃 NIGHT CITY", art, new ConsoleColor[]
            {
    ConsoleColor.Black,
    ConsoleColor.DarkBlue,
    ConsoleColor.Blue,
    ConsoleColor.Cyan,
    ConsoleColor.White
            });

            // 👻 GHOST
            Gradient("👻 GHOST", art, new ConsoleColor[]
            {
    ConsoleColor.Black,
    ConsoleColor.DarkGray,
    ConsoleColor.Gray,
    ConsoleColor.White
            });

            // 💜 VAPORWAVE
            Gradient("💜 VAPORWAVE", art, new ConsoleColor[]
            {
    ConsoleColor.Magenta,
    ConsoleColor.Blue,
    ConsoleColor.Cyan,
    ConsoleColor.White
            });

            // ☀ SOLAR FLARE
            Gradient("☀ SOLAR FLARE", art, new ConsoleColor[]
            {
    ConsoleColor.DarkRed,
    ConsoleColor.Red,
    ConsoleColor.Yellow,
    ConsoleColor.White
            });

            // 🌊 TSUNAMI
            Gradient("🌊 TSUNAMI", art, new ConsoleColor[]
            {
    ConsoleColor.DarkBlue,
    ConsoleColor.Blue,
    ConsoleColor.Cyan,
    ConsoleColor.Gray,
    ConsoleColor.White
            });

            // 🧪 TOXIC
            Gradient("🧪 TOXIC", art, new ConsoleColor[]
            {
    ConsoleColor.DarkGreen,
    ConsoleColor.Green,
    ConsoleColor.Yellow,
    ConsoleColor.White
            });

            // ⚔ WARZONE
            Gradient("⚔ WARZONE", art, new ConsoleColor[]
            {
    ConsoleColor.Black,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkRed,
    ConsoleColor.Red,
    ConsoleColor.White
            });

            // 🌈 HYPER RAINBOW
            Gradient("🌈 HYPER RAINBOW", art, new ConsoleColor[]
            {
    ConsoleColor.Red,
    ConsoleColor.DarkYellow,
    ConsoleColor.Yellow,
    ConsoleColor.Green,
    ConsoleColor.Cyan,
    ConsoleColor.Blue,
    ConsoleColor.Magenta,
    ConsoleColor.White
            });

            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void Gradient(string title, string[] art, ConsoleColor[] colors)
        {
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("══════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"        {title}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine();

            for (int y = 0; y < art.Length; y++)
            {
                double colorIndex =
                    y * (colors.Length - 1.0) / (art.Length - 1);

                Console.ForegroundColor =
                    colors[(int)Math.Round(colorIndex)];

                Console.WriteLine("   " + art[y]);
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}