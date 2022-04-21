using EntitiesSample.IdGenerators.Contract;

namespace EntitiesSample.IdGenerators.StaticClass;
public class StaticIdGenerator : IdGenerator
{
    private long id = 0;
    public long Next()
    {
        return ++id;
    }
}
