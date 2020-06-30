using Gandalan.Client.Contracts;
using System.Collections.Generic;

namespace Gandalan.IBOS3.Module.Lookups.Artikel
{
    public interface IDokumenteLookup : ILookupDialog<IDocumentsLookupResult, IDocodumentsLookupParams>
    {
    }

    public interface IDocument { }

    public interface IDocodumentsLookupParams
    {
        IList<IDocument> Documents { get; }
    }

    public interface IDocumentsLookupResult
    {
        IDocument Document { get; }
    }

    public class DocodumentsLookupParams : IDocodumentsLookupParams
    {
        public IList<IDocument> Documents { get; set; }
    }

    public class DocumentsLookupResult : IDocumentsLookupResult
    {
        public DocumentsLookupResult(IDocument doc)
        {
            Document = doc;
        }

        public static DocumentsLookupResult Empty { get; }

        public IDocument Document { get; set; }
        public bool IsValid => Document != null;
    }
}
