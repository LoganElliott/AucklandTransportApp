using System.Collections.Generic;

namespace ApiToAT.DataClasses
{
    public class Shape
    {
        public int ShapeId { get; set; }

        public List<Coordinate> Coordinates { get; set; }

        public Shape(int shapeId)
        {
            ShapeId = shapeId;
            Coordinates = new List<Coordinate>();

        }
    }
}
