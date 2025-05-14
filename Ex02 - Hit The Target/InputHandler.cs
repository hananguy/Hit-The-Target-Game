using GameLogic;
using System;


namespace UI
{
				public class InputHandler
				{
								public SecretCode GetSecretCodeInput()
								{
												Console.Write("Enter your guess (e.g. A B C D), or Q to quit: ");
												string userInput = Console.ReadLine();
												userInput = string.Join(" ", userInput.ToUpper().ToCharArray());

												return new SecretCode(userInput);
								}
				}
}


