using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AplicationDbContext _context;

        public PersonRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Person> AddPersonAsync(Person person)
        {
            await this._context.Set<Person>().AddAsync(person);
            await this._context.SaveChangesAsync();

            return person;
        }

        public async Task<Person?> FindPersonByDocumentNumberAsync(string documentNumber)
        {
            return await _context.Set<Person>()
                                 .FirstOrDefaultAsync(p => p.DocumentNumber == documentNumber);
        }

    }
}
