using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedLayer : ManagedFbxObject
    {
#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Layer_GetNormals(IntPtr pLayer);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Layer_GetUVs(IntPtr pLayer);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Layer_GetMaterials(IntPtr pLayer);



        public ManagedLayer(IntPtr pLayerPtr)
        {
            m_nativeObject = pLayerPtr;
        }

        public ManagedNormal GetNormals()
        {
            return new ManagedNormal(Layer_GetNormals(m_nativeObject));
        }

        public ManagedUV GetUVs()
        {
            return new ManagedUV(Layer_GetUVs(m_nativeObject));
        }
    }

    public class ManagedNormal : ManagedFbxObject
    {

        [DllImport("Win32Project1.dll")]
        private static extern int Normal_GetCount(IntPtr pNormal);

        [DllImport("Win32Project1.dll")]
        private static extern IntPtr Normal_GetAt(IntPtr pNormal, int pIndex);

        public ManagedNormal(IntPtr pNormalPtr)
        {
            m_nativeObject = pNormalPtr;
        }

        public int GetCount()
        {
            return Normal_GetCount(m_nativeObject);
        }

        public double[] GetAt(int pIndex)
        {
            double[] dest = new double[4];
            Marshal.Copy(Normal_GetAt(m_nativeObject, pIndex), dest, 0, 4);
            return dest;
        }
    }

    public class ManagedUV : ManagedFbxObject
    {

        [DllImport("Win32Project1.dll")]
        private static extern int UV_GetCount(IntPtr pUV);

        [DllImport("Win32Project1.dll")]
        private static extern IntPtr UV_GetAt(IntPtr pUV, int pIndex);

        public ManagedUV(IntPtr pUVPtr)
        {
            m_nativeObject = pUVPtr;
        }

        public int GetCount()
        {
            return UV_GetCount(m_nativeObject);
        }

        public double[] GetAt(int pIndex)
        {
            double[] dest = new double[2];
            Marshal.Copy(UV_GetAt(m_nativeObject, pIndex), dest, 0, 2);
            return dest;
        }
    }
}
