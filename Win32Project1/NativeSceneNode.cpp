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

const int SceneNode_GetMaterialCount(void* pSceneNode)
{
	FbxNode* lSceneNode = (FbxNode*)pSceneNode;
	return lSceneNode->GetMaterialCount();
}

const void* SceneNode_GetMaterial(void* pSceneNode, int pIndex)
{
	FbxNode* lSceneNode = (FbxNode*)pSceneNode;
	return lSceneNode->GetMaterial(pIndex);
}

const void* SceneNode_EvaluateLocalTransform(void* pSceneNode)
{
	FbxNode* lSceneNode = (FbxNode*)pSceneNode;
	FbxAMatrix transform = lSceneNode->EvaluateLocalTransform();
	double* result = new double[16];
	for (int i = 0; i < 4; i++)
	{
		memcpy(result + 4 * i, transform.mData[i].mData, 4 * sizeof(double));
	}
	return result;
}

const void* SceneNode_EvaluateGlobalTransform(void* pSceneNode)
{
	FbxNode* lSceneNode = (FbxNode*)pSceneNode;
	FbxAMatrix transform = lSceneNode->EvaluateGlobalTransform();
	double* result = new double[16];
	/*for (int i = 0; i < 4; i++)
	{
		memcpy(result + 4 * i, transform.mData[i].mData, 4 * sizeof(double));
	}*/
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			result[i * 4 + j] = transform[i][j];
		}
	}
	return result;
}

const void* SceneNode_EvaluateGeometricTransform(void* pSceneNode)
{
	FbxNode * lSceneNode = (FbxNode*)pSceneNode;
	FbxAMatrix matrixGeo;
	matrixGeo.SetIdentity();
	if (lSceneNode->GetNodeAttribute())
	{
		const FbxVector4 lT = lSceneNode->GetGeometricTranslation(FbxNode::eSourcePivot);
		const FbxVector4 lR = lSceneNode->GetGeometricRotation(FbxNode::eSourcePivot);
		const FbxVector4 lS = lSceneNode->GetGeometricScaling(FbxNode::eSourcePivot);
		matrixGeo.SetT(lT);
		matrixGeo.SetR(lR);
		matrixGeo.SetS(lS);
	}
	double* result = new double[16];
	for (int i = 0; i < 4; i++)
	{
		memcpy(result + 4 * i, matrixGeo.mData[i].mData, 4 * sizeof(double));
	}
	return result;
}