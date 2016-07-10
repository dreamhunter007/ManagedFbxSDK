#pragma once
#include "Common.h"
#include "Vector.h"

extern "C"
{
	const EXPORT_API void* Mesh_Create(void* pContainer, const char* pName);
	const EXPORT_API int Mesh_GetPolygonCount(void* pMesh);
	const EXPORT_API int Mesh_GetPolygonVertex(void* pMesh, int pPolygonIndex, int pPositionInPolygon);
	const EXPORT_API int Mesh_GetControlPointCount(void* pMesh);
	const EXPORT_API double* Mesh_GetControlPointAt(void* pMesh, int pIndex);

	const EXPORT_API int Mesh_GetPolygonSize(void* pMesh, int pPolygonIndex);
	const EXPORT_API int Mesh_GetLayerCount(void* pMesh);
	const EXPORT_API void* Mesh_GetLayer(void* pMesh, int pLayerIndex);
	const EXPORT_API int Mesh_IsTriangulated(void* pMesh);

	const EXPORT_API int Mesh_GetMaterialID(void* pMesh, int pPolygonIndex);
}