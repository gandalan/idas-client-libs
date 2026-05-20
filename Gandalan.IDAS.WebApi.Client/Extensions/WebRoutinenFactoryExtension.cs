using System;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public static class WebRoutinenFactoryExtension
{
    public static T WithErrorsIgnored<T>(this Func<T> factory) where T : WebRoutinenBase
    {
        var routinen = factory();
        routinen.IgnoreOnErrorOccured = true;
        return routinen;
    }
}