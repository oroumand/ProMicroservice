namespace EntitiesSample.Specifications;

public class RescheduleValidationSatisfied : ISpecification<FlightBooking>
{
    public bool IsSatisfiedBy(FlightBooking entity)
    {
        return !entity.IsApproved;
    }
}
