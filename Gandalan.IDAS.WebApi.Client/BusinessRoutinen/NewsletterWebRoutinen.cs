using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Diagnostics;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client
{
    public class NewsletterWebRoutinen : WebRoutinenBase
    {
        public NewsletterWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public void RequestNewsletter(Guid guid)
        {
            if (Login())
            {
                Post<string>($"Newsletter/?id={guid.ToString()}&eintragen=true", null);
            }
        }

        public void DeleteNewsletter(Guid guid)
        {
            if (Login())
            {
                Post<string>($"Newsletter/?id={guid.ToString()}&eintragen=false", null);
            }
        }

        public void RequestNewsletter(string mail)
        {
            if (Login())
            {
                Post<string>($"Newsletter/?mail={System.Uri.EscapeDataString(mail)}&eintragen=true", null);
            }
        }

        public void DeleteNewsletter(string mail)
        {
            if (Login())
            {
                Post<string>($"Newsletter/?mail={System.Uri.EscapeDataString(mail)}&eintragen=false", null);
            }
        }


        public async Task RequestNewsletterAsyn(Guid guid)
        {
            await Task.Run(() => RequestNewsletter(guid));
        }
        public async Task DeleteNewsletterAsyn(Guid guid)
        {
            await Task.Run(() => DeleteNewsletter(guid));
        }
        public async Task RequestNewsletterAsyn(string mail)
        {
            await Task.Run(() => RequestNewsletter(mail));
        }
        public async Task DeleteNewsletterAsyn(string mail)
        {
            await Task.Run(() => DeleteNewsletter(mail));
        }
    }
}
