using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class SulamaDTO
    {
        public class SulamaCreate
        {
            public string? Ad { get; set; }
            public string? Aciklama { get; set; }
        }

        public class SulamaQuery
        {
            public int? Id { get; set; }
            public string? Ad { get; set; }
            public string? Aciklama { get; set; }
        }
    }
}
