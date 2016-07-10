#include "Common.h"

extern "C"{
	const EXPORT_API void* Layer_GetNormals(void* pLayer);
	const EXPORT_API void* Layer_GetUVs(void* pLayer);
	const EXPORT_API void* Layer_GetMaterials(void* pLayer);

	const EXPORT_API int Normal_GetCount(void* pNormal);
	const EXPORT_API void* Normal_GetAt(void* pNormal, int pIndex);

	const EXPORT_API int UV_GetCount(void* pUV);
	const EXPORT_API void* UV_GetAt(void* pUV, int pIndex);
}