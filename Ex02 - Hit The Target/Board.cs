using System;
using System.Collections.Generic;
using System.Linq;


namespace GameLogic
{
	public class Board
	{
		private List<SecretCode> m_SecretCodes;
		private List<FeedBack> m_FeedBacks;
		private readonly int r_CodeLength;
		private readonly int r_MaxGuesses;

		public Board(int i_CodeLength, int i_MaxGuesses)
		{
			r_CodeLength = i_CodeLength;
			r_MaxGuesses = i_MaxGuesses;
			m_SecretCodes = new List<SecretCode>();
			m_FeedBacks = new List<FeedBack>();
		}

		public string GetBoardAsString()
		{
			int guessColWidth = 2 * r_CodeLength - 1;
			int resultColWidth = r_CodeLength;

			string header = $"| {"Pins:".PadRight(guessColWidth)} | {"Result:".PadRight(resultColWidth)} |";
			string separator = $"|{new string('=', guessColWidth + 2)}|{new string('=', resultColWidth + 2)}|";

			string boardString = "";
			boardString += "Current board status:\n";
			boardString += header + "\n";
			boardString += separator + "\n";

			string hidden = string.Join(" ", Enumerable.Repeat("#", r_CodeLength));
			boardString += $"| {hidden.PadRight(guessColWidth)} | {"".PadRight(resultColWidth)} |\n";
			boardString += separator + "\n";

			for (int line = 0; line < r_MaxGuesses; line++)
			{
				string guess = line < m_SecretCodes.Count ? m_SecretCodes[line].Code : "";
				string result = line < m_FeedBacks.Count ? m_FeedBacks[line].CreateBullsHitsString().Replace(" ", "") : "";

				boardString += $"| {guess.PadRight(guessColWidth)} | {result.PadRight(resultColWidth)} |\n";
				boardString += separator + "\n";
			}

			return boardString;
		}


		public void UpdateBoard(SecretCode i_Guess, FeedBack i_Feedback)
		{
			m_SecretCodes.Add(i_Guess);
			m_FeedBacks.Add(i_Feedback);
		}
	}
}
