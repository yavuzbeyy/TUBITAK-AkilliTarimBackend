using Katmanli.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.Entities
{
    public class Sehir : BaseEntity
    {
        public string SehirAdi {  get; set; }

        //Enlem
        public double EnlemKoordinat {  get; set; }

        //Boylam
        public double BoylamKoordinat { get; set; }

    }
}
