using System;
using System.Collections.Generic;
using GameLogic;

namespace GameUi
{
				public class Board
				{
								int m_NumberOfLines;
								List<SecretCode> m_SecretCodes;
								List<FeedBack> m_FeedBacks;	

								void PrintBoard()
								{
												Console.WriteLine("¦Pins:    ¦Result:¦");
												Console.WriteLine("¦=========¦=======¦");
												Console.WriteLine("¦ # # # # ¦       ¦");
												Console.WriteLine("¦=========¦       ¦");
												for(int i = 0;i < m_FeedBacks.Count;i++)
												{
																Console.WriteLine(m_FeedBacks[i]);
												}


								}

				}
}
