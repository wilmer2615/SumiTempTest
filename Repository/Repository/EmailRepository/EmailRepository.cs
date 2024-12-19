using Entities;

namespace Repository.Repository.EmailRepository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AplicationDbContext _context;

        public EmailRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Email>> AddEmailsAsync(List<Email> emails)
        {
            await this._context.Set<Email>().AddRangeAsync(emails);
            await this._context.SaveChangesAsync();

            return emails;
        }
    }
}
