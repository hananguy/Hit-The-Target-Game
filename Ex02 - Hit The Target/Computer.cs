
using System;
using System.Collections.Generic;

namespace GameLogic
{

	public class Computer
	{
		private SecretCode m_Secret;
		public void CreateSecretCode(char[] i_AvailableLetters, int i_SecretSize = 4)
		{
			char[] letters = new char[i_SecretSize];
			Random random = new Random();
			int index = 0;

			while (index < i_SecretSize)
			{
				char randomChar = i_AvailableLetters[random.Next(i_AvailableLetters.Length)];

				bool alreadyExists = false;
				for (int i = 0; i < index; i++)
				{
					if (letters[i] == randomChar)
					{
						alreadyExists = true;
						break;
					}
				}

				if (!alreadyExists)
				{
					letters[index] = randomChar;
					index++;
				}
			}

			m_Secret = new SecretCode();
			m_Secret.Code = string.Join(" ", letters);
		}

		public SecretCode GetSecretCode()
		{
			return m_Secret;
		}

		public SecretCode SecretCode
		{
			get { return m_Secret; }
		}
	}
}
