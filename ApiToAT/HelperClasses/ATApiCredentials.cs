namespace ApiToAT.HelperClasses
{
    public class AtApiCredentials
    {
        public readonly string ApiUrl;
        public readonly string ApiKey;

        public AtApiCredentials(string apiKey,string apiUrl)
        {
            ApiUrl = apiUrl;
            ApiKey = apiKey;
        }
    }
}
