using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class SehirBitkiDTO
    {

        public class SehirBitkiCreate
        {
            public int? Id { get; set; }
            public int SehirId { get; set; }
            public int BitkiId { get; set; }
        }

        public class SehirBitkiQuery
        {
            public int? Id { get; set; }
            public int SehirId { get; set; }
            public int BitkiId { get; set; }
        }

    }
}
