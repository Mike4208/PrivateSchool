    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Program
    {
        static void Main(string[] args)
        {
            string myDataBase = "IndividualProjectPartBFinalImported";
            PrivateSchool school = new PrivateSchool(myDataBase);
            school.Start();
        }
    }
}
