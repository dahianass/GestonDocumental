using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDocumental.Metadata
{
    public class DocumentProcessMD
    {
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int idTypeProces { get; set; }
        public bool Complet { get; set; }

        public int idExpedient { get; set; }
        public int idCheckType { get; set; }

    }
}