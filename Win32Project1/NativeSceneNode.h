#pragma once
#include "Common.h"

extern "C"
{
	const EXPORT_API void* SceneNode_Create(void* pContainer, const char* pName);
	const EXPORT_API void* SceneNode_GetMesh(void* pSceneNode);
	const EXPORT_API int SceneNode_GetChildCount(void* pSceneNode);
	const EXPORT_API void*  SceneNode_GetChild(void* pSceneNode, int pIndex);
	const EXPORT_API int SceneNode_GetMaterialCount(void* pSceneNode);
	const EXPORT_API void* SceneNode_GetMaterial(void* pSceneNode, int pIndex);
	const EXPORT_API void* SceneNode_EvaluateLocalTransform(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateGlobalTransform(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateGeometricTransform(void* pSceneNode);

	const EXPORT_API void* SceneNode_EvaluateLocalTranslation(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateLocalScaling(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateLocalRotation(void* pSceneNode);

	const EXPORT_API void* SceneNode_EvaluateGeometricTranslation(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateGeometricScaling(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateGeometricRotation(void* pSceneNode);

	const EXPORT_API void* SceneNode_EvaluateTranslation(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateScaling(void* pSceneNode);
	const EXPORT_API void* SceneNode_EvaluateRotation(void* pSceneNode);
}