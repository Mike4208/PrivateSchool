using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Trainer
    {
        private string _firstname;
        private string _lastname;

        public Trainer() : this("Kwstas", "Petridis") { }
        public Trainer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
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
