using System;
using System.Runtime.InteropServices;

namespace iBaseult
{
	public static class Execute
	{
		[DllImport("User32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern bool InjectMouseInput(MoveInfo[] inputs, int count);
	}
}