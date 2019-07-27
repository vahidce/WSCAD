﻿using System.Windows;

namespace Viewer
{
    internal sealed class PolygonGeometry : Geometry
    {
        public LineGeometry[] Edges { get; } 

        public PolygonGeometry(params Point[] points)
        {
            Edges = new LineGeometry[points.Length];

            int count = 0;
            while (count < points.Length - 1)
            {
                Edges[count] = new LineGeometry(points[count], points[count + 1]);
                count++;
            }

            Edges[count] = new LineGeometry(points[count], points[0]);
        }

        internal override Point[] Intersect(Geometry other)
        {
            switch (other)
            {
                case LineGeometry line:
                    return MathHelper.LinePolygonIntersection(line, this);
                case CircleGeometry circle:
                    return MathHelper.CirclePolygonIntersection(circle, this);
                case PolygonGeometry polygon:
                    return MathHelper.PolygonPolygonIntersection(polygon, this);
                default:
                    return new Point[0];
            }
        }
    }
}