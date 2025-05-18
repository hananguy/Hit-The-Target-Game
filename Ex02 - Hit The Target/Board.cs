using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

		public IReadOnlyList<SecretCode> SecretCodes => m_SecretCodes.AsReadOnly();
		public IReadOnlyList<FeedBack> FeedBacks => m_FeedBacks.AsReadOnly();
		public int CodeLength => r_CodeLength;
		public int MaxGuesses => r_MaxGuesses;

		public string GetBoardAsString()
		{
			int guessColumnWidth = 2 * r_CodeLength - 1;
			int resultColumnWidth = 2 * r_CodeLength - 1;

			string header = $"| {"Pins:".PadRight(guessColumnWidth)} | {"Result:".PadRight(resultColumnWidth)} |";
			string separator = $"|{new string('=', guessColumnWidth + 2)}|{new string('=', resultColumnWidth + 2)}|";

			StringBuilder boardString = new StringBuilder();
			boardString.AppendLine("Current board status:");
			boardString.AppendLine(header);
			boardString.AppendLine(separator);

			string hidden = string.Join(" ", Enumerable.Repeat("#", r_CodeLength));
			boardString.AppendLine($"| {hidden.PadRight(guessColumnWidth)} | {"".PadRight(resultColumnWidth)} |");
			boardString.AppendLine(separator);

			for (int line = 0; line < r_MaxGuesses; line++)
			{
				string guess = line < m_SecretCodes.Count ? string.Join(" ", m_SecretCodes[line].Code.Replace(" ", "").ToCharArray()) : "";
				string result = line < m_FeedBacks.Count ? string.Join(" ", m_FeedBacks[line].CreateBullsHitsString()) : "";

				boardString.AppendLine($"| {guess.PadRight(guessColumnWidth)} | {result.PadRight(resultColumnWidth)} |");
				boardString.AppendLine(separator);
			}

			return boardString.ToString();
		}


		public void UpdateBoard(SecretCode i_Guess, FeedBack i_Feedback)
		{
			m_SecretCodes.Add(i_Guess);
			m_FeedBacks.Add(i_Feedback);
		}
	}
}
