using GameLogic;

public class Player
{
	private readonly UserInterface m_ConsoleUI;
	private SecretCode m_LastGuess;

	public Player(UserInterface i_UserInterface)
	{
								m_ConsoleUI = i_UserInterface;
	}

	public void GuessSecretCode()
	{
		m_LastGuess = m_ConsoleUI.GetPlayerInput();
	}

	public void SetGuessFromUser(SecretCode i_Guess)
	{
		m_LastGuess = i_Guess;
	}

	public SecretCode CurrentSecretCode
	{
		get { return m_LastGuess; }
		set { m_LastGuess = value; }
	}

	public void SetSecretCode(string code)
	{
		m_LastGuess = new SecretCode(code);
	}
}