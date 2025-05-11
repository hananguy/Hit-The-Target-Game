using System;
using System.Linq;

namespace GameLogic
{
				public class InputValidator
				{
								char[] m_AllowedLetters;
								int m_ExpectedLength;
								public InputValidator(char[] i_AllowedLetters, int i_ExpectedLength) //Ctor
								{
												m_AllowedLetters = i_AllowedLetters;
												m_ExpectedLength = i_ExpectedLength;
								}

								public ValidationResult Validate(string i_UserGuess)
								{
												bool isValid = true;
												string parsedCode = null;
												string errorMessage = string.Empty;

												if (i_UserGuess.Length != m_ExpectedLength)
												{
																isValid = false;
																errorMessage = $"Input must be exactly {m_ExpectedLength} characters long.";
												}
												else
												{
																for (int i = 0; i < i_UserGuess.Length; i++)
																{
																				char c = i_UserGuess[i];

																				if (!char.IsUpper(c))
																				{
																								isValid = false;
																								errorMessage = $"Character '{c}' is not uppercase.";
																								break;
																				}

																				if (!m_AllowedLetters.Contains(c))
																				{
																								isValid = false;
																								errorMessage = $"Character '{c}' is not allowed.";
																								break;
																				}

																				for (int j = i + 1; j < i_UserGuess.Length; j++)
																				{
																								if (i_UserGuess[j] == c)
																								{
																												isValid = false;
																												errorMessage = "Input contains duplicate characters.";
																												break;
																								}
																				}

																				if (!isValid)
																				{
																								break;
																				}
																}

																if (isValid)
																{
																				parsedCode = i_UserGuess;
																}
												}

												return new ValidationResult(isValid, parsedCode, errorMessage);
								}
				}
}
