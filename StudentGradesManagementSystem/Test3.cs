using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesManagementSystem
{
    internal class Test3
    {
        public static void Run()
        {
            string padLeft = "";

            ConsoleColor[] colors =
{
    ConsoleColor.Cyan,      // 0 Borders
    ConsoleColor.Yellow,    // 1 Labels/Header
    ConsoleColor.White,     // 2 Values
    ConsoleColor.Magenta,   // 3 Title
    ConsoleColor.Green,     // 4 Passed
    ConsoleColor.Red,       // 5 Failed
    ConsoleColor.Blue,      // 6 Incomplete
    ConsoleColor.DarkYellow // 7 Pending
};

            string[] table =
            {
                "\n",
                padLeft + "╔══════════════════════════════════════════════════════════════════════════════════════════════════╗\n",
                padLeft + "║", "                                        2ND SEMESTER GRADES                                       ", "║\n",
                padLeft + "╠════╦══════════════╦═════════════════════════╦═══════╦═════════╦═══════════╦═════════╦════════════╣\n",
                padLeft + "║ ", "No", " ║ ", "Code", "         ║ ", "Subject", "                 ║ ", "Units", " ║ ", "MidTerm", " ║ ", "FinalTerm", " ║ ", "Average", " ║ ", "Remarks", "    ║\n",
                padLeft + "╠════╬══════════════╬═════════════════════════╬═══════╬═════════╬═══════════╬═════════╬════════════╣\n",
                padLeft + "║ ",
    "01",
    " ║ ",
    "IT 101",
    "       ║ ",
    "Introduction to Comp...",
    " ║   ",
    "3",
    "   ║ ",
    "1.50",
    "    ║ ",
    "1.50",
    "      ║ ",
    "1.50",
    "    ║ ",
    "PASSED",
    "     ║\n",

    // ROW 2
    padLeft + "║ ",
    "02",
    " ║ ",
    "IT 101L",
    "      ║ ",
    "Introduction to Comp...",
    " ║   ",
    "3",
    "   ║ ",
    "1.75",
    "    ║ ",
    "1.75",
    "      ║ ",
    "1.75",
    "    ║ ",
    "FAILED",
    "     ║\n",

    // ROW 3
    padLeft + "║ ",
    "03",
    " ║ ",
    "IT 103",
    "       ║ ",
    "Computer Programming 1",
    "  ║   ",
    "3",
    "   ║ ",
    "2.00",
    "    ║ ",
    "2.00",
    "      ║ ",
    "2.00",
    "    ║ ",
    "INCOMPLETE",
    " ║\n",

    // ROW 4
    padLeft + "║ ",
    "04",
    " ║ ",
    "GE-CC04",
    "      ║ ",
    "Mathematics in Moder...",
    " ║   ",
    "3",
    "   ║ ",
    "2.25",
    "    ║ ",
    "2.25",
    "      ║ ",
    "2.25",
    "    ║ ",
    "INCOMPLETE",
    " ║\n",

    // ROW 5
    padLeft + "║ ",
    "05",
    " ║ ",
    "PATHFit01",
    "    ║ ",
    "Movement Competency",
    "     ║   ",
    "3",
    "   ║ ",
    "1.25",
    "    ║ ",
    "1.25",
    "      ║ ",
    "1.25",
    "    ║ ",
    "PENDING",
    "    ║\n",

    // BOTTOM BORDER
    padLeft + "╠════╩══════════════╩═════════════════════════╩═══════╩═════════╩═══════════╩═════════╬════════════╣\n",

    // GENERAL AVERAGE
    padLeft + "║ ",
    "General Average",
    " : ",
    "N/A",
    "                                                               ║ ",
    "INCOMPLETE",
    " ║\n",

    // BOTTOM
    padLeft + "╚═════════════════════════════════════════════════════════════════════════════════════╩════════════╝\n"
};

            int[] colorIndexes =
            {
    // TOP
    0,
    0,

    // TITLE
    0, 3, 0,

    // HEADER BORDER
    0,

    // HEADERS
    0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,

    // HEADER BORDER
    0,

    // ROW 1
    0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 4, 0,

    // ROW 2
    0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 5, 0,

    // ROW 3
    0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 6, 0,

    // ROW 4
    0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 6, 0,

    // ROW 5
    0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 7, 0,

    // BOTTOM BORDER
    0,

    // GENERAL AVERAGE
    0, 1, 2, 2, 0, 6, 0,

    // BOTTOM
    0
};

            // PRINT
            for (int i = 0; i < table.Length; i++)
            {
                Console.ForegroundColor = colors[colorIndexes[i]];
                Console.Write(table[i]);
            }

            Console.ResetColor();

            string[] infoBox =
{
    // TOP
    padLeft + "╔═════════════════════════════════════════════════════════════════╦════════════════════════════════╗\n",

    // ROW 1
    padLeft + "║ ",
    "ID",
    "   : ",
    "123",
    "                                                      ║    ",
    "1-3",
    ": ",
    "PASSED",
    "    ",
    "8.8",
    ": ",
    "INC",
    "     ║\n",

    // ROW 2
    padLeft + "║ ",
    "Name",
    " : ",
    "John",
    "                                                     ║    ",
    "5.0",
    ": ",
    "FAILED",
    "    ",
    "9.9",
    ": ",
    "DRP",
    "     ║\n",

    // BOTTOM
    padLeft + "╚═════════════════════════════════════════════════════════════════╩════════════════════════════════╝\n"
};

            int[] infoBoxColors =
            {
    // TOP
    0,

    // ROW 1
    0, // ║
    1, // ID
    2, // :
    2, // 123
    0, // border

    1, // 1-3
    2, // :
    4, // PASSED

    1, // 8.8
    2, // :
    6, // INC

    0, // border

    // ROW 2
    0, // ║
    1, // Name
    2, // :
    2, // John
    0, // border

    1, // 5.0
    2, // :
    5, // FAILED

    1, // 9.9
    2, // :
    7, // DRP

    0, // border

    // BOTTOM
    0
};

            // PRINT
            for (int i = 0; i < infoBox.Length; i++)
            {
                Console.ForegroundColor = colors[infoBoxColors[i]];
                Console.Write(infoBox[i]);
            }

            Console.ResetColor();
        }
    }
}
