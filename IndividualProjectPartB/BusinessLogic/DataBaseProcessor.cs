using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    public class DataBaseProcessor
    {
        private string _mydatabase;

        public string MyDataBase
        {
            get { return _mydatabase; }
            set { _mydatabase = value; }
        }

        public DataBaseProcessor(string myDataBase)
        {
            this.MyDataBase = myDataBase;
        }
        public void Start() 
        {
            string queryString = "";
            bool stop = false;
            string input;
            do
            {
                PrintMenuOfChoices();
                input = Console.ReadLine();
                queryString = InsertQueries(input);
                stop = SelectProductsByCategory(queryString, _mydatabase, input);
            } while (!stop);
        }
        private string InsertQueries(string input) 
        {
            string queryString = "";
            switch (input)
            {
                case "1": 
                    queryString = "select * from Students"; 
                    break;
                case "2": 
                    queryString = "select * from Trainers"; 
                    break;
                case "3":
                    queryString = "select * from Assignments";
                    break;
                case "4":
                    queryString = "select c.ID, c.Title, ct.Title, cs.Title " +
                        "from Courses c inner join CourseTypes ct " +
                        "on ct.CourseTypeID = c.ID inner join CourseStreams cs " +
                        "on cs.CourseStreamID = c.StreamId";
                    break;
                case "5":
                    queryString = "select c.Title, ct.Title, strm.Title, s.studentID, s.Firsname, s.Lastname  " +
                        "from Courses c inner join CoursesStudents cs " +
                        "on cs.courseID = c.ID inner join Students s " +
                        "on s.studentID = cs.StudentID inner join CourseTypes ct " +
                        "on ct.CourseTypeID = c.TypeId inner join CourseStreams strm " +
                        "on strm.CourseStreamID = c.StreamId " +
                        "group by c.Title, ct.Title, strm.Title, s.studentID, s.Firsname, s.Lastname";
                    break;
                case "6":
                    queryString = "select c.Title, ct.Title, strm.Title, tr.Firstname, tr.Lastname " +
                        "from Courses c inner join CoursesTrainers ctr " +
                        "on ctr.courseID = c.ID inner join Trainers tr " +
                        "on tr.TrainerID = ctr.trainerID inner join CourseTypes ct " +
                        "on ct.CourseTypeID = c.TypeId inner join CourseStreams strm " +
                        "on strm.CourseStreamID = c.StreamId " +
                        "group by c.Title, ct.Title, strm.Title, tr.Firstname, tr.Lastname";
                    break;
                case "7":
                    queryString = "select c.Title, ct.Title, strm.Title, ass.Title " +
                        "from Courses c inner join CoursesAssignments ca " +
                        "on ca.courseID = c.ID inner join Assignments ass " +
                        "on ass.AssignmentID = ca.assignmentId join CourseTypes ct " +
                        "on ct.CourseTypeID = c.TypeId inner join CourseStreams strm " +
                        "on strm.CourseStreamID = c.StreamId " +
                        "group by c.Title, ct.Title, strm.Title, ass.Title";
                    break;
                case "8":
                    queryString = "select s.studentID, s.Firsname, s.Lastname, a.Title  " +
                        "from StudentsAssignments sa inner join Students s " +
                        "on s.studentID = sa.studentID inner join Assignments a " +
                        "on a.AssignmentID = sa.assignmentID " +
                        "group by s.studentID, s.Firsname, s.Lastname, a.Title";
                    break;
                case "9":
                    queryString = "select s.studentID, s.Firsname, s.Lastname  " +
                        "from CoursesStudents cs inner join Students s " +
                        "on s.studentID = cs.StudentID inner join Courses c " +
                        "on c.ID = cs.courseID " +
                        "group by s.studentID, s.Firsname, s.Lastname " +
                        "having count(c.ID) > 1";
                    break;
                case "10": Console.Clear(); break;
            }
            return queryString;
        }
        private bool SelectProductsByCategory(string queryString, string yourDataBase, string input)
        {
            List<string>inputVariants = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            bool stop = false;
            
            if(inputVariants.Contains(input))
            {
                if (input != "10")
                {
                    using (SqlConnection conn = new SqlConnection("Server=.;Database=" + yourDataBase + ";Trusted_Connection=True;"))
                    {
                        SqlDataReader rdr = null;
                        try
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryString, conn))
                            {
                                rdr = cmd.ExecuteReader();
                                if (rdr != null)
                                {
                                    Console.WriteLine("----------------------------------------------------------------------");
                                    while (rdr.Read())
                                        stop = ExecuteQueries(rdr, input);
                                    Console.WriteLine("----------------------------------------------------------------------");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                
            }
            else
                stop = true;
            return stop;
        }
        private void PrintMenuOfChoices() 
        {
            Console.WriteLine("What do you want to display?");
            Console.WriteLine("Type 1 for a list of all the students.");
            Console.WriteLine("Type 2 for a list of all the trainers.");
            Console.WriteLine("Type 3 for a list of all the assignments.");
            Console.WriteLine("Type 4 for a list of all the courses.");
            Console.WriteLine("Type 5 to output all the students per course.");
            Console.WriteLine("Type 6 to output all the trainers per course.");
            Console.WriteLine("Type 7 to output all the assignments per course.");
            Console.WriteLine("Type 8 to output all the assignments per student.");
            Console.WriteLine("Type 9 for a list of students that belong to more than one courses.");
            Console.WriteLine("Type 10 to clear console");
            Console.WriteLine("Type anything else to return th main menu.");
        }
        private bool ExecuteQueries(SqlDataReader rdr, string input)
        {
            bool stop = false;
            switch (input)
            {
                case "1": PrintAllStudents(rdr); break;
                case "2": PrintAllTrainers(rdr); break;
                case "3": PrintAllAssignments(rdr); break;
                case "4": PrintAllCourses(rdr); break;
                case "5": PrintStudentsPerCourse(rdr); break;
                case "6": PrintAllTrainersPerCourse(rdr); break;
                case "7": PrintAllAssignmentsPerCourse(rdr); break;
                case "8": PrintAllAssignmentsPerStudent(rdr); break;
                case "9": PrintStudentsThatBelongToMoreThanOneCourse(rdr); break;
                case "10": Console.Clear(); break;
                default: stop = true; break;
            }
            return stop;
        }
        private void PrintAllStudents(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-12} {rdr[2],-15} {rdr[3],-25} {rdr[4]} ");
        }
        private void PrintAllTrainers(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-12} {rdr[2]}");
        }
        private void PrintAllAssignments(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-20} {rdr[2]} {rdr[3]}");
        }
        private void PrintAllCourses(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-5} {rdr[2]}");
        }
        private void PrintAllTrainersPerCourse(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-10} {rdr[2],-5} {rdr[3],-11} {rdr[4]}");
        }
        private void PrintAllAssignmentsPerCourse(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-10} {rdr[2],-5} {rdr[3],-11}");
        }
        private void PrintAllAssignmentsPerStudent(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-11} {rdr[2],-15} {rdr[3]}");
        }
        private void PrintStudentsThatBelongToMoreThanOneCourse(SqlDataReader rdr)
        {
            Console.WriteLine($"{rdr[0]:00} {rdr[1],-11} {rdr[2]}");
        }
        private void PrintStudentsPerCourse(SqlDataReader rdr) 
        {
            Console.WriteLine($"{rdr[0],-5} {rdr[1], -10} {rdr[2], -5} {rdr[3]:00}  {rdr[4], -12} {rdr[5]} ");
        }
    }
}
