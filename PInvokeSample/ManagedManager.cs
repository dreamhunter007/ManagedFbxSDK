using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedManager : ManagedFbxObject
    {
#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Manager_Create();

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Importer_Create(IntPtr pContainer, string pName);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern bool Importer_Initialize(IntPtr pImporter, string pPath);


#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern bool Importer_Import(IntPtr pImporter, IntPtr pScene);


#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr Exporter_Create(IntPtr pContainer, string pName);


#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern bool Exporter_Initialize(IntPtr pExporter, string pPath);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern bool Exporter_Export(IntPtr pExporter, IntPtr pScene);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern void Manager_TriangulateMesh(IntPtr pManager, IntPtr pMesh);

        private IntPtr m_nativeImporter;
        private IntPtr m_nativeExporter;

        public ManagedManager()
        {
            m_nativeObject = Manager_Create();
            m_nativeImporter = Importer_Create(m_nativeObject, "importer");
            m_nativeExporter = Exporter_Create(m_nativeObject, "exporter");
        }

        public bool ImportScene(ref ManagedScene pScene, string pPath)
        {
            if (!Importer_Initialize(m_nativeImporter, pPath))
                return false;
            if (!Importer_Import(m_nativeImporter, pScene.NativeObject))
                return false;
            return true;
        }

        public bool ExportScene(ref ManagedManager pManager, string pPath)
        {
            if (!Exporter_Initialize(m_nativeExporter, pPath))
                return false;
            if (!Exporter_Export(m_nativeExporter, pManager.NativeObject))
                return false;
            return true;
        }

        public void TriangulateMesh(ManagedMesh pMesh)
        {
            Manager_TriangulateMesh(m_nativeObject, pMesh.NativeObject);
        }

    }
}
