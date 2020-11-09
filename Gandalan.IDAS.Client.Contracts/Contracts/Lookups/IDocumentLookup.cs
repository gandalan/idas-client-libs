using Gandalan.Client.Contracts;
using System;
using System.Collections.Generic;

namespace Gandalan.IBOS3.Module.Lookups.Document
{
    public interface IDocumentLookup : ILookupDialog<IDocumentLookupResult, IDocumentLookupParams>
    {
    }

    public interface IDocument
    {
        string Type { get; set; }
        Guid AssetGuid { get; set; }
        DateTime LastChange { get; set; }
        int Filesize { get; set; }
        string MimeType { get; set; }
        string md5 { get; set; }
    }

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
