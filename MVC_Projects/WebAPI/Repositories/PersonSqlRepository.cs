using Microsoft.EntityFrameworkCore;
using WaggleAPI.Models;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class PersonSqlRepository : IPersonRepository
    {
        private readonly AppDbContext db = null;
        public PersonSqlRepository(AppDbContext db)
        {
            this.db = db;
        }
        public List<Person> SelectAll()
        {
            List<Person> data = db.Persons.FromSqlRaw("SELECT PersonID, FirstName, LastName, Discriminator FROM Person ORDER BY PersonID ASC").ToList();
            return data;
        }
        public Person SelectByID(int id)
        {
            Person obj = db.Persons.FromSqlRaw("SELECT PersonID, FirstName, LastName, Discriminator FROM Person WHERE PersonID={0}", id).SingleOrDefault();

            return obj;
        }

        public void Insert(Person per)
        {
            db.Database.ExecuteSqlRaw("INSERT INTO Person(FirstName,LastName,Discriminator) VALUES ({0},{1},{2})", per.FirstName, per.LastName, per.Discriminator);
        }

        public void Update(Person per)
        {
            db.Database.ExecuteSqlRaw("UPDATE Person SET FirstName={0}, LastName={1}, Discriminator={2} WHERE PersonID={3}", per.FirstName, per.LastName, per.Discriminator, per.PersonID);
        }
        public void Delete(int id)
        {
            db.Database.ExecuteSqlRaw("DELETE FROM Person WHERE PersonID={0}", id);
        }
    }
}
