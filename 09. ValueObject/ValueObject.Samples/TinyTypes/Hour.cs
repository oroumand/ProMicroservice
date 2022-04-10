using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject.Samples.TinyTypes;

public class Hour
{
    public int Value { get; private set; }
    public Hour(int value)
    {
        Validate(value);
        Value = value;
    }
    public Hour Subtract(Hour input)
    {
        return new(Value - input.Value);
    }
    private void Validate(int value)
    {
        throw new NotImplementedException();
    }

    public static Hour operator +(Hour left, Hour right)
    {
        return new Hour(left.Value + right.Value);
    }

    public static Hour operator -(Hour left, Hour right)
    {
        return new Hour(left.Value - right.Value);
    }
}

public class OverTime
{
    public Hour OverTimeValue { get; private set; }
    public OverTime(Hour overTime)
    {
        OverTimeValue = overTime;
    }
}
public class OvertimeCalculator
{
    public OverTime Caculate(Hour workingHour, Hour contractHour)
    {
        return new OverTime(workingHour - contractHour);
    }
}

public class TimeRepository
{
    public void SaveOverTime(OverTime hour)
    {
        //Save To Db;
    }
}
    