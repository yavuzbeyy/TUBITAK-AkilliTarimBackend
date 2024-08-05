using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.BitkiDTO;
using static Katmanli.DataAccess.DTOs.IklimDTO;

namespace Katmanli.Service.Interfaces
{
    public interface IIklimService
    {
        IResponse<string> Create(IklimCreate model);
        Task<IResponse<string>> Delete(int id);

        IResponse<IklimQuery> GetIklimById(int IklimId);

        IResponse<IEnumerable<IklimQuery>> ListAll();
    }
}
