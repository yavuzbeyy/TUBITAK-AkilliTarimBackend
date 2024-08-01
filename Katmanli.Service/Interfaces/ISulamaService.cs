using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface ISulamaService
    {
        Task<IResponse<string>> Create(Sulama model);
        Task<IResponse<string>> Delete(int id);

        IResponse<Sulama> GetSulamaById(int sulamaId);
    }
}
