using WaggleBlazor.Models;

namespace WaggleBlazor.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext db = null;
        public PersonRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            Person per = db.Persons.Find(id);
            db.Persons.Remove(per);
            db.SaveChanges();
        }

        public void Insert(Person per)
        {
            db.Persons.Add(per);
            db.SaveChanges();
        }

        public List<Person> SelectAll()
        {
            return db.Persons.ToList();
        }

        public Person SelectByID(int id)
        {
            return db.Persons.Find(id);
        }

        public void Update(Person per)
        {
           db.Persons.Update(per);
            db.SaveChanges();
        }
    }
}
