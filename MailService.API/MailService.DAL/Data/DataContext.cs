using MailService.API.MailService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailService.API.MailService.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<MailLog> MailLogs { get; set; } 
    }
}
