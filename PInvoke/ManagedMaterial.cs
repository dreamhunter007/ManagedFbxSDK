using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedMaterial : ManagedFbxObject
    {
#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr LambertMaterial_GetAmbientColor(IntPtr pMaterial);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr LambertMaterial_GetEmissiveColor(IntPtr pMaterial);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr LambertMaterial_GetBumpColor(IntPtr pMaterial);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr LambertMaterial_GetDiffuseColor(IntPtr pMaterial);

        public ManagedMaterial(IntPtr pMaterial)
        {
            m_nativeObject = pMaterial;
        }

        public double[] GetAmbientColor()
        {
            double[] result = new double[3];
            Marshal.Copy(LambertMaterial_GetAmbientColor(m_nativeObject), result, 0, 3);
            return result;
        }

        public double[] GetEmissiveColor()
        {
            double[] result = new double[3];
            Marshal.Copy(LambertMaterial_GetEmissiveColor(m_nativeObject), result, 0, 3);
            return result;
        }

        public double[] GetBumpColor()
        {
            double[] result = new double[3];
            Marshal.Copy(LambertMaterial_GetBumpColor(m_nativeObject), result, 0, 3);
            return result;
        }

        public double[] GetDiffuseColor()
        {
            double[] result = new double[3];
            Marshal.Copy(LambertMaterial_GetDiffuseColor(m_nativeObject), result, 0, 3);
            return result;
        }

    }
}
