using Katmanli.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.Entities
{
    public class SehirBitki : BaseEntity
    {
        public int SehirId { get; set; }
        public int BitkiId { get; set; }
    }
}
