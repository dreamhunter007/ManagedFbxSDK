#pragma once
#include "Common.h"

extern "C"
{
	const EXPORT_API void* SceneNode_Create(void* pContainer, const char* pName);
	const EXPORT_API void* SceneNode_GetMesh(void* pSceneNode);
	const EXPORT_API int SceneNode_GetChildCount(void* pSceneNode);
	const EXPORT_API void*  SceneNode_GetChild(void* pSceneNode, int pIndex);
}