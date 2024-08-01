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
    public interface IToprakService
    {
        IResponse<string> Create(ToprakCreate model);
        Task<IResponse<string>> Delete(int id);
        IResponse<ToprakQuery> GetToprakById(int toprakId);
    }
}
