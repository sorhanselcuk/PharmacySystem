using Business.ExternalResources.Abstract;
using Entities.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalResources.Concrete
{
    public class MernisIDService : IIDService
    {
        private Dictionary<string, Person> _persons;
        public MernisIDService()
        {
            _persons = new Dictionary<string, Person>();
            _persons.Add("AF-78-A8-C1-71-56-12", new Person { Identity="0000000000",FirstName="Cengiz",LastName="Atay",DateOfBirth=new DateTime(1980,06,21)});
            _persons.Add("AF-78-A1-C1-71-56-12", new Person { Identity="0000000001",FirstName="Ömer",LastName="Uçar",DateOfBirth=new DateTime(1982,06,21)});
            _persons.Add("AF-98-A8-C1-71-56-12", new Person { Identity="0000000002",FirstName="Ali",LastName="Kırgız",DateOfBirth=new DateTime(1985,06,21)});
            _persons.Add("AF-12-A8-C1-71-56-12", new Person { Identity="0000000003",FirstName="Eşyan",LastName="Tezcan",DateOfBirth=new DateTime(1985,03,11)});
            _persons.Add("AF-75-A8-C1-71-56-12", new Person { Identity="0000000004",FirstName="Bahar",LastName="Tezcan",DateOfBirth=new DateTime(1989,01,31)});
            _persons.Add("AF-75-A8-C1-71-56-14", new Person { Identity="0000005001",FirstName="Ramiz",LastName="Karaeski",DateOfBirth=new DateTime(1940,01,24)});
            _persons.Add("AF-75-A8-C1-71-56-16", new Person { Identity="0000000004",FirstName="Kenan",LastName="Birkan",DateOfBirth=new DateTime(1947,01,31)});
            _persons.Add("AF-75-A8-C0-71-56-16", new Person { Identity="0000000004",FirstName="Tuncay",LastName="Deve",DateOfBirth=new DateTime(1976,06,23)});
        }
        public Person GetPerson(string idCardNumber)
        {
            return _persons.GetValueOrDefault(idCardNumber);
        }
    }
}
