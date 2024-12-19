using Entities;

namespace Repository.Repository.AddressRepository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AplicationDbContext _context;

        public AddressRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Address>> AddAddressesAsync(List<Address> addresses)
        {
            await this._context.Set<Address>().AddRangeAsync(addresses);
            await this._context.SaveChangesAsync();

            return addresses;
        }
    }
}
