using Entities;

namespace Repository.Repository.EmailRepository
{
    public interface IEmailRepository
    {
        public Task<List<Email>> AddEmailsAsync(List<Email> emails);
    }
}
