using System.Collections.Generic;

namespace ApiToAT.DataClasses
{
    public class Shape
    {
        public int ShapeId { get; set; }

        public List<Coordinate> Coordinate { get; set; }

        public Shape(int shapeId)
        {
            ShapeId = shapeId;
            Coordinate = new List<Coordinate>();

        }
    }
}
