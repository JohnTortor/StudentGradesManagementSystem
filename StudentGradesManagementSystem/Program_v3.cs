using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentGradesManagementSystem
{
    internal class Program_v3
    {
        public static string[,] STUDENTS = new string[0, 42];
        public static string[,,] SUBJECTS =
            {
                {
                    { "IT 101", "Introduction to Computing", "3" },
                    { "IT 101L", "Introduction to Computing", "3" },
                    { "IT 103", "Computer Programming 1", "3" },
                    { "IT 103L", "Computer Programming 1", "3" },
                    { "GE-CC04", "Mathematics in the Modern World", "3" },
                    { "GE-CC05", "Purposive Communication", "3" },
                    { "GE-CC01", "Understanding the Self", "3" },
                    { "GE-CC08", "Ethics", "3" },
                    { "PATHFit01", "Movement Competency Training", "3" },
                    { "NSTP-CW 101", "Civil Welfare Training Service 1", "3" }
                },
                {
                    { "IT 102", "Human Computer Interaction", "3" },
                    { "IT 102L", "Human Computer Interaction", "3" },
                    { "IT 104", "Computer Programming 2", "3" },
                    { "IT 104L", "Computer Programming 2", "3" },
                    { "IT 106", "Discrete Mathematics", "3" },
                    { "GE-CC02", "Reading in Philippine History", "3" },
                    { "GE-CC07", "Science Technology and Society", "3" },
                    { "GE-CC03", "The Contemporary World", "3" },
                    { "PATHFit02", "Exercise-Based Fitness Activities", "3" },
                    { "NSTP-CW 102", "Civic Welfare Training Service 2", "3" }
                }
            };

        public static void Run()
        {
            Debug();
            while (true)
            {
                int op = GetOperation();

                if (op == 1)
                {
                    int boxWidth;
                    string padLeft;

                    string id = "";
                    string name = "";
                    bool nameExists = false;
                    bool idExists = false;
                    bool tryAgain = true;
                    bool continueAdd = false;

                    while (true)
                    {
                        while (true)
                        {
                            boxWidth = Math.Max(Math.Max(id.Length, name.Length) + 11, 30);
                            //boxWidth = 40;
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

                            Console.Clear();
                        }

                        padLeft = GetPadding(40);
                        if (!continueAdd)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╔══════════════════════════════════════╗");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(padLeft + "║       Continue adding student?       ║");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╠══════════════════════════════════════╣");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(padLeft + "║   [1] Yes                            ║");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(padLeft + "║   [2] No                             ║");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(padLeft + "║   [3] Try again                      ║");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╚══════════════════════════════════════╝\n");
                            Console.ResetColor();

                            try
                            {
                                Console.Write(padLeft + "➤ Enter option: ");
                                int option = int.Parse(Console.ReadLine());

                                if (option == 1)
                                {
                                    int rows = STUDENTS.GetLength(0);
                                    int cols = STUDENTS.GetLength(1);

                                    string[,] update = new string[rows + 1, cols];

                                    for (int i = 0; i < rows; i++)
                                        for (int j = 0; j < cols; j++)
                                            update[i, j] = STUDENTS[i, j];

                                    update[rows, 0] = id;
                                    update[rows, 1] = name;

                                    STUDENTS = update;

                                    continueAdd = true;
                                    Console.Clear();
                                    continue;
                                }
                                else if (option == 2)
                                {
                                    tryAgain = false;
                                    break;
                                }
                                else if (option == 3)
                                {
                                    id = "";
                                    name = "";
                                    nameExists = false;
                                    idExists = false;
                                    Console.Clear();
                                }
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                continue;
                            }
                        }

                        if (continueAdd)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            CenterPrint("Successfully added student.");
                            Console.WriteLine("\n");
                            Console.ResetColor();

                            padLeft = GetPadding(40);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╔══════════════════════════════════════╗");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(padLeft + "║   [1] Add another student            ║");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(padLeft + "║   [2] Manage student grade           ║");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(padLeft + "║   [3] Exit                           ║");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╚══════════════════════════════════════╝\n");
                            Console.ResetColor();

                            try
                            {
                                Console.Write(padLeft += "Enter option: ");
                                int option = int.Parse(Console.ReadLine());

                                if (option == 1)
                                {
                                    id = "";
                                    name = "";
                                    nameExists = false;
                                    idExists = false;
                                    continueAdd = false;
                                    Console.Clear();
                                    continue;
                                }
                                else if (option == 2)
                                {
                                    break;
                                }
                                else if (option == 3)
                                {
                                    break;
                                }
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                continue;
                            }
                            Console.ReadKey();
                        }
                    }

                    Console.Clear();
                }
                else if (op == 2)
                {
                    int student = PickStudent();

                    if (student != -1)
                    {


                        while (true)
                        {
                            int boxWidth = Math.Max(Math.Max(STUDENTS[student, 0].Length, STUDENTS[student, 1].Length) + 11, 30);
                            string padLeft = new string(' ', Console.BufferWidth / 2 - boxWidth / 2);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╔" + new string('═', boxWidth) + "╗");
                            Console.Write(padLeft + "║  ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("ID   : " + STUDENTS[student, 0].PadRight(boxWidth - 11));
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("  ║");
                            Console.Write(padLeft + "║  ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Name : " + STUDENTS[student, 1].PadRight(boxWidth - 11));
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("  ║");
                            Console.WriteLine(padLeft + "╚" + new string('═', boxWidth) + "╝\n");
                            Console.ResetColor();

                            padLeft = GetPadding(51);
                            int[] totalUnits = new int[2];
                            double[] generalAverage = new double[2];
                            string[] generalAverageStr = new string[2];
                            bool[] isComplete = { true, true };
                            string generalStatus;
                            string[,,] grades = new string[2, SUBJECTS.GetLength(1), 2];
                            string[,] averages = new string[2, SUBJECTS.GetLength(1)];
                            string[,] remarks = new string[2, SUBJECTS.GetLength(1)];
                            int[,] status = new int[2, 5];
                            for (int semester = 0; semester < 2; semester++)
                            {
                                for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                                {
                                    int units = int.Parse(SUBJECTS[0, i, 2]);
                                    totalUnits[semester] += units;

                                    double midTerm = Convert.ToDouble(GetGrade(student, 0, i, 0));
                                    double finalTerm = Convert.ToDouble(GetGrade(student, 0, i, 1));

                                    if (midTerm > 3.0 && midTerm <= 5)
                                        grades[semester, i, 0] = "5.0";
                                    else if (midTerm >= 1 && midTerm <= 3)
                                        grades[semester, i, 0] = midTerm.ToString("F2");
                                    if (finalTerm > 3.0 && finalTerm <= 5)
                                        grades[semester, i, 0] = "5.0";
                                    else if (finalTerm >= 1 && finalTerm <= 3)
                                        grades[semester, i, 0] = finalTerm.ToString("F2");

                                    if (midTerm == 8.8 || finalTerm == 8.8)
                                    {
                                        if (midTerm == 8.8)
                                            grades[semester, i, 0] = "INC";
                                        if (finalTerm == 8.8)
                                            grades[semester, i, 1] = "INC";
                                        averages[semester, i] = "";
                                        remarks[semester, i] = "INCOMPLETE";
                                        status[semester, 3]++;
                                    }
                                    if (midTerm == 0 || finalTerm == 0)
                                    {
                                        if (midTerm == 0)
                                            grades[semester, i, 0] = "";
                                        if (finalTerm == 0)
                                            grades[semester, i, 1] = "";
                                        averages[semester, i] = "";
                                        remarks[semester, i] = "PENDING";
                                        status[semester, 2]++;
                                    }
                                    if (midTerm == 9.9 || finalTerm == 9.9)
                                    {
                                        if (midTerm == 9.9)
                                            grades[semester, i, 0] = "DRP";
                                        if (finalTerm == 9.9)
                                            grades[semester, i, 1] = "DRP";
                                        averages[semester, i] = "";
                                        remarks[semester, i] = "DROPPED";
                                        status[semester, 4]++;
                                    }

                                    if (remarks[semester, i] == null)
                                    {
                                        double average = (midTerm + finalTerm) / 2;
                                        generalAverage[semester] += average * units;

                                        if (average >= 3.0)
                                        {
                                            status[semester, 0]++;
                                            remarks[semester, i] = "PASSED";
                                            averages[semester, i] = average.ToString("F2");
                                        }
                                        else
                                        {
                                            status[semester, 1]++;
                                            remarks[semester, i] = "FAILED";
                                            averages[semester, i] = "5.0";
                                        }
                                    }
                                    else
                                        isComplete[semester] = false;
                                }

                                if (!isComplete[semester])
                                    generalAverageStr[semester] = "INCOMPLETE";
                            }


                            //Console.WriteLine(padLeft + "╔═════════════════════════════════════════════════╗");
                            //Console.WriteLine(padLeft + "║                   1ST SEMESTER                  ║");
                            //Console.WriteLine(padLeft + "╠═════════════════════════════════════════════════╣");
                            //Console.WriteLine(padLeft + "║ Subjects        : {0} ║", SUBJECTS.GetLength(1).ToString().PadRight(29));
                            //Console.WriteLine(padLeft + "║ Total Units     : {0} ║", totalUnits[0].ToString().PadRight(29));
                            //Console.WriteLine(padLeft + "║ General Average : {0} ║", generalAverageStr[0].PadRight(29));
                            ////Console.WriteLine(padLeft + "║ Standing        : {0} ║", SUBJECTS.GetLength(0).ToString().PadRight(29));
                            //Console.WriteLine(padLeft + "╠═════════════════════════════════════════════════╣");
                            //Console.WriteLine(padLeft + "║                 SUBJECT STATUS                  ║");
                            //Console.WriteLine(padLeft + "╠═════════╦═════════╦═════════╦═════════╦═════════╣");
                            //Console.WriteLine(padLeft + "║ PASSED  ║ FAILED  ║ PENDING ║   INC   ║   DRP   ║");
                            //Console.WriteLine(padLeft + "╠═════════╬═════════╬═════════╬═════════╬═════════╣");
                            //Console.WriteLine(padLeft + "║   {0}   ║   {1}   ║   {2}   ║   {3}   ║   {4}   ║", SSToS(status[0, 0]), SSToS(status[0, 1]), SSToS(status[0, 2]), SSToS(status[0, 3]), SSToS(status[0, 4]));
                            //Console.WriteLine(padLeft + "╚═════════╩═════════╩═════════╩═════════╩═════════╝");

                            DrawReport(STUDENTS[student, 0], STUDENTS[student, 1], totalUnits, generalAverageStr, null, status);

                            Console.ReadKey();


                        }
                    }
                }
            }
        }

        public static string SSToS(int n)
        {
            if (n == 10)
                return "All";
            else
                return " " + n + " ";
        }

        public static string GetGrade(int studentIndex, int semester, int subject, int term)
        {
            int column = 2 + (semester * 20) + (subject * 2) + term;
            return STUDENTS[studentIndex, column];
        }

        public static void SetGrade(int studentIndex, int semester, int subject, int term, string grade)
        {
            int column = 2 + (semester * 20) + (subject * 2) + term;
            STUDENTS[studentIndex, column] = grade;
        }

        public static int PickStudent(int page = 1)
        {
            if (STUDENTS.GetLength(0) == 0)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Red;
                CenterPrint("There is no students yet.");
                Console.ResetColor();
                Console.WriteLine("\n");
                CenterPrint("Press any key to return...");
                Console.ReadKey();
                Console.Clear();
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
                        options = new string[max + 2];
                        options[options.Length - 2] = "Next Page";
                        options[options.Length - 1] = "Exit";
                    }
                    else if (page == pages)
                    {
                        options = new string[STUDENTS.GetLength(0) % max + 2];
                        options[options.Length - 2] = "Previus Page";
                        options[options.Length - 1] = "Exit";
                    }
                    else
                    {
                        options = new string[max + 3];
                        options[options.Length - 3] = "Previus Page";
                        options[options.Length - 2] = "Next Page";
                        options[options.Length - 1] = "Exit";

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

                int boxWidth = 40;
                string padLeft = GetPadding(boxWidth);
                bool firstAttempt = true;

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(padLeft + "╔══════════════════════════════════════╗");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < options.Length; i++)
                    {
                        int pad = 27;
                        string option = (i + 1).ToString();
                        if (options.Length > 9 && i <= 8)
                            option = 0 + option;
                        else if (options.Length <= 9)
                            pad++;
                        Console.WriteLine(padLeft + "║   [{0}] {1}   ║", option, options[i].PadRight(pad));
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(padLeft + "╚══════════════════════════════════════╝\n");
                    Console.ResetColor();

                    string input = "";
                    try
                    {
                        if (!firstAttempt)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(padLeft + "✗ Not found. Try again.");
                            Console.ResetColor();
                        }
                        Console.Write(padLeft + "➤ Enter option/ID/name: ");
                        input = Console.ReadLine();

                        int option = int.Parse(input);

                        if (option > 0 && option <= index)
                        {
                            Console.Clear();
                            return option + max * (page - 1) - 1;
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
                        else if (option <= options.Length && options[option - 1] == "Exit")
                        {
                            Console.Clear();
                            return -1;
                        }
                    }
                    catch (Exception)
                    {

                    }

                    for (int i = 0; i < STUDENTS.GetLength(0); i++)
                    {
                        if (input == STUDENTS[i, 0] || input == STUDENTS[i, 1])
                        {
                            Console.Clear();
                            return i;
                        }
                    }

                    Console.Clear();
                    firstAttempt = false;
                }

                Console.Clear();
            }

            return -1;
        }

        public static int GetOperation()
        {
            while (true)
            {
                int width = 40;
                string padLeft = GetPadding(width);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(padLeft + "╔══════════════════════════════════════╗");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(padLeft + "║    STUDENT GRADE MANAGEMENT SYSTEM   ║");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(padLeft + "╠══════════════════════════════════════╣");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(padLeft + "║   [1] Add Student                    ║");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(padLeft + "║   [2] Manage Student Grades          ║");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(padLeft + "║   [3] View Grades by Subject         ║");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(padLeft + "║   [4] Check Grades Records           ║");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(padLeft + "║   [5] Search Students                ║");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(padLeft + "║   [6] Delete Student                 ║");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(padLeft + "║   [7] Exit                           ║");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(padLeft + "╚══════════════════════════════════════╝\n");
                Console.ResetColor();

                try
                {
                    Console.Write(padLeft + "➤ Enter operation: ");
                    int op = int.Parse(Console.ReadLine());

                    Console.Clear();

                    if (op > 0 && op <= 7)
                        return op;
                }
                catch (Exception)
                {
                    Console.Clear();
                }

            }
        }

        public static string Truncate(string text, int maxLength)
        {
            if (text.Length <= maxLength) return text;

            string newText = "";

            for (int i = 0; i < maxLength; i++)
            {
                newText += text[i];
            }

            return newText + "...";
        }

        public static void CenterPrint(string text)
        {
            Console.WriteLine(GetPadding(text.Length) + text);
        }

        public static string GetPadding(int width)
        {
            return new string(' ', Convert.ToInt32(Math.Floor(Console.BufferWidth / 2.0 - width / 2.0)));
        }

        public static void Debug()
        {
            string[,] data =
                {
                    { "123", "John" },
                    { "124", "Alex" },
                    { "125", "Steve" },
                    { "126", "Herobrine" },
                    { "127", "Notch" },
                    { "128", "Entity" },
                    { "129", "Ang" },
                    { "130", "Zuko" },
                    { "131", "Toph" },
                    { "132", "Soka" },
                    { "133", "Katara" },
                    { "134", "Suki" },
                    { "135", "Appa" },
                    { "136", "Kyoshi" },
                    { "137", "Korra" }
                };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                int rows = STUDENTS.GetLength(0);
                int cols = STUDENTS.GetLength(1);

                string[,] update = new string[rows + 1, cols];

                for (int r = 0; r < rows; r++)
                    for (int j = 0; j < cols; j++)
                        update[r, j] = STUDENTS[r, j];

                update[rows, 0] = data[i, 0];
                update[rows, 1] = data[i, 1];

                for (int r = 2; r < 42; r++)
                {
                    update[rows, r] = GetWeightedRandomValue();
                }

                STUDENTS = update;
            }
        }

        static Random _random = new Random();
        public static string GetWeightedRandomValue()
        {
            string[] categories = { "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "1-5", "8.8", "9.9", "0" };

            string selectedCategory = categories[_random.Next(categories.Length)];

            if (selectedCategory == "1-5")
            {
                double min = 1.0;
                double max = 5.0;
                double val = _random.NextDouble() * (max - min) + min;
                return Math.Round(val, 2).ToString();
            }
            else
                return selectedCategory;
        }

        static void DrawReport(
    string id,
    string name,
    int[] totalUnits,
    string[] generalAverage,
    string[] standing,
    int[,] status)
        {
            int outerWidth = 100;

            PrintTop(outerWidth);

            // STUDENT INFO BOX
            PrintLine(
                "╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗",
                outerWidth);

            PrintLine($"║ ID   : {id}".PadRight(94) + "║", outerWidth);
            PrintLine($"║ Name : {name}".PadRight(94) + "║", outerWidth);

            PrintLine(
                "╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝",
                outerWidth);

            // GAP
            PrintEmpty(outerWidth);

            // SEMESTER TITLES
            PrintDual(
                "╔═════════════════════════════════════════════════╗",
                "╔═════════════════════════════════════════════════╗",
                outerWidth);

            PrintDual(
                Center("1ST SEMESTER", 51, '║'),
                Center("2ND SEMESTER", 51, '║'),
                outerWidth);

            PrintDual(
                "╠═════════════════════════════════════════════════╣",
                "╠═════════════════════════════════════════════════╣",
                outerWidth);

            // SUMMARY
            for (int semester = 0; semester < 2; semester++)
            {
                string left =
                    $"║ Subjects        : 10".PadRight(50) + "║";

                string right =
                    $"║ Subjects        : 10".PadRight(50) + "║";

                if (semester == 0)
                    PrintDual(left, right, outerWidth);
            }

            PrintDual(
                $"║ Total Units     : {totalUnits[0]}".PadRight(50) + "║",
                $"║ Total Units     : {totalUnits[1]}".PadRight(50) + "║",
                outerWidth);

            PrintDual(
                $"║ General Average : {generalAverage[0]}".PadRight(50) + "║",
                $"║ General Average : {generalAverage[1]}".PadRight(50) + "║",
                outerWidth);

            //PrintDual(
            //    $"║ Standing        : {standing[0]}".PadRight(50) + "║",
            //    $"║ Standing        : {standing[1]}".PadRight(50) + "║",
            //    outerWidth);

            // SUBJECT STATUS
            PrintDual(
                "╠═════════════════════════════════════════════════╣",
                "╠═════════════════════════════════════════════════╣",
                outerWidth);

            PrintDual(
                Center("SUBJECT STATUS", 51, '║'),
                Center("SUBJECT STATUS", 51, '║'),
                outerWidth);

            PrintDual(
                "╠═════════╦═════════╦═════════╦═════════╦═════════╣",
                "╠═════════╦═════════╦═════════╦═════════╦═════════╣",
                outerWidth);

            PrintDual(
                "║ PASSED  ║ FAILED  ║ PENDING ║   INC   ║   DRP   ║",
                "║ PASSED  ║ FAILED  ║ PENDING ║   INC   ║   DRP   ║",
                outerWidth);

            PrintDual(
                "╠═════════╬═════════╬═════════╬═════════╬═════════╣",
                "╠═════════╬═════════╬═════════╬═════════╬═════════╣",
                outerWidth);

            string leftStatus =
                $"║{CenterText(status[0, 0].ToString(), 9)}" +
                $"║{CenterText(status[0, 1].ToString(), 9)}" +
                $"║{CenterText(status[0, 2].ToString(), 9)}" +
                $"║{CenterText(status[0, 3].ToString(), 9)}" +
                $"║{CenterText(status[0, 4].ToString(), 9)}║";

            string rightStatus =
                $"║{CenterText(status[1, 0].ToString(), 9)}" +
                $"║{CenterText(status[1, 1].ToString(), 9)}" +
                $"║{CenterText(status[1, 2].ToString(), 9)}" +
                $"║{CenterText(status[1, 3].ToString(), 9)}" +
                $"║{CenterText(status[1, 4].ToString(), 9)}║";

            PrintDual(leftStatus, rightStatus, outerWidth);

            PrintDual(
                "╚═════════╩═════════╩═════════╩═════════╩═════════╝",
                "╚═════════╩═════════╩═════════╩═════════╩═════════╝",
                outerWidth);

            PrintBottom(outerWidth);
        }

        static void PrintTop(int width)
        {
            Console.WriteLine("╔" + new string('═', width) + "╗");
        }

        static void PrintBottom(int width)
        {
            Console.WriteLine("╚" + new string('═', width) + "╝");
        }

        static void PrintEmpty(int width)
        {
            Console.WriteLine("║" + new string(' ', width) + "║");
        }

        static void PrintLine(string content, int width)
        {
            Console.WriteLine("║  " + content.PadRight(width - 2) + "  ║");
        }

        static void PrintDual(string left, string right, int width)
        {
            Console.WriteLine($"║  {left}  {right}  ║");
        }

        static string Center(string text, int width, char border)
        {
            int innerWidth = width - 2;

            int leftPadding = (innerWidth - text.Length) / 2;
            int rightPadding = innerWidth - text.Length - leftPadding;

            return border +
                   new string(' ', leftPadding) +
                   text +
                   new string(' ', rightPadding) +
                   border;
        }

        static string CenterText(string text, int width)
        {
            int left = (width - text.Length) / 2;
            int right = width - text.Length - left;

            return new string(' ', left) +
                   text +
                   new string(' ', right);
        }
    }

}
