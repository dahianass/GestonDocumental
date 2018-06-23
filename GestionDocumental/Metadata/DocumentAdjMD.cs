using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDocumental.Metadata
{
    public class DocumentAdjMD
    {
        public Nullable<int> idDocument { get; set; }
        public int idDocumentType { get; set; }
        public int IdDocumentCheck { get; set; }
        public int idCheckType { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int idType { get; set; }
        public string type { get; set; }
        public int idState { get; set; }
        public string state { get; set; }
        public bool requeried { get; set; }
        public string nameRequeried { get; set; }
        public int adj { get; set; }
        public bool adjImg { get; set; }
    }
}