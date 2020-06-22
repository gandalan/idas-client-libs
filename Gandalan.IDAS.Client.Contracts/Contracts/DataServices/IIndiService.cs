﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IIndiService
    {
        Task<List<IndiPropertyListDTO>> GetAll();
        Task<IndiPropertyListDTO> GetIndiPropertyList(string propertyListTitle);
    }
}
