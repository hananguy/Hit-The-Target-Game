using System;
using GameLogic;


namespace UI
{

	public class GameUI : IUserInterface
	{
		public void ShowWelcomeMessage()
		{
			Console.WriteLine(Messages.Welcome);
		}

		public void ClearScreen()
		{
			Console.Clear();
		}
		
		public int GetNumberOfGuesses(int i_Min, int i_Max)
		{
			Console.WriteLine(string.Format(Messages.EnterNumberOfGuesses, i_Min, i_Max));

			while (true)
			{
				string input = Console.ReadLine();

				if (input.ToUpper() == "Q")
				{
					Environment.Exit(0);
				}

				if (int.TryParse(input, out int number) && number >= i_Min && number <= i_Max)
				{
					return number;
				}
				else
				{
					Console.WriteLine(string.Format(Messages.InvalidNumberOfGuesses, i_Min, i_Max));
				}
			}
		}

		public void DisplayBoard(Board i_board)
		{
			Console.WriteLine(i_board.GetBoardAsString());
		}

		public void DisplayAllowedLetters(char[] i_AllowedLetters)
		{
			Console.WriteLine(string.Format(Messages.AvailableLetters, string.Join(" ", i_AllowedLetters)));
		}

		public void DisplayError(string errorMessage)
		{
			Console.WriteLine(errorMessage);
			Console.WriteLine(Messages.PressEnterToRetry);
			Console.ReadLine();
		}

		public void DisplayQuit(string code)
		{
			Console.WriteLine(Messages.YouQuit);
			Console.WriteLine(string.Format(Messages.CodeWas, code));
		}

		public void DisplayWin()
		{
			Console.WriteLine(Messages.YouWon);
		}

		public void DisplayLose(string code, Board board)
		{
			Console.Clear();
			Console.WriteLine(board.GetBoardAsString());
			Console.WriteLine(Messages.GameEnded);
			Console.WriteLine(code);
		}

		public SecretCode GetPlayerInput()
		{
			Console.Write(Messages.EnterGuessPrompt);
			string userInput = Console.ReadLine();
			userInput = string.Join(" ", userInput.ToUpper().ToCharArray());
			return new SecretCode(userInput);
		}

		public void DisplayQuitMessage(Computer i_Computer)
		{
			Console.WriteLine(Messages.YouQuit);
			Console.WriteLine(string.Format(Messages.CodeWas, i_Computer.SecretCode.Code));
		}

		public void DisplayPlayerLose(Board m_Board, Computer m_Computer)
		{
			Console.Clear();
			DisplayBoard(m_Board);
			DisplayLoseMessage(m_Computer);
		}
		public void DisplayLoseMessage(Computer i_Computer)
		{
			Console.WriteLine(Messages.GameEnded);
			Console.WriteLine(i_Computer.SecretCode.Code);
		}

		public void DisplayPlayerWin()
		{
			Console.WriteLine(Messages.YouWon);
		}
		public bool AskToPlayAgain()
		{
			string userInput;
			do
			{
				Console.WriteLine(Messages.PlayAgainPrompt);
				userInput = Console.ReadLine();
				userInput = userInput.Trim().ToUpper();
				if (userInput != "Y" && userInput != "N")
				{
					Console.WriteLine(Messages.InvalidYesNoInput);
				}
			}

			while (userInput != "Y" && userInput != "N");

			return userInput == "Y";
		}
	}
}