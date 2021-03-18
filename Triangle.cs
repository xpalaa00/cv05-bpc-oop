using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public sealed class Triangle : Object2D
    {
        private double a;
        public double A
        {
            get
            { return a; }
            set
            {
                if (value >= b + c || b >= value + c || c >= value + b)
                    throw new ArgumentException("Unable to construct the triangle.");
                else if (value <= 0.0)
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
                if (a >= value + c || value >= a + c || c >= a + value)
                    throw new ArgumentException("Unable to construct the triangle.");
                else if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                b = value;
            }
        }

        private double c;
        public double C
        {
            get
            { return c; }
            set
            {
                if (a >= b + value || b >= a + value || value >= a + b)
                    throw new ArgumentException("Unable to construct the triangle.");
                if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                c = value;
            }
        }

        public override double GetSurfaceArea()
        {
            //Heronův vzorec
            double s = (A + B + C) / 2.0;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }

        public override void Render()
        {
            Console.WriteLine("Triangle: a = {0:f2}; b = {1:f2}; c = {2:f2}; S = [{3:f2}; {4:f2}]; rot = {5:f2}", A, B, C, PositionX, PositionY, Rotation);
        }

        public Triangle(double a, double b, double c, double posX = 0.0, double posY = 0.0, double rot = 0.0)
        {
            if (a >= b + c || b >= a + c || c >= a + b)
                throw new ArgumentException("Unable to construct the triangle.");
            A = a;
            B = b;
            C = c;
            Position = new double[2] { posX, posY };
            Rotation = rot;
        }
    }
}
