using System;
using System.Security.Cryptography.X509Certificates;
using UI;

namespace GameLogic
{
	public class Player
	{
		private int m_NumberOfGuessues; // Warning !!!!!!
		private SecretCode m_LastGuess;
		private readonly InputHandler m_InputHandler;

				public Player(InputHandler i_inputHandler)
				{
				m_InputHandler = i_inputHandler;
				}

								public void GuessSecretCode() // Change From Void
		{
										m_LastGuess = m_InputHandler.GetSecretCodeInput();
		}

		public SecretCode CurrentSecretCode
		{
			get { return m_LastGuess; }
			set { m_LastGuess = value; }
		}
		public void SetSecretCode(string code)
		{
			m_LastGuess = new SecretCode(code);
		}
	}
}
