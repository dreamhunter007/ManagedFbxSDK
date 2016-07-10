#include "NativeManager.h";

const void* Manager_Create()
{
	return FbxManager::Create();
}

const void* Importer_Create(void* pContainer, const char* pName)
{
	FbxManager* lManager = (FbxManager*)pContainer;
	return FbxImporter::Create(lManager, pName);
}

bool Importer_Initialize(void* pImporter, const char* pName)
{
	FbxImporter *importer = (FbxImporter*)pImporter;
	return importer->Initialize(pName);
}

bool Importer_Import(void* pImporter, void* pScene)
{
	FbxImporter* lImporter = (FbxImporter*)pImporter;
	FbxScene* lScene = (FbxScene*)pScene;
	return lImporter->Import(lScene);
}


const void* Exporter_Create(void* pContainer, const char* pName)
{
	FbxManager *lManager = (FbxManager*)pContainer;
	return FbxExporter::Create(lManager, pName);
}

bool Exporter_Initialize(void* pExporter, const char* pPath)
{
	FbxExporter* lExporter = (FbxExporter*)pExporter;
	return lExporter->Initialize(pPath);
}

bool Exporter_Export(void* pExporter, void* pScene)
{
	FbxExporter* lExporter = (FbxExporter*)pExporter;
	FbxScene* lScene = (FbxScene*)pScene;
	return lExporter->Export(lScene);
}

const void* GeometryConverter_Create(void* pManager){
	FbxManager* lManager = (FbxManager*)pManager;
	return new FbxGeometryConverter(lManager);
}

const void* GeometryConverter_TriangulateMesh(void* pGeometryConverter, void* pMesh, bool pReplace, bool pLegacy)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	if (!lMesh->IsTriangleMesh())
	{
		FbxGeometryConverter* lConverter = (FbxGeometryConverter*)pGeometryConverter;
		FbxNodeAttribute* resultMesh = lConverter->Triangulate(lMesh, pReplace, pLegacy);
		delete lConverter;
		return resultMesh;
	}
	return lMesh;
}

bool GeometryConverter_EmulateNormalsByPolygonVertex(void* pGeometryConverter, void* pMesh)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	FbxGeometryConverter* lConverter = (FbxGeometryConverter*)pGeometryConverter;
	return lConverter->EmulateNormalsByPolygonVertex(lMesh);
}

bool GeometryConverter_ComputeEdgeSmoothingFromNormals(void* pGeometryConverter, void* pMesh)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	FbxGeometryConverter* lConverter = (FbxGeometryConverter*)pGeometryConverter;
	return lConverter->ComputeEdgeSmoothingFromNormals(lMesh);
}

bool GeometryConverter_ComputePolygonSmoothingFromEdgeSmoothing(void* pGeometryConverter, void* pMesh, int pIndex)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	FbxGeometryConverter* lConverter = (FbxGeometryConverter*)pGeometryConverter;
	return lConverter->ComputePolygonSmoothingFromEdgeSmoothing(lMesh, pIndex);
}

bool  GeometryConverter_ComputeEdgeSmoothingFromPolygonSmoothing(void* pGeometryConverter, void* pMesh, int pIndex)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	FbxGeometryConverter* lConverter = (FbxGeometryConverter*)pGeometryConverter;
	return lConverter->ComputeEdgeSmoothingFromPolygonSmoothing(lMesh, pIndex);
}