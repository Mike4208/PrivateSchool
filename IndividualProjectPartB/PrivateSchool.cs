using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class PrivateSchool
    {
        private string _database;
        public PrivateSchool(string database)
        {
            this.Database = database;
        }
        public void Start() 
        {
            bool stop = false;
            do
            {
                Console.Clear();
                DisplayMenu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        DataBaseProcessor db = new DataBaseProcessor(Database);
                        db.Start();
                        break;
                    case "2":
                        Console.Clear();
                        DataInserter dat = new DataInserter(Database);
                        dat.Start();
                        break;
                    default: stop = true; break;

                }            
            } while (!stop);
        }
        private void DisplayMenu() 
        {
            Console.WriteLine("Welcome To PrivateSchool!");
            Console.WriteLine("To retrive data press \"1\"");
            Console.WriteLine("To Insert data press \"2\"");
            Console.WriteLine("Type anything else to stop the execution of the program.");
        }
        public string Database 
        { 
            get { return this._database; } 
            set { this._database = value; } 
        }
    }
}
