namespace ApiToAT.DataClasses
{

    public class Route
    {
        public string RouteId { get; set; }
        public string RouteShortName { get; set; }

        public Shape Shape { get; set; }

        public Route(string routeId, string routeShortName)
        {
            RouteId = routeId;
            RouteShortName = routeShortName;
        }
    }
}
