namespace ApiToAT.DataClasses
{
    public class Coordinate
    {
        internal double Latitude { get; private set; }
        internal double Longitude { get; private set; }

        internal Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
