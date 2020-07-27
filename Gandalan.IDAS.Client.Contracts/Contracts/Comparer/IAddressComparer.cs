using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.Comparer
{
    interface IBeleganschriftComparer
    {
        bool Compare(BeleganschriftDTO beleganschrift, ZusatzanschriftDTO zusatzanschrift);
        //bool Compare(BeleganschriftDTO beleganschrift, AdresseDTO adresseDTO);
    }
}
