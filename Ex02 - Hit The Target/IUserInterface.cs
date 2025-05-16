using GameLogic;

public interface IUserInterface
{
    void ShowWelcomeMessage();
    int GetNumberOfGuesses(int min, int max);
    void DisplayBoard(Board board);
    void DisplayAllowedLetters(char[] allowedLetters);
    void DisplayError(string errorMessage);
    void DisplayQuit(string code);
    void DisplayWin();
    void DisplayLose(string code, Board board);
    bool AskToPlayAgain();
    void ClearScreen();
    SecretCode GetPlayerInput();
}