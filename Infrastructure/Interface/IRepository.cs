using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Infrastructure.Interface
{

    interface IRepository<T> where T: class
    {
        bool Insert(T objT);
        bool Update(T objT);
        bool Delete(int Id);
        T GetSingle(int Id);
        List<T> GetAll();

    }

    // yea design pattern Repository design pattern kehlata ha. 
    // data base programming main yahi istemal hota ha.
    // pros
    // TDD ho sakti ha. (Test Driven Development)
    // IoC use kar saktey hain. (Inversion of Control)
    // DI use kar saktey hain. (Dependency Injection)
    // DDD Domain Driven Development.
    // Moque, Mock Test and mock testing setup.
    
    // SOLID principle
    // S: Single Responsibility Principle, 
    // O: Object Oriented, 
    // L: Liskove segregation, 
    // I: Inversion of Control, 
    // D: Dependency Injection.

}

