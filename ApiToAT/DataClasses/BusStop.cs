using System;
using System.Collections.Generic;

namespace ApiToAT.DataClasses
{
    public class BusStop
    {
        public string StopCode { get; set; }

        public string StopId { get; set; }

        public IEnumerable<Route> Routes { get; set; }
        public BusStop(string stopCode)
        {
            StopCode = stopCode;
        }
    }
}
