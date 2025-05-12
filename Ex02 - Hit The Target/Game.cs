using System;
using GameLogic;
using GameUi;

namespace GameRun
{

	public class Game
	{
		private Computer m_Computer;
		private Player m_Player;
		private Board m_Board;
		private InputValidator m_Validator;

		private readonly int m_MaxNumberOfGuesses;
		private readonly int m_SecretCodeLength = 4;
		private readonly char[] m_AllowedLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

		public Game(int i_MaxGuesses)
		{
			m_MaxNumberOfGuesses = i_MaxGuesses;
			m_Computer = new Computer();
			m_Player = new Player();
			m_Board = new Board(m_SecretCodeLength, m_MaxNumberOfGuesses);
			m_Validator = new InputValidator(m_AllowedLetters, m_SecretCodeLength);
			m_Computer.CreateSecretCode(m_AllowedLetters, m_SecretCodeLength);
		}

		public void Run()
		{
			ValidationResult result;
			bool playerWon = false;

			for (int guessIndex = 0; guessIndex < m_MaxNumberOfGuesses; guessIndex++)
			{
				Console.Clear();
				m_Board.Display();
				Console.WriteLine($"Available letters: {string.Join(" ", m_AllowedLetters)}");
				string playerGuess = m_Player.GuessSecretCode();

				if (string.IsNullOrWhiteSpace(playerGuess))
				{
					Console.WriteLine("Input was empty. Please enter a guess.");
					Console.WriteLine("Press Enter to try again...");
					Console.ReadLine();
					guessIndex--;
					continue;
				}

				if (playerGuess.ToUpper() == "Q")
				{
					Console.WriteLine("You quit the game.");
					Console.WriteLine("The code was:");
					Console.WriteLine(m_Computer.SecretCode.Code);
					break;
				}
				result = m_Validator.Validate(playerGuess);
				if (!result.m_IsValid)
				{
					Console.WriteLine(result.ErrorMessage);
					Console.WriteLine("Press Enter to try again...");
					Console.ReadLine();
					guessIndex--;
					continue;
				}

				m_Player.SetSecretCode(result.ParsedCode);

				FeedBack feedback = new FeedBack();
				feedback.Evaluate(m_Player.CurrentSecretCode, m_Computer.SecretCode);

				m_Board.UpdateBoard(result.ParsedCode, feedback);

				if (feedback.IsWinningGuess())
				{
					playerWon = true;
					break;
				}
			}
			if (playerWon)
			{
				Console.WriteLine("You won!");
			}
			else
			{
				Console.Clear();
				m_Board.Display();
				Console.WriteLine("Game ended. The code was:");
				Console.WriteLine(m_Computer.SecretCode.Code);
			}
		}
	}
}
