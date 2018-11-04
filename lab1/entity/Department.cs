using System.Collections.Generic;

namespace SqlServerEFSample
{
    public class Department
    {
        public Department()
        {
        }

        public Department(string name, University assignedTo)
        {
            Name = name;
            AssignedTo = assignedTo;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual University AssignedTo { get; set; }
        public virtual IList<Teacher> Teachers { get; set; }

        public override string ToString()
        {
            return "{Department = " +
                   "Id: " + Id +
                   ", Name: " + Name +
                   ", Teachers: " + ListUtils.listToString(Teachers) + "}";
        }
    }
}
