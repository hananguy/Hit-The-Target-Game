using GameLogic;
using System;

namespace UI
{
	public class InputHandler
	{
		public SecretCode GetSecretCodeInput()
		{
			Console.Write(Messages.EnterGuessPrompt);

			string userInput = Console.ReadLine();
			userInput = string.Join(" ", userInput.ToUpper().ToCharArray());

			return new SecretCode(userInput);
		}
	}
}
