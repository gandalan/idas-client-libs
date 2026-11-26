using System;

namespace Gandalan.Client.Contracts.UIServices;

public interface IBenutzerEditor
{
    void EditBenutzer(Guid benutzerGuid);
    void CreateBenutzer();
}