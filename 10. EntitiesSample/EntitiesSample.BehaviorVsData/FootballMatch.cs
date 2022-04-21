namespace EntitiesSample.BehaviorVsData;

public class Score
{
    public int AwayGoals { get; private set; }
    public int HomeGoals { get; private set; }

    public Score(int awayGoals,int homeGoals)
    {
        AwayGoals = awayGoals;
        HomeGoals = homeGoals;
    }
    public int TotalGoals()
        => AwayGoals + HomeGoals;
}
public class FootballMatch
{
    public int Id { get; private set; }
    public Score Team1Score { get; private set; }
    public Score Team2Score { get; private set; }
    public FootballMatch(int id, Score team1Score, Score team2Score)
    {
        Id = id;
        Team1Score = team1Score;
        Team2Score = team2Score;
    }

    public string GetWinner()
    {
        if (Team1Score.TotalGoals() > Team2Score.TotalGoals())
            return "Team1";
        if (Team2Score.TotalGoals() > Team1Score.TotalGoals())
            return "Team2";
        if (Team1Score.AwayGoals > Team2Score.AwayGoals)
            return "Team1";
        if (Team2Score.AwayGoals > Team1Score.AwayGoals)
            return "Team2";

        return PenaltyWinner();
    }

    private string PenaltyWinner()
    {
        return "Team1";
    }
}
