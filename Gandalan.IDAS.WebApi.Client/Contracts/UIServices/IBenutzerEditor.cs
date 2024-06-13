using System;

namespace Gandalan.Client.Contracts.UIServices;

public interface IBenutzerEditor
{
    void EditBenutzer(Guid benutzerGuid, bool istProduzent);
    void DeleteBenutzer(Guid benutzerGuid);
    void CreateBenutzer(bool istProduzent);
}