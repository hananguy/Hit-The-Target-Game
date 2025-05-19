using System;
using GameLogic;
using UI;

public class UserInterface
{
    public void ShowWelcomeMessage()
    {
        Console.WriteLine(Messages.Welcome);
    }

    public int GetNumberOfGuesses(int min, int max)
    {
        string promptMessage = string.Format(Messages.PromptNumberOfGuesses, min, max);
        string invalidInputMessage = string.Format(Messages.InvalidNumberOfGuesses, min, max);
        Console.WriteLine(promptMessage);
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToUpper() == "Q") Environment.Exit(0);
            if (int.TryParse(input, out int number) && number >= min && number <= max)
                return number;
            Console.WriteLine(invalidInputMessage);
        }
    }

    public void DisplayBoard(Board board)
    {
        Console.WriteLine(board.GetBoardAsString());
    }

    public void DisplayAllowedLetters(char[] allowedLetters)
    {
        Console.WriteLine(string.Format(Messages.AvailableLetters, string.Join(" ", allowedLetters)));
    }

    public void DisplayError(string errorMessage)
    {
        string continuePrompt = Messages.ErrorTryAgain;
        Console.WriteLine(errorMessage);
        Console.WriteLine(continuePrompt);
        Console.ReadLine();
    }

    public void DisplayQuit(string code)
    {
        Console.WriteLine(Messages.QuitMessage);
        Console.WriteLine(string.Format(Messages.RevealCode, code));
    }

    public void DisplayWin()
    {
        Console.WriteLine(Messages.WinMessage);
    }

    public void DisplayLose(string code, Board board)
    {
        ClearScreen();
        Console.WriteLine(board.GetBoardAsString());
        Console.WriteLine(Messages.LoseMessage);
        Console.WriteLine(code);
    }

    public bool AskToPlayAgain()
    {
        string playAgainPrompt = Messages.PlayAgainPrompt;
        string invalidInputMessage = Messages.InvalidPlayAgainInput;
        while (true)
        {
            Console.WriteLine(playAgainPrompt);
            string input = Console.ReadLine().Trim().ToUpper();
            if (input == "Y") return true;
            if (input == "N") return false;
            Console.WriteLine(invalidInputMessage);
        }
    }

    public void ClearScreen()
    {
        Console.Clear();
    }

    public SecretCode GetPlayerInput()
    {
        Console.Write(Messages.InputGuessPrompt);
        string userInput = Console.ReadLine();
        userInput = string.Join(" ", userInput.ToUpper().ToCharArray());
        return new SecretCode(userInput);
    }
}