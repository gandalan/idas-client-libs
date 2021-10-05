using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class FeedbackDTO
    {
        public Guid BackgroundJobGuid { get; set; }
        public bool HasError { get; set; }
        public bool IsFinished { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseData { get; set; }
    }
}
