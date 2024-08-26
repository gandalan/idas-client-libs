using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client;

public class NewsletterWebRoutinen : WebRoutinenBase
{
    public NewsletterWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task RequestNewsletterAsync(Guid guid)
        => await PostAsync($"Newsletter/?id={guid}&eintragen=true", null);

    public async Task RequestNewsletterAsync(string mail)
        => await PostAsync($"Newsletter/?mail={Uri.EscapeDataString(mail)}&eintragen=true", null);

    public async Task DeleteNewsletterAsync(string mail)
        => await PostAsync($"Newsletter/?mail={Uri.EscapeDataString(mail)}&eintragen=false", null);

    public async Task DeleteNewsletterAsync(Guid guid)
        => await PostAsync($"Newsletter/?id={guid}&eintragen=false", null);
}