using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDocumental.Metadata
{
    public class ExpedientsMD
    {
        public int IdExpendient { get; set; }
        public int IdProject { get; set; }
        public string FileExpendient { get; set; }
        public string Predial { get; set; }
        public string NameDemandant { get; set; }
        public Nullable<int> IdTypeProcess { get; set; }
        public string Settled { get; set; }
        public string Court { get; set; }
        public string Magistrate { get; set; }
        public string Resposible { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> appraise { get; set; }
        public System.DateTime DateCreate { get; set; }
        public int Advance { get; set; }
        public bool Active { get; set; }
    }
}