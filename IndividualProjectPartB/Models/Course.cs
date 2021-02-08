using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Course
    {
        private string _title;
        private int _typeValue;
        private int _streamvalue;
        private DateTime _startdate;
        private DateTime _enddate;

        public Course() : this("CB12", 1, 1) { }
        public Course(string title, int typeValue, int streamValue)
            : this(title, typeValue, streamValue, new DateTime(2021, 03, 01), new DateTime(2021, 07, 01)) { }

        public Course(string title, int typeValue, int streamValue, DateTime startDate, DateTime endDate)
        {
            this.Title = title;
            this.TypeValue = typeValue;
            this.StreamValue = streamValue;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

        public DateTime StartDate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        public int StreamValue
        {
            get { return _streamvalue; }
            set { _streamvalue = value; }
        }

        public int TypeValue
        {
            get { return _typeValue; }
            set { _typeValue = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

    }
}
