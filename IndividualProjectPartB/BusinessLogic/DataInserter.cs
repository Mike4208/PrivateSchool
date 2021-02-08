using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class DataInserter
    {
        private CmdUtils cmd = new CmdUtils();
        private string _database;

        public string DataBase
        {
            get { return _database; }
            set { _database = value; }
        }

        public DataInserter(string database)
        {
            this.DataBase = database;
        }
        public void Start()
        {
            InsertPrivateSchoolData();
        }
        public void InsertItemsIntoDatabase(string sqlComand)
        {
            SqlConnection conn = new SqlConnection($"Server=.;Database={DataBase};Trusted_Connection=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlComand, conn);
            cmd.ExecuteNonQuery();

        }
        private void InsertPrivateSchoolData()
        {
            string input;
            string input2;
            do
            {
                Console.WriteLine("What do you want to insert?");
                Console.WriteLine("Type 1 to insert one or more courses.");
                Console.WriteLine("Type 2 to insert one or more trainers.");
                Console.WriteLine("Type 3 to insert one or more students.");
                Console.WriteLine("Type 4 to insert one or more assignments.");
                Console.WriteLine("Type 5 to insert an existing student to one or more courses.");
                Console.WriteLine("Type 6 to insert an existing trainer to one or more courses.");
                Console.WriteLine("Type 7 to insert an existing assignment to one or more courses.");
                Console.WriteLine("Type 8 to stop data insertion.");
                input = Console.ReadLine();
                // switch to choose depending user's input
                switch (input)
                {
                    case "1":
                        {
                            // insert courses until user don't press y
                            do
                            {
                                InsertItemsIntoDatabase(Course());
                                Console.Write("Do you want to insert another course? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "2":
                        {
                            // insert trainers until user don't press y
                            do
                            {
                                InsertItemsIntoDatabase(Trainer());
                                Console.Write("Do you want to insert another trainer? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "3":
                        {
                            // insert students until user don't press y
                            do
                            {
                                InsertItemsIntoDatabase(Students());
                                Console.Write("Do you want to insert another student? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "4":
                        {
                            // insert assignments until user don't press y
                            do
                            {
                                InsertItemsIntoDatabase(Assignment());
                                Console.Write("Do you want to insert another assignment? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "5":
                        {
                            do
                            {
                                InsertItemsIntoDatabase(ItemToCourses("CoursesStudents", "StudentID"));
                                Console.Write("Do you want to insert another student to course? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "6":
                        {
                            do
                            {
                                InsertItemsIntoDatabase(ItemToCourses("CoursesTrainers", "TrainerID"));
                                Console.Write("Do you want to insert another trainer to course? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "7":
                        {
                            do
                            {
                                InsertItemsIntoDatabase(ItemToCourses("CoursesAssignments", "AssignmentID"));
                                Console.Write("Do you want to insert another assignment to course? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                }
                Console.WriteLine();
            } while (input != "8");
        }
        private string Course()
        {
            Course c = this.cmd.ReturnCourse();
            DateTime d1 = c.StartDate;
            DateTime d2 = c.EndDate;
            string insertCourse = "insert into Courses(Title, TypeId, StreamId, StartDate, EndDate) " +
                $"values('{c.Title}', '{c.TypeValue}', {c.StreamValue}, " +
                $"'{d1.Year}-{d1.Month}-{d1.Day}', '{d2.Year}-{d2.Month}-{d2.Day}')";
            return (insertCourse);
        }
        private string Trainer()
        {
            Trainer t = this.cmd.ReturnTrainer();
            string insertTrainer = "insert into Trainers(Firsname, Lastname) " +
                 $"values('{t.FirstName}', '{t.LastName}')";
            return (insertTrainer);
        }
        private string Students()
        {
            Student s = this.cmd.ReturnStudent();
            DateTime d = s.DateOfBirth;
            string insertStudent = "insert into Students(Firsname, Lastname, DateOfBirth, TuitionFees) " +
                $"values('{s.FirstName}', '{s.LastName}', '{d.Year}-{d.Month}-{d.Day}', {s.TuitionFees})";
            return (insertStudent);
        }
        private string Assignment()
        {
            Assignment a = this.cmd.ReturnAssignment();
            DateTime d = a.SubDateTime;
            string insertAssignment = "insert into Assignments(Title, Description, SubmitionDate)" +
                $"values('{a.Title}', '{a.Description}', '{d.Year}-{d.Month}-{d.Day}')";
            return (insertAssignment);
        }
        private string ItemToCourses(string table, string itemID)
        {
            ItemsPerCourse c = cmd.ReturnItemsPerCourse(itemID);
            string insertItemToCourse = $"insert into {table} (courseID, {itemID})" +
                $"values({c.CourseID}, {c.ItemID})";
            return (insertItemToCourse);
        }
    }
}
