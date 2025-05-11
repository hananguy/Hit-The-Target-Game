using System;
using GameUi;

namespace GameLogic
{
				public class Player
				{
								private int m_NumberOfGuessues;
								private SecretCode m_LastGuess;

								public string GuessSecretCode()
								{
												Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit:");
												string userInput = Console.ReadLine();

												return userInput;
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
