#include "NativeMaterial.h"

const double* LambertMaterial_GetAmbientColor(void* pMaterial)
{
	FbxSurfaceLambert* lLambertMaterial = (FbxSurfaceLambert*)pMaterial;
	FbxPropertyT<FbxDouble3> ambientColor = lLambertMaterial->Ambient;
	double* result = new double[3];
	memcpy(result, ambientColor.Get().mData, 3 * sizeof(double));
	return result;
}

const double* LambertMaterial_GetEmissiveColor(void* pMaterial)
{
	FbxSurfaceLambert* lLambertMaterial = (FbxSurfaceLambert*)pMaterial;
	FbxPropertyT<FbxDouble3> emmisiveColor = lLambertMaterial->Emissive;
	double* result = new double[3];
	memcpy(result, emmisiveColor.Get().mData, 3 * sizeof(double));
	return result;
}

const double* LambertMaterial_GetBumpColor(void* pMaterial)
{
	FbxSurfaceLambert* lLambertMaterial = (FbxSurfaceLambert*)pMaterial;
	FbxPropertyT<FbxDouble3> bumpColor = lLambertMaterial->Bump;
	double* result = new double[3];
	memcpy(result, bumpColor.Get().mData, 3 * sizeof(double));
	return result;
}

const double* LambertMaterial_GetDiffuseColor(void* pMaterial)
{
	FbxSurfaceLambert* lLambertMaterial = (FbxSurfaceLambert*)pMaterial;
	FbxPropertyT<FbxDouble3> diffuseColor = lLambertMaterial->Diffuse;
	double* result = new double[3];
	memcpy(result, diffuseColor.Get().mData, 3 * sizeof(double));
	return result;
}