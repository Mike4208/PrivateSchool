using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class CmdUtils
    {
        public int ReturnCorrespondingData(string message)
        {
            int result = 0;
            string option;
            string[] items;

            Console.WriteLine($"Choose {message}");
            if (message == "Stream")
                items = new string[] { "C#", "Java", "Python", "Javascript" };
            else
                items = new string[] { "Full time", "Part time" };

            for (int i = 0; i < items.Length; i++)
                Console.WriteLine($"For {items[i]} Press \"{i + 1}\"");
            option = Console.ReadLine();

            result = ValidateOption(option, items.Length);
            return result;
        }
        private int ValidateOption(string option, int length)
        {
            int result = 0;
            for (int i = 0; i < length; i++)
            {
                if (option == (i + 1).ToString())
                {
                    result = i + 1;
                    return result;
                }
            }
            return -1;
        }
        public Course ReturnCourse()
        {
            DateTime start;
            DateTime end;

            string title = GiveCourseDataFor("Title");
            int type = ReturnCorrespondingData("Type");
            int stream = ReturnCorrespondingData("Stream");
            string date = GiveCourseDataFor("Start Date");
            date = GiveCourseDataFor("End Date");

            DateTime.TryParse(date, out start);
            DateTime.TryParse(date, out end);

            return new Course(title, type, stream, start, end);
        }
        public Student ReturnStudent()
        {
            DateTime d;
            Console.Write("Enter first name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastname = Console.ReadLine();

            Console.Write("Enter date of birth: ");
            string dateOfBirth = Console.ReadLine();
            DateTime.TryParse(dateOfBirth, out d);

            Console.Write("Enter tuition fees");
            int tuitionFees = Convert.ToInt32(Console.ReadLine());

            return new Student(firstname, lastname, d, tuitionFees);
        }
        public Trainer ReturnTrainer()
        {
            Console.Write("Enter first name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastname = Console.ReadLine();

            return new Trainer(firstname, lastname);
        }
        public Assignment ReturnAssignment()
        {
            DateTime d;
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Description (max number of letters is 255): ");
            string description = Console.ReadLine();
            Console.Write("Enter Submition date: ");
            string submitionDate = Console.ReadLine();
            DateTime.TryParse(submitionDate, out d);
            return new Assignment(title, description, d);
        }

        public ItemsPerCourse ReturnItemsPerCourse(string item) 
        {
            Console.Write($"Enter {item}: ");
            string studentID = Console.ReadLine();
            Console.Write("Enter courseID: ");
            string courseID = Console.ReadLine();
            int sID = ConvertToNumber(studentID);
            int cID = ConvertToNumber(courseID);
            return new ItemsPerCourse(sID, cID);
        }

        private int ConvertToNumber(string entry)
        {
            string pattern = "^\\d{1,3}$";
            Match m = Regex.Match(entry, pattern, RegexOptions.IgnoreCase);
            if (!m.Success)
                entry = "0";
            return (Convert.ToInt32(entry));
        }

        private string GiveCourseDataFor(string entry)
        {

            Console.Write($"Enter Course {entry}: ");
            string title = Console.ReadLine();


            return title;
        }
    }
}
