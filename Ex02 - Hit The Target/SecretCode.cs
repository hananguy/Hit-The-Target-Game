using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
	public struct SecretCode
	{
		private string m_Secret;
		public SecretCode(string secret)
		{
			m_Secret = secret;
		}
		//Public Properties:
		public string Code
		{
			get { return m_Secret; }
			set { m_Secret = value; }

		}
		public override string ToString()
		{
			return m_Secret;
		}

	}
}
