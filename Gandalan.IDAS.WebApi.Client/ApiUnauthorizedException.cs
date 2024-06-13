// *****************************************************************************
// Gandalan GmbH & Co. KG - (c) 2017
// *****************************************************************************
// Middleware//Gandalan.IDAS.WebApi.Client//WebRoutinenBase.cs
// Created: 27.01.2016
// Edit: phil - 21.02.2017
// *****************************************************************************

using System;

namespace Gandalan.IDAS.WebApi.Client;

[Serializable]
public class ApiUnauthorizedException : Exception
{
    public ApiUnauthorizedException()
    {
        }

    public ApiUnauthorizedException(string message) : base(message)
    {
        }

    public ApiUnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
        }
}