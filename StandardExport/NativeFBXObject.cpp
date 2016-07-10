#include "NativeFBXObject.h"

const char* Object_GetName(void* pObject)
{
	FbxObject* lObject = (FbxObject*)pObject;
	return lObject->GetName();
}

void Object_SetName(void* pObject, const char* pName)
{
	FbxObject* lObject = (FbxObject*)pObject;
	lObject->SetName(pName);
}