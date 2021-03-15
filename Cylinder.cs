using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public sealed class Cylinder : Object3D
    {
        private double r;
        public double R
        {
            get
            { return r; }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                r = value;
            }
        }

        private double v;
        public double V
        {
            get
            { return v; }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("The argument cannot be negative or equal to zero.");
                v = value;
            }
        }

        public override double GetSurfaceArea()
        {
            return 2.0 * Math.PI * (Math.Pow(R, 2.0) + R * V);
        }
        public override double GetObjectVolume()
        {
            return Math.PI * Math.Pow(R, 2.0) * V;
        }

        public override void Render()
        {
            Console.WriteLine("Cylinder: r = {0:f2}; v = {1:f2}; S = [{2:f2}; {3:f2}; {4:f2}]; rot = [{5:f2}; {6:f2}; {7:f2}]", R, V, PositionX, PositionY, PositionZ, RotationX, RotationY, RotationZ);
        }

        public Cylinder(double r, double v, double posX = 0.0, double posY = 0.0, double posZ = 0.0, double rotX = 0.0, double rotY = 0.0, double rotZ = 0.0)
        {
            R = r;
            V = v;
            Position = new double[3] { posX, posY, posZ };
            Rotation = new double[3] { rotX, rotY, rotZ };
        }
    }
}
