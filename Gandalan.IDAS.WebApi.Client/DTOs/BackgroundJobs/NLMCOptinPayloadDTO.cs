namespace Gandalan.IDAS.WebApi.DTO
{
    public class NLMCOptinPayloadDTO : INLMCPayloadDTO
    {
        public int NewsletterId { get; set; }
        public string EmailAddresse { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Firma { get; set; }
    }
}
