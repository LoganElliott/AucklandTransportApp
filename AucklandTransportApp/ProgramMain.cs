using System.Collections.Generic;
using System.Linq;
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
            Get["/busStopId={busStopId}"] = parameters =>
            {
                string busStopId = parameters.busStopId.ToString();
                if (!atApi.CheckValidBusId(busStopId))
                {
                    return "";
                }
                IEnumerable<Route>  routes = atApi.GetRoutesFromId(busStopId);
                routes = atApi.AddShapesToRoute(routes);
                routes = atApi.GetAllShapesCoordinatesFromShapeId(routes);
                return Response.AsJson(routes);
            };

        }
    }
}