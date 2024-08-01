using Katmanli.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.Entities
{
    public class Bitki : BaseEntity
    {
        public int? IklimId { get; set; }

        public int? ToprakId { get; set; }

        public int? SulamaId { get; set; }

        public int? GubrelemeId { get; set; }//Gübreleme vs

        public string? Fotokey { get; set; }
    }
}
