using GameLogic;
using System;
using System.Collections.Generic;
using System.Data;

namespace GameLogic
{
				public class FeedBack
				{
								private int m_Bulls = 0;
								private int m_Hits = 0;

								public void Evaluate(SecretCode i_ComputerCode, SecretCode i_PlayerCode)
								{
												int i = 0;

												foreach (char ch in i_PlayerCode.Code)
												{
																if (ch == i_ComputerCode.Code[i])
																{
																				m_Bulls++;
																}
																else
																{
																				foreach (char c in i_ComputerCode.Code)
																				{
																								if (ch == c)
																								{
																												m_Hits++;
																												break;
																								}
																				}
																}
																i++;

												}



								}
								public string CreateBullsHitsString()
								{
												List<char> symbolsString = new List<char>();
												for(int i = 0; i < m_Bulls; i++)
												{
																symbolsString.Add('V');
												}
												for (int i = 0; i < m_Hits; i++)
												{
																symbolsString.Add('X');
												}

												return string.Join(" ", symbolsString);
								}
				}
				
}
