#include "TestClass.h"
#include <iostream>

TestClass::TestClass()
{

}


TestClass::~TestClass()
{
}

int TestClass::TestInt()
{
	return 10;
}

float TestClass::TestFloat()
{
	return 10.5f;
}

FbxScene* TestClass::LoadFbxDocument(const char* path)
{
	printf(path);
	FbxManager* lManager = FbxManager::Create();
	FbxImporter *lImpoter = FbxImporter::Create(lManager, "Importer");
	try{
		if (!lImpoter->Initialize(path))
			throw new std::exception("failed to initialize");
	}
	catch(std::exception ex) {
		throw ex;
	}

	FbxScene *lscene = FbxScene::Create(lManager, "noname");
	
	if (!lImpoter->Import(lscene))
		throw new std::exception("failed to import");
	printf("load succeeded");

	return lscene;
}

int AddTwoInteger(int a, int b)
{
	return a + b;
}

float AddTwoFloat(float a, float b)
{
	return a + b;
}

const void* LoadFbxDocument(const char* path)
{
	return TestClass::LoadFbxDocument(path);
}

void PrintNode(FbxNode* node)
{
	std::cout << node->GetName() << "\n";
	for (size_t i = 0; i < node->GetChildCount(); i++)
	{
		FbxNode* current_node = node->GetChild(i);
		PrintNode(current_node);
	}
}

void PrintSceneName(void* ptr)
{
	FbxScene* lScene = (FbxScene*)ptr;
	printf(lScene->GetName());
	FbxNode* root = lScene->GetRootNode();
	if (root != NULL)
	{
		PrintNode(root);
	}
}

