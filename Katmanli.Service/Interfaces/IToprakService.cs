using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface IToprakService
    {
        Task<IResponse<string>> Create(Gubreleme model);
        Task<IResponse<string>> Delete(int id);
        IResponse<Toprak> GetToprakById(int toprakId);
    }
}
