using Crito.Contexts;
using Crito.Models;
using Crito.Models.Entities;

namespace Crito.Services;

public class NewsLetterSubscriberService
{
    private readonly DataContext _context;

    public NewsLetterSubscriberService(DataContext context)
    {
        _context = context;
    }

    public async Task AddNewsSubscriberAsync(GetNewsForm form)
    {
        _context.NewsLetterSubscribers.Add(new GetNewsEntity { Email = form.Email });
        await _context.SaveChangesAsync();
    }
}
