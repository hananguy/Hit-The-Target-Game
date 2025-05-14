using System;
using GameLogic;

namespace UI
{

				public class GameUI
				{
								public void showWelcomeMessage()
								{
												Console.WriteLine("Welcome to Hit the Target!");
								}
								
								public int getNumberOfGuessesFromUser()
								{
												const int k_MinGuesses = 4;
												const int k_MaxGuesses = 10;

												Console.WriteLine($"Enter number of guesses ({k_MinGuesses}-{k_MaxGuesses}):");

												while (true)
												{
																string input = Console.ReadLine();

																if (input.ToUpper() == "Q")
																{
																				Environment.Exit(0);
																}

																if (int.TryParse(input, out int number) && number >= k_MinGuesses && number <= k_MaxGuesses)
																{
																				return number;
																}
																else
																{
																				Console.WriteLine("Invalid input. Please enter a number between 4 and 10.");
																}
												}
								}

								public void DisplayBoard(Board i_board)
								{
												i_board.Display();
								}

								public void DisplayAllowedLetters(char[] i_AllowedLetters)
								{
												Console.WriteLine($"Available letters: {string.Join(" ", i_AllowedLetters)}");
								}

								public void DisplayQuitMessage(Computer i_Computer)
								{
									Console.WriteLine("You quit the game.");
									Console.WriteLine($"The code was: {i_Computer.SecretCode.Code}");
								}

								public void DisplayLoseMessage(Computer i_Computer)
								{
												Console.WriteLine("Game ended. The code was:");
												Console.WriteLine(i_Computer.SecretCode.Code);
								}

								public bool AskToPlayAgain()
								{
												string userInput;
												do
												{
																Console.WriteLine("Do you want to play again? (Y/N):");
																userInput = Console.ReadLine();
																if (userInput != "Y" && userInput != "N")
																{
																				Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
																}
												}

												while (userInput != "Y" && userInput != "N"); 

												return userInput == "Y"; 
				}
				}







}