#pragma once
#include "Common.h"

extern "C"
{
	void EXPORT_API Scene_SetName(void* pScene, const char* pName);
	const EXPORT_API char* Scene_GetName(void* pScene);
	const EXPORT_API void* Scene_GetRootNode(void* pScene);
	const EXPORT_API void* Scene_Create(void* pContainer, const char* name);
}

