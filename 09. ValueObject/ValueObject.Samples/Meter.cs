namespace ValueObject.Samples;
public class Meter
{
    public int Distance { get; private set; }

    public static Meter OneKilometer()
        => new Meter(1000);
    public static Meter CreateDepth(int depth)
    {
        if (depth > 0)
        {
            //throw new DistanceInMeterCannotBeLessThanZero();
            throw new ValueObjectInvalidState("depth in meter can not be grater than zero");
        }
        return new Meter
        {
            Distance = depth
        };
    }
   
    private Meter()
    {

    }
    public Meter(int distance)
    {
        if(distance < 0)
        {
            //throw new DistanceInMeterCannotBeLessThanZero();
            throw new ValueObjectInvalidState("Distance in meter can not be less than zero");
        }
        Distance = distance;
    }

    public Kilometer ToKiloMeter()
    {
        return new Kilometer(Distance / 1000);
    }

    public bool IsLongerThan(Meter meter)
    {
        return meter.Distance < Distance;
    }

    public Meter Add(Meter meter)
    {
       return new Meter(Distance + meter.Distance);
    }

    public Meter Subtract(Meter meter)
    {
        return new Meter(Distance + meter.Distance);
    }

    public static Meter operator +(Meter left,Meter right)
    {
        return new Meter(left.Distance + right.Distance);
    }

    public static Meter operator -(Meter left, Meter right)
    {
        return new Meter(left.Distance - right.Distance);
    }
    public override bool Equals(object? obj)
    {
        var other = obj as Meter;
        if(other is null)
            return false;

        return Distance == other.Distance;
    }
    public override int GetHashCode()
    {
        return Distance.GetHashCode();
    }
    public static bool operator ==(Meter left, Meter right)
    {
        return right.Equals(left);
    }
    public static bool operator !=(Meter left, Meter right)
    {
        return !(right == left);
    }
}
public class Distance
{
    public int Value { get; private set; }
    public Measure Measure { get; set; }
    public Distance(int value, Measure measure)
    {
        Value = value;
        Measure = measure;
    }
}

public enum Measure
{
    Meter,
    Kilometer,
    Yard
}