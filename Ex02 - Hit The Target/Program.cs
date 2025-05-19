using System;
using GameLogic;
using GameRun;

namespace GameMain
{
	public class Program
	{
		public static void Main()
		{
			UserInterface ui = new UserInterface();
			ui.ShowWelcomeMessage();

			const int k_SecretCodeLength = 4;
			const int k_MinGuesses = 4;
			const int k_MaxGuesses = 10;

			int numberOfGuesses = ui.GetNumberOfGuesses(k_MinGuesses, k_MaxGuesses);

			Computer computer = new Computer();
			Player player = new Player(ui);
			InputValidator validator = new InputValidator(
				new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' },
				k_SecretCodeLength
			);
			Board board = new Board(k_SecretCodeLength, numberOfGuesses);

			Game game = new Game(ui, player, computer, validator, board, numberOfGuesses);
			game.Run();
		}
	}
}
