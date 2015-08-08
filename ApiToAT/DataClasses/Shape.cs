using System.Collections.Generic;

namespace ApiToAT.DataClasses
{
    public class Shape
    {
        internal int ShapeId { get; set; }

        internal List<Coordinate> Coordinate { get; set; }

        internal Shape(int shapeId)
        {
            ShapeId = shapeId;
            Coordinate = new List<Coordinate>();

        }
    }
}
