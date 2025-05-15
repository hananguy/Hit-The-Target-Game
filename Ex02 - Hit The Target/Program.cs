using System;
using System.Linq;
using GameLogic;
using GameRun;
using Ex02.ConsoleUtils;
using UI;

namespace GameMain
{
				public class Program
				{
								static void Main()
								{
												Console.WriteLine("Welcome to Hit the Target!");
											//	GameUI gameUI = new GameUI();
												//int numberOfGuesses = gameUI.getNumberOfGuessesFromUser();
												Game game = new Game();
												game.Run();
								}
				}
}

