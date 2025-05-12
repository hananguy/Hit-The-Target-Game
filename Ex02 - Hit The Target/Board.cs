using System;
using System.Collections.Generic;
using GameLogic;
using System.Linq;

namespace GameUi
{
	public class Board
	{
		List<SecretCode> m_SecretCodes;
		List<FeedBack> m_FeedBacks;
		private readonly int r_CodeLength;
		private readonly int r_MaxGuesses;

		public Board(int i_CodeLength, int i_MaxGuesses)
		{
			r_CodeLength = i_CodeLength;
			r_MaxGuesses = i_MaxGuesses;
			m_SecretCodes = new List<SecretCode>();
			m_FeedBacks = new List<FeedBack>();
		}
		public void Display()
		{
			int guessColWidth = 2 * r_CodeLength - 1;
			int resultColWidth = r_CodeLength;

			string header = $"| {"Pins:".PadRight(guessColWidth)} | {"Result:".PadRight(resultColWidth)} |";
			string separator = $"|{new string('=', guessColWidth + 2)}|{new string('=', resultColWidth + 2)}|";

			Console.WriteLine("Current board status:");
			Console.WriteLine(header);
			Console.WriteLine(separator);

			string hidden = string.Join(" ", Enumerable.Repeat("#", r_CodeLength));
			Console.WriteLine($"| {hidden.PadRight(guessColWidth)} | {"".PadRight(resultColWidth)} |");
			Console.WriteLine(separator);

			for (int line = 0; line < r_MaxGuesses; line++)
			{
				string guess = line < m_SecretCodes.Count ? m_SecretCodes[line].Code : "";
				string result = line < m_FeedBacks.Count ? m_FeedBacks[line].CreateBullsHitsString().Replace(" ", "") : "";

				Console.WriteLine($"| {guess.PadRight(guessColWidth)} | {result.PadRight(resultColWidth)} |");
				Console.WriteLine(separator);
			}
		}
		public void UpdateBoard(string i_Guess, FeedBack i_Feedback)
		{
			SecretCode code = new SecretCode();
			code.Code = i_Guess;

			m_SecretCodes.Add(code);
			m_FeedBacks.Add(i_Feedback);
		}
	}
}
