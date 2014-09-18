namespace GameDb.Models
{
    public enum GameState
    {
        WaitingForSecondPlayer = 0,
        RedChoose = 1,
        GreenChoose = 2,
        OpenQuestion = 3,
        ClosedQuestion = 4,
        GameWonByRed = 5,
        GameWonByGreen = 6
    }
}
