using System.Collections.Generic;
using System.Linq;
using ApiToAT.DataClasses;
using ApiToAT.HelperClasses;

namespace ApiToAT
{
    public class ApiToAT
    {

        private readonly AtApiCredentials _atApiCredentials;

        public ApiToAT(string apiKey,string apiUrl)
        {
            _atApiCredentials = new AtApiCredentials(apiKey, apiUrl);
        }

        public BusStop GetStopIdFromStopCode(BusStop busBusStop)
        {
            var busStop = Utilities.GetIEnumerableJsonApiResponse(_atApiCredentials, "gtfs", "stops", "stopCode", busBusStop.StopCode).First();
            var busStopId = busStop.Value<string>("stop_id") ?? "";
            busBusStop.StopId = busStopId;
            return busBusStop;
        }

        public IEnumerable<Route> GetRoutesFromId(string stopId)
        {
            var routes = Utilities.GetIEnumerableJsonApiResponse(_atApiCredentials,"gtfs", "routes", "stopid", stopId);

            foreach (var route in routes)
            {
                var routeId = route["route_id"].ToString();
                var routeShortName = route["route_short_name"].ToString();
                yield return new Route(routeId, routeShortName);
            }
        }

        public IEnumerable<Route> AddShapesToRoute(IEnumerable<Route> routes)
        {
            foreach (var route in routes)
            {
                var trip = Utilities.GetIEnumerableJsonApiResponse(_atApiCredentials,"gtfs", "trips", "routeid", route.RouteId).First();
                var shapeId = int.Parse(trip["shape_id"].ToString());
                route.Shape = new Shape(shapeId);

                yield return route;
            }
        }

        public IEnumerable<Route> GetAllShapesCoordinatesFromShapeId(IEnumerable<Route> routes)
        {
            foreach (var route in routes)
            {
                var shapes = Utilities.GetIEnumerableJsonApiResponse(_atApiCredentials,"gtfs", "shapes", "shapeId", "" + route.Shape.ShapeId);
                foreach (var shape in shapes)
                {
                    var latitude = double.Parse(shape["shape_pt_lat"].ToString());
                    var longitude = double.Parse(shape["shape_pt_lon"].ToString());
                    route.Shape.Coordinates.Add(new Coordinate(latitude, longitude));
                }
                    yield return route;
            }
        }
    }
}
