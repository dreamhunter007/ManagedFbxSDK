using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace PInvokeSample
{
    class Program
    {
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_NO_APP_ASSOCIATED = 1155; 

        static void Main(string[] args)
        {
            ManagedManager manager = new ManagedManager();
            ManagedScene scene = new ManagedScene(manager, "test");
            if(manager.ImportScene(ref scene, "E:\\u3dmodel\\ttj.FBX\0"))
            {
                Console.WriteLine(scene.GetName());
                ManagedSceneNode root = scene.GetRootNode();
                loopTheNodes(root);
            }
            Console.ReadLine();
        }

        static void loopTheNodes(ManagedSceneNode node)
        {
            ManagedMesh lMesh = node.GetMesh();
            Console.WriteLine(node.GetName() + ":");
            if(lMesh.IsValid)
            {
                Console.WriteLine("mesh:" + lMesh.GetName() + " control points count: " + lMesh.GetControlPointCount());
                Console.WriteLine("polygon count: " + lMesh.GetPolygonCount());
                for (int i = 0; i < lMesh.GetControlPointCount(); i++)
                {
                    double[] vector4  = lMesh.GetControlPointAt(i);
                }
            }
            int count = node.GetChildCount();
            for (int i = 0; i < count; i++)
            {
                ManagedSceneNode current = node.GetChild(i);
                loopTheNodes(current);
            }
        }
    }
}
