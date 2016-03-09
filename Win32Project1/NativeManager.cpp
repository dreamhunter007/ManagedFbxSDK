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

const void* Manager_TriangulateMesh(void* pManager, void* pMesh)
{
	FbxMesh* lMesh = (FbxMesh*)pMesh;
	if (!lMesh->IsTriangleMesh())
	{
		FbxManager* lManager = (FbxManager*)pManager;
		FbxGeometryConverter* lConverter = new FbxGeometryConverter(lManager);
		FbxNodeAttribute* resultMesh = lConverter->Triangulate(lMesh, false);
		delete lConverter;
		return resultMesh;
	}
	return lMesh;
}
