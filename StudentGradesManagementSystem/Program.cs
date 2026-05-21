using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            ConsoleColor.DarkGray,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkBlue
        };
        public static int[] BannerColors =
        {
            0,
            0,
            0,
            0, 13, 0,
            0, 6, 0,
            0, 8, 0,
            0, 0, 0,
            0, 9, 0,
            0, 2, 0,
            0,
            0
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool subCon = true;         // Restrics user to input grades between 3 and 5
            bool subAvgCon = true;      // Convert all failing subject average grades to 5.0
            bool semAvgCon = false;     // Convert all failing semester average grades to 5.0
            bool GWAAvgCon = false;     // Convert all failing overall average grades to 5.0

            //
            //      Username: admin
            //      Password: 123
            //

            Login("admin", "123");
            Loading();
            Debug();

            string[] AddStudent =
            {
                "\n",
                "#", "  ╔════════════════════════════════════════════════════════════════════════════════════════════╗  \n",
                "#", "╔═╝                                                                                            ╚═╗\n",
                "#", "║    ", " █████╗ ██████╗ ██████╗     ███████╗████████╗██╗   ██╗██████╗ ███████╗███╗   ██╗████████╗", "   ║\n",
                "#", "║    ", "██╔══██╗██╔══██╗██╔══██╗    ██╔════╝╚══██╔══╝██║   ██║██╔══██╗██╔════╝████╗  ██║╚══██╔══╝", "   ║\n",
                "#", "║    ", "███████║██║  ██║██║  ██║    ███████╗   ██║   ██║   ██║██║  ██║█████╗  ██╔██╗ ██║   ██║   ", "   ║\n",
                "#", "║    ", "██╔══██║██║  ██║██║  ██║    ╚════██║   ██║   ██║   ██║██║  ██║██╔══╝  ██║╚██╗██║   ██║   ", "   ║\n",
                "#", "║    ", "██║  ██║██████╔╝██████╔╝    ███████║   ██║   ╚██████╔╝██████╔╝███████╗██║ ╚████║   ██║   ", "   ║\n",
                "#", "║    ", "╚═╝  ╚═╝╚═════╝ ╚═════╝     ╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ", "   ║\n",
                "#", "╚═╗                                                                                            ╔═╝\n",
                "#", "  ╚════════════════════════════════════════════════════════════════════════════════════════════╝  \n\n"
            };
            string[] MngGrades =
            {
                "\n",
                "#", "  ╔══════════════════════════════════════════════════════════════════════════════════════╗  \n",
                "#", "╔═╝                                                                                      ╚═╗\n",
                "#", "║    ", "███╗   ███╗███╗   ██╗ ██████╗      ██████╗ ██████╗  █████╗ ██████╗ ███████╗███████╗", "   ║\n",
                "#", "║    ", "████╗ ████║████╗  ██║██╔════╝     ██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝", "   ║\n",
                "#", "║    ", "██╔████╔██║██╔██╗ ██║██║  ███╗    ██║  ███╗██████╔╝███████║██║  ██║█████╗  ███████╗", "   ║\n",
                "#", "║    ", "██║╚██╔╝██║██║╚██╗██║██║   ██║    ██║   ██║██╔══██╗██╔══██║██║  ██║██╔══╝  ╚════██║", "   ║\n",
                "#", "║    ", "██║ ╚═╝ ██║██║ ╚████║╚██████╔╝    ╚██████╔╝██║  ██║██║  ██║██████╔╝███████╗███████║", "   ║\n",
                "#", "║    ", "╚═╝     ╚═╝╚═╝  ╚═══╝ ╚═════╝      ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚══════╝", "   ║\n",
                "#", "╚═╗                                                                                      ╔═╝\n",
                "#", "  ╚══════════════════════════════════════════════════════════════════════════════════════╝  \n\n"
            };
            string[] SubjGrades =
            {
                "\n",
                "#", "  ╔═════════════════════════════════════════════════════════════════════════════════════════╗  \n",
                "#", "╔═╝                                                                                         ╚═╗\n",
                "#", "║    ", "███████╗██╗   ██╗██████╗      ██╗     ██████╗ ██████╗  █████╗ ██████╗ ███████╗███████╗", "   ║\n",
                "#", "║    ", "██╔════╝██║   ██║██╔══██╗     ██║    ██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝", "   ║\n",
                "#", "║    ", "███████╗██║   ██║██████╔╝     ██║    ██║  ███╗██████╔╝███████║██║  ██║█████╗  ███████╗", "   ║\n",
                "#", "║    ", "╚════██║██║   ██║██╔══██╗██   ██║    ██║   ██║██╔══██╗██╔══██║██║  ██║██╔══╝  ╚════██║", "   ║\n",
                "#", "║    ", "███████║╚██████╔╝██████╔╝╚█████╔╝    ╚██████╔╝██║  ██║██║  ██║██████╔╝███████╗███████║", "   ║\n",
                "#", "║    ", "╚══════╝ ╚═════╝ ╚═════╝  ╚════╝      ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚══════╝", "   ║\n",
                "#", "╚═╗                                                                                         ╔═╝\n",
                "#", "  ╚═════════════════════════════════════════════════════════════════════════════════════════╝  \n\n"
            };
            string[] RecordCheck =
            {
                "\n",
                "#", "  ╔════════════════════════════════════════════════════════════════════════════════════════════════╗  \n",
                "#", "╔═╝                                                                                                ╚═╗\n",
                "#", "║    ", "██████╗ ███████╗ ██████╗ ██████╗ ██████╗ ██████╗      ██████╗██╗  ██╗███████╗ ██████╗██╗  ██╗", "   ║\n",
                "#", "║    ", "██╔══██╗██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔══██╗    ██╔════╝██║  ██║██╔════╝██╔════╝██║ ██╔╝", "   ║\n",
                "#", "║    ", "██████╔╝█████╗  ██║     ██║   ██║██████╔╝██║  ██║    ██║     ███████║█████╗  ██║     █████╔╝ ", "   ║\n",
                "#", "║    ", "██╔══██╗██╔══╝  ██║     ██║   ██║██╔══██╗██║  ██║    ██║     ██╔══██║██╔══╝  ██║     ██╔═██╗ ", "   ║\n",
                "#", "║    ", "██║  ██║███████╗╚██████╗╚██████╔╝██║  ██║██████╔╝    ╚██████╗██║  ██║███████╗╚██████╗██║  ██╗", "   ║\n",
                "#", "║    ", "╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝      ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝  ╚═╝", "   ║\n",
                "#", "╚═╗                                                                                                ╔═╝\n",
                "#", "  ╚════════════════════════════════════════════════════════════════════════════════════════════════╝  \n\n"
            };
            string[] RemStudent =
            {
                "\n",
                "#", "  ╔═══════════════════════════════════════════════════════════════════════════════════════════════╗  \n",
                "#", "╔═╝                                                                                               ╚═╗\n",
                "#", "║    ", "██████╗ ███████╗███╗   ███╗    ███████╗████████╗██╗   ██╗██████╗ ███████╗███╗   ██╗████████╗", "   ║\n",
                "#", "║    ", "██╔══██╗██╔════╝████╗ ████║    ██╔════╝╚══██╔══╝██║   ██║██╔══██╗██╔════╝████╗  ██║╚══██╔══╝", "   ║\n",
                "#", "║    ", "██████╔╝█████╗  ██╔████╔██║    ███████╗   ██║   ██║   ██║██║  ██║█████╗  ██╔██╗ ██║   ██║   ", "   ║\n",
                "#", "║    ", "██╔══██╗██╔══╝  ██║╚██╔╝██║    ╚════██║   ██║   ██║   ██║██║  ██║██╔══╝  ██║╚██╗██║   ██║   ", "   ║\n",
                "#", "║    ", "██║  ██║███████╗██║ ╚═╝ ██║    ███████║   ██║   ╚██████╔╝██████╔╝███████╗██║ ╚████║   ██║   ", "   ║\n",
                "#", "║    ", "╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝    ╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ", "   ║\n",
                "#", "╚═╗                                                                                               ╔═╝\n",
                "#", "  ╚═══════════════════════════════════════════════════════════════════════════════════════════════╝  \n\n"
            };

            int student = -1;
            int op = -1;
            bool fromAddStudent = false;
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
                            DisplayBanner(AddStudent);

                            boxWidth = Math.Max(Math.Max(id.Length, name.Length) + 11, 38);
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
                                id = Console.ReadLine().Trim();

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
                                name = Console.ReadLine().Trim();

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
                                padLeft + "║   ", "[2] Try again", "                      ║\n",
                                padLeft + "║   ", "[Q] Exit", "                           ║\n",
                                padLeft + "╚══════════════════════════════════════╝\n\n"
                            };

                            PrintColor(verify, Colors, new int[] { 0, 0, 1, 0, 0, 0, 4, 0, 0, 6, 0, 0, 9, 0, 0 });

                            try
                            {
                                Console.Write(padLeft + "➤ Enter option: ");
                                string input = Console.ReadLine().ToLower();

                                if (input == "q")
                                {
                                    tryAgain = false;
                                    break;
                                }

                                int option = int.Parse(input);

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
                                    id = "";
                                    name = "";
                                    nameExists = false;
                                    idExists = false;
                                    Console.Clear();
                                }
                                else
                                    Console.Clear();
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
                                    fromAddStudent = true;
                                    break;
                                }
                                else
                                    Console.Clear();
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                continue;
                            }
                        }
                    }

                    Console.Clear();
                    if (op == 1)
                        op = -1;
                }
                else if (op == 2)
                {
                    //DisplayBanner(MngGrades);
                    if (student == -1)
                    {
                        bool firstAttempt = true;
                        string[,] studentsInfo = new string[STUDENTS.GetLength(0), 5];

                        for (int j = 0; j < STUDENTS.GetLength(0); j++)
                        {
                            double GWA = 0;
                            string remark = "INCOMPLETE";
                            int color = 6;
                            int[] totalCountedUnits = new int[2];
                            double[] generalAverage = { 0, 0 };
                            bool isComplete = true;

                            for (int semester = 0; semester < 2; semester++)
                            {
                                for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                                {
                                    int units;
                                    int.TryParse(SUBJECTS[semester, i, 2], out units);

                                    double midTerm = Convert.ToDouble(GetGrade(j, semester, i, 0));
                                    double finalTerm = Convert.ToDouble(GetGrade(j, semester, i, 1));

                                    if (midTerm == 0 || finalTerm == 0 || midTerm == 8.8 || finalTerm == 8.8)
                                    {
                                        if (units != 0)
                                            isComplete = false;
                                    }
                                    else if (midTerm != 9.9 && finalTerm != 9.9)
                                    {
                                        double average = (midTerm + finalTerm) / 2;
                                        if (units != 0)
                                        {
                                            double computedGrade;

                                            if (subAvgCon && average > 3)
                                                computedGrade = 5.0 * units;
                                            else
                                                computedGrade = average * units;

                                            generalAverage[semester] += computedGrade;
                                            GWA += computedGrade;
                                            totalCountedUnits[semester] += units;
                                        }
                                    }

                                }

                                if (totalCountedUnits[semester] > 0)
                                    generalAverage[semester] /= totalCountedUnits[semester];
                            }

                            if (totalCountedUnits[0] + totalCountedUnits[1] > 0)
                                GWA /= totalCountedUnits[0] + totalCountedUnits[1];

                            if (GWA >= 1 && GWA <= 3)
                            {
                                remark = "PASSED";
                                color = 4;
                            }
                            else if (GWA > 3 && GWA <= 5)
                            {
                                if (GWAAvgCon)
                                    GWA = 5.0;
                                remark = "FAILED";
                                color = 5;
                            }

                            if (!isComplete)
                            {
                                remark = "INCOMPLETE";
                                color = 6;
                            }

                            if (semAvgCon)
                            {
                                if (generalAverage[0] > 3)
                                    generalAverage[0] = 5.0;
                                if (generalAverage[1] > 3)
                                    generalAverage[1] = 5.0;
                            }

                            if (GWA == 0)
                                studentsInfo[j, 0] = "--";
                            else
                                studentsInfo[j, 0] = GWA.ToString("F2");

                            studentsInfo[j, 0] = GradeToStr(GWA);
                            studentsInfo[j, 1] = remark;
                            studentsInfo[j, 2] = color.ToString();
                            studentsInfo[j, 3] = GradeToStr(generalAverage[0]);
                            studentsInfo[j, 4] = GradeToStr(generalAverage[1]);
                        }

                        string padLeft;
                        while (true)
                        {
                            DisplayBanner(MngGrades);
                            padLeft = GetPadding(95);

                            string[] labels =
                            {
                                padLeft + "╔════╦══════════════╦══════════════════════════════╦═════════╦═════════╦═════════╦════════════╗\n",
                                padLeft + "║ ", "No", " ║ ", "ID", "           ║ ", "Name", "                         ║ ", "1st Sem", " ║ ", "2nd Sem", " ║ ", "GWA", "     ║ ", "Remarks", "    ║\n",
                                padLeft + "╠════╬══════════════╬══════════════════════════════╬═════════╬═════════╬═════════╬════════════╣\n"
                            };

                            PrintColor(labels, Colors, new int[] { 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0 });

                            for (int j = 0; j < STUDENTS.GetLength(0); j++)
                                PrintColor(new string[] { padLeft + "║ ", (j + 1).ToString().PadLeft(2, '0'), " ║ ", Truncate(STUDENTS[j, 0], 12), " ║ ", Truncate(STUDENTS[j, 1], 28), " ║ ", studentsInfo[j, 3].PadRight(7), " ║ ", studentsInfo[j, 4].PadRight(7), " ║ ", studentsInfo[j, 0].PadRight(7), " ║ ", studentsInfo[j, 1].PadRight(10), " ║\n" }, Colors, new int[] { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, int.Parse(studentsInfo[j, 2]), 0 });

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╚════╩══════════════╩══════════════════════════════╩═════════╩═════════╩═════════╩════════════╝\n");
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
                                Console.Write(padLeft + "➤ Enter No/ID/Name ('Q' to exit): ");
                                input = Console.ReadLine().ToLower();

                                if (input == "q")
                                {
                                    Console.Clear();
                                    op = -1;
                                    break;
                                }
                                int option = int.Parse(input);

                                if (option > 0 && option <= STUDENTS.GetLength(0))
                                {
                                    Console.Clear();
                                    student = option - 1;
                                    break;
                                }
                            }
                            catch (Exception)
                            {

                            }

                            for (int i = 0; i < STUDENTS.GetLength(0); i++)
                            {
                                if (input == STUDENTS[i, 0].ToLower() || input == STUDENTS[i, 1].ToLower())
                                {
                                    student = i;
                                    break;
                                }
                            }

                            if (student != -1)
                            {
                                Console.Clear();
                                break;
                            }

                            Console.Clear();
                            firstAttempt = false;
                        }
                    }
                    
                    if (student != -1)
                    {
                        string padLeft = GetPadding(51);

                        int[] tableColorIndexes =
                        {
                            0,
                            0, 1, 2, 0, 1, 2, 2, 0,
                            0, 1, 2, 0, 1, 2, 4, 0,
                            0,
                            0,
                            0, 3, 0, 3, 0,
                            0,
                            0, 1, 2, 0, 1, 2, 0,
                            0, 1, 2, 0, 1, 2, 0,
                            0, 1, 2, 0, 1, 2, 0,
                            0, 1, 2, 4, 0, 1, 2, 4, 0,
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
                            //string generalStatus;
                            double GWA = 0;
                            string GWARemarks = "PASSED";
                            string[,,] grades = new string[2, SUBJECTS.GetLength(1), 2];
                            string[,] averages = new string[2, SUBJECTS.GetLength(1)];
                            string[,] remarks = new string[2, SUBJECTS.GetLength(1)];
                            int[,] status = new int[2, 5];

                            for (int semester = 0; semester < 2; semester++)
                            {
                                for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                                {
                                    int units;
                                    if (int.TryParse(SUBJECTS[semester, i, 2], out units))
                                        totalUnits[semester] += units;

                                    double midTerm = Convert.ToDouble(GetGrade(student, semester, i, 0));
                                    double finalTerm = Convert.ToDouble(GetGrade(student, semester, i, 1));
                                    grades[semester, i, 0] = GradeToStr(midTerm);
                                    grades[semester, i, 1] = GradeToStr(finalTerm);
                                    averages[semester, i] = "--";

                                    if (midTerm == 9.9 || finalTerm == 9.9)
                                    {
                                        //if (midTerm == 9.9)
                                        //    grades[semester, i, 1] = "DRP";
                                        remarks[semester, i] = "DROPPED";
                                        status[semester, 4]++;
                                    }
                                    else if (midTerm == 8.8 || finalTerm == 8.8)
                                    {
                                        remarks[semester, i] = "INCOMPLETE";
                                        if (units != 0)
                                            isComplete[semester] = false;
                                        status[semester, 3]++;
                                    }
                                    else if (midTerm == 0 || finalTerm == 0)
                                    {
                                        remarks[semester, i] = "PENDING";
                                        if (units != 0)
                                            isComplete[semester] = false;
                                        status[semester, 2]++;
                                    }
                                    else
                                    {
                                        double average = (midTerm + finalTerm) / 2;
                                        if (units != 0)
                                        {
                                            double computedGrade;

                                            if (subAvgCon && average > 3)
                                                computedGrade = 5.0 * units;
                                            else
                                                computedGrade = average * units;

                                            generalAverage[semester] += computedGrade;
                                            GWA += computedGrade;
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
                                            if (subAvgCon)
                                                averages[semester, i] = "5.0";
                                            else
                                                averages[semester, i] = average.ToString("F2");
                                        }
                                    }
                                }

                                if (totalCountedUnits[semester] > 0)
                                    generalAverage[semester] /= totalCountedUnits[semester];

                                tableColorIndexes[49 + semester * 4] = 4;
                                if (!isComplete[semester])
                                {
                                    generalAverageStr[semester] = "INCOMPLETE";
                                    tableColorIndexes[49 + semester * 4] = 6;
                                }
                                else if (generalAverage[semester] > 3 && generalAverage[semester] <= 5.0)
                                {
                                    if (semAvgCon)
                                        generalAverage[semester] = 5.0;
                                    generalAverageStr[semester] = "FAILED";
                                    tableColorIndexes[49 + semester * 4] = 5;
                                }
                                else
                                    generalAverageStr[semester] = "PASSED";
                            }

                            tableColorIndexes[15] = 4;
                            GWA /= totalCountedUnits[0] + totalCountedUnits[1];
                            if (!isComplete[0] || !isComplete[1])
                            {
                                GWARemarks = "INCOMPLETE";
                                tableColorIndexes[15] = 6;
                            }
                            else if (GWA > 3)
                            {
                                if (GWAAvgCon)
                                    GWA = 5.0;
                                GWARemarks = "FAILED";
                                tableColorIndexes[15] = 5;
                            }

                            if (selectedSemester == -1)
                            {
                                DisplayBanner(MngGrades);
                                padLeft = GetPadding(104);
                                string[] table =
                                {
                                    padLeft + "╔═════════════════════════════════════════════════════════════════════════╦════════════════════════════╗\n",
                                    padLeft + "║ ", "ID   : ", Truncate(STUDENTS[student, 0], 64), " ║    ", "GWA     ", ": ", GradeToStr(GWA).PadRight(10) ,"    ║\n",
                                    padLeft + "║ ", "Name : ", Truncate(STUDENTS[student, 1], 64), " ║    ", "Remarks ", ": ", GWARemarks.PadRight(10) ,"    ║\n",
                                    padLeft + "╚═════════════════════════════════════════════════════════════════════════╩════════════════════════════╝\n",
                                    padLeft + "╔═════════════════════════════════════════════════╗  ╔═════════════════════════════════════════════════╗\n",
                                    padLeft + "║                  ", "1ST SEMESTER", "                   ║  ║                  ", "2ND SEMESTER", "                   ║\n",
                                    padLeft + "╠═════════════════════════════════════════════════╣  ╠═════════════════════════════════════════════════╣\n",
                                    padLeft + "║ ", "Subjects", "        : " + SUBJECTS.GetLength(1).ToString().PadRight(29), " ║  ║ ", "Subjects", "        : " + SUBJECTS.GetLength(1).ToString().PadRight(29), " ║\n",
                                    padLeft + "║ ", "Total Units", "     : " + totalUnits[0].ToString().PadRight(29), " ║  ║ ", "Total Units", "     : " + totalUnits[1].ToString().PadRight(29), " ║\n",
                                    padLeft + "║ ", "General Average", " : " + GradeToStr(generalAverage[0]).PadRight(29), " ║  ║ ", "General Average", " : " + GradeToStr(generalAverage[1]).PadRight(29), " ║\n",
                                    padLeft + "║ ", "Remarks", "         : ", generalAverageStr[0].PadRight(29), " ║  ║ ", "Remarks", "         : ", generalAverageStr[1].PadRight(29), " ║\n",
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
                                {
                                    if (fromAddStudent)
                                    {
                                        op = -1;
                                        fromAddStudent = false;
                                    }
                                    break;
                                }
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

                                if (generalAverageStr[selectedSemester] == "PASSED")
                                    gradesTableBotColorIndexes[6] = 4;
                                else if (generalAverageStr[selectedSemester] == "FAILED")
                                    gradesTableBotColorIndexes[6] = 5;


                                while (true)
                                {
                                    DisplayBanner(MngGrades);
                                    padLeft = GetPadding(100);
                                    string[] gradesTableTop =
                                    {
                                        padLeft + "╔═════════════════════════════════════════════════════════════════╦════════════════════════════════╗\n",
                                        padLeft + "║ ", "ID   ", ": " + Truncate(STUDENTS[student, 0], 56), " ║    ", "1-3", ": ", "PASSED    ", "8.8", ": ", "INC", "     ║\n",
                                        padLeft + "║ ", "Name ", ": " + Truncate(STUDENTS[student, 1], 56), " ║    ", "5.0", ": ", "FAILED    ", "9.9", ": ", "DRP", "     ║\n",
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
                                            PrintColor(new string[] { padLeft + "║ ", (i + 1).ToString().PadLeft(2, '0'), " ║ ", Truncate(SUBJECTS[selectedSemester, i, 0], 12), " ║ ", Truncate(SUBJECTS[selectedSemester, i, 1], 23), " ║  ", SUBJECTS[selectedSemester, i, 2], "  ║ " }, Colors, new int[] { 0, 4, 0, 4, 0, 4, 0, 4, 0 });
                                            if (selectedTerm == 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.BackgroundColor = ConsoleColor.Green;
                                                Console.Write(grades[selectedSemester, i, 0].PadRight(7));
                                                Console.ResetColor();
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write(" ║ ");
                                                //Console.ForegroundColor = ConsoleColor.Green;
                                                Console.ForegroundColor = Colors[finalTermColor];
                                                Console.Write(grades[selectedSemester, i, 1].PadRight(9));
                                            }
                                            else
                                            {
                                                //Console.ForegroundColor = ConsoleColor.Green;
                                                Console.ForegroundColor = Colors[midTermColor];
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
                                            PrintColor(new string[] { padLeft + "║ ", (i + 1).ToString().PadLeft(2, '0'), " ║ ", Truncate(SUBJECTS[selectedSemester, i, 0], 12), " ║ ", Truncate(SUBJECTS[selectedSemester, i, 1], 23), " ║  ", SUBJECTS[selectedSemester, i, 2], "  ║ ", grades[selectedSemester, i, 0].PadRight(7), " ║ ", grades[selectedSemester, i, 1].PadRight(9), " ║ ", averages[selectedSemester, i].PadRight(4), "    ║ ", remarks[selectedSemester, i].PadRight(10), " ║\n" }, Colors, new int[] { 0, 2, 0, 2, 0, 2, 0, 2, 0, midTermColor, 0, finalTermColor, 0, 2, 0, remarksColor, 0 });
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
                                        else if (input == "inc")
                                            SetGrade(student, selectedSemester, selectedSubject, selectedTerm, "8.8");
                                        else if (input == "drp")
                                            SetGrade(student, selectedSemester, selectedSubject, selectedTerm, "9.9");
                                        else if (input == "pnd")
                                            SetGrade(student, selectedSemester, selectedSubject, selectedTerm, null);
                                        else if (double.TryParse(input, out grade))
                                        {
                                            if ((grade >= 1 && grade <= 3) || grade == 5.0 || grade == 8.8 || grade == 9.9 || (!subCon && grade > 3 && grade < 5))
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
                }
                else if (op == 3)
                {
                    int semester = 0;
                    int selectedSubject = -1;
                    string padLeft;

                    while (true)
                    {
                        DisplayBanner(SubjGrades);
                        if (selectedSubject == -1)
                        {
                            padLeft = GetPadding(95);

                            string[] subjects =
                            {
                                padLeft + "╔════════════════════════════════════════════╗   ╔════════════════════════════════════════════╗\n",
                                padLeft + "║                ", "1ST SEMESTER", "                ║   ║                ", "2ND SEMESTER", "                ║\n",
                                padLeft + "╠════════════════════════════════════════════╣   ╠════════════════════════════════════════════╣\n"
                            };

                            PrintColor(subjects, Colors, new int[] { 0, 0, 3, 0, 3, 0, 0 });

                            for (int i = 0; i < SUBJECTS.GetLength(1); i++)
                            {
                                int color = 2;
                                //if (i % 2 == 0)
                                //    color = 8;
                                string[] subject = { padLeft + "║ ", "[" + (i + 1).ToString().PadLeft(2, '0') + "] " + Truncate(SUBJECTS[0, i, 0], 12) + Truncate(SUBJECTS[0, i, 1], 25), " ║   ║ ", "[" + (i + 1 + SUBJECTS.GetLength(1)).ToString().PadLeft(2, '0') + "] " + Truncate(SUBJECTS[1, i, 0], 12) + Truncate(SUBJECTS[1, i, 1], 25), " ║\n" };
                                PrintColor(subject, Colors, new int[] { 0, color, 0, color, 0 });
                            }

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╚════════════════════════════════════════════╝   ╚════════════════════════════════════════════╝\n");
                            Console.ResetColor();

                            Console.Write(padLeft + "➤ Enter Option/Code ('Q' to exit): ");
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
                                padLeft + "║ ", "Subject: ", Truncate(SUBJECTS[semester, selectedSubject, 0] + "   " + SUBJECTS[semester, selectedSubject, 1], 63), " ║     ", "Units: ", "3", "     ║\n",
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
                                        if (subAvgCon)
                                            averageStr = "5.0";
                                        else
                                            averageStr = average.ToString("F2");
                                        remarks = "FAILED";
                                        colorIndex[11] = 5;
                                    }
                                    else
                                    {
                                        averageStr = average.ToString("F2");
                                        remarks = "PASSED";
                                        colorIndex[11] = 4;
                                    }
                                }

                                PrintColor(new string[] { padLeft + "║ ", Truncate(STUDENTS[i, 0], 12), " ║ ", Truncate(STUDENTS[i, 1], 31), " ║ ", midTermStr.PadRight(7), " ║ ", finalTermStr.PadRight(9), " ║ ", averageStr.PadRight(7), " ║ ", remarks.PadRight(10), " ║\n" }, Colors, colorIndex);

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
                    DisplayBanner(RecordCheck);
                    string padLeft = GetPadding(78);
                    string[] labels =
                    {
                        padLeft + "╔══════════════╦══════════════════════════════╦═════╦═════╦═════╦════════════╗\n",
                        padLeft + "║ ", "ID", "           ║ ", "Name", "                         ║ ", "PND", " ║ ", "INC", " ║ ", "DRP", " ║   ", "Status", "   ║\n",
                        padLeft + "╠══════════════╬══════════════════════════════╬═════╬═════╬═════╬════════════╣\n"
                    };

                    PrintColor(labels, Colors, new int[] { 0, 0, 1, 0, 1, 0, 10, 0, 6, 0, 7, 0, 3, 0, 0 });

                    for (int i = 0; i < STUDENTS.GetLength(0); i++)
                    {
                        int[] subjectStatus = new int[3];
                        string[] subjectStatusStr = new string[3];
                        string status = "INCOMPLETE";
                        int color = 6;

                        for (int semester = 0; semester < 2; semester++)
                        {
                            for (int j = 0; j < SUBJECTS.GetLength(1); j++)
                            {
                                double midTerm = Convert.ToDouble(GetGrade(i, semester, j, 0));
                                double finalTerm = Convert.ToDouble(GetGrade(i, semester, j, 1));

                                if (midTerm == 9.9 || finalTerm == 9.9)
                                    subjectStatus[2]++;
                                else if (midTerm == 8.8 || finalTerm == 8.8)
                                    subjectStatus[1]++;
                                else if (midTerm == 0 || finalTerm == 0)
                                    subjectStatus[0]++;
                            }
                        }

                        if (subjectStatus[0] + subjectStatus[1] == 0)
                        {
                            status = "COMPLETE";
                            color = 4;
                        }

                        for (int j = 0; j < 3; j++)
                        {
                            if (subjectStatus[j] == 0)
                                subjectStatusStr[j] = "   ";
                            else
                                subjectStatusStr[j] = subjectStatus[j].ToString().PadRight(3);
                        }


                        PrintColor(new string[] { padLeft + "║ ", Truncate(STUDENTS[i, 0], 12), " ║ ", Truncate(STUDENTS[i, 1], 28), " ║ ", subjectStatusStr[0], " ║ ", subjectStatusStr[1], " ║ ", subjectStatusStr[2], " ║ ", status.PadRight(10), " ║\n" }, Colors, new int[] { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, color, 0 });
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(padLeft + "╚══════════════╩══════════════════════════════╩═════╩═════╩═════╩════════════╝\n");
                    Console.ResetColor();

                    Console.Write(padLeft + "Press any key to return...");
                    Console.ReadKey();

                    Console.Clear();
                    op = -1;
                }
                else if (op == 5)
                {
                    bool loop = true;
                    bool firstAttempt = true;

                    while (loop)
                    {
                        if (student == -1)
                        {
                            DisplayBanner(RemStudent);
                            string padLeft = GetPadding(52);

                            string[] labels =
                            {
                                padLeft + "╔════╦══════════════╦══════════════════════════════╗\n",
                                padLeft + "║ ", "No", " ║ ", "ID", "           ║ ", "Name", "                         ║\n",
                                padLeft + "╠════╬══════════════╬══════════════════════════════╣\n"
                            };

                            PrintColor(labels, Colors, new int[] { 0, 0, 1, 0, 1, 0, 1, 0, 0 });

                            for (int i = 0; i < STUDENTS.GetLength(0); i++)
                            {
                                PrintColor(new string[] { padLeft + "║ ", (i + 1).ToString().PadLeft(2, '0'), " ║ ", Truncate(STUDENTS[i, 0], 12), " ║ ", Truncate(STUDENTS[i, 1], 28), " ║\n" }, Colors, new int[] { 0, 2, 0, 2, 0, 2, 0 });
                            }

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(padLeft + "╚════╩══════════════╩══════════════════════════════╝\n");
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
                                Console.Write(padLeft + "➤ Enter No/ID/Name ('Q' to exit): ");
                                input = Console.ReadLine().ToLower();

                                if (input == "q")
                                {
                                    Console.Clear();
                                    op = -1;
                                    break;
                                }
                                int option = int.Parse(input);

                                if (option > 0 && option <= STUDENTS.GetLength(0))
                                {
                                    Console.Clear();
                                    student = option - 1;
                                    break;
                                }
                            }
                            catch (Exception)
                            {

                            }

                            for (int i = 0; i < STUDENTS.GetLength(0); i++)
                            {
                                if (input == STUDENTS[i, 0].ToLower() || input == STUDENTS[i, 1].ToLower())
                                {
                                    student = i;
                                    break;
                                }
                            }

                            if (student != -1)
                            {
                                Console.Clear();
                                break;
                            }

                            Console.Clear();
                            firstAttempt = false;
                        }

                        if (student != -1)
                        {
                            string id = STUDENTS[student, 0];
                            string name = STUDENTS[student, 1];

                            int boxWidth;
                            string padLeft;
                            bool continueDel = false;

                            while (true)
                            {
                                DisplayBanner(RemStudent);
                                boxWidth = Math.Max(Math.Max(id.Length, name.Length) + 11, 38);
                                padLeft = GetPadding(boxWidth);
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
                                    padLeft = GetPadding(38);
                                    string[] verify =
                                    {
                                        padLeft + "╔══════════════════════════════════════╗\n",
                                        padLeft + "║      ", "Continue removing student?", "      ║\n",
                                        padLeft + "╠══════════════════════════════════════╣\n",
                                        padLeft + "║   ", "[1] Yes", "                            ║\n",
                                        padLeft + "║   ", "[Q] Exit", "                           ║\n",
                                        padLeft + "╚══════════════════════════════════════╝\n\n"
                                    };

                                    PrintColor(verify, Colors, new int[] { 0, 0, 1, 0, 0, 0, 5, 0, 0, 9, 0, 0 });

                                    try
                                    {
                                        Console.Write(padLeft + "➤ Enter option: ");
                                        string input = Console.ReadLine().ToLower();

                                        if (input == "q")
                                        {
                                            student = -1;
                                            loop = false;
                                            break;
                                        }

                                        int option = int.Parse(input);

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

                                            student = -1;
                                            continueDel = true;
                                            Console.Clear();
                                            continue;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            continue;
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

                                    PrintColor(options, Colors, new int[] { 0, 0, 1, 0, 0, 9, 0, 0 });

                                    try
                                    {
                                        Console.Write(padLeft += "Enter option: ");
                                        string input = Console.ReadLine().ToLower();

                                        if (input == "q")
                                        {
                                            op = -1;
                                            loop = false;
                                            break;
                                        }

                                        int option = int.Parse(input);

                                        if (option == 1)
                                            break;
                                        else
                                        {
                                            Console.Clear();
                                            continue;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        continue;
                                    }
                                }
                            }

                            Console.Clear();
                        }
                        else
                            break;
                    }
                }
                else
                {
                    ExitScreen();
                    break;
                }
            }
        }

        public static void DisplayBanner(string[] banner)
        {
            string padLeft = GetPadding(banner[2].Length - 1);
            int colorIndex = 0;
            for (int i = 0; i < banner.Length; i++)
            {
                if (banner[i] == "#")
                    Console.Write(padLeft);
                else
                {
                    Console.ForegroundColor = Colors[BannerColors[colorIndex]];
                    Console.Write(banner[i]);
                    colorIndex++;
                }
            }
            Console.ResetColor();
        }

        public static void ExitScreen()
        {
            Console.Clear();

            if (Console.BufferHeight > 25)
                for (int i = 0; i < (Console.BufferHeight - 20) / 2 - 2; i++)
                    Console.WriteLine();

            string padleft = GetPadding(72);

            string[] display =
            {
                padleft + "  ╔══════════════════════════════════════════════════════════════════╗\n",
                padleft + "╔═╝                            ", "Thank You!", "                            ╚═╗\n",
                padleft + "║                                                                      ║\n",
                padleft + "║", "                   ██████╗ ██████╗      ██╗     ██╗                   ", "║\n",
                padleft + "║", "                   ██╔══██╗██╔══██╗     ██║     ██║                   ", "║\n",
                padleft + "║", "                   ██████╔╝██████╔╝     ██║     ██║                   ", "║\n",
                padleft + "║", "                   ██╔══██╗██╔══██╗██   ██║██   ██║                   ", "║\n",
                padleft + "║", "                   ██████╔╝██║  ██║╚█████╔╝╚█████╔╝                   ", "║\n",
                padleft + "║", "                   ╚═════╝ ╚═╝  ╚═╝ ╚════╝  ╚════╝                    ", "║\n",
                padleft + "║                                                                      ║\n",
                padleft + "║", "                   Student Grade Management System                    ", "║\n",
                padleft + "║                                                                      ║\n",
                padleft + "║", "                 Thank you for using our application                  ", "║\n",
                padleft + "║", "                        We hope it helped you!                        ", "║\n",
                padleft + "║                                                                      ║\n",
                padleft + "╚═╗                   ", "Developed By BRJJ Developers", "                   ╔═╝\n",
                padleft + "  ╚══════════════════════════════════════════════════════════════════╝\n"
            };

            int[] displayColors =
            {
                0,
                0, 4, 0,
                0,
                0, 13, 0,
                0, 6, 0,
                0, 8, 0,
                0, 0, 0,
                0, 9, 0,
                0, 2, 0,
                0,
                0, 1, 0,
                0,
                0, 4, 0,
                0, 2, 0,
                0,
                0, 3, 0,
                0
            };

            PrintColor(display, Colors, displayColors);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(GetPadding(28) + "Press any key to exit...");
            Console.ResetColor();

            Console.ReadKey();
            Console.WriteLine("\n");
            //Console.Clear();
        }

        public static void Loading()
        {
            if (Console.BufferHeight > 25)
                for (int i = 0; i < (Console.BufferHeight - 22) / 2 - 2; i++)
                    Console.WriteLine();

            string padleft = GetPadding(72);  // Get left padding to center display
            string[] display =
            {
                padleft + "  ╔══════════════════════════════════════════════════════════════════╗  \n",
                padleft + "╔═╝                            ", "Welcome To", "                            ╚═╗\n",
                padleft + "║                                                                      ║\n",
                padleft + "║", "                   ██████╗ ██████╗      ██╗     ██╗                   ", "║\n",
                padleft + "║", "                   ██╔══██╗██╔══██╗     ██║     ██║                   ", "║\n",
                padleft + "║", "                   ██████╔╝██████╔╝     ██║     ██║                   ", "║\n",
                padleft + "║", "                   ██╔══██╗██╔══██╗██   ██║██   ██║                   ", "║\n",
                padleft + "║", "                   ██████╔╝██║  ██║╚█████╔╝╚█████╔╝                   ", "║\n",
                padleft + "║", "                   ╚═════╝ ╚═╝  ╚═╝ ╚════╝  ╚════╝                    ", "║\n",
                padleft + "║                                                                      ║\n",
                padleft + "║", "   ██████╗ ██████╗  █████╗ ██████╗ ███████╗██╗  ██╗██╗   ██╗██████╗   ", "║\n",
                padleft + "║", "  ██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝██║  ██║██║   ██║██╔══██╗  ", "║\n",
                padleft + "║", "  ██║  ███╗██████╔╝███████║██║  ██║█████╗  ███████║██║   ██║██████╔╝  ", "║\n",
                padleft + "║", "  ██║   ██║██╔══██╗██╔══██║██║  ██║██╔══╝  ██╔══██║██║   ██║██╔══██╗  ", "║\n",
                padleft + "║", "  ╚██████╔╝██║  ██║██║  ██║██████╔╝███████╗██║  ██║╚██████╔╝██████╔╝  ", "║\n",
                padleft + "║", "   ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚═════╝   ", "║\n",
                padleft + "║                                                                      ║\n",
                padleft + "╚═╗              ", "By Brent, Romar, Joshua, and John Royz", "              ╔═╝\n",
                padleft + "  ╚══════════════════════════════════════════════════════════════════╝  \n\n"
            };

            int[] displayColors =
            {
                0,
                0, 4, 0,
                0,
                0, 13, 0,
                0, 6, 0,
                0, 8, 0,
                0, 0, 0,
                0, 9, 0,
                0, 2, 0,
                0,
                0, 13, 0,
                0, 6, 0,
                0, 8, 0,
                0, 0, 0,
                0, 9, 0,
                0, 2, 0,
                0,
                0, 3, 0,
                0
            };

            PrintColor(display, Colors, displayColors);

            Console.WriteLine(GetPadding(7) + "Loading");

            Console.CursorVisible = false;
            Console.Write(GetPadding(15));
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 15; i++)
            {
                Console.Write("█");
                System.Threading.Thread.Sleep(200);
                //Console.Read();
            }
            Console.CursorVisible = true;

            //Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }

        public static void Login(string username, string password)
        {
            string input1 = "";
            string input2 = "";
            bool invalid = false;

            while (true)
            {
                for (int i = 0; i < Console.BufferHeight / 2 - 8; i++)
                    Console.WriteLine();

                string padLeft = GetPadding(40);
                string[] login =
                {
                    padLeft + "╔══════════════════════════════════════╗\n",
                    padLeft + "║                 ", "Login", "                ║\n",
                    padLeft + "╠══════════════════════════════════════╣\n",
                    padLeft + "║   ", "Username", ": " + Truncate(input1, 24), " ║\n",
                    padLeft + "║   ", "Password", ": " + Truncate(input2, 24), " ║\n",
                    padLeft + "╚══════════════════════════════════════╝\n\n"
                };

                PrintColor(login, Colors, new int[] { 0, 0, 6, 0, 0, 0, 1, 2, 0, 0, 1, 2, 0, 0 });

                if (invalid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    padLeft = GetPadding(54);
                    Console.Write(padLeft + "✗ Credentials incorrect. Press any key to try again...");
                    Console.ResetColor();
                    Console.ReadKey();

                    invalid = false;
                    input1 = "";
                    input2 = "";
                }
                else if (input1 == "")
                {
                    Console.Write(padLeft + "➤ Enter username: ");
                    input1 = Console.ReadLine().Trim();
                }
                else if (input2 == "")
                {
                    Console.Write(padLeft + "➤ Enter password: ");
                    input2 = Console.ReadLine().Trim();
                }
                else
                {
                    if (input1 == username && input2 == password)
                        break;
                    else
                        invalid = true;
                }

                Console.Clear();
            }

            Console.Clear();
        }

        public static string GradeToStr(double grade)
        {
            if (grade == 0 || double.IsNaN(grade))
                return "--";
            else if (grade == 8.8)
                return "INC";
            else if (grade == 9.9)
                return "DRP";
            else
                return grade.ToString("F2");
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
            else if (n == 0)
                return "   ";
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

        public static int GetOperation()
        {
            while (true)
            {
                string padLeft = GetPadding(72);

                string[] Home =
                {
                    "\n",
                    padLeft + "  ╔══════════════════════════════════════════════════════════════════╗  \n",
                    padLeft + "╔═╝                                                                  ╚═╗\n",
                    padLeft + "║                 ", "██╗  ██╗ ██████╗ ███╗   ███╗███████╗", "                 ║\n",
                    padLeft + "║                 ", "██║  ██║██╔═══██╗████╗ ████║██╔════╝", "                 ║\n",
                    padLeft + "║                 ", "███████║██║   ██║██╔████╔██║█████╗  ", "                 ║\n",
                    padLeft + "║                 ", "██╔══██║██║   ██║██║╚██╔╝██║██╔══╝  ", "                 ║\n",
                    padLeft + "║                 ", "██║  ██║╚██████╔╝██║ ╚═╝ ██║███████╗", "                 ║\n",
                    padLeft + "║                 ", "╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝", "                 ║\n",
                    padLeft + "╚═╗                                                                  ╔═╝\n",
                    padLeft + "  ╚══════════════════════════════════════════════════════════════════╝  \n\n"
                };
                PrintColor(Home, Colors, BannerColors);

                int width = 40;
                padLeft = GetPadding(width);

                string[] options =
                {
                    padLeft + "╔══════════════════════════════════════╗\n",
                    padLeft + "║    ", "STUDENT GRADE MANAGEMENT SYSTEM", "   ║\n",
                    padLeft + "╠══════════════════════════════════════╣\n",
                    padLeft + "║   ", "[1] Add Student", "                    ║\n",
                    padLeft + "║   ", "[2] Manage Student Grades", "          ║\n",
                    padLeft + "║   ", "[3] View Grades by Subject", "         ║\n",
                    padLeft + "║   ", "[4] Check Grades Record", "            ║\n",
                    padLeft + "║   ", "[5] Remove Student", "                 ║\n",
                    padLeft + "║   ", "[E] Exit", "                           ║\n",
                    padLeft + "╚══════════════════════════════════════╝\n\n"
                };

                //PrintColor(options, Colors, new int[] { 0, 0, 9, 0, 0, 0, 1, 0, 0, 6, 0, 0, 8, 0, 0, 5, 0, 0, 9, 0, 0 });
                PrintColor(options, Colors, new int[] { 0, 0, 9, 0, 0, 0, 1, 0, 0, 6, 0, 0, 8, 0, 0, 3, 0, 0, 5, 0, 0, 9, 0, 0 });

                try
                {
                    Console.Write(padLeft + "➤ Enter operation: ");
                    string input = Console.ReadLine().ToLower();
                    Console.Clear();

                    if (input == "e")
                        return 6;

                    int op = int.Parse(input);

                    if (op >= 1 && op <= 5)
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
            if (text.Length <= maxLength) return text.PadRight(maxLength);

            string newText = "";

            for (int i = 0; i < maxLength - 3; i++)
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
                    { "137", "Korra" },
                    { "138", "pneumonoultramicroscopicsilicovolcanoconiosis" }
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
            double failChance = 0.2;
            double anomalyRoll = _random.NextDouble();

            // 1. Adjustable check for 5.0 failure rate
            if (anomalyRoll < failChance) return "5.0";

            // Shift the remaining anomaly checks down
            double remainingRoll = _random.NextDouble();
            if (remainingRoll < 0.02) return "0";    // 2% chance
            if (remainingRoll < 0.03) return "8.8";  // 1% chance
            if (remainingRoll < 0.04) return "9.9";  // 1% chance

            // 2. Gaussian Bell Curve for passing grades (1.0 to 3.0)
            double u1 = 1.0 - _random.NextDouble();
            double u2 = 1.0 - _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            // Mean = 2.1, StdDev = 0.45
            double grade = 2.1 + (0.45 * randStdNormal);

            // 3. Clamp values
            if (grade < 1.0) grade = 1.0;
            if (grade > 3.0) grade = 3.0;

            return Math.Round(grade, 2).ToString();
        }
    }
}