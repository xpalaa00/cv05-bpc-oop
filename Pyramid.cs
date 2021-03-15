using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public sealed class Pyramid : Object3D
    {
        private Object2D baseSide;
        public Object2D BaseSide
        {
            get
            { return baseSide; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The base must by specified.");
                baseSide = value;
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
            if (BaseSide is Circle)
            {
                // Sp + Spl = π r^2 + π r √(r^2 + v^2)
                return BaseSide.GetSurfaceArea() + Math.PI * ((Circle)BaseSide).Radius * Math.Sqrt(Math.Pow(((Circle)BaseSide).Radius, 2.0) + Math.Pow(V, 2.0));
            }
            else if (BaseSide is Triangle)
            {
                // vp = 2 * Sp / x
                double vpa = BaseSide.GetSurfaceArea() * 2.0 / ((Triangle)BaseSide).A,
                       vpb = BaseSide.GetSurfaceArea() * 2.0 / ((Triangle)BaseSide).B,
                       vpc = BaseSide.GetSurfaceArea() * 2.0 / ((Triangle)BaseSide).C;

                // vpl = √((vp/3)^2 + v^2)
                double vpla = Math.Sqrt(Math.Pow(vpa / 3.0, 2.0) + Math.Pow(V, 2.0)),
                       vplb = Math.Sqrt(Math.Pow(vpb / 3.0, 2.0) + Math.Pow(V, 2.0)),
                       vplc = Math.Sqrt(Math.Pow(vpc / 3.0, 2.0) + Math.Pow(V, 2.0));

                // Sp + Spla + Splb + Splc = HV + (A * vpla / 2.0) + (B * vplb / 2.0) + (C * vplc / 2.0)
                return BaseSide.GetSurfaceArea() + ((Triangle)BaseSide).A * vpla / 2.0 + ((Triangle)BaseSide).B * vplb / 2.0 + ((Triangle)BaseSide).C * vplc / 2.0;
            }
            else if (BaseSide is Rectangle)
            {
                // vpl = √((x/2)^2 + v^2)
                double vpla = Math.Sqrt(Math.Pow(((Rectangle)BaseSide).A / 2.0, 2.0) + Math.Pow(V, 2.0)),
                       vplb = Math.Sqrt(Math.Pow(((Rectangle)BaseSide).B / 2.0, 2.0) + Math.Pow(V, 2.0));

                // Sp + 2 (Spla + Splb) = a b + 2 (a vpla / 2 + b vplb / 2)
                return BaseSide.GetSurfaceArea() + 2.0 * (((Rectangle)BaseSide).A * vpla / 2.0 + ((Rectangle)BaseSide).B * vplb / 2.0);
            }
            else
                throw new ArgumentException("Unsupported base type.");
        }
        public override double GetObjectVolume()
        {
            return BaseSide.GetSurfaceArea() * V / 3.0;
        }

        public override void Render()
        {
            if (BaseSide is Circle)
            {
                Console.WriteLine("Cone: r = {0:f2}; v = {1:f2}; S = [{2:f2}; {3:f2}; {4:f2}]; rot = [{5:f2}; {6:f2}; {7:f2}]", ((Circle)BaseSide).Radius, V, PositionX, PositionY, PositionZ, RotationX, RotationY, RotationZ);
            }
            else if (BaseSide is Triangle)
            {
                Console.WriteLine("Pyramid (Trigular base): a = {0:f2}; b = {1:f2}; c = {2:f2}; v = {3:f2}; S = [{4:f2}; {5:f2}; {6:f2}]; rot = [{7:f2}; {8:f2}; {9:f2}]", ((Triangle)BaseSide).A, ((Triangle)BaseSide).B, ((Triangle)BaseSide).C, V, PositionX, PositionY, PositionZ, RotationX, RotationY, RotationZ);
            }
            else if (BaseSide is Rectangle)
            {
                Console.WriteLine("Pyramid (Rectangle base): a = {0:f2}; b = {1:f2}; v = {2:f2}; S = [{3:f2}; {4:f2}; {5:f2}]; rot = [{6:f2}; {7:f2}; {8:f2}]", ((Rectangle)BaseSide).A, ((Rectangle)BaseSide).B, V, PositionX, PositionY, PositionZ, RotationX, RotationY, RotationZ);
            }
            else
                throw new ArgumentException("Unsupported base type.");
        }

        public Pyramid(Object2D baseSide, double v, double posX = 0.0, double posY = 0.0, double posZ = 0.0, double rotX = 0.0, double rotY = 0.0, double rotZ = 0.0)
        {
            BaseSide = baseSide;
            V = v;
            Position = new double[3] { posX, posY, posZ };
            Rotation = new double[3] { rotX, rotY, rotZ };
        }
    }
}
