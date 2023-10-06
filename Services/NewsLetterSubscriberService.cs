using Crito.Contexts;
using Crito.Models;
using Crito.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
        var _subscriber = await _context.NewsLetterSubscribers.FirstOrDefaultAsync(x => x.Email == form.Email);

        if (_subscriber is null)
        {
            _context.NewsLetterSubscribers.Add(new GetNewsEntity { Email = form.Email });
            await _context.SaveChangesAsync();
        }
    }
}
