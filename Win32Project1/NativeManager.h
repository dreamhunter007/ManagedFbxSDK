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

	const EXPORT_API void TriangulateMesh(void* pManager, void* pMesh);
}