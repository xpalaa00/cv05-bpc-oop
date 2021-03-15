using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public sealed class Sphere : Object3D
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

        public override double GetSurfaceArea()
        {
            return 4.0 * Math.PI * Math.Pow(R, 2.0);
        }
        public override double GetObjectVolume()
        {
            return (4.0 / 3.0)  * Math.PI * Math.Pow(R, 3.0);
        }

        public override void Render()
        {
            Console.WriteLine("Sphere: r = {0:f2}; S = [{1:f2}; {2:f2}; {3:f2}]", R, PositionX, PositionY, PositionZ);
        }

        public Sphere(double r, double posX = 0.0, double posY = 0.0, double posZ = 0.0)
        {
            R = r;
            Position = new double[3] { posX, posY, posZ };
            Rotation = new double[3] { 0.0, 0.0, 0.0 };
        }
    }
}
