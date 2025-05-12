using System;
using System.Linq;
using GameLogic;
using GameUi;
using GameRun;
using Ex02.ConsoleUtils;


namespace GameMain
{
	public class Program
	{
		static void Main()
		{
			Console.WriteLine("Welcome to Hit the Target!");
			int numberOfGuesses = getNumberOfGuessesFromUser();
			Game game = new Game(numberOfGuesses);
			game.Run();
		}

		private static int getNumberOfGuessesFromUser()
		{
			const int k_MinGuesses = 4;
			const int k_MaxGuesses = 10;

			Console.WriteLine($"Enter number of guesses ({k_MinGuesses}-{k_MaxGuesses}):");

			while (true)
			{
				string input = Console.ReadLine();

				if (input.ToUpper() == "Q")
				{
					Environment.Exit(0);
				}

				if (int.TryParse(input, out int number) && number >= k_MinGuesses && number <= k_MaxGuesses)
				{
					return number;
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a number between 4 and 10.");
				}
			}
		}

	}
}

