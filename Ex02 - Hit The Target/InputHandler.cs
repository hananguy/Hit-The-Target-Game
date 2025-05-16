using GameLogic;
using System;


namespace UI
{
	public class InputHandler
	{
		public SecretCode GetSecretCodeInput()
		{
			Console.WriteLine(Messages.EnterGuessPrompt);
			string userInput = Console.ReadLine();
			userInput = string.Join(" ", userInput.ToUpper().ToCharArray());

			return new SecretCode(userInput);
		}
	}
}


