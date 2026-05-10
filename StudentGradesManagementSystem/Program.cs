using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentGradesManagementSystem
{
    internal class Program
    {
        public static string[,] STUDENTS = new string[15, 22] 
        { 
            { "123", "John", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "124", "Alex", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "125", "Steve", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "126", "Herobrine", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "127", "Notch", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "128", "Entity", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "129", "Ang", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "130", "Zuko", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "131", "Toph", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "132", "Soka", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "133", "Katara", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "134", "Suki", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "135", "Appa", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "136", "Kyoshi", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
            { "137", "Korra", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
        };
        //public static string[,] STUDENTS = new string[0, 22];
        public static string[,,] SUBJECTS =
            {
                {
                    { "IT 101", "Introduction to Computing" },
                    { "IT 101L", "Introduction to Computing" },
                    { "IT 103", "Computer Programming 1" },
                    { "IT 103L", "Computer Programming 1" },
                    { "GE-CC04", "Mathematics in the Modern World" },
                    { "GE-CC05", "Purposive Communication" },
                    { "GE-CC01", "Understanding the Self" },
                    { "GE-CC08", "Ethics" },
                    { "PATHFit01", "Movement Competency Training" },
                    { "NSTP-CW 101", "Civil Welfare Training Service 1" }
                },
                {
                    { "IT 102", "Human Computer Interaction" },
                    { "IT 102L", "Human Computer Interaction" },
                    { "IT 104", "Computer Programming 2" },
                    { "IT 104L", "Computer Programming 2" },
                    { "IT 106", "Discrete Mathematics" },
                    { "GE-CC02", "Reading in Philippine History" },
                    { "GE-CC07", "Science Technology and Society" },
                    { "GE-CC03", "The Contemporary World" },
                    { "PATHFit02", "Exercise-Based Fitness Activities" },
                    { "NSTP-CW 102", "Civic Welfare Training Service 2" }
                }
            };

        public static int DefaultBoxWidth = 40;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Program_v2.Run();
            //Test3.Run();
            return;

            //Test2.Run();
            //return;

            //WaitFullScreen();
            //Console.WriteLine("\n");
            //Console.ForegroundColor = ConsoleColor.DarkBlue;
            //Console.WriteLine(CenterText("██████╗ ██████╗      ██╗     ██╗     ██████╗ ██████╗  █████╗ ██████╗ ███████╗███╗   ███╗ █████╗ ███╗   ██╗ █████╗  ██████╗ ███████╗██████╗ ", Console.BufferWidth));
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine(CenterText("██╔══██╗██╔══██╗     ██║     ██║    ██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝████╗ ████║██╔══██╗████╗  ██║██╔══██╗██╔════╝ ██╔════╝██╔══██╗", Console.BufferWidth));
            //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine(CenterText("██████╔╝██████╔╝     ██║     ██║    ██║  ███╗██████╔╝███████║██║  ██║█████╗  ██╔████╔██║███████║██╔██╗ ██║███████║██║  ███╗█████╗  ██████╔╝", Console.BufferWidth));
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(CenterText("██╔══██╗██╔══██╗██   ██║██   ██║    ██║   ██║██╔══██╗██╔══██║██║  ██║██╔══╝  ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══██╗", Console.BufferWidth));
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine(CenterText("██████╔╝██║  ██║╚█████╔╝╚█████╔╝    ╚██████╔╝██║  ██║██║  ██║██████╔╝███████╗██║ ╚═╝ ██║██║  ██║██║ ╚████║██║  ██║╚██████╔╝███████╗██║  ██║", Console.BufferWidth));
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(CenterText("╚═════╝ ╚═╝  ╚═╝ ╚════╝  ╚════╝      ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝", Console.BufferWidth));
            //Console.ResetColor();

            ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.DarkCyan, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Gray };
            Console.WriteLine("\n");

            int[] restartState = GetConsoleState();

            while (true)
            {
                int operation = OptionPicker(new string[] { "Add Student", "Manage Student Grades", "View Grades by Subject", "Check Grades Records", "Search Students", "Delete Student", "Exit" }, "STUDENT GRADE MANAGEMENT SYSTEM", colors);

                GoBack(restartState);

                if (operation == 1)
                {
                    while (true)
                    {
                        int boxWidth;
                        string padLeft;

                        string id = "";
                        string name = "";
                        bool nameExists = false;
                        bool idExists = false;
                        int[] state = GetConsoleState();

                        while (true)
                        {
                            //int boxWidth = Math.Max(id.Length, name.Length) + 11;
                            boxWidth = DefaultBoxWidth;
                            padLeft = new string(' ', Console.BufferWidth / 2 - boxWidth / 2);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╔" + new string('═', boxWidth) + "╗");
                            Console.Write(padLeft + "║  ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("ID   : " + id.PadRight(boxWidth - 11));
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("  ║");
                            Console.Write(padLeft + "║  ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Name : " + name.PadRight(boxWidth - 11));
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("  ║");
                            Console.WriteLine(padLeft + "╚" + new string('═', boxWidth) + "╝");

                            Console.WriteLine();
                            if (idExists || nameExists)
                            {
                                idExists = false;
                                nameExists = false;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(padLeft + "✗ Already exists. Try again.");
                            }

                            Console.ForegroundColor = ConsoleColor.White;
                            if (id == "")
                            {
                                Console.Write(padLeft + "➤ Enter ID: ");
                                id = Console.ReadLine();

                                for (int i = 0; i < STUDENTS.GetLength(0); i++)
                                {
                                    if (id == STUDENTS[i, 0])
                                    {
                                        nameExists = true;
                                        id = "";
                                        break;
                                    }
                                }
                            }
                            else if (name == "")
                            {
                                Console.Write(padLeft + "➤ Enter Name: ");
                                name = Console.ReadLine();

                                for (int i = 0; i < STUDENTS.GetLength(0); i++)
                                {
                                    if (name == STUDENTS[i, 1])
                                    {
                                        nameExists = true;
                                        name = "";
                                        break;
                                    }
                                }
                            }
                            else
                                break;

                            GoBack(state);
                        }

                        int option = OptionPicker(new string[] { "Yes", "No", "Try again" }, "Continue adding student?", new ConsoleColor[] { ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Gray }, boxWidth);

                        if (option == 1)
                        {
                            int rows = STUDENTS.GetLength(0);
                            int cols = STUDENTS.GetLength(1);

                            string[,] update = new string[rows + 1, cols];

                            for (int i = 0; i < rows; i++)
                                for (int j = 0; j < cols; j++)
                                    update[i, j] = STUDENTS[i, j];

                            //for (int j = 2; j < cols; j++)
                            //    newArray[rows, j] = "0";
                            update[rows, 0] = id;
                            update[rows, 1] = name;

                            STUDENTS = update;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n" + padLeft + "Successfully added student.\n\n");
                            Console.ResetColor();

                            option = OptionPicker(new string[] { "Add another student", "Manage student grades", "Exit" }, null, new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Gray }, boxWidth);

                            if (option == 1)
                                GoBack(restartState);
                            else if (option == 2)
                                break;
                            else
                                break;
                        }
                        else if (option == 2)
                            break;
                        else
                            GoBack(restartState);
                    }
                }
                else if (operation == 2)
                {
                    int student = PickStudent();
                    
                    if (student != -1)
                    {
                        ManageStudentGrades(student);
                    }
                }

                GoBack(restartState);
            }
        }

        public static void ManageStudentGrades(int index)
        {
            int[] startState = GetConsoleState();

            int boxWidth = 60;
            string padLeft = new string(' ', Console.BufferWidth / 2 - boxWidth / 2);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(padLeft + "╔" + new string('═', boxWidth) + "╗");
            Console.Write(padLeft + "║  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ID   : " + STUDENTS[index, 0].PadRight(boxWidth - 11));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ║");
            Console.Write(padLeft + "║  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Name : " + STUDENTS[index, 1].PadRight(boxWidth - 11));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ║");
            Console.WriteLine(padLeft + "╚" + new string('═', boxWidth) + "╝");

            string[] options = new string[SUBJECTS.GetLength(1)];
            string[] options2 = new string[SUBJECTS.GetLength(1)];

            for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                options[i] = SUBJECTS[0, i, 0].PadRight(13) + SUBJECTS[0, i, 1];

            for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                options2[i] = SUBJECTS[1, i, 0].PadRight(13) + SUBJECTS[0, i, 1];

            DisplayOptions(options, "First Semester", null, boxWidth);
            Console.WriteLine();
            DisplayOptions(options2, "Second Semester", null, boxWidth);
            Console.ReadKey();
            //while (true)
            //{
            //}
        }

        public static void displayBox()
        {

        }

        public static int PickStudent(int page = 1)
        {
            int[] startState = GetConsoleState();
            if (STUDENTS.GetLength(0) == 0)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(CenterText("There is no students yet.", Console.BufferWidth));
                Console.ResetColor();
                Console.WriteLine("\n\n" + CenterText("Press any key to return...", Console.BufferWidth));
                Console.ReadKey();
                GoBack(startState);
                Console.CursorVisible = true;
                return -1;
            }

            int max = 9;
            int pages = Convert.ToInt32(Math.Ceiling(STUDENTS.GetLength(0) * 1m / max));
            int pickedOption = -1;

            while (pickedOption == -1)
            {
                string[] options;
                int index = 0;

                if (pages > 1)
                {
                    if (page == 1)
                    {
                        options = new string[max + 1];
                        options[options.Length - 1] = "Next Page";
                    }
                    else if (page == pages)
                    {
                        options = new string[STUDENTS.GetLength(0) % max + 1];
                        options[options.Length - 1] = "Previus Page";
                    }
                    else
                    {
                        options = new string[max + 2];
                        options[options.Length - 2] = "Previus Page";
                        options[options.Length - 1] = "Next Page";

                    }

                    for (int i = 0; i < max; i++)
                    {
                        if (max * (page - 1) + i < STUDENTS.GetLength(0))
                        {
                            //options[i, 0] = STUDENTS[max * (page - 1) + i, 0];
                            options[i] = STUDENTS[max * (page - 1) + i, 1];
                            index++;
                        }
                    }
                }
                else
                {
                    options = new string[STUDENTS.GetLength(0)];

                    for (int i = 0; i < STUDENTS.GetLength(0); i++)
                    {
                        options[i] = STUDENTS[i, 1];
                        index++;
                    }
                }

                int boxWidth = DefaultBoxWidth;
                DisplayOptions(options, "Pick Student", null, boxWidth);
                Console.WriteLine();
                string padLeft = new string(' ', Console.BufferWidth / 2 - boxWidth / 2);

                int[] restartState = GetConsoleState();
                bool firstAttempt = true;
                bool usedOption = true;
                while (true)
                {
                    try
                    {
                        if (!firstAttempt)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(padLeft + "✗ Not found. Try again.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write(padLeft + "➤ Enter option/ID/name: ");
                        if (Console.CursorTop >= Console.WindowHeight - 1)
                            restartState[1]--;
                        string input = Console.ReadLine();

                        bool found = false;
                        for (int i = 0; i < STUDENTS.GetLength(0); i++)
                        {
                            if (input == STUDENTS[i, 0] || input == STUDENTS[i, 1])
                            {
                                pickedOption = i;
                                usedOption = false;
                                found = true;
                                break;
                            }
                        }
                        if (found)
                            break;

                        int option = int.Parse(input);

                        if (option > 0 && option <= index)
                        {
                            pickedOption = option;
                            break;
                        }
                        else if (option <= options.Length && options[option - 1] == "Next Page")
                        {
                            page++;
                            break;
                        }
                        else if (option <= options.Length && options[option - 1] == "Previus Page")
                        {
                            page--;
                            break;
                        }

                        firstAttempt = false;
                        GoBack(restartState);
                    }
                    catch (FormatException)
                    {
                        firstAttempt = false;
                        GoBack(restartState);
                    }
                }

                GoBack(startState);

                if (pickedOption != -1 && usedOption)
                    pickedOption += max * (page - 1) - 1;
            }

            return pickedOption;
        }

        //public static void DisplayIDName(string id, string name)
        //{
        //    string padLeft = new string(' ', Console.BufferWidth / 2 - boxWidth / 2);

        //    Console.WriteLine(padLeft + "╔" + new string('═', boxWidth) + "╗");
        //    for (int i = 0; i < py; i++)
        //        Console.WriteLine(padLeft + "║" + new string(' ', boxWidth - 2) + "║");

        //    Console.WriteLine(padLeft + "║" + new string(' ', px));
        //    for (int i = 0; i < content.Length; i++)
        //    {
        //        if (content[i] == "\n")
        //            Console.WriteLine(new string(' ', px) + )
        //        else
        //        {

        //        }
        //    }
        //}

        public static int OptionPicker(string[] options, string label, ConsoleColor[] optionsColor = null, int boxWidth = 0, string prefix = "   ")
        {
            if (boxWidth == 0)
                boxWidth = DefaultBoxWidth;
            int[] resetState = GetConsoleState();
            DisplayOptions(options, label, optionsColor, boxWidth, prefix);
            string padLeft = new string(' ', Console.BufferWidth / 2 - boxWidth / 2);

            int[] restartState = GetConsoleState();
            int pickedOption;
            bool firstAttempt = true;
            while (true)
            {
                Console.WriteLine();
                try
                {
                    if (!firstAttempt)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(padLeft + "✗ Invalid option. Try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(padLeft + "➤ Pick option: ");
                    if (Console.CursorTop >= Console.WindowHeight - 1)
                        restartState[1]--;
                    pickedOption = int.Parse(Console.ReadLine());

                    if (pickedOption > 0 && pickedOption <= options.Length)
                        break;

                    firstAttempt = false;
                    GoBack(restartState);
                }
                catch (FormatException)
                {
                    firstAttempt = false;
                    GoBack(restartState);
                }
            }

            GoBack(resetState);
            return pickedOption;
        }

        public static void DisplayOptions(string[] options, string label, ConsoleColor[] optionsColor = null, int boxWidth = 0, string prefix = "   ")
        {
            if (boxWidth == 0)
                boxWidth = DefaultBoxWidth;
            string padLeft = new string(' ', Console.BufferWidth / 2 - boxWidth / 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(padLeft + "╔" + new string('═', boxWidth) + "╗");

            if (label != null)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                string labelPad = new string(' ', (boxWidth - label.Length) / 2);
                Console.Write(padLeft + "║" + labelPad + label + labelPad);

                if (label.Length % 2 == 0)
                    Console.WriteLine("║");
                else
                    Console.WriteLine(" ║");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(padLeft + "╠" + new string('═', boxWidth) + "╣");
            }

            for (int i = 0; i < options.Length; i++)
            {
                Console.Write(padLeft + "║" + prefix);

                int optionLen = prefix.Length + options[i].Length + 4;
                if (optionsColor == null)
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = optionsColor[i % optionsColor.Length];
                Console.Write("[");

                if (options.Length > 9 && i <= 8)
                    Console.Write("0" + (i + 1) + "] ");
                else
                    Console.Write(i + 1 + "] ");

                Console.Write(options[i] + new string(' ', boxWidth - optionLen - Math.Min(1, options.Length / 10)));
                //Console.Write(options[i] + new string(' ', boxWidth - optionLen));

                //Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("║");
            }

            Console.WriteLine(padLeft + "╚" + new string('═', boxWidth) + "╝");
            Console.ResetColor();
        }

        public static void GoBack(int[] state)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            // The number of characters that was used
            int length = (Console.BufferWidth - state[0] + left + 2) + (top - state[1] - 1) * Console.BufferWidth;

            // Clearing the console up to the saved position startLeft and startTop
            Console.SetCursorPosition(state[0], state[1]);
            Console.Write(new string(' ', length));
            Console.SetCursorPosition(state[0], state[1]);
        }

        public static int[] GetConsoleState()
        {
            return new int[] { Console.CursorLeft, Console.CursorTop };
        }

        public static string CenterText(string text, int width)
        {
            if (width < text.Length)
                return text;

            return new string(' ', (int) Math.Floor(width / 2.0 - text.Length / 2.0)) + text + new string(' ', (int) Math.Ceiling(width / 2.0 - text.Length / 2.0));
        }

        public static void WaitFullScreen()
        {
            int startWidth = Console.WindowWidth;
            int startHeight = Console.WindowHeight;
            Console.CursorVisible = false;

            while (
                startWidth == Console.WindowWidth ||
                startHeight == Console.WindowHeight)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.Write(new string('\n', Console.WindowHeight / 2 - 1));
                Console.WriteLine(new string(' ', (Console.BufferWidth / 2 - 18)) + "Please maximize the console window...");
                Console.Write(new string(' ', (Console.BufferWidth / 2 - 13)) + "Press Q to continue anyway");

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
                    break;

                Thread.Sleep(50);
            }

            Console.CursorVisible = true;
            Console.Clear();
        }
    }
}
