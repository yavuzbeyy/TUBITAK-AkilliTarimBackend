using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface IIklimService
    {
        Task<IResponse<string>> Create(Iklim model);
        Task<IResponse<string>> Delete(int id);

        IResponse<Iklim> GetSehirById(int IklimId);
    }
}
