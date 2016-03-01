using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public abstract class ManagedFbxObject
    {
        [DllImport("Win32Project1.dll")]
        private static extern IntPtr Object_GetName(IntPtr pObject);

        [DllImport("Win32Project1.dll")]
        private static extern void Object_SetName(IntPtr pObject, string pName);

        protected IntPtr m_nativeObject;
        public IntPtr NativeObject
        {
            get
            {
                return m_nativeObject;
            }
        }

        public bool IsValid
        {
            get
            {
                return m_nativeObject != IntPtr.Zero;
            }
        }


        public string GetName()
        {
            return Marshal.PtrToStringAnsi(Object_GetName(m_nativeObject));
        }

        public void SetName(string pName)
        {
            Object_SetName(m_nativeObject, pName);
        }
    }
}
