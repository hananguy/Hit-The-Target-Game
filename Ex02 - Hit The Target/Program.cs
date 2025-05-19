using System;
using GameLogic;
using GameRun;
using UI;
namespace GameMain
{
	public class Program
	{
		public static void Main()
		{
			UserInterface ui = new UserInterface();
			ui.ShowWelcomeMessage();

			const int k_SecretCodeLength = 4;
	

			Game game = new Game(ui);
			game.Run();
		}
	}
}
