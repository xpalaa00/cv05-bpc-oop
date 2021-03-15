using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public sealed class Rectangle : Object2D
    {
        private double a;
        public double A
        {
            get
            { return a; }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                a = value;
            }
        }

        private double b;
        public double B
        {
            get
            { return b; }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                b = value;
            }
        }

        public override double GetSurfaceArea()
        {
            return A * B;
        }

        public override void Render()
        {
            Console.WriteLine("Rectangle: a = {0:f2}; b = {1:f2}; S = [{2:f2}; {3:f2}]; rot = {4:f2}", A, B, PositionX, PositionY, Rotation);
        }

        public Rectangle(double a, double b, double posX = 0.0, double posY = 0.0, double rot = 0.0)
        {
            A = a;
            B = b;
            Position = new double[2] { posX, posY };
            Rotation = rot;
        }
    }
}
