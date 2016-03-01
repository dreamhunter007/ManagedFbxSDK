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
}