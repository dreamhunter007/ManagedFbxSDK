using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
    public class ManagedSceneNode :ManagedFbxObject
    {
#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_Create(IntPtr pContainer, string pName);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_GetMesh(IntPtr pSceneNode);


#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int SceneNode_GetChildCount(IntPtr pSceneNode);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_GetChild(IntPtr pSceneNode, int pIndex);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern int SceneNode_GetMaterialCount(IntPtr pSceneNode);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_GetMaterial(IntPtr pSceneNode, int pIndex);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_EvaluateLocalTransform(IntPtr pSceneNode);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_EvaluateGlobalTransform(IntPtr pSceneNode);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_EvaluateGeometricTransform(IntPtr pSceneNode);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_EvaluateLocalTranslation(IntPtr pSceneNode);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_EvaluateLocalScaling(IntPtr pSceneNode);

#if MS_BUILD
        [DllImport("Win32Project1.dll")]
#else
        [DllImport("Win32Project1")]
#endif
        private static extern IntPtr SceneNode_EvaluateLocalRotation(IntPtr pSceneNode);


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

        public int GetMaterialCount()
        {
            return SceneNode_GetMaterialCount(m_nativeObject);
        }

        public ManagedMaterial GetMaterial(int pIndex)
        {
            return new ManagedMaterial(SceneNode_GetMaterial(m_nativeObject, pIndex));
        }

        public double[] EvaluateLocalTransform()
        {
            IntPtr nativeTranform = SceneNode_EvaluateLocalTransform(m_nativeObject);
            double[] transformData = new double[4 * 4];
            Marshal.Copy(nativeTranform, transformData, 0, 4 * 4);
            return transformData;
        }

        public double[] EvaluateGlobalTransform()
        {
            IntPtr nativeTransform = SceneNode_EvaluateGlobalTransform(m_nativeObject);
            double[] transformData = new double[4 * 4];
            Marshal.Copy(nativeTransform, transformData, 0, 4 * 4);
            return transformData;
        }

        public double [] EvaluateGeometricTransform()
        {
            IntPtr nativeTransform = SceneNode_EvaluateGeometricTransform(m_nativeObject);
            double[] transformData = new double[4 * 4];
            Marshal.Copy(nativeTransform, transformData, 0, 4 * 4);
            return transformData;
        }

        public double[] EvaluateLocalTranslation()
        {
            IntPtr nativeTranslation = SceneNode_EvaluateGeometricTransform(m_nativeObject);
            double[] translationData = new double[4];
            Marshal.Copy(nativeTranslation, translationData, 0, 4);
            return translationData;
        }

        public double[] EvaluateLocalScaling()
        {
            IntPtr nativeScaling = SceneNode_EvaluateLocalScaling(m_nativeObject);
            double[] scalingData = new double[4];
            Marshal.Copy(nativeScaling, scalingData, 0, 4);
            return scalingData;
        }

        public double[] EvaluateLocalRotation()
        {
            IntPtr nativeRotation = SceneNode_EvaluateLocalRotation(m_nativeObject);
            double[] rotationData = new double[4];
            Marshal.Copy(nativeRotation, rotationData, 0, 4);
            return rotationData;
        }
    }
}
