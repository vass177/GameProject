using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GameProject
{
    class GameElement
    {
        private Point location;
        protected double height;
        protected double width;


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
            this.height = height;
            this.width = width;
            Shape = new EllipseGeometry(new Rect(0, 0, width, height));
        }
    }
    class Rectangle : GameElement
    {
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
            Shape = new RectangleGeometry(new Rect(0, 0, width, height));
        }
    }
    class Cross : GameElement
    {
        public Cross(double height, double width)
        {
            this.height = height;
            this.width = width;
            GeometryGroup group = new GeometryGroup();
            group.Children.Add(new LineGeometry(Location, new Point(Location.X + width, Location.Y + height)));
            group.Children.Add(new LineGeometry(new Point(Location.X, Location.Y + height), new Point(Location.X + width, Location.Y)));
            Shape = group;
        }
    }
}
