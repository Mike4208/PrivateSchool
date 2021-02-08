using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Student
    {
        private string _firstname;
        private string _lastname;
        private DateTime _dateofbirth;
        private int _tuitionfees;

        public Student() : this("John", "Doe") { }
        public Student(string firstName, string LastName)
            : this(firstName, LastName, new DateTime(1990, 01, 01), 1000) { }
        public Student(string firstName, string LastName, DateTime dateOfBirth, int tuitionFees)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.DateOfBirth = dateOfBirth;
            this.TuitionFees = tuitionFees;
        }

        public int TuitionFees
        {
            get { return _tuitionfees; }
            set { _tuitionfees = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
    }
}
