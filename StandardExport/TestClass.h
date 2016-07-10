#include "fbxsdk.h"

#if _MSC_VER // this is defined when compiling with Visual Studio
#define EXPORT_API __declspec(dllexport) // Visual Studio needs annotating exported functions with this
#else
#define EXPORT_API // XCode does not need annotating exported functions, so define is empty
#endif

#pragma once
class TestClass
{
public:
	TestClass();
	~TestClass();

	static FbxScene* LoadFbxDocument(const char* path);

	int TestInt();
	float TestFloat();
};

extern "C" 
{
	int EXPORT_API AddTwoInteger(int a, int b);
	float EXPORT_API AddTwoFloat(float a, float b);
	const EXPORT_API void*  LoadFbxDocument(const char* path);
	void EXPORT_API PrintSceneName(void* ptr);
}