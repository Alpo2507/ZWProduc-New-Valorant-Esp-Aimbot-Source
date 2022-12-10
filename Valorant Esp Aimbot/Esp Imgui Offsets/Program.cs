using System;
using System.Windows.Forms;

namespace iBaseult
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MessageBox.Show("Я foooor не создатель чита, я только изменил визуальную составляющую: #coded_software (iBaseult)\n\nВерсия чита v2.0 от 09.05.2020\n\nБезопасность: 09.05.2020 Undetected.\n\n!!!Вы используете этот чит на свой страх и риск!!!\n\nДля безопасности измените название чита!\n\nВизуальные элементы могут не работать в полноэкранном режиме!\n\nСледующие функции могут замедлить работу Aimbot:\n\nColorESP and Aimbot - Target\n\nЗа актуальностью версии или обновлениями чита следите за моей темой: https://yougame.biz/threads/133790/");
			Application.Run(new Form1());
		}
	}
}