using System;
using System.ComponentModel;

namespace iBaseult
{
	public static class CaseExecute
	{
		public static void ExecuteMovementCase(MoveInfo input)
		{
			CaseExecute.ExecuteMovementCase(new MoveInfo[] { input });
		}

		public static void ExecuteMovementCase(MoveInfo[] inputs)
		{
			if (!Execute.InjectMouseInput(inputs, (int)inputs.Length))
			{
				throw new Win32Exception();
			}
		}
	}
}