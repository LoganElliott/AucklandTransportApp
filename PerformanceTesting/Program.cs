using System.Linq;
namespace PerformanceTesting
{
    class Program
    {
        const string ApiKey = "api_key=62b7f366-c205-4640-aaff-917f6e228682";
        private const string ApiUrl = "https://api.at.govt.nz/v1";
        static void Main(string[] args)
        {
            var atApi = new ApiToAT.ApiToAT(ApiKey, ApiUrl);
            string busStopId = "0001";
            var routes = atApi.GetRoutesFromId(busStopId);
            routes = atApi.AddShapesToRoute(routes);
            routes = atApi.GetAllShapesCoordinatesFromShapeId(routes);
            routes.ToArray();
        }
    }
}
