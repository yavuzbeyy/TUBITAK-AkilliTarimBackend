using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface ISehirService
    {
        Task<IResponse<string>> Create(Sehir model);
        Task<IResponse<string>> Delete(int id);

        IResponse<Sehir> GetSehirById(int sehirId);
    }
}
