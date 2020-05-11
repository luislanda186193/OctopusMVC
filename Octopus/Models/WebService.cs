using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class WebService
    {
        public int Id { get; set; }

        public int Order { get; set; }
        public bool Status { get; set; }
        public int WebServDescId { get; set; }
        public WebServDesc WebServDesc { get; set; }
        public string WSDesc
        {
            get
            {
                return string.Format("{0} - {1}", WebServDesc.WebServiceName, Order );
            }
        }
    }
}
