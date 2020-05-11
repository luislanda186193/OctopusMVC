using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class WebServRegion
    {

        public WebServRegion(){
           
        }
        public int Id { get; set; }
        public int WebServiceId { get; set; }
        public int RegionId { get; set; }
        public WebService WebService { get; set; }
        public Region Region { get; set; }
       
    }
}
