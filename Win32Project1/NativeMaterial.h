#pragma once
#include "Common.h"

extern "C"
{
	const EXPORT_API double* LambertMaterial_GetAmbientColor(void* pMaterial);
	const EXPORT_API double* LambertMaterial_GetEmissiveColor(void* pMaterial);
	const EXPORT_API double* LambertMaterial_GetBumpColor(void* pMaterial);
	const EXPORT_API double* LambertMaterial_GetDiffuseColor(void* pMaterial);
}