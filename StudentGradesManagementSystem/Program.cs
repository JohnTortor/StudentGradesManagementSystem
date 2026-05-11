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
        public static string[,] STUDENTS = new string[0, 42];
        public static string[,,] SUBJECTS =
            {
                {
                    { "IT 101", "Introduction to Computing", " 1 " },
                    { "IT 101L", "Introduction to Computing", " 2 " },
                    { "IT 103", "Computer Programming 1", " 1 " },
                    { "IT 103L", "Computer Programming 1", " 2 " },
                    { "GE-CC04", "Mathematics in the Modern World", " 3 " },
                    { "GE-CC05", "Purposive Communication", " 3 " },
                    { "GE-CC01", "Understanding the Self", " 3 " },
                    { "GE-CC08", "Ethics", " 3 " },
                    { "PATHFit01", "Movement Competency Training", " 2 " },
                    { "NSTP-CW 101", "Civil Welfare Training Service 1", "(3)" }
                },
                {
                    { "IT 102", "Human Computer Interaction", " 1 " },
                    { "IT 102L", "Human Computer Interaction", " 2 " },
                    { "IT 104", "Computer Programming 2", " 1 " },
                    { "IT 104L", "Computer Programming 2", " 2 " },
                    { "IT 106", "Discrete Mathematics", " 3 " },
                    { "GE-CC02", "Reading in Philippine History", " 3 " },
                    { "GE-CC07", "Science Technology and Society", " 3 " },
                    { "GE-CC03", "The Contemporary World", " 3 " },
                    { "PATHFit02", "Exercise-Based Fitness Activities", " 2 " },
                    { "NSTP-CW 102", "Civic Welfare Training Service 2", "(3)" }
                }
            };

        public static ConsoleColor[] Colors =
        {
            ConsoleColor.Cyan,
            ConsoleColor.Yellow,
            ConsoleColor.White,
            ConsoleColor.Magenta,
            ConsoleColor.Green,
            ConsoleColor.Red,
            ConsoleColor.Blue,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkCyan,
            ConsoleColor.Gray,
            ConsoleColor.DarkYellow,
            ConsoleColor.DarkGray
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Debug();
            int student = -1;
            int op = -1;
            while (true)
            {
                if (op == -1)
                    op = GetOperation();

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
                            padLeft = GetPadding(boxWidth + 2);

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
                            string[] verify =
                            {
                                padLeft + "╔══════════════════════════════════════╗\n",
                                padLeft + "║       ", "Continue adding student?", "       ║\n",
                                padLeft + "╠══════════════════════════════════════╣\n",
                                padLeft + "║   ", "[1] Yes", "                            ║\n",
                                padLeft + "║   ", "[2] No", "                             ║\n",
                                padLeft + "║   ", "[3] Try again", "                      ║\n",
                                padLeft + "╚══════════════════════════════════════╝\n\n"
                            };

                            PrintColor(verify, Colors, new int[] { 0, 0, 1, 0, 0, 0, 4, 0, 0, 5, 0, 0, 9, 0, 0 });

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

                            string[] options =
                            {
                                padLeft + "╔══════════════════════════════════════╗\n",
                                padLeft + "║   ", "[1] Add another student", "            ║\n",
                                padLeft + "║   ", "[2] Manage student grade", "           ║\n",
                                padLeft + "║   ", "[Q] Exit", "                           ║\n",
                                padLeft + "╚══════════════════════════════════════╝\n\n"
                            };

                            PrintColor(options, Colors, new int[] { 0, 0, 1, 0, 0, 6, 0, 0, 9, 0, 0 });

                            try
                            {
                                Console.Write(padLeft += "Enter option: ");
                                string input = Console.ReadLine().ToLower();

                                if (input == "q")
                                    break;

                                int option = int.Parse(input);

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
                                    student = STUDENTS.GetLength(0) - 1;
                                    op = 2;
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
                    if (op == 1)
                        op = -1;
                }
                else if (op == 2)
                {
                    if (student == -1)
                        student = PickStudent();

                    if (student != -1)
                    {
                        //Console.WriteLine()
                        int boxWidth = Math.Max(Math.Max(STUDENTS[student, 0].Length, STUDENTS[student, 1].Length) + 11, 30);
                        string padLeft = GetPadding(51);

                        int[] tableColorIndexes =
                        {
                            0,
                            0, 1, 2, 0,
                            0, 1, 2, 0,
                            0,
                            0,
                            0, 3, 0, 3, 0,
                            0,
                            0, 1, 2, 0, 1, 2, 0,
                            0, 1, 2, 0, 1, 2, 0,
                            0, 1, 2, 0, 1, 2, 0,
                            0,
                            0, 3, 0, 3, 0,
                            0,
                            0, 4, 0, 5, 0, 10, 0, 6, 0, 7, 0, 4, 0, 5, 0, 10, 0, 6, 0, 7, 0,
                            0,
                            0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
                            0
                        };
                        int[] optionsColorIndexes = { 0, 0, 6, 0, 0, 8, 0, 0, 9, 0, 0 };

                        int selectedSemester = -1;
                        int selectedSubject = -1;
                        int selectedTerm = 0;
                        bool loop = false;
                        bool invalidGrade = false;

                        while (true)
                        {
                            int[] totalUnits = new int[2];
                            int[] totalCountedUnits = new int[2];
                            double[] generalAverage = { 0, 0 };
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
                                    int units = -1;
                                    if (int.TryParse(SUBJECTS[semester, i, 2], out units))
                                        totalUnits[semester] += units;

                                    double midTerm = Convert.ToDouble(GetGrade(student, semester, i, 0));
                                    double finalTerm = Convert.ToDouble(GetGrade(student, semester, i, 1));

                                    grades[semester, i, 0] = midTerm.ToString("F2");
                                    grades[semester, i, 1] = finalTerm.ToString("F2");
                                    //if (midTerm > 3.0 && midTerm <= 5)
                                    //    grades[semester, i, 0] = "5.0";
                                    //else if (midTerm >= 1 && midTerm <= 3)
                                    //    grades[semester, i, 0] = midTerm.ToString("F2");
                                    //if (finalTerm > 3.0 && finalTerm <= 5)
                                    //    grades[semester, i, 1] = "5.0";
                                    //else if (finalTerm >= 1 && finalTerm <= 3)
                                    //    grades[semester, i, 1] = finalTerm.ToString("F2");

                                    if (midTerm == 8.8 || finalTerm == 8.8)
                                    {
                                        if (midTerm == 8.8)
                                            grades[semester, i, 0] = "INC";
                                        if (finalTerm == 8.8)
                                            grades[semester, i, 1] = "INC";
                                        averages[semester, i] = "--";
                                        remarks[semester, i] = "INCOMPLETE";
                                        if (units != -1)
                                            isComplete[semester] = false;
                                    }
                                    if (midTerm == 0 || finalTerm == 0)
                                    {
                                        if (midTerm == 0)
                                            grades[semester, i, 0] = "--";
                                        if (finalTerm == 0)
                                            grades[semester, i, 1] = "--";
                                        averages[semester, i] = "--";
                                        remarks[semester, i] = "PENDING";
                                        if (units != -1)
                                            isComplete[semester] = false;
                                    }
                                    if (midTerm == 9.9 || finalTerm == 9.9)
                                    {
                                        if (midTerm == 9.9)
                                            grades[semester, i, 0] = "DRP";
                                        if (finalTerm == 9.9)
                                            grades[semester, i, 1] = "DRP";
                                        averages[semester, i] = "--";
                                        remarks[semester, i] = "DROPPED";
                                        status[semester, 4]++;
                                    }

                                    if (remarks[semester, i] == null)
                                    {
                                        double average = (midTerm + finalTerm) / 2;
                                        if (units != -1)
                                        {
                                            generalAverage[semester] += average * units;
                                            totalCountedUnits[semester] += units;
                                        }

                                        if (average <= 3.0)
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
                                    else if (remarks[semester, i] == "INCOMPLETE")
                                        status[semester, 3]++;
                                    else if (remarks[semester, i] == "PENDING")
                                        status[semester, 2]++;

                                }

                                if (totalCountedUnits[semester] > 0)
                                    generalAverage[semester] /= totalCountedUnits[semester];
                                if (generalAverage[semester] > 3)
                                    generalAverage[semester] = 5.0;

                                if (!isComplete[semester])
                                    generalAverageStr[semester] = "INCOMPLETE";
                                else if (generalAverage[semester] == 5.0)
                                    generalAverageStr[semester] = "FAILED";
                                else
                                    generalAverageStr[semester] = "PASSED";
                            }

                            if (selectedSemester == -1)
                            {
                                padLeft = GetPadding(104);
                                string[] table =
                                {
                                    "\n\n" +
                                    padLeft + "╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗\n",
                                    padLeft + "║ ", "ID   : ", Truncate(STUDENTS[student, 0], 90), " ║\n",
                                    padLeft + "║ ", "Name : ", Truncate(STUDENTS[student, 1], 90), " ║\n",
                                    padLeft + "╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝\n",
                                    padLeft + "╔═════════════════════════════════════════════════╗  ╔═════════════════════════════════════════════════╗\n",
                                    padLeft + "║                   ", "1ST SEMESTER", "                  ║  ║                   ", "2ND SEMESTER", "                  ║\n",
                                    padLeft + "╠═════════════════════════════════════════════════╣  ╠═════════════════════════════════════════════════╣\n",
                                    padLeft + "║ ", "Subjects", "        : " + SUBJECTS.GetLength(1).ToString().PadRight(29), " ║  ║ ", "Subjects", "        : " + SUBJECTS.GetLength(1).ToString().PadRight(29), " ║\n",
                                    padLeft + "║ ", "Total Units", "     : " + totalUnits[0].ToString().PadRight(29)," ║  ║ ", "Total Units", "     : " + totalUnits[1].ToString().PadRight(29), " ║\n",
                                    padLeft + "║ ", "General Average", " : " + generalAverage[0].ToString("F2").PadRight(29)," ║  ║ ", "General Average", " : " + generalAverage[1].ToString("F2").PadRight(29), " ║\n",
                                    padLeft + "╠═════════════════════════════════════════════════╣  ╠═════════════════════════════════════════════════╣\n",
                                    padLeft + "║                 ", "SUBJECT STATUS", "                  ║  ║                 ", "SUBJECT STATUS", "                  ║\n",
                                    padLeft + "╠═════════╦═════════╦═════════╦═════════╦═════════╣  ╠═════════╦═════════╦═════════╦═════════╦═════════╣\n",
                                    padLeft + "║ ", "PASSED", "  ║ ", "FAILED", "  ║ ", "PENDING", " ║   ", "INC", "   ║   ", "DRP", "   ║  ║ ", "PASSED", "  ║ ", "FAILED", "  ║ ", "PENDING", " ║   ", "INC", "   ║   ", "DRP", "   ║\n",
                                    padLeft + "╠═════════╬═════════╬═════════╬═════════╬═════════╣  ╠═════════╬═════════╬═════════╬═════════╬═════════╣\n",
                                    padLeft + "║   ", SSToS(status[0, 0]) ,"   ║   ", SSToS(status[0, 1]) ,"   ║   ", SSToS(status[0, 2]) ,"   ║   ", SSToS(status[0, 3]) ,"   ║   ", SSToS(status[0, 4]) ,"   ║  ║   ", SSToS(status[1, 0]) ,"   ║   ", SSToS(status[1, 1]) ,"   ║   ", SSToS(status[1, 2]) ,"   ║   ", SSToS(status[1, 3]) ,"   ║   ", SSToS(status[1, 4]) ,"   ║\n",
                                    padLeft + "╚═════════╩═════════╩═════════╩═════════╩═════════╝  ╚═════════╩═════════╩═════════╩═════════╩═════════╝\n\n"
                                };

                                PrintColor(table, Colors, tableColorIndexes);

                                padLeft = GetPadding(38);
                                string[] texts =
                                {
                                    padLeft + "╔════════════════════════════════════╗\n",
                                    padLeft + "║   ", "[1] Manage 1st Semester Grades", "   ║\n",
                                    padLeft + "║   ", "[2] Manage 2nd Semester Grades", "   ║\n",
                                    padLeft + "║   ", "[Q] Exit", "                         ║\n",
                                    padLeft + "╚════════════════════════════════════╝\n\n"
                                };
                                PrintColor(texts, Colors, optionsColorIndexes);

                                Console.Write(padLeft + "➤ Enter option: ");
                                string input = Console.ReadLine().ToLower();
                                int option;

                                if (input == "q")
                                    break;
                                else if (int.TryParse(input, out option))
                                {
                                    if (option == 1)
                                        selectedSemester = 0;
                                    else if (option == 2)
                                        selectedSemester = 1;
                                }



                                Console.Clear();
                            }
                            else
                            {
                                string semesterStr = "1ST";
                                if (selectedSemester == 1)
                                    semesterStr = "2ND";

                                int[] gradesTableTopColorIndexes =
                                {
                                    0,
                                    0,
                                    0, 1, 2, 0, 1, 2, 4, 1, 2, 6, 0,
                                    0, 1, 2, 0, 1, 2, 5, 1, 2, 7, 0,
                                    0,
                                    0,
                                    0, 3, 0,
                                    0,
                                    0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
                                    0,
                                };
                                int[] gradesTableBotColorIndexes =
                                {
                                    0,
                                    0, 1, 2, 2, 0, 6, 0,
                                    0
                                };
                                padLeft = GetPadding(100);

                                if (generalAverageStr[selectedSemester] == "PASSED")
                                    gradesTableBotColorIndexes[6] = 4;
                                else if (generalAverageStr[selectedSemester] == "FAILED")
                                    gradesTableBotColorIndexes[6] = 5;


                                while (true)
                                {
                                    string[] gradesTableTop =
                                    {
                                        "\n",
                                        padLeft + "╔═════════════════════════════════════════════════════════════════╦════════════════════════════════╗\n",
                                        padLeft + "║ ", "ID   ", ": 123", "                                                      ║    ", "1-3", ": ", "PASSED    ", "8.8", ": ", "INC", "     ║\n",
                                        padLeft + "║ ", "Name ", ": John", "                                                     ║    ", "5.0", ": ", "FAILED    ", "9.9", ": ", "DRP", "     ║\n",
                                        padLeft + "╚═════════════════════════════════════════════════════════════════╩════════════════════════════════╝\n",
                                        padLeft + "╔══════════════════════════════════════════════════════════════════════════════════════════════════╗\n",
                                        padLeft + "║                                        ", semesterStr + " SEMESTER GRADES", "                                       ║\n",
                                        padLeft + "╠════╦══════════════╦═════════════════════════╦═══════╦═════════╦═══════════╦═════════╦════════════╣\n",
                                        padLeft + "║ ", "No", " ║ ", "Code", "         ║ ", "Subject", "                 ║ ", "Units", " ║ ", "MidTerm", " ║ ", "FinalTerm", " ║ ", "Average", " ║ ", "Remarks", "    ║\n",
                                        padLeft + "╠════╬══════════════╬═════════════════════════╬═══════╬═════════╬═══════════╬═════════╬════════════╣\n",
                                    };
                                    string[] gradesTableTBot =
                                    {
                                        padLeft + "╠════╩══════════════╩═════════════════════════╩═══════╩═════════╩═══════════╩═════════╬════════════╣\n",
                                        padLeft + "║ ", "General Average", " : ", generalAverage[selectedSemester].ToString("F2").PadRight(65), " ║ ", generalAverageStr[selectedSemester].PadRight(10), " ║\n",
                                        padLeft + "╚═════════════════════════════════════════════════════════════════════════════════════╩════════════╝\n\n"
                                    };

                                    PrintColor(gradesTableTop, Colors, gradesTableTopColorIndexes);
                                    for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                                    {
                                        int midTermColor = 2;
                                        int finalTermColor = 2;
                                        int remarksColor = 4;
                                        if (grades[selectedSemester, i, 0] == "INC")
                                            midTermColor = 6;
                                        else if (grades[selectedSemester, i, 0] == "DRP")
                                            midTermColor = 7;
                                        if (grades[selectedSemester, i, 1] == "INC")
                                            finalTermColor = 6;
                                        else if (grades[selectedSemester, i, 1] == "DRP")
                                            finalTermColor = 7;
                                        if (remarks[selectedSemester, i] == "FAILED")
                                            remarksColor = 5;
                                        else if (remarks[selectedSemester, i] == "PENDING")
                                            remarksColor = 10;
                                        else if (remarks[selectedSemester, i] == "INCOMPLETE")
                                            remarksColor = 6;
                                        else if (remarks[selectedSemester, i] == "DROPPED")
                                            remarksColor = 7;

                                        if (i == selectedSubject)
                                        {
                                            PrintColor(new string[] { padLeft + "║ ", (i + 1).ToString().PadLeft(2, '0'), " ║ ", SUBJECTS[selectedSemester, i, 0].PadRight(12), " ║ ", Truncate(SUBJECTS[selectedSemester, i, 1], 20), " ║  ", SUBJECTS[selectedSemester, i, 2], "  ║ " }, Colors, new int[] { 0, 4, 0, 4, 0, 4, 0, 4, 0 });
                                            if (selectedTerm == 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.BackgroundColor = ConsoleColor.Green;
                                                Console.Write(grades[selectedSemester, i, 0].PadRight(7));
                                                Console.ResetColor();
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write(" ║ ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write(grades[selectedSemester, i, 1].PadRight(9));
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write(grades[selectedSemester, i, 0].PadRight(7));
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write(" ║ ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.BackgroundColor = ConsoleColor.Green;
                                                Console.Write(grades[selectedSemester, i, 1].PadRight(9));
                                                Console.ResetColor();
                                            }
                                            PrintColor(new string[] { " ║ ", averages[selectedSemester, i].PadRight(4), "    ║ ", remarks[selectedSemester, i].PadRight(10), " ║\n" }, Colors, new int[] { 0, 2, 0, remarksColor, 0 });
                                            //); , grades[selectedSemester, i, 0].PadRight(7), " ║ ", grades[selectedSemester, i, 1].PadRight(9), " ║ ", averages[selectedSemester, i].PadRight(4), "    ║ ", remarks[selectedSemester, i].PadRight(10), " ║\n" }, Colors, gradesTableMidColorIndexes);
                                        }
                                        else
                                            PrintColor(new string[] { padLeft + "║ ", (i + 1).ToString().PadLeft(2, '0'), " ║ ", SUBJECTS[selectedSemester, i, 0].PadRight(12), " ║ ", Truncate(SUBJECTS[selectedSemester, i, 1], 20), " ║  ", SUBJECTS[selectedSemester, i, 2], "  ║ ", grades[selectedSemester, i, 0].PadRight(7), " ║ ", grades[selectedSemester, i, 1].PadRight(9), " ║ ", averages[selectedSemester, i].PadRight(4), "    ║ ", remarks[selectedSemester, i].PadRight(10), " ║\n" }, Colors, new int[] { 0, 2, 0, 2, 0, 2, 0, 2, 0, midTermColor, 0, finalTermColor, 0, 2, 0, remarksColor, 0 });
                                    }
                                    PrintColor(gradesTableTBot, Colors, gradesTableBotColorIndexes);

                                    if (selectedSubject == -1)
                                    {
                                        Console.Write(padLeft + "➤ Enter Subject No/Code ('All' to edit sequentially, 'Q' to exit): ");
                                        string input = Console.ReadLine().ToLower();

                                        int no;
                                        if (input == "q")
                                            selectedSemester = -1;
                                        else if (input == "all")
                                        {
                                            selectedSubject = 0;
                                            loop = true;
                                        }
                                        else if (int.TryParse(input, out no) && no > 0 && no <= SUBJECTS.GetLength(1))
                                            selectedSubject = no - 1;
                                        else
                                        {
                                            bool found = false;
                                            for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                                            {
                                                if (SUBJECTS[selectedSemester, i, 0].ToLower() == input)
                                                {
                                                    found = true;
                                                    selectedSubject = i;
                                                    break;
                                                }
                                            }
                                            if (!found)
                                            {
                                                Console.Clear();
                                                continue;
                                            }
                                        }

                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        if (invalidGrade)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine(padLeft + "✗ Invalid grade. Try again.");
                                            Console.ResetColor();
                                            invalidGrade = false;
                                        }
                                        Console.Write(padLeft + "➤ Enter Grade (Leave empty to skip, 'Q' to stop): ");
                                        string input = Console.ReadLine().ToLower();

                                        double grade;
                                        if (input == "q")
                                        {
                                            loop = false;
                                            selectedSubject = -1;
                                            selectedTerm = 0;
                                        }
                                        else if (double.TryParse(input, out grade))
                                        {
                                            if ((grade >= 1 && grade <= 5) || grade == 8.8 || grade == 9.9)
                                                SetGrade(student, selectedSemester, selectedSubject, selectedTerm, grade.ToString());
                                            else
                                                invalidGrade = true;
                                        }
                                        else if (input != "")
                                            invalidGrade = true;

                                        if (!invalidGrade && selectedSubject != -1)
                                        {
                                            if (selectedTerm == 0)
                                                selectedTerm++;
                                            else
                                            {
                                                selectedTerm--;
                                                if (loop)
                                                {
                                                    if (selectedSubject + 1 == SUBJECTS.GetLength(1))
                                                    {
                                                        selectedSubject = -1;
                                                        loop = false;
                                                    }
                                                    else
                                                        selectedSubject++;
                                                }
                                                else
                                                    selectedSubject = -1;
                                            }
                                        }
                                    }

                                    Console.Clear();
                                    break;
                                }
                            }
                        }
                        Console.Clear();
                    }
                    student = -1;
                    op = -1;
                }
                else if (op == 3)
                {
                    int semester = 0;
                    int selectedSubject = -1;
                    string padLeft;

                    while (true)
                    {
                        if (selectedSubject == -1)
                        {
                            padLeft = GetPadding(94);

                            string[] subjects =
                            {
                                padLeft + "╔════════════════════════════════════════════╗  ╔════════════════════════════════════════════╗\n",
                                padLeft + "║                ", "1ST SEMESTER", "                ║  ║                ", "2ND SEMESTER", "                ║\n",
                                padLeft + "╠════════════════════════════════════════════╣  ╠════════════════════════════════════════════╣\n"
                            };

                            PrintColor(subjects, Colors, new int[] { 0, 0, 3, 0, 3, 0, 0 });

                            for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                            {
                                string[] subject = { padLeft + "║ ", "[" + (i + 1).ToString().PadLeft(2, '0') + "] " + (SUBJECTS[0, i, 0].PadRight(12) + Truncate(SUBJECTS[0, i, 1], 22)).PadRight(37), " ║  ║ ", "[" + (i + 1 + SUBJECTS.GetLength(1)).ToString().PadLeft(2, '0') + "] " + (SUBJECTS[1, i, 0].PadRight(12) + Truncate(SUBJECTS[1, i, 1], 22)).PadRight(37), " ║\n" };
                                PrintColor(subject, Colors, new int[] { 0, 2, 0, 2, 0 });
                            }

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╚════════════════════════════════════════════╝  ╚════════════════════════════════════════════╝\n");
                            Console.ResetColor();

                            Console.Write(padLeft + "➤ Enter Option/Code or 'Q' to exit: ");
                            string input = Console.ReadLine().ToLower();

                            int option;
                            if (input == "q")
                            {
                                Console.Clear();
                                break;
                            }
                            else if (int.TryParse(input, out option) && option > 0 && option <= SUBJECTS.GetLength(1) * 2)
                            {
                                semester = (option - 1) / SUBJECTS.GetLength(1);
                                selectedSubject = (option - 1) % SUBJECTS.GetLength(1);
                            }
                            else
                            {
                                for (int i = 0; i < SUBJECTS.GetLength(0); i++)
                                {
                                    for (int j = 0; j < SUBJECTS.GetLength(1); j++)
                                    {
                                        if (input == SUBJECTS[i, j, 0].ToLower())
                                        {
                                            semester = i;
                                            selectedSubject = j;
                                        }
                                    }
                                }
                            }

                            Console.Clear();
                        }
                        else
                        {
                            padLeft = GetPadding(95);

                            string[] grades =
                            {
                                padLeft + "╔══════════════════════════════════════════════════════════════════════════╦══════════════════╗\n",
                                padLeft + "║ ", "Subject: ", (SUBJECTS[semester, selectedSubject, 0] + "   " + SUBJECTS[semester, selectedSubject, 1]).PadRight(63), " ║     ", "Units: ", "3", "     ║\n",
                                padLeft + "╚══════════════════════════════════════════════════════════════════════════╩══════════════════╝\n",
                                padLeft + "╔══════════════╦═════════════════════════════════╦═════════╦═══════════╦═════════╦════════════╗\n",
                                padLeft + "║ ", "ID", "           ║ ", "Name", "                            ║ ", "MidTerm", " ║ ", "FinalTerm", " ║ ", "Average", " ║ ", "Remarks", "    ║\n",
                                padLeft + "╠══════════════╬═════════════════════════════════╬═════════╬═══════════╬═════════╬════════════╣\n"
                            };

                            PrintColor(grades, Colors, new int[] { 0, 0, 1, 2, 0, 1, 2, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0 });

                            for (int i = 0; i < STUDENTS.GetLength(0); i++)
                            {
                                int[] colorIndex = { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0 };

                                string midTermStr = GetGrade(i, semester, selectedSubject, 0);
                                string finalTermStr = GetGrade(i, semester, selectedSubject, 1);
                                string averageStr = "";
                                string remarks = "";

                                double midTerm = Convert.ToDouble(midTermStr);
                                double finalTerm = Convert.ToDouble(finalTermStr);

                                if (midTerm == 8.8 || finalTerm == 8.8)
                                {
                                    if (midTerm == 8.8)
                                    {
                                        midTermStr = "INC";
                                        colorIndex[5] = 6;
                                    }
                                    if (finalTerm == 8.8)
                                    {
                                        finalTermStr = "INC";
                                        colorIndex[7] = 6;
                                    }
                                    averageStr = "--";
                                    remarks = "INCOMPLETE";
                                    colorIndex[11] = 6;
                                }
                                if (midTerm == 0 || finalTerm == 0)
                                {
                                    if (midTerm == 0)
                                    {
                                        midTermStr = "--";
                                        //colorIndex[5] = 10;
                                    }
                                    if (finalTerm == 0)
                                    {
                                        finalTermStr = "--";
                                        //colorIndex[7] = 10;
                                    }
                                    averageStr = "--";
                                    remarks = "PENDING";
                                    colorIndex[11] = 10;
                                }
                                if (midTerm == 9.9 || finalTerm == 9.9)
                                {
                                    if (midTerm == 9.9)
                                    {
                                        midTermStr = "DRP";
                                        colorIndex[5] = 7;
                                    }
                                    if (finalTerm == 9.9)
                                    {
                                        finalTermStr = "DRP";
                                        colorIndex[7] = 7;
                                    }
                                    averageStr = "--";
                                    remarks = "DROPPED";
                                    colorIndex[11] = 7;
                                }

                                if (remarks == "")
                                {
                                    double average = (midTerm + finalTerm) / 2;

                                    if (average > 3)
                                    {
                                        averageStr = "5.0";
                                        remarks = "PASSED";
                                        colorIndex[11] = 4;
                                    }
                                    else
                                    {
                                        averageStr = average.ToString("F2");
                                        remarks = "FAILED";
                                        colorIndex[11] = 5;
                                    }
                                }

                                PrintColor(new string[] { padLeft + "║ ", Truncate(STUDENTS[i, 0], 9), " ║ ", Truncate(STUDENTS[i, 1], 28), " ║ ", midTermStr.PadRight(7), " ║ ", finalTermStr.PadRight(9), " ║ ", averageStr.PadRight(7), " ║ ", remarks.PadRight(10), " ║\n" }, Colors, colorIndex);

                            }

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╚══════════════╩═════════════════════════════════╩═════════╩═══════════╩═════════╩════════════╝\n");
                            Console.ResetColor();

                            Console.Write(padLeft + "Press any key to return...");
                            Console.ReadKey();
                            selectedSubject = -1;
                            Console.Clear();
                        }
                    }
                    op = -1;
                }
                else if (op == 4)
                {
                    bool loop = true;

                    while (loop)
                    {
                        student = PickStudent();

                        if (student != -1)
                        {
                            string id = STUDENTS[student, 0];
                            string name = STUDENTS[student, 1];

                            int boxWidth;
                            string padLeft;
                            bool continueDel = false;

                            while (true)
                            {
                                boxWidth = Math.Max(Math.Max(id.Length, name.Length) + 11, 30);
                                padLeft = GetPadding(boxWidth + 2);
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
                                Console.WriteLine(padLeft + "╚" + new string('═', boxWidth) + "╝\n");

                                if (!continueDel)
                                {
                                    padLeft = GetPadding(42);
                                    string[] verify =
                                    {
                                        padLeft + "╔════════════════════════════════════════╗\n",
                                        padLeft + "║       ", "Continue removing student?", "       ║\n",
                                        padLeft + "╠════════════════════════════════════════╣\n",
                                        padLeft + "║   ", "[1] Yes", "                              ║\n",
                                        padLeft + "║   ", "[2] No", "                               ║\n",
                                        padLeft + "╚════════════════════════════════════════╝\n\n"
                                    };

                                    PrintColor(verify, Colors, new int[] { 0, 0, 1, 0, 0, 0, 4, 0, 0, 5, 0, 0 });

                                    try
                                    {
                                        Console.Write(padLeft + "➤ Enter option: ");
                                        int option = int.Parse(Console.ReadLine());

                                        if (option == 1)
                                        {
                                            int rows = STUDENTS.GetLength(0);
                                            int cols = STUDENTS.GetLength(1);

                                            string[,] update = new string[rows - 1, cols];

                                            int index = 0;
                                            for (int i = 0; i < rows; i++)
                                            {
                                                if (i != student)
                                                {
                                                    for (int j = 0; j < cols; j++)
                                                        update[index, j] = STUDENTS[i, j];
                                                    index++;
                                                }
                                            }
                                            STUDENTS = update;

                                            continueDel = true;
                                            Console.Clear();
                                            continue;
                                        }
                                        else if (option == 2)
                                        {
                                            loop = false;
                                            break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.Clear();
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine();
                                    CenterPrint("Successfully removed student.");
                                    Console.WriteLine("\n");
                                    Console.ResetColor();

                                    padLeft = GetPadding(40);

                                    string[] options =
                                    {
                                        padLeft + "╔══════════════════════════════════════╗\n",
                                        padLeft + "║   ", "[1] Remove another student", "         ║\n",
                                        padLeft + "║   ", "[Q] Exit", "                           ║\n",
                                        padLeft + "╚══════════════════════════════════════╝\n\n"
                                    };

                                    PrintColor(options, Colors, new int[] { 0, 0, 1, 0, 0, 6, 0, 0, 9, 0, 0 });

                                    try
                                    {
                                        Console.Write(padLeft += "Enter option: ");
                                        string input = Console.ReadLine().ToLower();

                                        if (input == "q")
                                        {
                                            loop = false;
                                            break;
                                        }

                                        int option = int.Parse(input);

                                        if (option == 1)
                                            break;
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
                        else
                            break;
                    }
                    op = -1;
                }
            }
        }

        public static void PrintColor(string[] texts, ConsoleColor[] colors, int[] colorIndexes)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                Console.ForegroundColor = colors[colorIndexes[i]];
                Console.Write(texts[i]);
            }
            Console.ResetColor();
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
                    options = new string[max];

                    for (int i = 0; i < max; i++)
                    {
                        if (max * (page - 1) + i < STUDENTS.GetLength(0))
                        {
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
                    for (int i = 0; i < index; i++)
                        PrintColor(new string[] { padLeft + "║   ", "[" + (i + 1) + "] ", options[i].PadRight(30), " ║\n" }, Colors, new int[] { 0, 1, 2, 0 });
                    if (pages > 1)
                    {
                        if (page != 1)
                            PrintColor(new string[] { padLeft + "║   ", "[A] Previous Page", "                  ║\n" }, Colors, new int[] { 0, 6, 0 });
                        if (page != pages)
                            PrintColor(new string[] { padLeft + "║   ", "[D] Next Page", "                      ║\n" }, Colors, new int[] { 0, 4, 0 });

                    }
                    PrintColor(new string[] { padLeft + "║   ", "[Q] Exit", "                           ║\n" }, Colors, new int[] { 0, 11, 0 });
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

                        if (input == "q")
                        {
                            Console.Clear();
                            return -1;
                        }
                        else if (pages > 1 && page != pages && input == "d")
                        {
                            page++;
                            break;
                        }
                        else if (pages > 1 && page != 1 && input == "a")
                        {
                            page--;
                            break;
                        }

                        int option = int.Parse(input);

                        if (option > 0 && option <= index)
                        {
                            Console.Clear();
                            return option + max * (page - 1) - 1;
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

                string[] options =
                {
                    padLeft + "╔══════════════════════════════════════╗\n",
                    padLeft + "║    ", "STUDENT GRADE MANAGEMENT SYSTEM", "   ║\n",
                    padLeft + "╠══════════════════════════════════════╣\n",
                    padLeft + "║   ", "[1] Add Student", "                    ║\n",
                    padLeft + "║   ", "[2] Manage Student Grades", "          ║\n",
                    padLeft + "║   ", "[3] View Grades by Subject", "         ║\n",
                    //padLeft + "║   ", "[5] Search Students", "                ║\n",
                    padLeft + "║   ", "[4] Delete Student", "                 ║\n",
                    padLeft + "║   ", "[5] Exit", "                           ║\n",
                    padLeft + "╚══════════════════════════════════════╝\n\n"
                };

                PrintColor(options, Colors, new int[] { 0, 0, 9, 0, 0, 0, 1, 0, 0, 6, 0, 0, 8, 0, 0, 5, 0, 0, 9, 0, 0 });
                //PrintColor(options, Colors, new int[] { 0, 0, 9, 0, 0, 0, 1, 0, 0, 6, 0, 0, 8, 0, 0, 3, 0, 0, 5, 0, 0, 9, 0, 0 });

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
            if (text.Length <= maxLength) return text.PadRight(maxLength + 3);

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
            return new string(' ', Convert.ToInt32(Math.Ceiling(Console.BufferWidth / 2.0 - width / 2.0)));
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
    }
}