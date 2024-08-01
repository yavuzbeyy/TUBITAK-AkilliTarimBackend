using Katmanli.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.Entities
{
    public class Iklim : BaseEntity
    {
        public string? Ad {  get; set; }

        public string? Aciklama { get; set; }
    }
}
