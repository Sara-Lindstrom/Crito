using Crito.Models;
using Crito.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crito.Contexts;

public class DataContext : DbContext
{
    protected DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<GetNewsEntity> NewsLetterSubscribers { get; set; }
    public DbSet<ContactFormEntity> ContactRequests { get; set; }
}
