#include "NativeLayer.h"

const void* Layer_GetNormals(void* pLayer)
{
	FbxLayer *lLayer = (FbxLayer*)pLayer;
	return lLayer->GetNormals();
}

const void* Layer_GetUVs(void* pLayer)
{
	FbxLayer *lLayer = (FbxLayer*)pLayer;
	return lLayer->GetUVs();
}

const void* Layer_GetMaterials(void* pLayer)
{
	FbxLayer *lLayer = (FbxLayer*)pLayer;
	return lLayer->GetMaterials();
}

const int Normal_GetCount(void* pNormal)
{
	FbxLayerElementNormal* lNormal = (FbxLayerElementNormal*)pNormal;
	return lNormal->GetDirectArray().GetCount();
}

const void* Normal_GetAt(void* pNormal, int pIndex)
{
	FbxLayerElementNormal *lNormal = (FbxLayerElementNormal*)pNormal;
	FbxVector4 lVector = lNormal->GetDirectArray().GetAt(pIndex);
	double* result = new double[4];
	memcpy(result, lVector.mData, 4 * sizeof(double));
	return result;
}

const int UV_GetCount(void* pUV)
{
	FbxLayerElementUV* lUV = (FbxLayerElementUV*)pUV;
	return lUV->GetDirectArray().GetCount();
}

const void* UV_GetAt(void* pUV, int pIndex)
{
	FbxLayerElementUV* lUV = (FbxLayerElementUV*)pUV;
	FbxDouble2 lVector = lUV->GetDirectArray().GetAt(pIndex);
	double* result = new double[4];
	memcpy(result, lVector.mData, 4 * sizeof(double));
	return result;
}
