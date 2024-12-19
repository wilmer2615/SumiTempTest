using Entities;

namespace Repository.Repository.AddressRepository
{
    public interface IAddressRepository
    {
        public Task<List<Address>> AddAddressesAsync(List<Address> addresses);
    }
}
