using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IPersonRepository
    {
        List<Person> SelectAll();
        Person SelectByID(int id);
        void Insert(Person per);
        void Update(Person per);
        void Delete(int id);
    }
}
