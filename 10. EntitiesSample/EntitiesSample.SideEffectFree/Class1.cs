namespace EntitiesSample.SideEffectFree;
public class Dice
{
    private Random random = new Random();

    public int Id { get; private set; }

    public Dice(int id)
    {
        Id = id;
    }


    public int GetValue()
    {
        return random.Next(1, 7);
    }
}


public class DiceSideEffectFree
{
    private Random random = new Random();

    public int Id { get; private set; }
    public int Value { get; private set; }

    public DiceSideEffectFree(int id)
    {
        Id = id;
    }


    public void Roll()
    {
        Value = random.Next(1, 7);
    }
}
