using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{

    class InterCase
    {
        [DllImport("Win32Project1.dll")]
        public static extern IntPtr LoadFbxDocument(string path);

        [DllImport("Win32Project1.dll")]
        public static extern void PrintSceneName(IntPtr ptr);

        private IntPtr m_NativeScenePointer;

        public bool LoadFbx(string path)
        {
            m_NativeScenePointer = InterCase.LoadFbxDocument(path);
            return m_NativeScenePointer != IntPtr.Zero;
        }


    }
}
