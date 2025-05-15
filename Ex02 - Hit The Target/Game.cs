using System;
using GameLogic;
using UI;

namespace GameRun
{

				public class Game
				{
								private Computer m_Computer;
								private Player m_Player;
								private Board m_Board;
								private InputValidator m_Validator;
								private GameUI m_GameUI;
								private InputHandler m_InputHandler;

								private int m_MaxNumberOfGuesses;
								private const int m_SecretCodeLength = 4;
								private readonly char[] m_AllowedLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };


								private void InitializeGame()
								{
												m_MaxNumberOfGuesses = m_GameUI.getNumberOfGuessesFromUser();
												m_Board = new Board(m_SecretCodeLength, m_MaxNumberOfGuesses);
												m_Computer.CreateSecretCode(m_AllowedLetters, m_SecretCodeLength);
								}

								public void Run()
								{
												bool playAgain = true;
												m_GameUI = new GameUI();
												m_InputHandler = new InputHandler();
												m_Player = new Player(m_InputHandler); 
												m_Computer = new Computer(); 
												m_Validator = new InputValidator(m_AllowedLetters, m_SecretCodeLength); 

												while (playAgain)
												{
																Console.Clear();
																InitializeGame();
																bool playerWon = false;

																for (int guessIndex = 0; guessIndex < m_MaxNumberOfGuesses; guessIndex++)
																{
																				Console.Clear();
																				m_GameUI.DisplayBoard(m_Board);
																				m_Player.GuessSecretCode();
																				if (m_Player.CurrentSecretCode.Code.ToUpper() == "Q")
																				{
																								m_GameUI.DisplayQuitMessage(m_Computer);
																								break;
																				}

																				ValidationResult validationResult = m_Validator.Validate(m_Player.CurrentSecretCode);

																				if (validationResult.m_IsValid == false)
																				{
																								m_GameUI.DisplayErrorMessage(validationResult);
																								guessIndex--;
																								continue;
																				}

																			//	m_Player.CurrentSecretCode = validationResult.ParsedCode;
																				
																				FeedBack feedback = new FeedBack();
																				feedback.Evaluate(m_Player.CurrentSecretCode, m_Computer.SecretCode);
																				m_Board.UpdateBoard(validationResult.ParsedCode, feedback);

																				if (feedback.IsWinningGuess())
																				{
																								playerWon = true;
																								break;
																				}
																}

																if (playerWon)
																{
																m_GameUI.DisplayPlayerWin();             
																}

																else
																{
																				m_GameUI.DisplayPlayerLose(m_Board, m_Computer);
																}
																playAgain = m_GameUI.AskToPlayAgain();
												}


								}
				}
}
