using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Entity
{


    public class Libros
    {
        public int? id_libro { get; set; }

        public string? nom_libro { get; set; } 

        public string? autor_libro { get; set; } 

        public string? categoria { get; set; } 

        public string? fecha_lanzamiento { get; set; } 

        public int? estado { get; set; }
       
    }
}
