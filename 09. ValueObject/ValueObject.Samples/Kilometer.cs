namespace ValueObject.Samples;

public class Kilometer
{
    public int Distance { get; private set; }

    public static Kilometer FromMeter(Meter meter)
    {
        return new Kilometer(meter.Distance / 1000);

    }
    public Kilometer(int distance)
    {
        Distance = distance;
    }
    public override bool Equals(object? obj)
    {
        var other = obj as Meter;
        if (other is null)
            return false;

        return Distance == other.Distance;
    }

    public override int GetHashCode()
    {
        return Distance.GetHashCode();
    }
    public static bool operator ==(Kilometer right, Kilometer left)
    {
        return right.Equals(left);
    }
    public static bool operator !=(Kilometer right, Kilometer left)
    {
        return !(right == left);
    }
}
