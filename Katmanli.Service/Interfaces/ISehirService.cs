using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.BitkiDTO;
using static Katmanli.DataAccess.DTOs.SehirDTO;

namespace Katmanli.Service.Interfaces
{
    public interface ISehirService
    {
        IResponse<string> Create(SehirCreate model);
        Task<IResponse<string>> Delete(int id);

        IResponse<SehirQuery> GetSehirById(int sehirId);

        IResponse<IEnumerable<SehirQuery>> ListAll();
    }
}
