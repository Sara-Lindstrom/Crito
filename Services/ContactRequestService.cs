using Crito.Contexts;
using Crito.Models;
using Crito.Models.Entities;

namespace Crito.Services;

public class ContactRequestService
{
    private readonly DataContext _context;

    public ContactRequestService(DataContext context)
    {
        _context = context;
    }

    public async Task AddNewContactRequest(ContactForm form)
    {
        _context.ContactRequests.Add(new ContactFormEntity
        {
            Id = Guid.NewGuid(),
            Name = form.Name,
            Email = form.Email,
            Message = form.Message,
        });

        await _context.SaveChangesAsync();
    }
}
