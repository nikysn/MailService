using MailService.API.Abstraction;
using MailService.API.MailService.DAL.Data;
using MailService.API.MailService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailService.API.MailService.DAL.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DataContext _dataContext;

        public EmailRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddMailLogAsync(MailLog mailLog)
        {
             _dataContext.MailLogs.Add(mailLog);

            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MailLog>> GetAllMailLogs()
        {
            return await _dataContext.MailLogs.ToArrayAsync();
        }
    }
}
