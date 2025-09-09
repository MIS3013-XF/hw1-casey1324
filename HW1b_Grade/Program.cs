// HW1b Student Grade
// Your Name: Casey Wallen
// Did you seek help? If yes, specify the helper or web link here: ChatGPT

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HW1b_StudentGrade
{
    internal class Program
    {
        
        private const decimal WeightExam1 = 15m;  
        private const decimal WeightExam2 = 25m;  
        private const decimal WeightExam3 = 25m;  
        private const decimal WeightHomework = 20m;  
        private const decimal WeightParticipation = 15m;  
        

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            // Guard check: weights must total 100
            decimal weightTotal = WeightExam1 + WeightExam2 + WeightExam3 + WeightHomework + WeightParticipation;
            if (weightTotal != 100m)
            {
                Console.WriteLine("CONFIG ERROR: Grading weights do not sum to 100%. Fix the constants at the top.");
                Console.WriteLine($"Current total = {weightTotal}%");
                Console.Write("Press any key to exit . . . ");
                Console.ReadKey(true);
                return;
            }

            
            string firstName = ReadName("What is your first name? ");
            string lastName = ReadName("What is your last name? ");
            string studentId = ReadStudentId("What is your student id? ");

            decimal pctHomework = ReadPercentage("What is your overall percentage grade for homeworks? ");
            decimal pctParticipation = ReadPercentage("What is your overall percentage grade for participations? ");
            decimal pctExam1 = ReadPercentage("What is your overall percentage grade for Exam 1? ");
            decimal pctExam2 = ReadPercentage("What is your overall percentage grade for Exam 2? ");
            decimal pctExam3 = ReadPercentage("What is your overall percentage grade for Exam 3? ");

            // Weight avg
            decimal finalPct =
                (pctExam1 * WeightExam1 +
                 pctExam2 * WeightExam2 +
                 pctExam3 * WeightExam3 +
                 pctHomework * WeightHomework +
                 pctParticipation * WeightParticipation) / 100m;

            finalPct = decimal.Round(finalPct, 2, MidpointRounding.AwayFromZero);

            
            Console.WriteLine();
            Console.WriteLine($"{firstName} {lastName} ({studentId}), your final grade is {finalPct:0.00}%");
            Console.WriteLine();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        

        private static string ReadName(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(input)) { Console.WriteLine("  Please enter a non-empty name."); continue; }

                if (Regex.IsMatch(input, @"^[A-Za-z][A-Za-z '\-]*$"))
                {
                    return ToTitleCase(input);
                }

                Console.WriteLine("  Please use letters, spaces, hyphens, or apostrophes only.");
            }
        }

        private static string ReadStudentId(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? "").Trim();

                if (Regex.IsMatch(input, @"^\d+$"))
                    return input;

                Console.WriteLine("  Student ID should contain digits only.");
            }
        }

        private static decimal ReadPercentage(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? "").Trim();

                if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value)
                    && value >= 0m && value <= 100m)
                {
                    return value;
                }

                Console.WriteLine("  Please enter a valid percent between 0 and 100 (e.g., 87.5).");
            }
        }

        private static string ToTitleCase(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }
    }
}
