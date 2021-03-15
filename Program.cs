using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05_bpc_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GraphicObject> graphicObjects = new List<GraphicObject>();
            graphicObjects.Add(new Circle(3));
            graphicObjects.Add(new Cuboid(1, 2, 5));
            graphicObjects.Add(new Pyramid(new Triangle(3, 4, 5), 10));
            graphicObjects.Add(new Sphere(4));
            graphicObjects.Add(new Cylinder(4, 1));

            double total3DVolume = 0.0,
                   total3DSurfaceArea = 0.0,
                   total2DSurfaceArea = 0.0;

            foreach (GraphicObject currentObject in graphicObjects)
            {
                currentObject.Render();
                if(currentObject is Object2D)
                {
                    Console.WriteLine("S = {0:f2}", ((Object2D)currentObject).GetSurfaceArea());
                    total2DSurfaceArea += ((Object2D)currentObject).GetSurfaceArea();
                }
                else if(currentObject is Object3D)
                {
                    
                    if (currentObject is Pyramid)
                        Console.WriteLine("S = {0:f2}  ( Sp = {1:f2} )", ((Object3D)currentObject).GetSurfaceArea(), ((Pyramid)currentObject).BaseSide.GetSurfaceArea());
                    else
                    {
                        Console.WriteLine("S = {0:f2}", ((Object3D)currentObject).GetSurfaceArea());
                    }
                    total3DSurfaceArea += ((Object3D)currentObject).GetSurfaceArea();
                    Console.WriteLine("V = {0:f2}", ((Object3D)currentObject).GetObjectVolume());
                    total3DVolume += ((Object3D)currentObject).GetObjectVolume();
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total 2D surfaces\' area: {0:f2}", total2DSurfaceArea);
            Console.WriteLine();
            Console.WriteLine("Total 3D surfaces\' area: {0:f2}", total3DSurfaceArea);
            Console.WriteLine("Total 3D objects\' volume: {0:f2}", total3DVolume);

            Console.ReadLine();
        }
    }
}
