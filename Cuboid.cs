using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public sealed class Cuboid : Object3D
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

        private double c;
        public double C
        {
            get
            { return c; }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                c = value;
            }
        }

        public override double GetSurfaceArea()
        {
            return 2.0 * (A * B + B * C + C * A);
        }
        public override double GetObjectVolume()
        {
            return A * B * C;
        }

        public override void Render()
        {
            Console.WriteLine("Cuboid: a = {0:f2}; b = {1:f2}; c = {2:f2}; S = [{3:f2}; {4:f2}; {5:f2}]; rot = [{6:f2}; {7:f2}; {8:f2}]", A, B, C, PositionX, PositionY, PositionZ, RotationX, RotationY, RotationZ);
        }

        public Cuboid(double a, double b, double c, double posX = 0.0, double posY = 0.0, double posZ = 0.0, double rotX = 0.0, double rotY = 0.0, double rotZ = 0.0)
        {
            A = a;
            B = b;
            C = c;
            Position = new double[3] { posX, posY, posZ };
            Rotation = new double[3] { rotX, rotY, rotZ };
        }
    }
}
