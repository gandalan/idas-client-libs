using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ICalcAblageFachBedarf
    {        
        /// <summary>
        /// Berechnet den Gesamtbedarf an Ablagefächern für eine Position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        int CalcBedarf(BelegPositionAVDTO position);

        /// <summary>
        /// Berechnet die positionsbezogene Fachnummer für ein Material (z.B. {Fr} = 1, {Fr}2 = 2, etc.)
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        int GetPositionRelatedFachNr(MaterialbedarfDTO material);
    }
}
