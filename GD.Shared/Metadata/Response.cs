using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Shared.Metadata.Response
{
    public class Response
    {
        public string status { get; set; }
        public string http_code { get; set; }
        public error error { get; set; }

    }
}
