using Entities;

namespace Repository.Repository.PersonRepository
{
    public interface IPersonRepository
    {
        public Task<Person> AddPersonAsync(Person person);
        public Task<Person?> FindPersonByDocumentNumberAsync(string documentNumber);
    }
}
