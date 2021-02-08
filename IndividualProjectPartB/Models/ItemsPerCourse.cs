using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class ItemsPerCourse
    {
        private int _itemid;
        private int _courseid;

        public ItemsPerCourse(int studentID, int courseID)
        {
            this.ItemID = studentID;
            this.CourseID = courseID;
        }

        public int CourseID
        {
            get { return _courseid; }
            private set { _courseid = value; }
        }


        public int ItemID
        {
            get { return _itemid; }
            private set { _itemid= value; }
        }

    }
}
