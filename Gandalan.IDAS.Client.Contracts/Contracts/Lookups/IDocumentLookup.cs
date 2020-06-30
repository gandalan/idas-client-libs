using Gandalan.Client.Contracts;
using System.Collections.Generic;

namespace Gandalan.IBOS3.Module.Lookups.Document
{
    public interface IDoCumentLookup : ILookupDialog<IDocumentLookupResult, IDocumentLookupParams>
    {
    }

    public interface IDocument { }

    public interface IDocumentLookupParams
    {
        IList<IDocument> Documents { get; }
    }

    public interface IDocumentLookupResult
    {
        IDocument Document { get; }
    }

    public class DocumentLookupParams : IDocumentLookupParams
    {
        public IList<IDocument> Documents { get; set; }
    }

    public class DocumentLookupResult : IDocumentLookupResult
    {
        public DocumentLookupResult(IDocument doc)
        {
            Document = doc;
        }

        public static DocumentLookupResult Empty { get; }

        public IDocument Document { get; set; }
        public bool IsValid => Document != null;
    }
}
