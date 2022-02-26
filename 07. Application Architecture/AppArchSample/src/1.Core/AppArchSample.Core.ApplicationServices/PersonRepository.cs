using AppArchSample.Core.Domain;

namespace AppArchSample.Core.ApplicationServices;

public interface PersonRepository
{
    public void Add(Person person);
    public Person Get(int id);
    public void Update(Person person);
}
