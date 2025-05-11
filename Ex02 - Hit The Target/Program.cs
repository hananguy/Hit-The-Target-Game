using System;
using System.Linq;
using GameLogic;
using GameUi;
using GameRun;

namespace GameMain
{
				public class Program
				{
								static void Main()
								{
												/*
												char[] availableLetters = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
												Computer computer = new Computer();
												computer.CreateSecretCode(availableLetters);
												string code = computer.GetSecretCode().Code;
												foreach (char ch in code)
												{
																Console.Write(ch);
																Console.Write(" ");
												*/
												Game game = new Game();
												game.Run();
												}



								}
				}

