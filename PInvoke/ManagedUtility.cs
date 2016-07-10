using System;
using System.Runtime.InteropServices;

namespace PInvokeSample
{
	public static class ManagedUtility
	{
		public static double[] MarshalDouble(IntPtr nativePointer, int size)
		{
			double[] result = new double[size];
			Marshal.Copy (nativePointer, result, 0, size);
			return result;
		}
	}
}

