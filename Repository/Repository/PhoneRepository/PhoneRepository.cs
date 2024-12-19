using Entities;

namespace Repository.Repository.PhoneRepository
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly AplicationDbContext _context;

        public PhoneRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Phone>> AddPhonesAsync(List<Phone> phones)
        {
            await this._context.Set<Phone>().AddRangeAsync(phones);
            await this._context.SaveChangesAsync();

            return phones;
        }

    }
}
