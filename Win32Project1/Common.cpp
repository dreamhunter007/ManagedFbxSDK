#include "Common.h"

double* CopyVecotr4(FbxVector4 vector)
{
	double* result = new double[4];
	memcpy(result, vector.mData, 4 * sizeof(double));
	return result;
}