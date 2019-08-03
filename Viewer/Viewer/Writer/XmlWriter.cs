﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace Viewer.Writer
{
    public sealed class XmlWriter : IWriter<XElement>
    {
        private readonly IFormatProvider m_formatProvider;

        public XmlWriter(IFormatProvider formatProvider)
        {
            m_formatProvider = formatProvider;
        }

        public XElement WriteLine(Point a, Point b, Color color, DashStyle dashStyle)
        {
            return new XElement(
                "line",
                WriteLineGeometry(a, b),
                WriteColor(color),
                WriteDashStyle(dashStyle));
        }

        public XElement WriteCircle(Point center, double radius, Color color, DashStyle dashStyle, bool filled)
        {
            return new XElement(
                "circle",
                WriteCircleGeometry(center, radius),
                WriteFilled(filled),
                WriteColor(color),
                WriteDashStyle(dashStyle));
        }

        public XElement WriteTriangle(Point a, Point b, Point c, Color color, DashStyle dashStyle, bool filled)
        {
            throw new NotImplementedException();
        }

        public XElement WriteView(View view)
        {
            throw new NotImplementedException();
        }

        private XElement WriteLineGeometry(Point a, Point b)
        {
            return new XElement(
                "geometry",
                new XElement("a", $"{a.X.ToString(m_formatProvider)}; {a.Y.ToString(m_formatProvider)}"),
                new XElement("b", $"{b.X.ToString(m_formatProvider)}; {b.Y.ToString(m_formatProvider)}"));
        }

        private XElement WriteCircleGeometry(Point center, double radius)
        {
            return new XElement(
                "geometry",
                new XElement("center", $"{center.X.ToString(m_formatProvider)}; {center.Y.ToString(m_formatProvider)}"),
                new XElement("radius", $"{radius.ToString(m_formatProvider)}"));
        }

        private static XElement WriteColor(Color color)
        {
            return new XElement("color", $"{color}");
        }

        private static XElement WriteDashStyle(DashStyle dashStyle)
        {
            return new XElement("lineType", $"{dashStyle.AsString()}");
        }

        private static XElement WriteFilled(bool filled)
        {
            return new XElement("filled", $"{filled}");
        }
    }
}