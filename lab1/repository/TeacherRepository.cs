using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SqlServerEFSample.repository
{
    public class TeacherRepository
    {
        private EFSampleContext context;
        private DbSet<Teacher> contextTeachers;

        public TeacherRepository(EFSampleContext context)
        {
            this.context = context;
            this.contextTeachers = context.Teachers;
        }

        public void save(Teacher teacher)
        {
            contextTeachers.Add(teacher);
            context.SaveChanges();
        }

        public void update(int id, Teacher teacher)
        {
            var query = from entity in contextTeachers
                where entity.Id == id
                select entity;
            var foundEntity = query.First();
            foundEntity.Name = teacher.Name;
            context.SaveChanges();
        }

        public Teacher finById(int id)
        {
            var query = from entity in contextTeachers
                where entity.Id == id
                select entity;
            return query.First();
        }
        
        public Teacher findByName(string name)
        {
            var query = from entity in contextTeachers
                where entity.Name == name
                select entity;
            return query.First();
        }

        public IList<Teacher> findAll()
        {
            var query = from entity in contextTeachers
                select entity;
            return query.ToList();
        }

        public void delete(int id)
        {
            var query = from entity in contextTeachers
                where entity.Id == id
                select entity;
            contextTeachers.Remove(query.First());
            context.SaveChanges();
        }
    }
}
