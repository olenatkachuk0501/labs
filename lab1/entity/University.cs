using System;
using System.Collections.Generic;

namespace SqlServerEFSample
{
    public class University
    {
        public University()
        {
        }

        public University(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public virtual IList<Department> Departments { get; set; }

        public override string ToString()
        {
            return "{University = " +
                   "Id: " + Id +
                   ", Name: " + Name +
                   ", Departments: " + ListUtils.listToString(Departments) + "}";
        }
    }
}
