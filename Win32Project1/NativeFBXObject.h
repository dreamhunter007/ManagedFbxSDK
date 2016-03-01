#pragma once
#include "Common.h"

extern "C"
{
	const EXPORT_API char* Object_GetName(void* pObject);
	void EXPORT_API Object_SetName(void* pObject, const char* pName);
}