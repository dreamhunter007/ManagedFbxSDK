#include "NativeMesh.h"

const void* Mesh_Create(void* pContainer, const char* pName)
{
	FbxScene* lScene = (FbxScene*)pContainer;
	return FbxMesh::Create(lScene, pName);
}

const int Mesh_GetPolygonCount(void* pMesh)
{
	FbxMesh * lMesh = (FbxMesh*)pMesh;
	return lMesh->GetPolygonCount();
}

const int Mesh_GetPolygonVertex(void* pMesh, int pPolygonIndex, int pPositionInPolygon)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	return lMesh->GetPolygonVertex(pPolygonIndex, pPositionInPolygon);
}

const int Mesh_GetControlPointCount(void* pMesh)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	return lMesh->GetControlPointsCount();
}

const double* Mesh_GetControlPointAt(void* pMesh, int pIndex)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	FbxVector4 lVector = lMesh->GetControlPointAt(pIndex);
	double* lReturnValue = new double[4];
	for (size_t i = 0; i < 4; i++)
	{
		lReturnValue[i] = lVector.mData[i];
	}
	return lReturnValue;
}