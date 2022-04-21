namespace EntitiesSample.Behavior;

public class RaftOBargasht
{
    public DateTime Raft { get; set; }
    public DateTime Barghasth { get; set; }

    public RaftOBargasht(DateTime raft, DateTime bargasht)
    {
        if (DateTime.Now > raft)
        {
            throw new InvalidOperationException("Invalid Value For Raft");
        }

        if (DateTime.Now > bargasht)
        {
            throw new InvalidOperationException("Invalid Value For Raft");
        }
        if (raft > bargasht)
        {
            throw new InvalidOperationException("Invalid Value For Raft");
        }
        Raft = raft;
        Barghasth = bargasht;
    }
}
public class FlightReservation
{
    public Guid Id { get; private set; }
    public RaftOBargasht RaftOBargasht { get; private set; }

    public FlightReservation(Guid id, RaftOBargasht raftOBargasht)
    {
        Id = id;
        RaftOBargasht = raftOBargasht;
    }

}

public class FlightController
{
    public void UseFlight()
    {
        FlightReservation reservation = new(Guid.NewGuid(), new RaftOBargasht(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)));
    }
}
