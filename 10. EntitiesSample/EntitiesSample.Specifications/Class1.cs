namespace EntitiesSample.Specifications;

public class FlightDate
{
    public DateTime Value { get; private set; }
    public FlightDate(DateTime flightDate)
    {
        if (DateTime.Now > flightDate)
            throw new ArgumentException("");
        Value = flightDate;
    }
}
public class FlightBooking
{
    private readonly RescheduleValidationSatisfied spec = new RescheduleValidationSatisfied();
    public int Id { get; private set; }
    public FlightDate FlightDate { get; private set; }
    public bool IsApproved { get; private set; }
    public FlightBooking(int id, FlightDate flightDate)
    {

        Id = id;
        FlightDate = flightDate;
    }

    public void Approve()
    {
        IsApproved = true;
    }

    public void Reschedule(FlightDate newFlieghtDate)
    {
        if (!spec.IsSatisfiedBy(this))
        {
            throw new InvalidOperationException("");
        }
        FlightDate = newFlieghtDate;
    }

}
