using System;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
	public class ManagedGeometryConverter : ManagedFbxObject
	{
		#if MS_BUILD
		[DllImport("Win32Project1.dll")]
		#else
		[DllImport("Win32Project1")]
		#endif
		private static extern IntPtr GeometryConverter_Create(IntPtr pManager);

		#if MS_BUILD
		[DllImport("Win32Project1.dll")]
		#else
		[DllImport("Win32Project1")]
		#endif
		private static extern IntPtr GeometryConverter_TriangulateMesh(IntPtr pGeometryConverter, IntPtr pMesh, bool pReplace, bool pLegacy = false);

		#if MS_BUILD
		[DllImport("Win32Project1.dll")]
		#else
		[DllImport("Win32Project1")]
		#endif
		private static extern bool GeometryConverter_EmulateNormalsByPolygonVertex(IntPtr pGeometryConverter, IntPtr pMesh);

		#if MS_BUILD
		[DllImport("Win32Project1.dll")]
		#else
		[DllImport("Win32Project1")]
		#endif
		private static extern bool GeometryConverter_ComputeEdgeSmoothingFromNormals(IntPtr pGeometryConverter, IntPtr pMesh);

		#if MS_BUILD
		[DllImport("Win32Project1.dll")]
		#else
		[DllImport("Win32Project1")]
		#endif
		private static extern bool GeometryConverter_ComputePolygonSmoothingFromEdgeSmoothing(IntPtr pGeometryConverter, IntPtr pMesh,int pIndex = 0);

		#if MS_BUILD
		[DllImport("Win32Project1.dll")]
		#else
		[DllImport("Win32Project1")]
		#endif
		private static extern bool GeometryConverter_ComputeEdgeSmoothingFromPolygonSmoothing(IntPtr pGeometryConverter, IntPtr pMesh, int pIndex = 0);

		public ManagedGeometryConverter (ManagedManager pManager)
		{
			m_nativeObject = GeometryConverter_Create (pManager.NativeObject);
		}

		public ManagedMesh TriangulateMesh(ManagedMesh pMesh, bool pReplace, bool pLegacy)
		{
			IntPtr nativeMesh = GeometryConverter_TriangulateMesh (m_nativeObject, pMesh.NativeObject, pReplace, pLegacy);
			return new ManagedMesh (nativeMesh);
		}

		public bool EmulateNormalsByPolygonVertex(ManagedMesh pMesh)
		{
			return GeometryConverter_EmulateNormalsByPolygonVertex (m_nativeObject, pMesh.NativeObject);
		}

		public bool ComputeEdgeSmoothingFromNormals(ManagedMesh pMesh)
		{
			return GeometryConverter_ComputeEdgeSmoothingFromNormals (m_nativeObject, pMesh.NativeObject);
		}

		public bool ComputePolygonSmoothingFromEdgeSmoothing(ManagedMesh pMesh, int pIndex = 0)
		{
			return GeometryConverter_ComputePolygonSmoothingFromEdgeSmoothing (m_nativeObject, pMesh.NativeObject, pIndex);
		}

		public bool ComputeEdgeSmoothingFromPolygonSmoothing(ManagedMesh pMesh, int pIndex = 0)
		{
			return GeometryConverter_ComputeEdgeSmoothingFromPolygonSmoothing (m_nativeObject, pMesh.NativeObject, pIndex);	
		}
	}
}

