using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public abstract class Object2D : GraphicObject
    {
        public enum Dim { X, Y};

        private double[] position = new double[2];
        public double[] Position
        {
            get
            {
                return position;
            }
            set
            {
                if (value.Length != 2)
                    throw new ArgumentException("Entered array is not valid, required double[2].");
                position = value;
            }
        }
        public double PositionX
        {
            get
            { return position[(int)Dim.X]; }
            set
            { position[(int)Dim.X] = value; }
        }
        public double PositionY
        {
            get
            { return position[(int)Dim.Y]; }
            set
            { position[(int)Dim.Y] = value; }
        }

        private double rotation;
        public double Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                if (value > 0.0)
                    rotation = ((value / 360.0) - ((long)value / 360)) * 360.0;
                else
                    rotation = 360.0 - ((value / 360.0) - ((long)value / 360)) * 360.0;
            }
        }
        public abstract double GetSurfaceArea();
    }
}
