﻿using Katmanli.Core.Response;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.BitkiDTO;

namespace Katmanli.Service.Interfaces
{
    public interface IGubreService
    {
        IResponse<string> Create(GubreCreate model);
        Task<IResponse<string>> Delete(int id);
        IResponse<GubreQuery> GetGubreById(int gubreId);
        IResponse<IEnumerable<GubreQuery>> ListAll();
    }
}
