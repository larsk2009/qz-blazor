using System;
using System.Collections.Generic;
using System.Text;

namespace QzBlazor
{
    public class PrinterOptions
    {
        public Bounds Bounds;

        public ColorType ColorType { get; set; }

        public int Copies { get; set; }

        public int Density { get; set; }

        public DuplexOption DuplexOption { get; set; }

        public int? FallbackDensity { get; set; }

        public Interpolation Interpolation { get; set; }

        public string JobName { get; set; }

        public bool Legacy { get; set; }
    }

    public class Bounds
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public enum ColorType
    {
        Color,
        Grayscale,
        Blackwhite
    }

    public enum DuplexOption
    {
        False,
        OneSided,
        Duplex,
        LongEdge,
        Tumble,
        ShortEdge
    }

    public enum Interpolation
    {
        Bicubic,
        Bilinear,
        NearestNeighbor
    }
}
