using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.Lookups;

public interface IFeldEditor
{
    [Obsolete("Use CanHandle(BelegPositionDTO data, UIEingabeFeldDTO feldDTO = null, string tag = null) instead.")]
    bool CanHandle(BelegPositionDTO data, string tag, bool initGroup = false);
    bool CanHandle(BelegPositionDTO data, UIEingabeFeldDTO feldDTO = null, string tag = null);
    Task<Dictionary<string, string>> ExecuteAsync(BelegPositionDTO data);
}

public interface IFeldEditor<T> : IFeldEditor where T : class
{
    void Init(T data);
}