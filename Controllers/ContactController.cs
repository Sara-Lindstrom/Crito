using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactController : SurfaceController
    {
        private readonly NewsLetterSubscriberService _subscribeService;
        private readonly ContactRequestService _contactRequestService;

        public ContactController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            NewsLetterSubscriberService subscribeService,
            ContactRequestService contactRequestService)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _subscribeService = subscribeService;
            _contactRequestService = contactRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> ContactForm(ContactForm contactForm, string currentUrl)
        {
            Uri uri = new Uri(currentUrl);
            string subdirectory = uri.AbsolutePath;

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contactForm@crito.com", "BytMig123!");
            ////to sender
            //await mail.SendAsync(contactForm.Email, "Your request has been received.", "Hi your request was received and we will be in contact as soon as posible.");
            ////to us
            //await mail.SendAsync("umbraco@crito.com", $"{contactForm.Name} sent an request.", contactForm.Message);


            await _contactRequestService.AddNewContactRequest(contactForm);
            return LocalRedirect(subdirectory);
        }

        [HttpPost]
        public async Task<IActionResult> GetNewsForm(GetNewsForm getNewsForm, string currentUrl)
        {
            Uri uri = new Uri(currentUrl);
            string subdirectory = uri.AbsolutePath;

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            else{
                await _subscribeService.AddNewsSubscriberAsync(getNewsForm);
                return LocalRedirect(subdirectory);
            }
        }
    }
}
