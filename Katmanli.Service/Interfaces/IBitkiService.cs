using Katmanli.Core.Response;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface IBitkiService
    {
        IResponse<IEnumerable<Bitki>> ListAll();
        IResponse<Bitki> FindById(int id);
        Task<IResponse<Bitki>> Update(UserUpdate model);
        Task<IResponse<string>> Create(UserCreate model);
        Task<IResponse<string>> Delete(int id);
    }
}
