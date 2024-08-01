using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class ToprakCreate
    {
        public string? Ad { get; set; }
        public string? Aciklama { get; set; }
    }

    public class ToprakQuery
    {
        public int? Id { get; set; }
        public string? Ad { get; set; }
        public string? Aciklama { get; set; }
    }
}
