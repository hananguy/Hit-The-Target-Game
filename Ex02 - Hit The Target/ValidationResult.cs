using System;


namespace GameLogic					
{
				public class ValidationResult
				{
								public bool m_IsValid = false;
								public SecretCode m_ParsedCode;
								public string m_ErrorMessage;

						
								public ValidationResult(bool i_IsValid, SecretCode i_ParsedCode, string i_ErrorMessage)
								{
												m_IsValid = i_IsValid;	
												m_ParsedCode = i_ParsedCode;
												m_ErrorMessage = i_ErrorMessage;
								}

								public bool IsValid
								{
												get { return m_IsValid; }
												set { m_IsValid = value; }
								}

								public SecretCode ParsedCode
								{
												get { return m_ParsedCode; }
												set { m_ParsedCode = value; }
								}

								public string ErrorMessage
								{
												get { return m_ErrorMessage; }
								}



				}
}
