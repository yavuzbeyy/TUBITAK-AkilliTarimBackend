using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.SehirBitkiDTO;

namespace Katmanli.Service.Interfaces
{
    public interface ISehirBitkiService
    {
        IResponse<string> Create(SehirBitkiCreate model);
        Task<IResponse<string>> Delete(int id);
    }
}
