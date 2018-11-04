namespace SqlServerEFSample
{
    public class Teacher
    {
        public Teacher()
        {
        }

        public Teacher(string name, Department assignedTo)
        {
            Name = name;
            AssignedTo = assignedTo;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Department AssignedTo { get; set; }

        public override string ToString()
        {
            return "{University = " +
                   "Id: " + Id +
                   ", Name: " + Name + "}";
        }
    }
}
