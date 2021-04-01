using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IAdministratorLogic
    {
     IEnumerable<Administrator> GetAll();

     Administrator Get(Guid id);

    void Update(Administrator Administrator);
    void Delete(Guid id);

    void Add(string Name, string Email, string Password ); );
    
     
    }
}