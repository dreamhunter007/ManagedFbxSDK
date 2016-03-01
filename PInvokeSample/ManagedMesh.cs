using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedMesh : ManagedFbxObject
    {

        [DllImport("Win32Project1.dll")]
        private static extern IntPtr Mesh_Create(IntPtr pContainer, string pName);

        [DllImport("Win32Project1.dll")]
        private static extern int Mesh_GetPolygonCount(IntPtr pMesh);

        [DllImport("Win32Project1.dll")]
        private static extern int Mesh_GetPolygonVertex(IntPtr pMesh, int pPolygonIndex, int pPositionInPolygon);

        [DllImport("Win32Project1.dll")]
        private static extern int Mesh_GetControlPointCount(IntPtr pMesh);

        [DllImport("Win32Project1.dll")]
        private static extern IntPtr Mesh_GetControlPointAt(IntPtr pMesh, int pIndex);

        public ManagedMesh(IntPtr pPointer)
        {
            m_nativeObject = pPointer;
        }

        public ManagedMesh(ManagedSceneNode pNode, string pName)
        {
            m_nativeObject = Mesh_Create(pNode.NativeObject, pName);
        }

        public int GetPolygonCount()
        {
            return Mesh_GetPolygonCount(m_nativeObject);
        }

        public int GetPolygonVertex(int pPolygonIndex, int pPositionInPolygon)
        {
            return Mesh_GetPolygonVertex(m_nativeObject, pPolygonIndex, pPositionInPolygon);
        }

        public int GetControlPointCount()
        {
            return Mesh_GetControlPointCount(m_nativeObject);
        }

        public double[] GetControlPointAt(int pIndex)
        {
            IntPtr lVector4 = Mesh_GetControlPointAt(m_nativeObject, pIndex);
            double[] lManagedVector4 = new double[4];
            Marshal.Copy(lVector4, lManagedVector4, 0, 4);
            return lManagedVector4;
        }

    }
}
