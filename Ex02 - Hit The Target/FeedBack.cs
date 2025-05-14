using GameLogic;
using System;
using System.Collections.Generic;
using System.Data;

namespace GameLogic
{
	public class FeedBack
	{
		public int NumberOfBulls
		{
			get;
			private set;
		}
		public int NumberOfHits
		{
			get;
			private set;
		}

		public void Evaluate(SecretCode i_ComputerCode, SecretCode i_PlayerCode)
		{
			char[] computerCodeChars = i_ComputerCode.Code.Replace(" ", "").ToCharArray();
			char[] playerCodeChars = i_PlayerCode.Code.Replace(" ", "").ToCharArray();
			bool[] computerCodeUsedFlags = new bool[computerCodeChars.Length];
			bool[] playerGuessUsedFlags = new bool[playerCodeChars.Length];

			for (int position = 0; position < playerGuessUsedFlags.Length; position++)
			{
				if (playerCodeChars[position] == computerCodeChars[position])
				{
					NumberOfBulls++;
					computerCodeUsedFlags[position] = true;
					playerGuessUsedFlags[position] = true;
				}
			}
			for (int playerPosition = 0; playerPosition < playerCodeChars.Length; playerPosition++)
			{
				if (playerGuessUsedFlags[playerPosition])
				{
					continue; // already counted as a Bull
				}

				for (int computerPosition = 0; computerPosition < computerCodeChars.Length; computerPosition++)
				{
					if (computerCodeUsedFlags[computerPosition])
					{
						continue; // already used for a Bull
					}

					if (playerCodeChars[playerPosition] == computerCodeChars[computerPosition])
					{
						NumberOfHits++;
						playerGuessUsedFlags[playerPosition] = true;
						computerCodeUsedFlags[computerPosition] = true;
						break;
					}
				}
			}
		}
		public string CreateBullsHitsString()
		{
			List<char> symbolsString = new List<char>();
			for (int i = 0; i < NumberOfBulls; i++)
			{
				symbolsString.Add('V');
			}
			for (int i = 0; i < NumberOfHits; i++)
			{
				symbolsString.Add('X');
			}

			return string.Join(" ", symbolsString);
		}

		public bool IsWinningGuess()
		{
			
			return NumberOfBulls == 4;
		}
	}

}
