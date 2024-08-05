using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class SehirDTO
    {

        public class SehirCreate
        {
            public string SehirAdi { get; set; }

            //Enlem
            public double EnlemKoordinat { get; set; }

            //Boylam
            public double BoylamKoordinat { get; set; }
        }

        public class SehirQuery
        {

            public int Id { get; set; }
            public string SehirAdi { get; set; }

            //Enlem
            public double EnlemKoordinat { get; set; }

            //Boylam
            public double BoylamKoordinat { get; set; }
        }

    }
}
