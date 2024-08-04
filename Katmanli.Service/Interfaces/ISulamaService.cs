using Katmanli.Core.Response;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.BitkiDTO;
using static Katmanli.DataAccess.DTOs.SulamaDTO;

namespace Katmanli.Service.Interfaces
{
    public interface ISulamaService
    {
        IResponse<string> Create(SulamaCreate model);
        Task<IResponse<string>> Delete(int id);

        IResponse<SulamaQuery> GetSulamaById(int sulamaId);

        IResponse<IEnumerable<SulamaQuery>> ListAll();
    }
}
