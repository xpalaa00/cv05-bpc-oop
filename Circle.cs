using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public sealed class Circle : Object2D
    {
        private double radius;
        public double Radius
        {
            get
            { return radius; }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                radius = value;
            }
        }

        public override double GetSurfaceArea()
        {
            return Math.PI * Math.Pow(Radius, 2.0);
        }

        public override void Render()
        {
            Console.WriteLine("Circle: r = {0:f2}; S = [{1:f2}; {2:f2}]", Radius, PositionX, PositionY);
        }

        public Circle(double r, double posX = 0.0, double posY = 0.0)
        {
            Radius = r;
            Position = new double[2] { posX, posY };
            Rotation = 0.0;
        }
    }
}
