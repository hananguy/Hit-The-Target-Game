using System;
using GameLogic;
using GameUi;

namespace GameRun
{

				public class Game
				{
								private Computer m_Computer;
								private Player m_Player;
								private Board m_Board;
								private InputValidator m_Validator;

								//private readonly int m_MaxNumberOfGuesses = 10;
								private readonly int m_SecretCodeLength = 4;
								private readonly char[] m_AllowedLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

								public Game()
								{
												m_Computer = new Computer();				
												m_Player = new Player();
												m_Board = new Board();
												m_Validator = new InputValidator(m_AllowedLetters, m_SecretCodeLength);
								}

								public void Run()
								{
												ValidationResult result;


												do { 
												string playerGuess = m_Player.GuessSecretCode();
												result = m_Validator.Validate(playerGuess);

												

																if (result.m_IsValid)
																{
																				Console.WriteLine(result.ParsedCode);
																}
																else
																{
																				Console.WriteLine(result.ErrorMessage);
																}
												}
												while (result.m_IsValid == false);

												m_Player.SetSecretCode(result.ParsedCode);
												FeedBack feedBack = new FeedBack();
												SecretCode tmp = new SecretCode();
												string tmpString = "ABCE";
												tmp.Code = tmpString;
												feedBack.Evaluate(m_Player.CurrentSecretCode, tmp);

												Console.WriteLine("The result :");
												Console.WriteLine(feedBack.CreateBullsHitsString());
								}
				}
}
