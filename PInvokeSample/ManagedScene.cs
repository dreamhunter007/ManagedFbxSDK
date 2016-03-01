using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedScene : ManagedFbxObject
    {
        [DllImport("Win32Project1.dll")]
        private static extern IntPtr Scene_Create(IntPtr pContainer, string pName);

        [DllImport("Win32Project1.dll")]
        private static extern IntPtr Scene_GetRootNode(IntPtr pScene);

        [DllImport("Win32Project1.dll")]
        private static extern string Scene_GetName(IntPtr pScene);

        [DllImport("Win32Project1.dll")]
        private static extern void Scene_SetName(IntPtr pScene, string pName);

        public ManagedScene(ManagedManager pManager, string pName)
        {
            m_nativeObject = Scene_Create(pManager.NativeObject, pName);
        }


        public ManagedSceneNode GetRootNode()
        {
            return new ManagedSceneNode(Scene_GetRootNode(m_nativeObject));
        }


    }

}
