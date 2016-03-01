#include "NativeSceneNode.h"

const void* SceneNode_Create(void* pContainer, const char* pName)
{
	FbxScene *lScene = (FbxScene*)pContainer;
	return FbxNode::Create(lScene, pName);
}

const void* SceneNode_GetMesh(void* pSceneNode)
{
	FbxNode *lSceneNode = (FbxNode*)pSceneNode;
	return lSceneNode->GetMesh();
}

const int SceneNode_GetChildCount(void* pSceneNode)
{
	FbxNode* lSceneNode = (FbxNode*)pSceneNode;
	return lSceneNode->GetChildCount();
}

const void* SceneNode_GetChild(void* pSceneNode, int pIndex)
{
	FbxNode* lSceneNode = (FbxNode*)pSceneNode;
	return lSceneNode->GetChild(pIndex);
}