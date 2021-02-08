using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Assignment
    {
        private string _title;
        private string _description;
        private DateTime _subdatetime;

        public Assignment()
            : this("Un-Titled") { }
        public Assignment(string title)
            : this(title, "Un-Described", new DateTime(2021 / 04 / 01)) { }
        public Assignment(string title, string description, DateTime subDateTime)
        {
            this.Title = title;
            this.Description = description;
            this.SubDateTime = subDateTime;
        }

        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        public DateTime SubDateTime
        {
            get { return this._subdatetime; }
            set { this._subdatetime = value; }
        }
    }
}
