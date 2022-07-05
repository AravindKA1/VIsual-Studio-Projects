using WaggleBlazor.Models;

namespace WaggleBlazor.Repositories
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
