using AppArchSample.Core.ApplicationServices;
using AppArchSample.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArchSample.Infra.Data.SQLServer;
public class EfPersonRepository : PersonRepository
{
    private readonly AppArchContext appArchContext;

    public EfPersonRepository(AppArchContext appArchContext)
    {
        this.appArchContext = appArchContext;
    }
    public void Add(Person person)
    {
        appArchContext.People.Add(person);
        appArchContext.SaveChanges();
    }

    public Person Get(int id)
    {
        var person = appArchContext.People.Include(c=>c.PhoneNumbers).SingleOrDefault(c=>c.Id == id);
        return person;
    }

    public void Update(Person person)
    {

        appArchContext.SaveChanges();
    }
}
