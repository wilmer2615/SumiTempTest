using Entities;

namespace Repository.Repository.PhoneRepository
{
    public interface IPhoneRepository
    {
        public Task<List<Phone>> AddPhonesAsync(List<Phone> phones);
    }
}
