using GameLogic;

public class Player
{
	private readonly IUserInterface m_UserInterface;
	private SecretCode m_LastGuess;

	public Player(IUserInterface i_UserInterface)
	{
		m_UserInterface = i_UserInterface;
	}

	public void GuessSecretCode()
	{
		m_LastGuess = m_UserInterface.GetPlayerInput();
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