using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    public abstract class Object3D : GraphicObject
    {
        public enum Dim { X, Y, Z};

        private double[] position = new double[3];
        public double[] Position
        {
            get
            {
                return position;
            }
            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Entered array is not valid, required double[3].");
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
        public double PositionZ
        {
            get
            { return position[(int)Dim.Z]; }
            set
            { position[(int)Dim.Z] = value; }
        }

        private double[] rotation = new double[3];
        public double[] Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Entered array is not valid, required double[3].");
                
                if (value[(int)Dim.X] > 0.0)
                    rotation[(int)Dim.X] = ((value[(int)Dim.X] / 360.0) - ((long)value[(int)Dim.X] / 360)) * 360.0;
                else if (value[(int)Dim.X] < 0.0)
                    rotation[(int)Dim.X] = 360.0 - ((value[(int)Dim.X] / 360.0) - ((long)value[(int)Dim.X] / 360)) * 360.0;
                else
                    rotation[(int)Dim.X] = value[(int)Dim.X];

                if (value[(int)Dim.Y] > 0.0)
                    rotation[(int)Dim.Y] = ((value[(int)Dim.Y] / 360.0) - ((long)value[(int)Dim.Y] / 360)) * 360.0;
                else if (value[(int)Dim.Z] < 0.0)
                    rotation[(int)Dim.Y] = 360.0 - ((value[(int)Dim.Y] / 360.0) - ((long)value[(int)Dim.Y] / 360)) * 360.0;
                else
                    rotation[(int)Dim.Y] = value[(int)Dim.Y];

                if (value[(int)Dim.Z] > 0.0)
                    rotation[(int)Dim.Z] = ((value[(int)Dim.Z] / 360.0) - ((long)value[(int)Dim.Z] / 360)) * 360.0;
                else if (value[(int)Dim.Z] < 0.0)
                    rotation[(int)Dim.Z] = 360.0 - ((value[(int)Dim.Z] / 360.0) - ((long)value[(int)Dim.Z] / 360)) * 360.0;
                else
                    rotation[(int)Dim.Z] = value[(int)Dim.Z];
            }
        }
        public double RotationX
        {
            get
            { return rotation[(int)Dim.X]; }
            set
            {
                if (value > 0.0)
                    rotation[(int)Dim.X] = ((value / 360.0) - ((long)value / 360)) * 360.0;
                else
                    rotation[(int)Dim.X] = 360.0 - ((value / 360.0) - ((long)value / 360)) * 360.0;
            }
        }
        public double RotationY
        {
            get
            { return rotation[(int)Dim.Y]; }
            set
            {
                if (value > 0.0)
                    rotation[(int)Dim.Y] = ((value / 360.0) - ((long)value / 360)) * 360.0;
                else
                    rotation[(int)Dim.Y] = 360.0 - ((value / 360.0) - ((long)value / 360)) * 360.0;
            }
        }
        public double RotationZ
        {
            get
            { return rotation[(int)Dim.Z]; }
            set
            {
                if (value > 0.0)
                    rotation[(int)Dim.Z] = ((value / 360.0) - ((long)value / 360)) * 360.0;
                else
                    rotation[(int)Dim.Z] = 360.0 - ((value / 360.0) - ((long)value / 360)) * 360.0;
            }
        }
        public abstract double GetSurfaceArea();
        public abstract double GetObjectVolume();
    }
}
