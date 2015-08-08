namespace ApiToAT.DataClasses
{

    public class Route
    {
        internal string RouteId { get; set; }
        internal string RouteShortName { get; set; }

        internal Shape Shape { get; set; }

        internal Route(string routeId, string routeShortName)
        {
            RouteId = routeId;
            RouteShortName = routeShortName;
        }
    }
}
