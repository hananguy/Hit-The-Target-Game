using System;
using GameLogic;

namespace GameRun
{
	public class Game
	{
		private Computer m_Computer;
		private Player m_Player;
		private Board m_Board;
		private InputValidator m_Validator;
		private UserInterface m_UI;
		private int m_MaxNumberOfGuesses;
		private const int m_SecretCodeLength = 4;
		private const int k_MinGuesses = 4;
		private const int k_MaxGuesses = 10;
		private readonly char[] m_AllowedLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

		public Game(UserInterface i_UI, Player i_Player, Computer i_Computer, InputValidator i_Validator, Board i_Board, int i_MaxGuesses)
		{
			m_UI = i_UI;
			m_Player = i_Player;
			m_Computer = i_Computer;
			m_Validator = i_Validator;
			m_Board = i_Board;
			m_MaxNumberOfGuesses = i_MaxGuesses;
		}

		private void InitializeGame()
		{
			m_Board = new Board(m_SecretCodeLength, m_MaxNumberOfGuesses);
			m_Computer.CreateSecretCode(m_AllowedLetters, m_SecretCodeLength);
		}

		public void Run()
		{
			bool playAgain = true;
			m_UI.ClearScreen();

			while (playAgain)
			{
				InitializeGame();
				bool playerWon = false;

				for (int guessIndex = 0; guessIndex < m_MaxNumberOfGuesses; guessIndex++)
				{
					m_UI.ClearScreen();
					m_UI.DisplayBoard(m_Board);
					m_Player.GuessSecretCode();

					if (m_Player.CurrentSecretCode.Code.ToUpper() == "Q")
					{
						m_UI.DisplayQuit(m_Computer.SecretCode.Code);
						break;
					}

					ValidationResult validationResult = m_Validator.Validate(m_Player.CurrentSecretCode);

					if (!validationResult.IsValid)
					{
						m_UI.DisplayError(validationResult.ErrorMessage);
						guessIndex--;
						continue;
					}

					FeedBack feedback = new FeedBack();
					feedback.Evaluate(m_Player.CurrentSecretCode, m_Computer.SecretCode);

					m_Board.UpdateBoard(m_Player.CurrentSecretCode, feedback);

					if (feedback.IsWinningGuess())
					{
						playerWon = true;
						break;
					}
				}

				if (playerWon)
				{
					m_UI.DisplayWin();
				}
				else
				{
					m_UI.DisplayLose(m_Computer.SecretCode.Code, m_Board);
				}

				playAgain = m_UI.AskToPlayAgain();
			}
		}
	}
}