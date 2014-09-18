namespace GameDb.Models
{
    public enum GameState
    {
        WaitingForSecondPlayer = 0,
        NotAnswered = 1,
        RedAnswered = 2,
        GreenAnswered = 3,
        OpenQuestion = 4,
        ClosedQuestion = 5,
        GameWonByRed = 6,
        GameWonByGreen = 7
    }
}
