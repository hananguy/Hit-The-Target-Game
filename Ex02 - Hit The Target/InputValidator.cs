using System;
using System.Linq;

namespace GameLogic
{
	public class InputValidator
	{
		char[] m_AllowedLetters;
		int m_ExpectedLength;
		public InputValidator(char[] i_AllowedLetters, int i_ExpectedLength) //Ctor
		{
			m_AllowedLetters = i_AllowedLetters;
			m_ExpectedLength = i_ExpectedLength;
		}

		public ValidationResult Validate(string i_UserGuess)
		{
			bool isValid = true;
			string parsedCode = null;
			string guessWithoutSpaces = i_UserGuess.Replace(" ", "");
			string errorMessage = string.Empty;

			if (guessWithoutSpaces.Length != m_ExpectedLength)
			{
				isValid = false;
				errorMessage = $"Input must be exactly {m_ExpectedLength} characters long.";
			}
			else
			{
				for (int i = 0; i < guessWithoutSpaces.Length; i++)
				{
					char c = guessWithoutSpaces[i];

					if (!char.IsUpper(c))
					{
						isValid = false;
						errorMessage = $"Character '{c}' is not uppercase.";
						break;
					}

					if (!m_AllowedLetters.Contains(c))
					{
						isValid = false;
						errorMessage = $"Character '{c}' is not allowed.";
						break;
					}

					for (int j = i + 1; j < guessWithoutSpaces.Length; j++)
					{
						if (guessWithoutSpaces[j] == c)
						{
							isValid = false;
							errorMessage = "Input contains duplicate characters.";
							break;
						}
					}

					if (!isValid)
					{
						break;
					}
				}

				if (isValid)
				{
					parsedCode = guessWithoutSpaces;
				}
			}

			return new ValidationResult(isValid, parsedCode, errorMessage);
		}
	}
}
