﻿using System.Windows;

namespace Viewer
{
    public sealed class CircleGeometry : Geometry
    {
        public Point Center { get; }

        public double Radius { get; }

        internal override Rect Bounds { get; }

        public CircleGeometry(Point center, double radius)
        {
            Center = center;
            Radius = radius;
            Bounds = GetBounds();
        }

        internal override Point[] Intersect(Geometry other)
        {
            switch (other)
            {
                case LineGeometry line:
                    return IntersectionHelper.LineCircleIntersection(line, this);
                case CircleGeometry circle:
                    return IntersectionHelper.CircleCircleIntersecton(this, circle);
                case PolygonGeometry polygon:
                    return IntersectionHelper.CirclePolygonIntersection(this, polygon);
                default:
                    return new Point[0];
            }
        }

        private Rect GetBounds()
        {
            var a = new Point(Center.X - Radius, Center.Y + Radius);
            var b = new Point(Center.X + Radius, Center.Y - Radius);

            return new Rect(a, b);
        }
    }
}