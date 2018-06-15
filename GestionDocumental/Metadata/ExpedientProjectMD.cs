using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDocumental.Metadata
{
    public class ExpedientProjectMD
    {
        public int IdProject { get; set; }
        public string CodProject { get; set; }
        public string NameProject { get; set; }
        public Nullable<int> IdRepresent { get; set; }
        public System.DateTime DateCreate { get; set; }
        public bool UseProject { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Avance { get; set; }

        public List<ExpedientsMD> ListExpendient{ get; set; }
    }
}