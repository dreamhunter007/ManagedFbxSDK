#include "Common.h"


extern "C"
{
	const EXPORT_API void* Manager_Create();

	//Importer
	const EXPORT_API void* Importer_Create(void* pContainer, const char* pName);
	bool EXPORT_API Importer_Initialize(void* pImporter, const char* pPath);
	bool EXPORT_API Importer_Import(void* pImporter, void* pScene);

	//Exporter
	const EXPORT_API void* Exporter_Create(void* pContainer, const char* pName);
	bool EXPORT_API Exporter_Initialize(void *pExporter, const char* pPath);
	bool EXPORT_API Exporter_Export(void* pExporter, void* pScene);

	//GeometryConverter
	const EXPORT_API void* GeometryConverter_Create(void* pManager);
	const EXPORT_API void* GeometryConverter_TriangulateMesh(void* pGeometryConverter, void* pMesh, bool pReplace, bool pLegacy = false);
	bool EXPORT_API GeometryConverter_EmulateNormalsByPolygonVertex(void* pGeometryConverter, void* pMesh);
	bool EXPORT_API GeometryConverter_ComputeEdgeSmoothingFromNormals(void* pGeometryConverter, void* pMesh);
	bool EXPORT_API GeometryConverter_ComputePolygonSmoothingFromEdgeSmoothing(void* pGeometryConverter, void* pMesh,int pIndex = 0);
	bool EXPORT_API GeometryConverter_ComputeEdgeSmoothingFromPolygonSmoothing(void* pGeometryConverter, void* pMesh, int pIndex = 0);
}