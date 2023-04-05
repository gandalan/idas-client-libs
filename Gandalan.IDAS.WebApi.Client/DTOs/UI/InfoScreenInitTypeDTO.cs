using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die Dateninitialisierung der InfoScreens.
    /// Es wird festgelegt, mit welchen Daten der InfoScreen initialisiert wird und welcher Datentyp als Basis für den Screen genutzt wird.
    /// Wird in den IInfoScreenDataInitiator Implementierungen genutzt
    /// </summary>
    public class InfoScreenInitTypeDTO
    {
        public string Name { get; set; }

        public Type Type { get; set; }

        public object Data { get; set; }

    }

}