using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Shared.Metadata
{
    public class ProjectMetadata
    {
        public int IdProject { get; set; }
        public string CodProject { get; set; }
        public string NameProject { get; set; }
        public Nullable<int> IdRepresent { get; set; }
        public System.DateTime DateCreate { get; set; }
        public bool UseProject { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Avance { get; set; }
    }
}
