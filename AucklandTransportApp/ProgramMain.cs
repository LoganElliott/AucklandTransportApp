using System.Collections.Generic;
using ApiToAT.DataClasses;
using Nancy;
using Nancy.Json;

namespace AucklandTransportApp
{
    public class ProgramMain :NancyModule
    {
        const string ApiKey = "api_key=62b7f366-c205-4640-aaff-917f6e228682";
        private const string ApiUrl = "https://api.at.govt.nz/v1";

        public ProgramMain()
        {
            var atApi = new ApiToAT.ApiToAT(ApiKey, ApiUrl);
            JsonSettings.MaxJsonLength = int.MaxValue;
            Get["/busStopCode={busStopCode}"] = parameters =>
            {
                string busStopCode = parameters.busStopCode.ToString();
                var busStop = new BusStop(busStopCode);
                busStop = atApi.GetStopIdFromStopCode(busStop);
                if (busStop.StopId.Length == 0)
                {
                    return "";
                }
                IEnumerable<Route> routes = atApi.GetRoutesFromId(busStop.StopId);
                routes = atApi.AddShapesToRoute(routes);
                routes = atApi.GetAllShapesCoordinatesFromShapeId(routes);
                busStop.Routes = routes;
                return Response.AsJson(busStop);
            };

            Get["/"] = parameters => "Home Page";
        }
    }
}