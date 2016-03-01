using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedSceneNode :ManagedFbxObject
    {
        [DllImport("Win32Project1.dll")]
        private static extern IntPtr SceneNode_Create(IntPtr pContainer, string pName);

        [DllImport("Win32Project1.dll")]
        private static extern IntPtr SceneNode_GetMesh(IntPtr pSceneNode);


        [DllImport("Win32Project1.dll")]
        private static extern int SceneNode_GetChildCount(IntPtr pSceneNode);

        [DllImport("Win32Project1.dll")]
        private static extern IntPtr SceneNode_GetChild(IntPtr pSceneNode, int pIndex);

        public ManagedSceneNode(IntPtr pPointer)
        {
            m_nativeObject = pPointer;
        }

        public ManagedSceneNode(ManagedScene pScene, string pName)
        {
            m_nativeObject = SceneNode_Create(pScene.NativeObject, pName);
        }

        public int GetChildCount()
        {
            return SceneNode_GetChildCount(m_nativeObject);
        }

        public ManagedSceneNode GetChild(int pIndex)
        {
            IntPtr lChildNodePtr = SceneNode_GetChild(m_nativeObject, pIndex);
            return new ManagedSceneNode(lChildNodePtr);
        }

        public ManagedMesh GetMesh()
        {
            return new ManagedMesh(SceneNode_GetMesh(m_nativeObject));
        }

    }
}
