using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SqlServerEFSample.repository
{
    public class DepartmentRepository
    {
        private EFSampleContext context;
        private DbSet<Department> contextDepartments;

        public DepartmentRepository(EFSampleContext context)
        {
            this.context = context;
            this.contextDepartments = context.Departments;
        }

        public void save(Department department)
        {
            contextDepartments.Add(department);
            context.SaveChanges();
        }

        public void update(int id, Department department)
        {
            var query = from entity in contextDepartments
                where entity.Id == id
                select entity;
            var foundEntity = query.First();
            foundEntity.Name = department.Name;
            context.SaveChanges();
        }

        public Department findById(int id)
        {
            var query = from entity in contextDepartments
                where entity.Id == id
                select entity;
            return query.First();
        }
        
        public Department findbyName(string name)
        {
            var query = from entity in contextDepartments
                where entity.Name == name
                select entity;
            return query.First();
        }

        public IList<Department> findAll()
        {
            var query = from entity in contextDepartments
                select entity;
            return query.ToList();
        }

        public void delete(int id)
        {
            var query = from entity in contextDepartments
                where entity.Id == id
                select entity;
            contextDepartments.Remove(query.First());
            context.SaveChanges();
        }
    }
}
