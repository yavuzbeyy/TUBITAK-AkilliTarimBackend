using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class BitkiDTO
    {

        public class BitkiCreate 
        {
            public string? Ad { get; set; }
            public string? Aciklama { get; set; }
            public int? IklimId { get; set; }

            public int? ToprakId { get; set; }

            public int? SulamaId { get; set; }

            public int? GubrelemeId { get; set; }//Gübreleme vs

            public string? Fotokey { get; set; }

        }


        public class BitkiQuery
        {
            public string? Ad { get; set; }
            public int? Id { get; set; }
            public string? Aciklama { get; set; }
            public int? IklimId { get; set; }

            public int? ToprakId { get; set; }

            public int? SulamaId { get; set; }

            public int? GubrelemeId { get; set; }//Gübreleme vs

            public string? Fotokey { get; set; }

        }

        public class BitkiUpdate
        {
            public int Id { get; set; }

            public string? Ad { get; set; }
            public string? Aciklama { get; set; }
            public int? IklimId { get; set; }

            public int? ToprakId { get; set; }

            public int? SulamaId { get; set; }

            public int? GubrelemeId { get; set; }//Gübreleme vs

            public string? Fotokey { get; set; }

        }

        public class BitkiFullInformation
        {
            public int Id { get; set; }

            public string? Ad { get; set; }
            public string? Aciklama { get; set; }
            public string? IklimAdi { get; set; }

            public string? IklimAciklama { get; set; }

            public string? ToprakAdi { get; set; }

            public string? ToprakAciklama { get; set; }

            public string? SulamaAdi { get; set; }

            public string? SulamaAciklama{ get; set; }

            public string? GubrelemeAdi { get; set; }//Gübreleme vs

            public string? GubrelemeAciklama { get; set; }

            public string? Fotokey { get; set; }

        }




    }

}
