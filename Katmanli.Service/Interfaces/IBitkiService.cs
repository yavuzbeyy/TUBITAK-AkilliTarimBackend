using Katmanli.Core.Response;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Katmanli.DataAccess.DTOs.BitkiDTO;

namespace Katmanli.Service.Interfaces
{
    public interface IBitkiService
    {
        IResponse<IEnumerable<BitkiQuery>> ListAll();
        IResponse<BitkiQuery> FindById(int id);
        Task<IResponse<BitkiUpdate>> Update(BitkiUpdate model);
        IResponse<string> Create(BitkiCreate model);
        Task<IResponse<string>> Delete(int id);
        IResponse<BitkiFullInformation> ListBitkilerFullInformation(int bitkiId);
        IResponse<IEnumerable<BitkiFullInformation>> GetCityAndPlantsByLocation(double enlemKoordinat, double boylamKoordinat);
    }
}
