using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace GameProject
{
    class GameElement
    {
        private Point location;
        private double height;
        private double width;
        static Brush[] brushArray = new Brush[] { Brushes.Lime, Brushes.LightGray, Brushes.LightGoldenrodYellow, Brushes.LightYellow, Brushes.LightBlue , Brushes.WhiteSmoke, Brushes.Red, Brushes.Orange};
        static Random rnd = new Random();
        public Brush ElementColor { get; set; }


        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        private Geometry shape;

        public Geometry Shape
        {
            get { return shape; }
            set { shape = value; }
        }

        public bool IsClicked { get; set; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }

        public GameElement()
        {
            IsClicked = false;
            ElementColor = brushArray[rnd.Next(0, 8)];
        }

        public Geometry GetTransformedGeometry()
        {
            Geometry copy = shape.Clone();
            copy.Transform = new TranslateTransform(Location.X, Location.Y);
            return copy.GetFlattenedPathGeometry();
        }


    }

    class Circle : GameElement
    {
        public Circle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
            Shape = new EllipseGeometry(new Rect(0, 0, width, height));
            
        }
    }
    class Rectangle : GameElement
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
            Shape = new RectangleGeometry(new Rect(0, 0, width, height));
        }
    }
    class Cross : GameElement
    {
        public Cross(double height, double width)
        {
            this.Height = height;
            this.Width = width;
            GeometryGroup group = new GeometryGroup();
            group.Children.Add(new LineGeometry(Location, new Point(Location.X + width, Location.Y + height)));
            group.Children.Add(new LineGeometry(new Point(Location.X, Location.Y + height), new Point(Location.X + width, Location.Y)));
            Shape = group;
        }
    }
    class Triangle:GameElement
    {
        public Triangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new Point(Location.X + width / 2, Location.Y);
            PathSegmentCollection segmentCollection = new PathSegmentCollection();
            segmentCollection.Add(new LineSegment() { Point = new Point(Location.X, Location.Y + height) });
            segmentCollection.Add(new LineSegment() { Point = new Point(Location.X + width, Location.Y + height) });
            figure.Segments = segmentCollection;
            figure.IsClosed = true;
            pathGeometry.Figures.Add(figure);
            Shape = pathGeometry;
        }
    }
}
