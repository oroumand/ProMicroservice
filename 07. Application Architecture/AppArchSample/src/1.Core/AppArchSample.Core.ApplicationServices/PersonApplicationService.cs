using AppArchSample.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArchSample.Core.ApplicationServices;
public class PersonApplicationService
{
    private readonly PersonRepository personRepository;

    public PersonApplicationService(PersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }
    public void AddPerson(CreatePersonInputDto createPersonDto)
    {
        PhoneNumber phoneNumber = new(createPersonDto.PhoneNumber);
        Person person = new(createPersonDto.FirstName, createPersonDto.LastName, phoneNumber);
        personRepository.Add(person);
    }

    public void AddNumberToPerson(AddNumberToPersonInputDto addNumberToPerson)
    {
        var person = personRepository.Get(addNumberToPerson.PersonId);
        if(person == null)
        {
            throw new ApplicationException($"There is no person with Id={addNumberToPerson.PersonId}");
        }
        PhoneNumber phoneNumber = new(addNumberToPerson.Number);
        person.AddPhoneNumber(phoneNumber);
        personRepository.Update(person);

    }
}
