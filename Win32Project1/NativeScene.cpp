#include "NativeScene.h"

void Scene_SetName(void* pScene, const char* pName)
{
	FbxScene* lScene = (FbxScene*)pScene;
	lScene->SetName(pName);
}

const char* Scene_GetName(void* pScene)
{
	FbxScene* lScene = (FbxScene*)pScene;
	return lScene->GetName();
}
const void* Scene_GetRootNode(void* pScene)
{
	FbxScene* lScene = (FbxScene*)pScene;
	FbxNode *rootNode = lScene->GetRootNode();
	return rootNode;
}

const void* Scene_Create(void* pContainer, const char* name)
{
	FbxManager* lManager = (FbxManager*)pContainer;
	FbxScene *lScene = FbxScene::Create(lManager, name);
	return lScene;
}