using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SqlServerEFSample.repository
{
    public class UniversityRepository
    {
        private EFSampleContext context;
        private DbSet<University> contextUniversities;

        public UniversityRepository(EFSampleContext context)
        {
            this.context = context;
            this.contextUniversities = context.Universities;
        }

        public void save(University university)
        {
            contextUniversities.Add(university);
            context.SaveChanges();
        }

        public void update(int id, University university)
        {
            var query = from entity in contextUniversities
                where entity.Id == id
                select entity;
            var foundEntity = query.First();
            foundEntity.Name = university.Name;
            context.SaveChanges();
        }

        public University findById(int id)
        {
            var query = from entity in contextUniversities
                where entity.Id == id
                select entity;
            return query.First();
        }
        
        public University findByName(string name)
        {
            var query = from entity in contextUniversities
                where entity.Name == name
                select entity;
            return query.First();
        }

        public IList<University> findAll()
        {
            var query = from entity in contextUniversities
                select entity;
            return query.ToList();
        }

        public void delete(int id)
        {
            var query = from entity in contextUniversities
                where entity.Id == id
                select entity;
            contextUniversities.Remove(query.First());
            context.SaveChanges();
        }
    }
}
