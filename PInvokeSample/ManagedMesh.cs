using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedMesh : ManagedFbxObject
    {
#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Mesh_Create(IntPtr pContainer, string pName);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int Mesh_GetPolygonCount(IntPtr pMesh);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int Mesh_GetPolygonVertex(IntPtr pMesh, int pPolygonIndex, int pPositionInPolygon);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int Mesh_GetControlPointCount(IntPtr pMesh);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Mesh_GetControlPointAt(IntPtr pMesh, int pIndex);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int Mesh_GetPolygonSize(IntPtr pMesh, int pPolygonIndex);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int Mesh_GetLayerCount(IntPtr pMesh);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Mesh_GetLayer(IntPtr pMesh, int pIndex);
        
#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int Mesh_IsTriangulated(IntPtr pMesh);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int Mesh_GetMaterialID(IntPtr pMesh, int pPolygonIndex);

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

        public int GetPolygonSize(int pPolygonIndex)
        {
            return Mesh_GetPolygonSize(m_nativeObject, pPolygonIndex);
        }

        public int GetLayerCount()
        {
            return Mesh_GetLayerCount(m_nativeObject);
        }

        public ManagedLayer GetLayer(int pIndex)
        {
            return new ManagedLayer(Mesh_GetLayer(m_nativeObject, pIndex));
        }

        public bool IsTriangulated()
        {
            return Mesh_IsTriangulated(m_nativeObject) == 1;
        }

        public int GetMaterialID(int pPolygonIndex)
        {
            return Mesh_GetMaterialID(m_nativeObject, pPolygonIndex);
        }

    }
}
