using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Mail;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class MailWebRoutinen : WebRoutinenBase
{
    public MailWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<JobStatusResponseDTO> Send(MailJobInfo job, List<string> attachments)
    {
            var content = new MultipartFormDataContent
            {
                { new StringContent(JsonConvert.SerializeObject(job)), "jobAsString" }
            };
            if (attachments != null && attachments.Count > 0)
            {
                foreach (var attachment in attachments)
                {
                    // read each file and add it to the multipart form data
                    var fileStream = File.OpenRead(attachment);
                    var fileContentStream = new StreamContent(fileStream);
                    content.Add(fileContentStream, "files", Path.GetFileName(attachment));
                }
            }

            await PostDataAsync("Mail", content, version: "2.0");
            return new JobStatusResponseDTO();
            //var response = JsonConvert.DeserializeObject<JobStatusResponseDTO>(await PostDataAsync("Mail", content));
            //return response;
        }

    public async Task<IList<JobStatusEntryDTO>> GetStatus(Guid guid) =>
        await GetAsync<IList<JobStatusEntryDTO>>($"Mail/{guid}");
}

public sealed class JobStatusEntryDTO
{
    public Guid JobGuid { get; set; }
    public DateTime Timestamp { get; set; }
    public string StatusText { get; set; }
    public Guid RowKey { get; private set; }

    public JobStatusEntryDTO(Guid jobGuid, string statusText)
    {
            JobGuid = jobGuid;
            RowKey = Guid.NewGuid();
            StatusText = statusText;
            Timestamp = DateTime.UtcNow;
        }
}

public sealed class JobStatusResponseDTO
{
    public Guid JobGuid { get; set; }
}