using System;
using GameLogic;
using UI;

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
		private const int k_SecretCodeLength = 4;
		private const int k_MinGuesses = 4;
		private const int k_MaxGuesses = 10;
		private readonly char[] m_AllowedLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

		public Game(UserInterface i_UI)
		{
			m_UI = i_UI;
		}

		private void InitializeGame()
		{
			m_MaxNumberOfGuesses = m_UI.GetNumberOfGuesses(k_MinGuesses, k_MaxGuesses);
			m_Computer = new Computer();
			m_Board = new Board(k_SecretCodeLength, m_MaxNumberOfGuesses);
			m_Validator = new InputValidator(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' }, k_SecretCodeLength);
			m_Player = new Player(m_UI);

			m_Computer.CreateSecretCode(m_AllowedLetters, k_SecretCodeLength);

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
						m_Board.UpdateBoard(m_Player.CurrentSecretCode, feedback);
						m_UI.DisplayBoard(m_Board);
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